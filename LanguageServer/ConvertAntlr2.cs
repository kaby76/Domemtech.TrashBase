﻿namespace LanguageServer
{
    // See https://tomassetti.me/migrating-from-antlr2-to-antlr4/
    // https://theantlrguy.atlassian.net/wiki/spaces/ANTLR3/pages/2687070/Migrating+from+ANTLR+2+to+ANTLR+3
    // http://dust.ess.uci.edu/ppr/ppr_Par07.pdf

    using Antlr4.Runtime;
    using Antlr4.Runtime.Tree;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using org.eclipse.wst.xml.xpath2.processor.util;
    using Antlr4.Runtime.Misc;
    using Workspaces;

    public class ConvertAntlr2
    {
        public bool StripLabelOperator { get; set; } = true; // "x:foobar" => "foobar"
        public bool StripActionBlocks { get; set; } = true; // "{ ... }" => ""
        public bool StripAssignmentOperator { get; set; } = true; // "x=foobar" => "foobar"

        public ConvertAntlr2()
        {
        }

        public Dictionary<string, string> Try(string ffn, string input)
        {
            // Create a new .g2 doc with this text and apply substitutions.
            // Antlr4 parses do not allow keywords as symbol names, so we have to do
            // a rename first. (I might take care of this later, but order is relevant
            // for now.)
            Document document = Workspaces.Workspace.Instance.FindDocument("DUMMY.g2");
            if (document == null)
            {
                document = new Workspaces.Document("DUMMY.g2");
                document.Code = input;
                Project project = Workspaces.Workspace.Instance.FindProject("Misc");
                if (project == null)
                {
                    project = new Project("Misc", "Misc", "Misc");
                    Workspaces.Workspace.Instance.AddChild(project);
                }
                project.AddDocument(document);
            }
            document.Changed = true;
            _ = ParsingResultsFactory.Create(document);
            var workspace = document.Workspace;
            _ = new LanguageServer.Module().Compile(workspace);
            var rename_list = new Dictionary<string, string>()
                { { "grammar", "grammar_" }, { "tree", "tree_" } };

            var res1 = LanguageServer.Transform.Rename(rename_list, document);

            // Get renamed symbol input.
            input = res1["DUMMY.g2"];

            Dictionary<string, string> results = new Dictionary<string, string>();
            var now = DateTime.Now.ToString();
            var errors = new StringBuilder();
            var str = new AntlrInputStream(input);
            var lexer = new ANTLRv2Lexer(str);
            var tokens = new CommonTokenStream(lexer);
            var parser = new ANTLRv2Parser(tokens);
            var elistener = new ErrorListener<IToken>(parser, lexer, 0);
            parser.AddErrorListener(elistener);
            var tree = parser.grammar_();
            var error_file_name = ffn;
            error_file_name = error_file_name.EndsWith(".g2")
                ? (error_file_name.Substring(0, error_file_name.Length - 3) + ".txt") : error_file_name;
            error_file_name = error_file_name.EndsWith(".g")
                ? (error_file_name.Substring(0, error_file_name.Length - 2) + ".txt") : error_file_name;

            var new_ffn = ffn;
            new_ffn = new_ffn.EndsWith(".g2")
                ? (new_ffn.Substring(0, new_ffn.Length - 3) + ".g4") : new_ffn;
            new_ffn = new_ffn.EndsWith(".g")
                ? (new_ffn.Substring(0, new_ffn.Length - 2) + ".g4") : new_ffn;

            if (elistener.had_error)
            {
                results.Add(error_file_name, errors.ToString());
                return results;
            }
            else
            {
                errors.AppendLine("File " + ffn + " parsed successfully.");
                errors.AppendLine("Date: " + now);
            }

            // Transforms derived from two sources:
            // https://github.com/senseidb/sensei/pull/23
            var (text_before, other) = TreeEdits.TextToLeftOfLeaves(tokens, tree);

            // Remove "header".
            using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext =
                    new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
            {
                org.eclipse.wst.xml.xpath2.processor.Engine engine =
                    new org.eclipse.wst.xml.xpath2.processor.Engine();               
                var nodes = engine.parseExpression(
                        @"//header_",
                        new StaticContextBuilder()).evaluate(
                        dynamicContext, new object[] { dynamicContext.Document })
                    .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree);
                foreach (var n in nodes) TreeEdits.Delete(n);
            }

            // Remove classDef action blocks for now.
            using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext =
                    new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
            {
                org.eclipse.wst.xml.xpath2.processor.Engine engine =
                    new org.eclipse.wst.xml.xpath2.processor.Engine();
                var nodes = engine.parseExpression(
                        @"//classDef/actionBlock",
                        new StaticContextBuilder()).evaluate(
                        dynamicContext, new object[] { dynamicContext.Document })
                    .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree);
                foreach (var n in nodes) TreeEdits.Delete(n);
            }

            // Let's take care of options first, nuking options that have no equivalent in
            // Antlr4.
            using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext =
                    new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
            {
                org.eclipse.wst.xml.xpath2.processor.Engine engine =
                    new org.eclipse.wst.xml.xpath2.processor.Engine();
                var options = engine.parseExpression(
                        @"//(fileOptionsSpec | parserOptionsSpec | lexerOptionsSpec | treeOptionsSpec)",
                        new StaticContextBuilder()).evaluate(
                        dynamicContext, new object[] { dynamicContext.Document })
                    .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree).ToList();
                var nodes = engine.parseExpression(
                        @"//(fileOptionsSpec | parserOptionsSpec | lexerOptionsSpec | treeParserOptionsSpec)
                            /(option | lexerOption)
                                [id/*
                                        [
                                        text() = 'output'
                                        or text() = 'ASTLabelType'
                                        or text() = 'backtrack'
                                        or text() = 'buildAST'
                                        or text() = 'charVocabulary'
                                        or text() = 'classHeaderSuffix'
                                        or text() = 'codeGenBitsetTestThreshold'
                                        or text() = 'codeGenMakeSwitchThreshold'
                                        or text() = 'defaultErrorHandler'
                                        or text() = 'exportVocab'
                                        or text() = 'generateAmbigWarnings'
                                        or text() = 'interactive'
                                        or text() = 'k'
                                        or text() = 'memoize'
                                        or text() = 'paraphrase'
                                        or text() = 'rewrite'
                                        or text() = 'testLiterals'
                                        or text() = 'warnWhenFollowAmbig'
                                        ]]",
                        new StaticContextBuilder()).evaluate(
                        dynamicContext, new object[] { dynamicContext.Document })
                    .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree);
                TreeEdits.Delete(nodes);
                foreach (var opt in options)
                {
                    if (opt.ChildCount == 3)
                        TreeEdits.Delete(opt);
                }
            }

            // Convert tokens { ... } string declarations into hardwired rules. I just don't
            // understand why these were here, but thankfully Parr made them explicit rules that
            // can be easily refactored for whatever reason.
            using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext =
                    new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
            {
                IParseTree tokens_node = null;
                org.eclipse.wst.xml.xpath2.processor.Engine engine =
                    new org.eclipse.wst.xml.xpath2.processor.Engine();
                var nodes = engine.parseExpression(
                        @"//tokenEntry
                                [TOKEN_REF and EQUAL and STRING_LITERAL]",
                        new StaticContextBuilder()).evaluate(
                        dynamicContext, new object[] { dynamicContext.Document })
                    .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree);
                Dictionary<string, string> new_rules = new Dictionary<string, string>();
                if (nodes.Any())
                {
                    tokens_node = nodes.First().Parent;
                    // Note tokenEntry, e.g., 'A = "b";'.
                    foreach (var n in nodes)
                    {
                        new_rules.Add(n.GetChild(0).GetText(), n.GetChild(2).GetText());
                    }
                    TreeEdits.Delete(nodes);
                }
                var str_nodes = engine.parseExpression(
                  @"//tokenEntry
                         [STRING_LITERAL]",
                      new StaticContextBuilder()).evaluate(
                      dynamicContext, new object[] { dynamicContext.Document })
                  .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree);
                List<string> no_name_rules = new List<string>();
                if (str_nodes.Any())
                {
                    tokens_node = str_nodes.First().Parent;
                    // Note tokenEntry, e.g., 'A = "b";'.
                    foreach (var n in str_nodes)
                    {
                        no_name_rules.Add(n.GetChild(0).GetText());
                    }
                    TreeEdits.Delete(str_nodes);
                }
                if (tokens_node != null && tokens_node.ChildCount == 3)
                {
                    TreeEdits.Delete(tokens_node);
                }
                // Find insertion point for new lexer rules.
                var lexer_nodes = engine.parseExpression(
                        @"//rule_[id/TOKEN_REF]",
                        new StaticContextBuilder()).evaluate(
                        dynamicContext, new object[] { dynamicContext.Document })
                    .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree);
                var insert = lexer_nodes?.First();
                int number = 0;
                foreach (string p in no_name_rules)
                {
                    TreeEdits.InsertBefore(insert, Environment.NewLine + "DUMMY_" + number++ + " : '" + p.Substring(1, p.Length-2) + "';" + Environment.NewLine);
                }
                foreach (var p in new_rules)
                {
                    TreeEdits.InsertBefore(insert, Environment.NewLine + p.Key + " : '" + p.Value.Substring(1, p.Value.Length - 2) + "';" + Environment.NewLine);
                }
            }

            // Delete all rule options. As far as I can tell, they have no equivalent in
            // Antlr4 except for maybe a few.
            using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext =
                    new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
            {
                org.eclipse.wst.xml.xpath2.processor.Engine engine =
                    new org.eclipse.wst.xml.xpath2.processor.Engine();
                var nodes = engine.parseExpression(
                        @"//rule_/ruleOptionsSpec
                            /option
                                [id
                                    /(TOKEN_REF | RULE_REF)
                                        [text() = 'output'
                                        or text() = 'ASTLabelType'
                                        or text() = 'backtrack'
                                        or text() = 'charVocabulary'
                                        or text() = 'classHeaderSuffix'
                                        or text() = 'codeGenBitsetTestThreshold'
                                        or text() = 'codeGenMakeSwitchThreshold'
                                        or text() = 'defaultErrorHandler'
                                        or text() = 'exportVocab'
                                        or text() = 'generateAmbigWarnings'
                                        or text() = 'interactive'
                                        or text() = 'k'
                                        or text() = 'memoize'
                                        or text() = 'paraphrase'
                                        or text() = 'rewrite'
                                        or text() = 'testLiterals'
                                        or text() = 'warnWhenFollowAmbig'
                                        ]]",
                        new StaticContextBuilder()).evaluate(
                        dynamicContext, new object[] { dynamicContext.Document })
                    .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree);
                TreeEdits.Delete(nodes);
                var options = engine.parseExpression(
                        @"//rule_/ruleOptionsSpec",
                        new StaticContextBuilder()).evaluate(
                        dynamicContext, new object[] { dynamicContext.Document })
                    .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree);
                foreach (var os in options)
                {
                    if (os.ChildCount == 3) TreeEdits.Delete(os);
                }
            }

            //// Convert "protected" to "fragment" for lexer symbols.
            ////  Remove "protected" for parser symbols.
            //{
            //    using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext =
            //        new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
            //    {
            //        org.eclipse.wst.xml.xpath2.processor.Engine engine =
            //         new org.eclipse.wst.xml.xpath2.processor.Engine();
            //        var nodes = engine.parseExpression(
            //                @"//rule_[id/RULE_REF]/(PROTECTED | PUBLIC | PRIVATE)",
            //                new StaticContextBuilder()).evaluate(
            //                dynamicContext, new object[] { dynamicContext.Document })
            //            .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree);
            //        TreeEdits.Delete(nodes);
            //    }
            //}

            // Remove crap in "rule_ :
            // DOC_COMMENT? ((PROTECTED | PUBLIC | PRIVATE))? id
            // BANG? argActionBlock? (RETURNS argActionBlock)?
            // throwsSpec? ruleOptionsSpec? ruleAction* COLON altList
            // SEMI exceptionGroup?"
            using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext =
                    new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
            {
                org.eclipse.wst.xml.xpath2.processor.Engine engine =
                    new org.eclipse.wst.xml.xpath2.processor.Engine();
                var nodes = engine.parseExpression(
                        @"//rule_",
                        new StaticContextBuilder()).evaluate(
                        dynamicContext, new object[] { dynamicContext.Document })
                    .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree);
                foreach (var node in nodes)
                {
                    for (int i = node.ChildCount - 1; i >= 0; --i)
                    {
                        if (node.GetChild(i) is ParserRuleContext prc)
                        {
                            if (prc as ANTLRv2Parser.ExceptionGroupContext!= null)
                            {
                                TreeEdits.Delete(prc);
                            }
                            else if (prc as ANTLRv2Parser.RuleActionContext != null)
                            {
                                TreeEdits.Delete(prc);
                            }
                            else if (prc as ANTLRv2Parser.RuleOptionsSpecContext != null)
                            {
                                TreeEdits.Delete(prc);
                            }
                            else if (prc as ANTLRv2Parser.ThrowsSpecContext != null)
                            {
                                TreeEdits.Delete(prc);
                            }
                            else if (prc as ANTLRv2Parser.ArgActionBlockContext != null)
                            {
                                TreeEdits.Delete(prc);
                            }
                        }
                        else if (node.GetChild(i) is TerminalNodeImpl tni)
                        {
                            if (tni.Symbol.Type == ANTLRv2Parser.RETURNS)
                            {
                                TreeEdits.Delete(tni);
                            }
                            else if (tni.Symbol.Type == ANTLRv2Parser.BANG)
                            {
                                TreeEdits.Delete(tni);
                            }
                            else if (tni.Symbol.Type == ANTLRv2Parser.PRIVATE)
                            {
                                TreeEdits.Delete(tni);
                            }
                            else if (tni.Symbol.Type == ANTLRv2Parser.PROTECTED)
                            {
                                TreeEdits.Delete(tni);
                            }
                            else if (tni.Symbol.Type == ANTLRv2Parser.PUBLIC)
                            {
                                TreeEdits.Delete(tni);
                            }
                        }
                    }
                }
            }

            // Remove syntactic predicates.
            {
                using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext =
                    new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
                {
                    org.eclipse.wst.xml.xpath2.processor.Engine engine =
                     new org.eclipse.wst.xml.xpath2.processor.Engine();
                    var nodes = engine.parseExpression(
                            @"//ebnf
                            [SEMPREDOP]",
                            new StaticContextBuilder()).evaluate(
                            dynamicContext, new object[] { dynamicContext.Document })
                        .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree);
                    TreeEdits.Delete(nodes);
                }
            }


            // Remove crap in "ebnf :
            // LPAREN(subruleOptionsSpec actionBlock ? COLON | actionBlock COLON) ? block
            // RPAREN ((QM | STAR | PLUS) ? BANG ? | SEMPREDOP)"
            using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext =
                    new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
            {
                org.eclipse.wst.xml.xpath2.processor.Engine engine =
                    new org.eclipse.wst.xml.xpath2.processor.Engine();
                var nodes = engine.parseExpression(
                        @"//ebnf",
                        new StaticContextBuilder()).evaluate(
                        dynamicContext, new object[] { dynamicContext.Document })
                    .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree);
                foreach (var node in nodes)
                {
                    for (int i = node.ChildCount - 1; i >= 0; --i)
                    {
                        if (node.GetChild(i) is ParserRuleContext prc)
                        {
                            if (prc as ANTLRv2Parser.SubruleOptionsSpecContext != null)
                            {
                                TreeEdits.Delete(prc);
                            }
                            else if (prc as ANTLRv2Parser.ActionBlockContext != null)
                            {
                                TreeEdits.Delete(prc);
                            }
                        }
                        else if (node.GetChild(i) is TerminalNodeImpl tni)
                        {
                            if (tni.Symbol.Type == ANTLRv2Parser.COLON)
                            {
                                TreeEdits.Delete(tni);
                            }
                            else if (tni.Symbol.Type == ANTLRv2Parser.BANG)
                            {
                                TreeEdits.Delete(tni);
                            }
                            else if (tni.Symbol.Type == ANTLRv2Parser.SEMPREDOP)
                            {
                                TreeEdits.Delete(tni);
                            }
                        }
                    }
                }
            }


            // Parser and Lexer in One Definition
            using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext =
                    new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
            {
                org.eclipse.wst.xml.xpath2.processor.Engine engine =
                    new org.eclipse.wst.xml.xpath2.processor.Engine();
                var parser_nodes = engine.parseExpression(
                        @"//parserSpec",
                        new StaticContextBuilder()).evaluate(
                        dynamicContext, new object[] { dynamicContext.Document })
                    .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree);
                var lexer_nodes = engine.parseExpression(
                        @"//lexerSpec",
                        new StaticContextBuilder()).evaluate(
                        dynamicContext, new object[] { dynamicContext.Document })
                    .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree);
                var tree_nodes = engine.parseExpression(
                        @"//treeParserSpec",
                        new StaticContextBuilder()).evaluate(
                        dynamicContext, new object[] { dynamicContext.Document })
                    .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree);
                // Can this be a "combined" grammar? That can happen only if
                // one parser and one lexer decl and no tree decl. Options for
                // the lexer must be removed too.
                if (parser_nodes.Count() == 1 && lexer_nodes.Count() == 1 && tree_nodes.Count() == 0)
                {
                    var lexerSpec = lexer_nodes.First() as ANTLRv2Parser.LexerSpecContext;
                    if (lexerSpec.lexerOptionsSpec() == null)
                    {
                        // Nuke lexer class decl because it's a combined grammar.
                        TreeEdits.Delete(lexerSpec);
                        lexerSpec = null;
                    }
                    // Rewrite the parser spec.
                    var parserSpec = parser_nodes.First() as ANTLRv2Parser.ParserSpecContext;
                    var c = parserSpec.CLASS();
                    var i = parserSpec.id();
                    var e = parserSpec.EXTENDS();
                    var p = parserSpec.PARSER();
                    var s = parserSpec.superClass();
                    var new_sym = new TerminalNodeImpl(new CommonToken(ANTLRv4Lexer.GRAMMAR)
                    { Line = -1, Column = -1, Text = "grammar" });
                    text_before.TryGetValue(c as TerminalNodeImpl, out string v);
                    if (v != null)
                        text_before.Add(new_sym, v);
                    TreeEdits.Replace(c, (in IParseTree n, out bool cc) =>
                    {
                        cc = false;
                        return new_sym;
                    });
                    TreeEdits.Delete(e);
                    TreeEdits.Delete(p);
                    TreeEdits.Delete(s);
                }
            }

            // Get rid of labels.
            // elementNoOptionSpec
            // : (id EQUAL (id COLON) ? (rule_ref_or_keyword_as argActionBlock ? BANG ? | TOKEN_REF argActionBlock ?))
            // | ((id COLON)? (rule_ref_or_keyword_as argActionBlock? BANG? | range | terminal_ | NOT(notTerminal | ebnf) | ebnf))
            if (StripLabelOperator)
            {
                using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext =
                    new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
                {
                    org.eclipse.wst.xml.xpath2.processor.Engine engine =
                     new org.eclipse.wst.xml.xpath2.processor.Engine();
                    var nodes = engine.parseExpression(
                            @"//elementNoOptionSpec",
                            new StaticContextBuilder()).evaluate(
                            dynamicContext, new object[] { dynamicContext.Document })
                        .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree).ToList();
                    foreach (var n in nodes)
                    {
                        for (int i = n.ChildCount-1; i >= 0; --i)
                        {
                            var c = n.GetChild(i);
                            if (c is TerminalNodeImpl tni)
                            {
                                if (tni.Symbol.Type == ANTLRv2Parser.COLON)
                                {
                                    TreeEdits.Delete(tni);
                                    c = n.GetChild(--i);
                                    TreeEdits.Delete(c);
                                }
                                else if (tni.Symbol.Type == ANTLRv2Parser.EQUAL)
                                {
                                    TreeEdits.Delete(tni);
                                    c = n.GetChild(--i);
                                    TreeEdits.Delete(c);
                                }
                            }
                        }
                    }
                }
            }

            if (StripActionBlocks)
            {
                using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext =
                    new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
                {
                    org.eclipse.wst.xml.xpath2.processor.Engine engine =
                     new org.eclipse.wst.xml.xpath2.processor.Engine();
                    var nodes = engine.parseExpression(
                            @"//actionBlock
                            [not(following-sibling::QM)]",
                            new StaticContextBuilder()).evaluate(
                            dynamicContext, new object[] { dynamicContext.Document })
                        .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree).ToList();
                    foreach (var n in nodes) TreeEdits.Delete(n);
                }
            }

            // Convert double-quoted string literals to single quote.
            {
                using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext =
                    new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
                {
                    org.eclipse.wst.xml.xpath2.processor.Engine engine =
                     new org.eclipse.wst.xml.xpath2.processor.Engine();
                    var nodes = engine.parseExpression(
                            @"//STRING_LITERAL",
                            new StaticContextBuilder()).evaluate(
                            dynamicContext, new object[] { dynamicContext.Document })
                        .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree);
                    foreach (var n in nodes)
                    {
                        var text = n.GetText();
                        if (text.Length == 0) continue;
                        if (text[0] != '"') continue;
                        text = text.Substring(1, text.Length - 2);
                        StringBuilder ss = new StringBuilder();
                        ss.Append("'");
                        foreach (var c in text)
                        {
                            if (c == '"') ss.Append("\\");
                            else ss.Append(c);
                        }
                        ss.Append("'");
                        var new_sym = new TerminalNodeImpl(new CommonToken(ANTLRv4Lexer.STRING_LITERAL)
                        { Line = -1, Column = -1, Text = ss.ToString() });
                        text_before.TryGetValue(n as TerminalNodeImpl, out string v);
                        if (v != null)
                            text_before.Add(new_sym, v);
                        TreeEdits.Replace(n, new_sym);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            TreeEdits.Reconstruct(sb, tree, text_before);
            var new_code = sb.ToString();

            results.Add(ffn.Replace(".g", ".txt"), errors.ToString());
            results.Add(new_ffn, new_code);
            return results;
        }
    }
}

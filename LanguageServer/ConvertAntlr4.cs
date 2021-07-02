namespace LanguageServer
{
    using Antlr4.Runtime;
    using Antlr4.Runtime.Tree;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using org.eclipse.wst.xml.xpath2.processor.util;

    public class ConvertAntlr4
    {
        public ConvertAntlr4() { }

        public Dictionary<string, string> Try(string ffn, string input, string out_type = "lark")
        {
            if (out_type == "lark")
            {
                var error_file_name = ffn.Substring(0, ffn.Length - 3) + ".txt";
                var new_ffn = ffn.Substring(0, ffn.Length - 3) + ".lark";

                Dictionary<string, string> results = new Dictionary<string, string>();
                var now = DateTime.Now.ToString();
                var errors = new StringBuilder();
                var str = new AntlrInputStream(input);
                var lexer = new ANTLRv4Lexer(str);
                var tokens = new CommonTokenStream(lexer);
                var parser = new ANTLRv4Parser(tokens);
                var elistener = new ErrorListener<IToken>(parser, lexer, 0);
                parser.AddErrorListener(elistener);
                var tree = parser.grammarSpec();

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

                var (text_before, other) = TreeEdits.TextToLeftOfLeaves(tokens, tree);

                // Remove nodes that I cannot deal with at this point.
                using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext =
                        new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
                {
                    org.eclipse.wst.xml.xpath2.processor.Engine engine =
                        new org.eclipse.wst.xml.xpath2.processor.Engine();
                    // Allow language, tokenVocab, TokenLabelType, superClass
                    var nodes = engine.parseExpression(
                        @"//(grammarDecl
						 | grammarType
						 | prequelConstruct
						 | optionsSpec
						 | option
						 | optionValue
						 | delegateGrammars
						 | delegateGrammar
						 | tokensSpec
						 | channelsSpec
						 | idList
						 | action_
						 | actionScopeName
						 | actionBlock
						 | argActionBlock
						 | exceptionGroup
						 | exceptionHandler
						 | finallyClause
						 | rulePrequel
						 | ruleReturns
						 | throwsSpec
						 | localsSpec
						 | ruleAction
						 | ruleModifiers
						 | ruleModifier
						 | elementOptions
						 | elementOption
                        | FRAGMENT
                        | BLOCK_COMMENT
                        | LINE_COMMENT
                        | DOC_COMMENT
						)",
                            new StaticContextBuilder()).evaluate(
                            dynamicContext, new object[] { dynamicContext.Document })
                        .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree);
                    TreeEdits.Delete(nodes);
                }

                // Remove ';' at end of rules, but make sure it contains newline at end.
                // Colon must be placed on same line after LHS symbol.
                // Change case of symbols for new Lark grammar: parser
                // rules are all lower case; lexer rules are all upper case.
                using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext =
                        new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
                {
                    org.eclipse.wst.xml.xpath2.processor.Engine engine =
                        new org.eclipse.wst.xml.xpath2.processor.Engine();
                    var nodes = engine.parseExpression(
                        @"//(parserRuleSpec | lexerRuleSpec)",
                            new StaticContextBuilder()).evaluate(
                            dynamicContext, new object[] { dynamicContext.Document })
                        .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree);
                    foreach (var n in nodes)
                    {
                        if (n is ANTLRv4Parser.ParserRuleSpecContext prs)
                        {
                            TreeEdits.Replace(prs.SEMI(), "\r\n");
                            TreeEdits.Delete(prs.COLON());
                            var name = prs.RULE_REF().GetText();
                            name = RemoveCamelCase(name);
                            TreeEdits.Replace(prs.RULE_REF(), name + " : ");
                        }
                        else if (n is ANTLRv4Parser.LexerRuleSpecContext lrs)
                        {
                            TreeEdits.Replace(lrs.SEMI(), "\r\n");
                            TreeEdits.Delete(lrs.COLON());
                            TreeEdits.Replace(lrs.TOKEN_REF(), lrs.TOKEN_REF() + " : ");
                        }
                    }
                }

                // Convert lexer expressions that contain '~'.

                // Convert '-> skip' or '-> channel(.....)' into '%ignore'

                // Are modes are unnecessary in Lark? Context dependent lexing is default.

                // Convert '...' to "..." for string literals.
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
                        // Convert "foobar" to 'foobar', taking care of single quote nonsense.
                        var text = n.GetText();
                        if (text.Length == 0) continue;
                        if (text[0] == '"')
                        {
                            text = text.Substring(1, text.Length - 2);
                            StringBuilder ss = new StringBuilder();
                            ss.Append("'");
                            foreach (var c in text)
                            {
                                if (c == '\'') ss.Append("\\'");
                                else ss.Append(c);
                            }
                            ss.Append("'");
                            text = ss.ToString();
                            TreeEdits.Replace(n, text);
                        }
                    }
                }

                using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext =
                    new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
                {
                    org.eclipse.wst.xml.xpath2.processor.Engine engine =
                        new org.eclipse.wst.xml.xpath2.processor.Engine();
                    var nodes = engine.parseExpression(
                        @"//(parserRuleSpec | lexerRuleSpec)//(TOKEN_REF | RULE_REF)",
                            new StaticContextBuilder()).evaluate(
                            dynamicContext, new object[] { dynamicContext.Document })
                        .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree);
                    foreach (var n in nodes)
                    {
                        var z = n as TerminalNodeImpl;
                        if (z.Symbol.Type == ANTLRv4Lexer.RULE_REF)
                        {
                            var name = z.GetText();
                            name = RemoveCamelCase(name);
                            TreeEdits.Replace(n, name);
                        }
                        else if (z.Symbol.Type == ANTLRv4Lexer.TOKEN_REF)
                        {
                            var name = z.GetText();
                            name = name.ToUpper();
                            TreeEdits.Replace(n, name);
                        }
                    }
                }

                StringBuilder sb = new StringBuilder();
                TreeEdits.Reconstruct(sb, tree, new Dictionary<TerminalNodeImpl, string>());
                var new_code = sb.ToString();
                results.Add(new_ffn, new_code);

                return results;
            }
            return null;
        }

        private string RemoveCamelCase(string str)
        {
            return string.Concat((str ?? string.Empty).Select((x, i) => i > 0 && char.IsUpper(x) && !char.IsUpper(str[i - 1]) ? $"_{x}" : x.ToString())).ToLower();
        }
    }
}

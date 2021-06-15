﻿namespace LanguageServer
{
    using Algorithms;
    using Antlr4.Runtime;
    using Antlr4.Runtime.Misc;
    using Antlr4.Runtime.Tree;
    using Microsoft.CodeAnalysis;
    using org.eclipse.wst.xml.xpath2.processor.util;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Document = Workspaces.Document;

    public class Analysis
    {
        public static void ShowCycles(int pos, Document document)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            // Check if initial file is a grammar.
            ParsingResults pd_parser = ParsingResultsFactory.Create(document) as ParsingResults;
            if (pd_parser == null)
            {
                throw new LanguageServerException("A grammar file is not selected. Please select one first.");
            }
            Transform.ExtractGrammarType egt = new Transform.ExtractGrammarType();
            ParseTreeWalker.Default.Walk(egt, pd_parser.ParseTree);
            bool is_grammar = egt.Type == Transform.ExtractGrammarType.GrammarType.Parser
                || egt.Type == Transform.ExtractGrammarType.GrammarType.Combined
                || egt.Type == Transform.ExtractGrammarType.GrammarType.Lexer;
            if (!is_grammar)
            {
                throw new LanguageServerException("A grammar file is not selected. Please select one first.");
            }

            // Find all other grammars by walking dependencies (import, vocab, file names).
            HashSet<string> read_files = new HashSet<string>
            {
                document.FullPath
            };
            Dictionary<Workspaces.Document, List<TerminalNodeImpl>> every_damn_literal =
                new Dictionary<Workspaces.Document, List<TerminalNodeImpl>>();
            for (; ; )
            {
                int before_count = read_files.Count;
                foreach (string f in read_files)
                {
                    List<string> additional = ParsingResults.InverseImports.Where(
                        t => t.Value.Contains(f)).Select(
                        t => t.Key).ToList();
                    read_files = read_files.Union(additional).ToHashSet();
                }
                foreach (string f in read_files)
                {
                    var additional = ParsingResults.InverseImports.Where(
                        t => t.Key == f).Select(
                        t => t.Value);
                    foreach (var t in additional)
                    {
                        read_files = read_files.Union(t).ToHashSet();
                    }
                }
                int after_count = read_files.Count;
                if (after_count == before_count)
                {
                    break;
                }
            }

            // Construct graph of symbol usage.
            Transform.TableOfRules table = new Transform.TableOfRules(pd_parser, document);
            table.ReadRules();
            table.FindPartitions();
            table.FindStartRules();
            Digraph<string> graph = new Digraph<string>();
            foreach (Transform.TableOfRules.Row r in table.rules)
            {
                if (!r.is_parser_rule)
                {
                    continue;
                }
                graph.AddVertex(r.LHS);
            }
            foreach (Transform.TableOfRules.Row r in table.rules)
            {
                if (!r.is_parser_rule)
                {
                    continue;
                }
                List<string> j = r.RHS;
                //j.Reverse();
                foreach (string rhs in j)
                {
                    Transform.TableOfRules.Row sym = table.rules.Where(t => t.LHS == rhs).FirstOrDefault();
                    if (!sym.is_parser_rule)
                    {
                        continue;
                    }
                    DirectedEdge<string> e = new DirectedEdge<string>(r.LHS, rhs);
                    graph.AddEdge(e);
                }
            }
            List<string> starts = new List<string>();
            List<string> parser_lhs_rules = new List<string>();
            foreach (Transform.TableOfRules.Row r in table.rules)
            {
                if (r.is_parser_rule)
                {
                    parser_lhs_rules.Add(r.LHS);
                    if (r.is_start)
                    {
                        starts.Add(r.LHS);
                    }
                }
            }

            IParseTree rule = null;
            IParseTree it = pd_parser.AllNodes.Where(n =>
            {
                if (!(n is ANTLRv4Parser.ParserRuleSpecContext || n is ANTLRv4Parser.LexerRuleSpecContext))
                    return false;
                Interval source_interval = n.SourceInterval;
                int a = source_interval.a;
                int b = source_interval.b;
                IToken ta = pd_parser.TokStream.Get(a);
                IToken tb = pd_parser.TokStream.Get(b);
                var start = ta.StartIndex;
                var stop = tb.StopIndex + 1;
                return start <= pos && pos < stop;
            }).FirstOrDefault();
            rule = it;
            var k = (ANTLRv4Parser.ParserRuleSpecContext)rule;
            var tarjan = new TarjanSCC<string, DirectedEdge<string>>(graph);
            List<string> ordered = new List<string>();
            var sccs = tarjan.Compute();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Cycles in " + document.FullPath);
            var done = new List<IEnumerable<string>>();
            foreach (var scc in sccs)
            {
                if (scc.Value.Count() <= 1) continue;
                if (!done.Contains(scc.Value))
                {
                    foreach (var s in scc.Value)
                    {
                        sb.Append(" ");
                        sb.Append(s);
                    }
                    sb.AppendLine();
                    sb.AppendLine();
                    done.Add(scc.Value);
                }
            }

            //var scc = sccs[k.RULE_REF().ToString()];
            //foreach (var v in scc)
            //{
            //    ordered.Add(v);
            //}
        }

        public static List<DiagnosticInfo> PerformAnalysis(Document document)
        {
            List<DiagnosticInfo> result = new List<DiagnosticInfo>();

            // Check if initial file is a grammar.
            ParsingResults pd_parser = ParsingResultsFactory.Create(document) as ParsingResults;
            if (pd_parser == null)
            {
                throw new LanguageServerException("A grammar file is not selected. Please select one first.");
            }
            Transform.ExtractGrammarType egt = new Transform.ExtractGrammarType();
            ParseTreeWalker.Default.Walk(egt, pd_parser.ParseTree);
            bool is_grammar = egt.Type == Transform.ExtractGrammarType.GrammarType.Parser
                || egt.Type == Transform.ExtractGrammarType.GrammarType.Combined
                || egt.Type == Transform.ExtractGrammarType.GrammarType.Lexer;
            if (!is_grammar)
            {
                throw new LanguageServerException("A grammar file is not selected. Please select one first.");
            }

            // Find all other grammars by walking dependencies (import, vocab, file names).
            HashSet<string> read_files = new HashSet<string>
            {
                document.FullPath
            };
            Dictionary<Workspaces.Document, List<TerminalNodeImpl>> every_damn_literal =
                new Dictionary<Workspaces.Document, List<TerminalNodeImpl>>();
            for (; ; )
            {
                int before_count = read_files.Count;
                foreach (string f in read_files)
                {
                    List<string> additional = ParsingResults.InverseImports.Where(
                        t => t.Value.Contains(f)).Select(
                        t => t.Key).ToList();
                    read_files = read_files.Union(additional).ToHashSet();
                }
                foreach (string f in read_files)
                {
                    var additional = ParsingResults.InverseImports.Where(
                        t => t.Key == f).Select(
                        t => t.Value);
                    foreach (var t in additional)
                    {
                        read_files = read_files.Union(t).ToHashSet();
                    }
                }
                int after_count = read_files.Count;
                if (after_count == before_count)
                {
                    break;
                }
            }

            {
                if (pd_parser.AllNodes != null)
                {
                    int[] histogram = new int[pd_parser.Map.Length];
                    var fun = pd_parser.Classify;
                    IEnumerable<IParseTree> it = pd_parser.AllNodes.Where(n => n is TerminalNodeImpl);
                    foreach (var n in it)
                    {
                        var t = n as TerminalNodeImpl;
                        int i = -1;
                        try
                        {
                            i = pd_parser.Classify(pd_parser, pd_parser.Attributes, t);
                            if (i >= 0)
                            {
                                histogram[i]++;
                            }
                        }
                        catch (Exception) { }
                    }
                    for (int j = 0; j < histogram.Length; ++j)
                    {
                        string i = "Parser type " + j + " " + histogram[j];
                        result.Add(
                            new DiagnosticInfo()
                            {
                                Document = document.FullPath,
                                Severify = DiagnosticInfo.Severity.Info,
                                Start = 0,
                                End = 0,
                                Message = i
                            });
                    }
                }
            }


            //IParseTree rule = null;
            //var tarjan = new TarjanSCC<string, DirectedEdge<string>>(graph);
            //List<string> ordered = new List<string>();
            //var sccs = tarjan.Compute();
            //foreach (var scc in sccs)
            //{
            //    if (scc.Value.Count() <= 1) continue;
            //    var k = scc.Key;
            //    var v = scc.Value;
            //    string i = "Participates in cycle " +
            //        string.Join(" => ", scc.Value);
            //    var (start, end) = table.rules.Where(r => r.LHS == k).Select(r =>
            //    {
            //        var lmt = TreeEdits.LeftMostToken(r.rule);
            //        var source_interval = lmt.SourceInterval;
            //        int a = source_interval.a;
            //        int b = source_interval.b;
            //        IToken ta = pd_parser.TokStream.Get(a);
            //        IToken tb = pd_parser.TokStream.Get(b);
            //        var st = ta.StartIndex;
            //        var ed = tb.StopIndex + 1;
            //        return (st, ed);
            //    }).FirstOrDefault();
            //    result.Add(
            //        new DiagnosticInfo()
            //        {
            //            Document = document.FullPath,
            //            Severify = DiagnosticInfo.Severity.Info,
            //            Start = start,
            //            End = end,
            //            Message = i
            //        });
            //}


            // Check for useless lexer tokens.
            List<string> unused = new List<string>();
            var pt = pd_parser.ParseTree;
            var l1 = TreeEdits.FindTopDown(pt, (in IParseTree t, out bool c) =>
            {
                c = true;
                if (t is ANTLRv4Parser.LexerRuleSpecContext)
                {
                    c = false;
                    return t;
                }
                return null;
            }).ToList();
            foreach (var t in l1)
            {
                var r1 = t as ANTLRv4Parser.LexerRuleSpecContext;
                var lhs = r1.TOKEN_REF();
                var k = lhs.GetText();
                var source_interval = lhs.SourceInterval;
                int a = source_interval.a;
                int b = source_interval.b;
                IToken ta = pd_parser.TokStream.Get(a);
                IToken tb = pd_parser.TokStream.Get(b);
                var st = ta.StartIndex;
                var ed = tb.StopIndex + 1;
                var refs = new Module().FindRefsAndDefs(st, document);
                if (refs.Count() <= 1)
                {
                    string i = "Lexer rule " + k + " unused in parser grammar rules. Consider removing.";
                    result.Add(
                        new DiagnosticInfo()
                        {
                            Document = document.FullPath,
                            Severify = DiagnosticInfo.Severity.Info,
                            Start = st,
                            End = ed,
                            Message = i
                        });
                }
            }

            // Check for literals or sets that contain \uXXXX with further characters past that
            // aren't other escapes. In other words, it gets confusing when you write '\u123456'.
            // Did you mean '\u{123456}' or did you mean '\u1234' '56'?
            var (tree, parser, lexer) = (pd_parser.ParseTree, pd_parser.Parser, pd_parser.Lexer);
            using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext =
                new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
            {
                org.eclipse.wst.xml.xpath2.processor.Engine engine = new org.eclipse.wst.xml.xpath2.processor.Engine();
                {
                    var nodes = engine.parseExpression(
                        @"//STRING_LITERAL",
                        new StaticContextBuilder()).evaluate(dynamicContext, new object[] { dynamicContext.Document })
                    .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree)
                    .ToArray();
                    foreach (var n in nodes)
                    {
                        var t = n as TerminalNodeImpl;
                        var text = t.Payload.Text;
                        for (int i = 0; i < text.Length; ++i)
                        {
                            if (text[i] == '\\')
                            {
                                if (i + 1 >= text.Length) continue;
                                if (text[i + 1] == 'u')
                                {
                                    if (i + 2 >= text.Length) continue;
                                    if (text[i + 2] == '{') continue;
                                    if (i + 6 >= text.Length) continue;
                                    if (text[i + 6] == '\\') continue;
                                    else if (text[i + 6] == '\'') continue;
                                    else
                                    {
                                        // String containing Unicode 4-byte quantity, but it's questionable.
                                        string m = "Literal " + text + " looks unusual. Consider moving \\u's to end, or changing to code point \\u{XXXXXX} syntax.";
                                        result.Add(
                                            new DiagnosticInfo()
                                            {
                                                Document = document.FullPath,
                                                Severify = DiagnosticInfo.Severity.Info,
                                                Start = t.Payload.StartIndex,
                                                End = t.Payload.StopIndex,
                                                Message = m
                                            });
                                    }
                                }
                            }
                        }
                    }
                }
            }

            using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext =
                new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
            {
                org.eclipse.wst.xml.xpath2.processor.Engine engine = new org.eclipse.wst.xml.xpath2.processor.Engine();
                {
                    var nodes = engine.parseExpression(
                        @"//LEXER_CHAR_SET",
                        new StaticContextBuilder()).evaluate(dynamicContext, new object[] { dynamicContext.Document })
                    .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree)
                    .ToArray();
                    foreach (var n in nodes)
                    {
                        var t = n as TerminalNodeImpl;
                        var text = t.Payload.Text;
                        for (int i = 0; i < text.Length; ++i)
                        {
                            if (text[i] == '\\')
                            {
                                if (i + 1 >= text.Length) continue;
                                if (text[i + 1] == 'u')
                                {
                                    if (i + 2 >= text.Length) continue;
                                    if (text[i + 2] == '{') continue;
                                    if (i + 6 >= text.Length) continue;
                                    if (text[i + 6] == '\\') continue;
                                    else if (text[i + 6] == ']') continue;
                                    else if (text[i + 6] == '-') continue;
                                    else
                                    {
                                        // String containing Unicode 4-byte quantity, but it's questionable.
                                        string m = "Literal " + text + " looks unusual. Consider moving \\u's to end, or changing to code point \\u{XXXXXX} syntax.";
                                        result.Add(
                                            new DiagnosticInfo()
                                            {
                                                Document = document.FullPath,
                                                Severify = DiagnosticInfo.Severity.Info,
                                                Start = t.Payload.StartIndex,
                                                End = t.Payload.StopIndex,
                                                Message = m
                                            });
                                    }
                                }
                            }
                        }
                    }
                }
            }

            using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext =
                new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
            {
                org.eclipse.wst.xml.xpath2.processor.Engine engine = new org.eclipse.wst.xml.xpath2.processor.Engine();
                {
                    var nodes = engine.parseExpression(
			            @"//parserRuleSpec",
                        new StaticContextBuilder()).evaluate(dynamicContext, new object[] { dynamicContext.Document })
                    .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement))
                    .ToArray();
                    foreach (var n in nodes)
                    {
                        var elements = engine.parseExpression(
                            @"ruleBlock/ruleAltList/labeledAlt/alternative/element[1]/atom/terminal/TOKEN_REF",
                                new StaticContextBuilder()).evaluate(dynamicContext, new object[] { n })
                            .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree as TerminalNodeImpl)
                            .Select(x => x.GetText())
                            .ToArray();
                        // If there are more than 1 of any name, flag rule.
                        if (elements.Distinct().Count() != elements.Count())
                        {
                            var rule_ref = (n.AntlrIParseTree as ANTLRv4Parser.ParserRuleSpecContext)?.RULE_REF() as TerminalNodeImpl; ;
                            string name = rule_ref.GetText();
                            string m = "Rule " + name + " contains some common left factors. Consider grouping.";
                            result.Add(
                                new DiagnosticInfo()
                                {
                                    Document = document.FullPath,
                                    Severify = DiagnosticInfo.Severity.Info,
                                    Start = rule_ref.Payload.StartIndex,
                                    End = rule_ref.Payload.StopIndex,
                                    Message = m
                                });
                        }
                    }
                }
            }

            {
                ParsingResults pd = pd_parser;
                //var pt = pd.ParseTree;

                List<ANTLRv4Parser.AltListContext> altlists;
                List<ANTLRv4Parser.ElementContext> elements;
                List<ANTLRv4Parser.AltListContext> altlists2;
                List<ANTLRv4Parser.ElementContext> elements2;
                using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext = new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
                {
                    org.eclipse.wst.xml.xpath2.processor.Engine engine = new org.eclipse.wst.xml.xpath2.processor.Engine();

                    altlists = engine.parseExpression(
                        "//(altList | labeledAlt)/alternative/element/ebnf[not(child::blockSuffix)]/block/altList[not(@ChildCount > 1)]",
                        new StaticContextBuilder()).evaluate(dynamicContext, new object[] { dynamicContext.Document })
                        .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree as ANTLRv4Parser.AltListContext).ToList();
                    altlists2 = engine.parseExpression(
                        "//(altList | labeledAlt)[not(@ChildCount > 1)]/alternative[not(@ChildCount > 1)]/element/ebnf[not(child::blockSuffix)]/block/altList[@ChildCount > 1]",
                        new StaticContextBuilder()).evaluate(dynamicContext, new object[] { dynamicContext.Document })
                        .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree as ANTLRv4Parser.AltListContext).ToList();
                    elements = altlists.Select(t => t.Parent.Parent.Parent as ANTLRv4Parser.ElementContext).ToList();
                    elements2 = altlists2.Select(t => t.Parent.Parent.Parent as ANTLRv4Parser.ElementContext).ToList();
                }

                for (int j = 0; j < altlists.Count; ++j)
                {
                    // Remove {altlist}/../../.. (an element), which is the "i'th" child.
                    var altlist = altlists[j];
                    var element = elements[j];
                    var parent_alternative = element?.Parent as ANTLRv4Parser.AlternativeContext;
                    IParseTree p = null;
                    for (p = element; p != null; p = p.Parent)
                    {
                        if (p as ANTLRv4Parser.ParserRuleSpecContext != null) break;
                    }
                    var rule_ref = (p as ANTLRv4Parser.ParserRuleSpecContext)?.RULE_REF() as TerminalNodeImpl; ;
                    string name = rule_ref.GetText();
                    string m = "Rule " + name + " contains useless parentheses. ";
                    result.Add(
                        new DiagnosticInfo()
                        {
                            Document = document.FullPath,
                            Severify = DiagnosticInfo.Severity.Info,
                            Start = rule_ref.Payload.StartIndex,
                            End = rule_ref.Payload.StopIndex,
                            Message = m
                        });
                    //int i = 0;
                    //for (; i < parent_alternative.ChildCount;)
                    //{
                    //    if (parent_alternative.children[i] == element)
                    //        break;
                    //    ++i;
                    //}
                    //parent_alternative.children.RemoveAt(i);
                    //parent_alternative.children.Insert(i, altlist);
                }
                for (int j = 0; j < altlists2.Count; ++j)
                {
                    // Remove {altlist}/../../.. (an element), which is the "i'th" child.
                    var altlist = altlists2[j];
                    var element = elements2[j];
                    var parent_alternative = element?.Parent as ANTLRv4Parser.AlternativeContext;
                    IParseTree p = null;
                    for (p = element; p != null; p = p.Parent)
                    {
                        if (p as ANTLRv4Parser.ParserRuleSpecContext != null) break;
                    }
                    var rule_ref = (p as ANTLRv4Parser.ParserRuleSpecContext)?.RULE_REF() as TerminalNodeImpl; ;
                    string name = rule_ref.GetText();
                    string m = "Rule " + name + " contains useless parentheses. ";
                    result.Add(
                        new DiagnosticInfo()
                        {
                            Document = document.FullPath,
                            Severify = DiagnosticInfo.Severity.Info,
                            Start = rule_ref.Payload.StartIndex,
                            End = rule_ref.Payload.StopIndex,
                            Message = m
                        });
                    //int i = 0;
                    //for (; i < parent_alternative.ChildCount;)
                    //{
                    //    if (parent_alternative.children[i] == element)
                    //        break;
                    //    ++i;
                    //}
                    //parent_alternative.children.RemoveAt(i);
                    //parent_alternative.children.Insert(i, altlist);
                }
            }

            return result;
        }
    }
}

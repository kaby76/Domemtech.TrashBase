﻿using Algorithms;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using AntlrTreeEditing.AntlrDOM;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using org.eclipse.wst.xml.xpath2.processor.util;
using Domemtech.Symtab;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Document = Workspaces.Document;
using NWayDiff;
using org.w3c.dom;
using Microsoft.CodeAnalysis.Operations;
using System.Collections.Immutable;
using System.Collections;
using System.Text.RegularExpressions;

namespace LanguageServer
{
    public class EnumerateDerivation
    {
        private readonly Document _document;
        private ParsingResults _pd;
        private List<ParserRuleContext> _rules;
        private string _start;
        Stack<ParserRuleContext> _todo_stack = new Stack<ParserRuleContext>();
        Stack<ParserRuleContext> _completed_stack = new Stack<ParserRuleContext>();

        public EnumerateDerivation(Document document, string start)
        {
            // Check if initial file is a grammar.
            if (!(ParsingResultsFactory.Create(document) is ParsingResults pd_parser))
                throw new LanguageServerException("A grammar file is not selected. Please select one first.");

            ExtractGrammarType egt = new ExtractGrammarType();
            ParseTreeWalker.Default.Walk(egt, pd_parser.ParseTree);
            bool is_grammar = egt.Type == ExtractGrammarType.GrammarType.Parser
                              || egt.Type == ExtractGrammarType.GrammarType.Combined
                              || egt.Type == ExtractGrammarType.GrammarType.Lexer;
            if (!is_grammar)
            {
                throw new LanguageServerException("A grammar file is not selected. Please select one first.");
            }
            _document = document;
            if (!(ParsingResultsFactory.Create(_document) is ParsingResults pd_doc))
                throw new Exception("Cannot create parser doc.");
            _pd = pd_doc;
            _start = start;
        }

        public string Enumerate(int depth)
        {
            var (tree, parser, lexer) = (_pd.ParseTree, _pd.Parser, _pd.Lexer);
            using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext = new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
            {
                org.eclipse.wst.xml.xpath2.processor.Engine engine = new org.eclipse.wst.xml.xpath2.processor.Engine();
                var rules = engine.parseExpression(
                        @"//ruleSpec/parserRuleSpec",
                        new StaticContextBuilder()).evaluate(dynamicContext, new object[] { dynamicContext.Document })
                    .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree as ParserRuleContext).ToList();
                if (rules.Count == 0) throw new Exception("No rules.");
                _rules = rules.ToList();
            }
            if (_start != null)
            {
                MyVisitor mylist = new MyVisitor(_rules);
                for (int i = 0; i < 10099; ++i)
                {
                    StringBuilder sb = new StringBuilder();
                    var rule = _rules.Where(t => (t as ANTLRv4Parser.ParserRuleSpecContext)?.RULE_REF().GetText() == _start).First() as ANTLRv4Parser.ParserRuleSpecContext;
                    var res = mylist.VisitParserRuleSpec(rule as ANTLRv4Parser.ParserRuleSpecContext);
                    sb.Append(res.GetText());
                    var gen = sb.ToString();
                    System.Console.WriteLine(gen);
                }
            }
            return "";
        }

        public class Model
        {
            Random random = new Random();

            public Model()
            {
            }

            public int Alt(IParseTree alt)
            {
                if (alt is ANTLRv4Parser.RuleAltListContext t1)
                {
                    int count = t1.labeledAlt().Length;
                    int v = random.Next(count);
                    return v;
                }
                else if (alt is ANTLRv4Parser.AlternativeContext t2)
                {
                    int count = t2.element().Length;
                    int v = random.Next(count);
                    return v;
                }
                else
                { }
                return 0;
            }
        }

        public class MyVisitor : LanguageServer.ANTLRv4ParserBaseVisitor<IParseTree>
        {
            Model _model = new Model();
            Stack<ParserRuleContext> _todo_stack = new Stack<ParserRuleContext>();
            private List<ParserRuleContext> _rules;

            public MyVisitor(List<ParserRuleContext> rules)
            {
                _rules = rules;
            }

            public override IParseTree VisitParserRuleSpec([NotNull] ANTLRv4Parser.ParserRuleSpecContext context)
            {
                var result = new ParserRuleContext(null, 0);
                if (_todo_stack.Count > 0)
                {
                    var p = _todo_stack.Peek();
                    p.AddChild(result);
                }
                _todo_stack.Push(result);
                var c = VisitRuleBlock(context.ruleBlock());
                _todo_stack.Pop();
                return result;
            }

            public override IParseTree VisitRuleBlock([NotNull] ANTLRv4Parser.RuleBlockContext context)
            {
                var c = VisitRuleAltList(context.ruleAltList());
                return c;
            }

            public override IParseTree VisitRuleAltList([NotNull] ANTLRv4Parser.RuleAltListContext context)
            {
                var labeledAlts = context.labeledAlt();
                var alt = _model.Alt(context);
                var result = VisitLabeledAlt(labeledAlts[alt]);
                return result;
            }

            public override IParseTree VisitLabeledAlt([NotNull] ANTLRv4Parser.LabeledAltContext context)
            {
                var c = context.alternative();
                return VisitAlternative(c);
            }

            public override IParseTree VisitAlternative([NotNull] ANTLRv4Parser.AlternativeContext context)
            {
                var cs = context.element();
                foreach (var e in cs)
                {
                    _ = VisitElement(e);
                }
                return null;
            }

            public override IParseTree VisitElement([NotNull] ANTLRv4Parser.ElementContext context)
            {
                var le = context.labeledElement();
                var at = context.atom();
                var ebnf = context.ebnf();
                if (at != null)
                {
                    return VisitAtom(at);
                }
                else if (le != null)
                {
                    return VisitLabeledElement(le);
                }
                else if (ebnf != null)
                {
                    return VisitEbnf(ebnf);
                }
                else throw new Exception();
                return null;
            }

            public override IParseTree VisitAtom([NotNull] ANTLRv4Parser.AtomContext context)
            {
                var t = context.terminal();
                var rr = context.ruleref();
                var ns = context.notSet();
                var dot = context.DOT();
                if (t != null)
                {
                    return VisitTerminal(t);
                }
                else if (rr != null)
                {
                    return VisitRuleref(rr);
                }
                else if (ns != null)
                {
                    return VisitNotSet(ns);
                }
                else if (dot != null)
                {
                    // Create a random lexer rule symbol. TODO.
                    return null;
                }
                else throw new Exception();
            }

            public override IParseTree VisitTerminal([NotNull] ANTLRv4Parser.TerminalContext context)
            {
                var token_ref = context.TOKEN_REF();
                var str_lit = context.STRING_LITERAL();
                if (token_ref != null)
                {
                    var str = token_ref.Symbol.Text.Substring(1, token_ref.Symbol.Text.Length - 2);
                    var c = new TerminalNodeImpl(new CommonToken(token_ref.Symbol.Type) { Line = -1, Column = -1, Text = str });
                    var p = _todo_stack.Peek();
                    p.AddChild(c);
                    return c;
                }
                else if (str_lit != null)
                {
                    var str = str_lit.Symbol.Text.Substring(1, str_lit.Symbol.Text.Length - 2);
                    var c = new TerminalNodeImpl(new CommonToken(str_lit.Symbol.Type) { Line = -1, Column = -1, Text = str });
                    var p = _todo_stack.Peek();
                    p.AddChild(c);
                    return c;
                }
                return null;
            }

            public override IParseTree VisitTerminal(ITerminalNode node)
            {
                throw new Exception();
            }

            public override IParseTree VisitRuleref([NotNull] ANTLRv4Parser.RulerefContext context)
            {
                var rule_ref = context.RULE_REF();
                var start = rule_ref.GetText();
                var rule = _rules.Where(t => (t as ANTLRv4Parser.ParserRuleSpecContext)?.RULE_REF().GetText() == start).First() as ANTLRv4Parser.ParserRuleSpecContext;
                var res = VisitParserRuleSpec(rule as ANTLRv4Parser.ParserRuleSpecContext);
                return res;
            }
        }
    }

}

using Algorithms;
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
        private readonly Document _parser_doc;
        private readonly Document _lexer_doc;
        private ParsingResults _pr_parser;
        private ParsingResults _pr_lexer;
        private List<ParserRuleContext> _prules;
        private List<ParserRuleContext> _lrules;
        private string _start;
        Stack<ParserRuleContext> _todo_stack = new Stack<ParserRuleContext>();
        Stack<ParserRuleContext> _completed_stack = new Stack<ParserRuleContext>();

        public EnumerateDerivation(Document parser_doc, Document lexer_doc, string start)
        {
            // Check if initial file is a grammar.
            if (!(ParsingResultsFactory.Create(parser_doc) is ParsingResults pd_parser))
                throw new LanguageServerException("A grammar file is not selected. Please select one first.");
            if (!(ParsingResultsFactory.Create(lexer_doc) is ParsingResults pd_lexer))
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
            _parser_doc = parser_doc;
            _lexer_doc = lexer_doc;
            if (!(ParsingResultsFactory.Create(_parser_doc) is ParsingResults pr_parser))
                throw new Exception("Cannot create parser doc.");
            _pr_parser = pr_parser;
            if (!(ParsingResultsFactory.Create(_lexer_doc) is ParsingResults pr_lexer))
                throw new Exception("Cannot create lexer doc.");
            _pr_lexer = pr_lexer;
            _start = start;
        }

        public string Enumerate()
        {
            {
                var (ptree, pparser, plexer) = (_pr_parser.ParseTree, _pr_parser.Parser, _pr_parser.Lexer);
                using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext = new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(ptree, pparser))
                {
                    org.eclipse.wst.xml.xpath2.processor.Engine engine = new org.eclipse.wst.xml.xpath2.processor.Engine();
                    var rules = engine.parseExpression(
                            @"//ruleSpec/parserRuleSpec",
                            new StaticContextBuilder()).evaluate(dynamicContext, new object[] { dynamicContext.Document })
                        .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree as ParserRuleContext).ToList();
                    if (rules.Count == 0) throw new Exception("No rules.");
                    _prules = rules.ToList();
                }
            }
            {
                var (ptree, pparser, plexer) = (_pr_lexer.ParseTree, _pr_lexer.Parser, _pr_lexer.Lexer);
                using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext = new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(ptree, pparser))
                {
                    org.eclipse.wst.xml.xpath2.processor.Engine engine = new org.eclipse.wst.xml.xpath2.processor.Engine();
                    var rules = engine.parseExpression(
                            @"//ruleSpec/lexerRuleSpec",
                            new StaticContextBuilder()).evaluate(dynamicContext, new object[] { dynamicContext.Document })
                        .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree as ParserRuleContext).ToList();
                    if (rules.Count == 0) throw new Exception("No rules.");
                    _lrules = rules.ToList();
                }
            }
            if (_start != null)
            {
                MyVisitor mylist = new MyVisitor(_pr_parser, _prules, _pr_lexer, _lrules);
                for (int i = 0; i < 10; ++i)
                {
                    var rule = _prules.Where(t => (t as ANTLRv4Parser.ParserRuleSpecContext)?.RULE_REF().GetText() == _start).First() as ANTLRv4Parser.ParserRuleSpecContext;
                    var res = mylist.VisitParserRuleSpec(rule as ANTLRv4Parser.ParserRuleSpecContext);
                    StringBuilder sb = new StringBuilder();
                    TreeEdits.Reconstruct(sb, res, new Dictionary<TerminalNodeImpl, string>());
                    var new_code = sb.ToString();
                    System.Console.WriteLine(new_code);
                }
            }
            return "";
        }

        public class Model
        {
            Random _random = new Random();
            ConvertToDOM _convertToDOM;
            AntlrTreeEditing.AntlrDOM.AntlrDynamicContext _pdynamicContext;
            AntlrTreeEditing.AntlrDOM.AntlrDynamicContext _ldynamicContext;
            org.eclipse.wst.xml.xpath2.processor.Engine _engine;
            public ParsingResults _pr_parser;
            public List<ParserRuleContext> _prules;
            public ParsingResults _pr_lexer;
            public List<ParserRuleContext> _lrules;

            public Model(ParsingResults pr_parser, List<ParserRuleContext> prules, ParsingResults pr_lexer, List<ParserRuleContext> lrules)
            {
                _pr_parser = pr_parser;
                _prules = prules;
                _pr_lexer = pr_lexer;
                _lrules = lrules;
                _convertToDOM = new AntlrTreeEditing.AntlrDOM.ConvertToDOM();
                _pdynamicContext = _convertToDOM.Try(_pr_parser.ParseTree, _pr_parser.Parser);
                _ldynamicContext = _convertToDOM.Try(_pr_lexer.ParseTree, _pr_lexer.Parser);
                _engine = new org.eclipse.wst.xml.xpath2.processor.Engine();
            }

            public int Alt(IParseTree alt)
            {
                if (alt is ANTLRv4Parser.RuleAltListContext t1)
                {
                    int count = t1.labeledAlt().Length;
                    int v = _random.Next(count);
                    return v;
                }
                else if (alt is ANTLRv4Parser.AltListContext t3)
                {
                    int count = t3.alternative().Length;
                    int v = _random.Next(count);
                    return v;
                }
                else if (alt is ANTLRv4Parser.LexerAltListContext t4)
                {
                    int count = t4.lexerAlt().Length;
                    int v = _random.Next(count);
                    return v;
                }
                else throw new Exception();
            }

            internal int ZeroOrMore()
            {
                return _random.Next(10);
            }

            internal int OneOrMore()
            {
                return _random.Next(10) + 1;
            }

            public int ZeroOrOne()
            {
                return _random.Next(2);
            }

            internal bool Pattern(IParseTree context, string v)
            {
                var node = _convertToDOM.FindDomNode(context);
                var res = _engine.parseExpression(
                        v,
                        new StaticContextBuilder()).evaluate(_pdynamicContext, new object[] { node })
                    .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree as ParserRuleContext).ToList();
                if (res.Count == 0) return false;
                else return true;
            }

            internal string FindLexerRuleString(ANTLRv4Parser.LexerRuleSpecContext context)
            {
                if (context == null) return null;
                var node = _convertToDOM.FindDomNode(context);
                var res = _engine.parseExpression(
                        "lexerRuleBlock/lexerAltList/lexerAlt/lexerElements/lexerElement/lexerAtom/terminal/STRING_LITERAL",
                        new StaticContextBuilder()).evaluate(_ldynamicContext, new object[] { node })
                    .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree as TerminalNodeImpl).ToList();
                if (res.Count == 1) return res.First().Symbol.Text.Substring(1, res.First().Symbol.Text.Length - 2);
                else return null;
            }
        }

        public class MyVisitor : LanguageServer.ANTLRv4ParserBaseVisitor<IParseTree>
        {
            Model _model;
            Stack<ParserRuleContext> _todo_stack = new Stack<ParserRuleContext>();

            public MyVisitor(ParsingResults pr_parser, List<ParserRuleContext> prules, ParsingResults pr_lexer, List<ParserRuleContext> lrules)
            {
                _model = new Model(pr_parser, prules, pr_lexer, lrules);
            }

            public override IParseTree VisitAltList([NotNull] ANTLRv4Parser.AltListContext context)
            {
                var alts = context.alternative();
                var alt = _model.Alt(context);
                var result = VisitAlternative(alts[alt]);
                return result;
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
                if (_model.Pattern(context, ".[atom/ruleref/RULE_REF/text()='prequelConstruct']")) return null;
                if (_model.Pattern(context, ".[atom/ruleref/RULE_REF/text()='modeSpec']")) return null;
                var le = context.labeledElement();
                var at = context.atom();
                var ebnf = context.ebnf();
                var suffix = context.ebnfSuffix();
                if (at != null)
                {
                    int times = 1;
                    if (_model.Pattern(context, ".[atom/ruleref/RULE_REF/text()='atom' and ../element/ebnf/block/altList/alternative/element/atom/ruleref/RULE_REF/text()='ebnfSuffix']"))
                        times = _model.ZeroOrMore();
                    for (int i = 0; i < times; ++i) VisitAtom(at);
                    return null;
                }
                else if (le != null)
                {
                    int times = 1;
                    if (_model.Pattern(context, ".[atom/ruleref/RULE_REF/text()='labeledElement' and ../element/ebnf/block/altList/alternative/element/atom/ruleref/RULE_REF/text()='ebnfSuffix']"))
                        times = _model.ZeroOrMore();
                    return VisitLabeledElement(le);
                }
                else if (ebnf != null)
                {
                    return VisitEbnf(ebnf);
                }
                else throw new Exception();
            }

            public override IParseTree VisitLabeledElement([NotNull] ANTLRv4Parser.LabeledElementContext context)
            {
                var atom = context.atom();
                var block = context.block();
                if (atom != null)
                {
                    return VisitAtom(atom);
                }
                else if (block != null)
                {
                    return VisitBlock(block);
                }
                else throw new Exception();
            }

            public override IParseTree VisitEbnf([NotNull] ANTLRv4Parser.EbnfContext context)
            {
                var block = context.block();
                var block_suffix = context.blockSuffix();
                var str_block_suffix = "";
                if (block_suffix != null)
                {
                    str_block_suffix = block_suffix.GetText();
                    switch (str_block_suffix)
                    {
                        case "+":
                        case "+?":
                            {
                                int times = _model.OneOrMore();
                                //System.Console.WriteLine("Times = " + times);
                                for (int i = 0; i < times; i++) VisitBlock(block);
                            }
                            break;
                        case "*":
                        case "*?":
                            {
                                int times = _model.ZeroOrMore();
                                //System.Console.WriteLine("Times = " + times);
                                for (int i = 0; i < times; i++) VisitBlock(block);
                            }
                            break;
                        case "??":
                        case "?":
                            {
                                int times = _model.ZeroOrOne();
                                //System.Console.WriteLine("Times = " + times);
                                for (int i = 0; i < times; i++) VisitBlock(block);
                            }
                            break;
                        default: throw new Exception();
                    }
                    return null;
                }
                else return VisitBlock(block);
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

            public override IParseTree VisitBlock([NotNull] ANTLRv4Parser.BlockContext context)
            {
                return VisitAltList(context.altList());
            }

            public override IParseTree VisitParserRuleSpec([NotNull] ANTLRv4Parser.ParserRuleSpecContext context)
            {
                //System.Console.WriteLine(context.RULE_REF().GetText());
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

            public override IParseTree VisitLexerRuleSpec([NotNull] ANTLRv4Parser.LexerRuleSpecContext context)
            {
                //System.Console.WriteLine(context.TOKEN_REF().GetText());
                var result = new ParserRuleContext(null, 0);
                if (_todo_stack.Count > 0)
                {
                    var p = _todo_stack.Peek();
                    p.AddChild(result);
                }
                _todo_stack.Push(result);
                var c = VisitLexerRuleBlock(context.lexerRuleBlock());
                _todo_stack.Pop();
                return result;
            }

            public override IParseTree VisitLexerRuleBlock([NotNull] ANTLRv4Parser.LexerRuleBlockContext context)
            {
                var c = VisitLexerAltList(context.lexerAltList());
                return c;
            }

            public override IParseTree VisitLexerAltList([NotNull] ANTLRv4Parser.LexerAltListContext context)
            {
                var lexerAlts = context.lexerAlt();
                var alt = _model.Alt(context);
                var result = VisitLexerAlt(lexerAlts[alt]);
                return result;
            }

            public override IParseTree VisitLexerAlt([NotNull] ANTLRv4Parser.LexerAltContext context)
            {
                var lexer_elements = context.lexerElements();
                if (lexer_elements != null)
                {
                    return VisitLexerElements(lexer_elements);
                }
                return null;
            }

            public override IParseTree VisitLexerElements([NotNull] ANTLRv4Parser.LexerElementsContext context)
            {
                var cs = context.lexerElement();
                foreach (var e in cs)
                {
                    _ = VisitLexerElement(e);
                }
                return null;
            }

            public override IParseTree VisitLexerElement([NotNull] ANTLRv4Parser.LexerElementContext context)
            {
                var le = context.labeledLexerElement();
                var at = context.lexerAtom();
                var lb = context.lexerBlock();
                var ab = context.actionBlock();
                var suffix = context.ebnfSuffix();
                if (at != null)
                {
                    int times = 1;
                    for (int i = 0; i < times; ++i) VisitLexerAtom(at);
                    return null;
                }
                else if (le != null)
                {
                    int times = 1;
                    return VisitLabeledLexerElement(le);
                }
                else if (lb != null)
                {
                    return VisitLexerBlock(lb);
                }
                else if (ab != null) { return null; }
                else throw new Exception();
            }

            public override IParseTree VisitLexerAtom([NotNull] ANTLRv4Parser.LexerAtomContext context)
            {
                var cr = context.characterRange();
                var t = context.terminal();
                var ns = context.notSet();
                var lcs = context.LEXER_CHAR_SET();
                var d = context.DOT();
                if (cr != null)
                {
                    return VisitCharacterRange(cr);
                }
                else if (t != null)
                {
                    return VisitTerminal(t);
                }
                else if (ns != null)
                {
                    return VisitNotSet(ns);
                }
                else if (lcs != null)
                {
                    var str = context.GetText();
                    var c = new TerminalNodeImpl(new CommonToken(444) { Line = -1, Column = -1, Text = str });
                    var p = _todo_stack.Peek();
                    p.AddChild(c);
                    return c;
                    throw new Exception();
                    return null;
                }
                else if (d != null)
                {
                    var str = context.GetText();
                    var c = new TerminalNodeImpl(new CommonToken(444) { Line = -1, Column = -1, Text = str });
                    var p = _todo_stack.Peek();
                    p.AddChild(c);
                    return c;
                    throw new Exception();
                    return null;
                }
                else throw new Exception();
            }

            public override IParseTree VisitLabeledLexerElement([NotNull] ANTLRv4Parser.LabeledLexerElementContext context)
            {
                var la = context.lexerAtom();
                var lb = context.lexerBlock();
                if (la != null)
                {
                    return VisitLexerAtom(la);
                }
                else if (lb != null)
                {
                    return VisitLexerBlock(lb);
                }
                else throw new Exception();
            }

            public override IParseTree VisitLexerBlock([NotNull] ANTLRv4Parser.LexerBlockContext context)
            {
                return VisitLexerAltList(context.lexerAltList());
            }

            public override IParseTree VisitTerminal([NotNull] ANTLRv4Parser.TerminalContext context)
            {
                var token_ref = context.TOKEN_REF();
                var str_lit = context.STRING_LITERAL();
                if (token_ref != null)
                {
                    var str = token_ref.Symbol.Text;
                    if (str == "EOF") return null;
                    if (str == "TOKEN_REF")
                    {
                        TerminalNodeImpl c2 = new TerminalNodeImpl(new CommonToken(token_ref.Symbol.Type) { Line = -1, Column = -1, Text = "TOKEN_REF" });
                        var p2 = _todo_stack.Peek();
                        p2.AddChild(c2);
                        return c2;
                    }
                    if (str == "RULE_REF")
                    {
                        TerminalNodeImpl c2 = new TerminalNodeImpl(new CommonToken(token_ref.Symbol.Type) { Line = -1, Column = -1, Text = "RULE_REF" });
                        var p2 = _todo_stack.Peek();
                        p2.AddChild(c2);
                        return c2;
                    }
                    if (str == "ARGUMENT_CONTENT")
                    {
                        return null;
                    }
                    var fn = token_ref.Symbol.TokenSource.SourceName;
                    var fn_doc = Workspaces.Workspace.Instance.FindDocument(fn);
                    if (!(ParsingResultsFactory.Create(fn_doc) is ParsingResults fn_doc_pr))
                        throw new LanguageServerException("A grammar file is not selected. Please select one first.");
                    var index = new LanguageServer.Module().GetIndex(token_ref.Symbol.Line-1, token_ref.Symbol.Column,
                        fn_doc);
                    var defs = new LanguageServer.Module().FindDefs(index, fn_doc);
                    if (defs != null && defs.Count > 0)
                    {
                        Location d = defs[0];
                        Workspaces.Range r = d.Range;
                        var uri = d.Uri;
                        if (!(ParsingResultsFactory.Create(uri) is ParsingResults def_doc))
                            throw new Exception("Cannot create lexer doc.");
                        IParseTree pt = Util.Find(r.Start.Value, uri);
                        if (pt != null)
                        {
                            var par = pt.Parent as ANTLRv4Parser.LexerRuleSpecContext;
                            if (par == null) return null;
                            var res = VisitLexerRuleSpec(par);
                            
                            return res;

                            //var st2 = _model.FindLexerRuleString(pt.Parent as ANTLRv4Parser.LexerRuleSpecContext);
                            //TerminalNodeImpl c2;
                            //if (st2 != null)
                            //    c2 = new TerminalNodeImpl(new CommonToken(token_ref.Symbol.Type) { Line = -1, Column = -1, Text = st2 });
                            //else
                            //    c2 = new TerminalNodeImpl(new CommonToken(token_ref.Symbol.Type) { Line = -1, Column = -1, Text = str });
                            //var p2 = _todo_stack.Peek();
                            //p2.AddChild(c2);
                            //return c2;
                        }
                    }
                    // Convert the token type to a string value.
                    var rule = _model._lrules.Where(t => (t as ANTLRv4Parser.LexerRuleSpecContext)?.TOKEN_REF().GetText() == str).FirstOrDefault() as ANTLRv4Parser.LexerRuleSpecContext;
                    var st = _model.FindLexerRuleString(rule);
                    TerminalNodeImpl c;
                    if(st != null)
                        c = new TerminalNodeImpl(new CommonToken(token_ref.Symbol.Type) { Line = -1, Column = -1, Text = st });
                    else
                        c = new TerminalNodeImpl(new CommonToken(token_ref.Symbol.Type) { Line = -1, Column = -1, Text = str });
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
                var rule = _model._prules.Where(t => (t as ANTLRv4Parser.ParserRuleSpecContext)?.RULE_REF().GetText() == start).First() as ANTLRv4Parser.ParserRuleSpecContext;
                var res = VisitParserRuleSpec(rule as ANTLRv4Parser.ParserRuleSpecContext);
                return res;
            }

            public override IParseTree VisitNotSet([NotNull] ANTLRv4Parser.NotSetContext context)
            {
                var str = context.GetText();
                var c = new TerminalNodeImpl(new CommonToken(444) { Line = -1, Column = -1, Text = str });
                var p = _todo_stack.Peek();
                p.AddChild(c);
                return c;

                throw new Exception();
            }
        }
    }

}

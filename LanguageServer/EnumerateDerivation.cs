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
        private readonly Document _document;
        private ParsingResults _pd;
        private List<IParseTree> _rules;
        private string _start;

        public EnumerateDerivation(Document document)
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
        }

        public string Enumerate(int depth)
        {
            StringBuilder sb = new StringBuilder();
            var (tree, parser, lexer) = (_pd.ParseTree, _pd.Parser, _pd.Lexer);
            using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext = new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
            {
                org.eclipse.wst.xml.xpath2.processor.Engine engine = new org.eclipse.wst.xml.xpath2.processor.Engine();
                var rules = engine.parseExpression(
                        @"//ruleSpec/parserRuleSpec",
                        new StaticContextBuilder()).evaluate(dynamicContext, new object[] { dynamicContext.Document })
                    .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree).ToList();
                if (rules.Count == 0) throw new Exception("No rules.");
                _rules = rules.ToList();
            }
            Stack<IParseTree> stack = new Stack<IParseTree>();
            stack.Push(_rules.Where(t => (t as ANTLRv4Parser.ParserRuleSpecContext)?.RULE_REF().GetText() == _start).First());
            while (stack.Count > 0)
            {
                IParseTree rule = stack.Pop();
            }
            return sb.ToString();
        }
    }

    public class MyListener : LanguageServer.ANTLRv4ParserBaseListener
    {
        string _start;

        public override void EnterParserRuleSpec([NotNull] ANTLRv4Parser.ParserRuleSpecContext context)
        {
            //if (context.RULE_REF() == _start)
            //{

            //}
            base.EnterParserRuleSpec(context);
        }
    }
}

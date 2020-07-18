using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Algorithms;
using Antlr4.Runtime.Misc;
using LanguageServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Workspaces;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public static Document CheckDoc(string path)
        {
            string file_name = path;
            Document document = Workspaces.Workspace.Instance.FindDocument(file_name);
            if (document == null)
            {
                document = new Workspaces.Document(file_name);
                try
                {   // Open the text file using a stream reader.
                    using (StreamReader sr = new StreamReader(file_name))
                    {
                        // Read the stream to a string, and write the string to the console.
                        string str = sr.ReadToEnd();
                        document.Code = str;
                    }
                }
                catch (IOException)
                {
                }
                Project project = Workspaces.Workspace.Instance.FindProject("Misc");
                if (project == null)
                {
                    project = new Project("Misc", "Misc", "Misc");
                    Workspaces.Workspace.Instance.AddChild(project);
                }
                project.AddDocument(document);
            }
            document.Changed = true;
            _ = ParserDetailsFactory.Create(document);
            _ = LanguageServer.Module.Compile();
            return document;
        }

        [TestMethod]
        public void TestIndexQuickInfo()
        {
            var cwd = Directory.GetCurrentDirectory();
            Document lexer_doc = CheckDoc("../../../../LanguageServer/ANTLRv4Lexer.g4");
            Document document = CheckDoc("../../../../LanguageServer/ANTLRv4Parser.g4");
            int line = 1;
            int character = 1;
            int index = LanguageServer.Module.GetIndex(line, character, document);
            (int, int) back = LanguageServer.Module.GetLineColumn(index, document);
            if (back.Item1 != line || back.Item2 != character) throw new Exception();
            QuickInfo quick_info = LanguageServer.Module.GetQuickInfo(index, document);
            if (quick_info != null) throw new Exception();
        }

        [TestMethod]
        public void TestIndexQuickInfo2()
        {
            var cwd = Directory.GetCurrentDirectory();
            Document lexer_doc = CheckDoc("../../../../LanguageServer/ANTLRv4Lexer.g4");
            Document document = CheckDoc("../../../../LanguageServer/ANTLRv4Parser.g4");
            // Position at the "grammarSpec" rule, beginning of LHS symbol.
            // All lines and columns are zero based in LSP.
            int line = 45;
            int character = 0;
            int index = LanguageServer.Module.GetIndex(line, character, document);
            (int, int) back = LanguageServer.Module.GetLineColumn(index, document);
            if (back.Item1 != line || back.Item2 != character) throw new Exception();
            QuickInfo quick_info = LanguageServer.Module.GetQuickInfo(index, document);
            if (quick_info == null) throw new Exception();
            (int, int) back_start = LanguageServer.Module.GetLineColumn(quick_info.Range.Start.Value, document);
            if (back_start.Item1 != line || back_start.Item2 != character) throw new Exception();
            (int, int) back_end = LanguageServer.Module.GetLineColumn(quick_info.Range.End.Value, document);
            if (back_end.Item1 != line || back_end.Item2 != character + 11) throw new Exception();
        }

        [TestMethod]
        public void TestFindDef()
        {
            var cwd = Directory.GetCurrentDirectory();
            Document lexer_doc = CheckDoc("../../../../LanguageServer/ANTLRv4Lexer.g4");
            Document document = CheckDoc("../../../../LanguageServer/ANTLRv4Parser.g4");
            // Position at the "grammarSpec" rule, beginning of RHS symbol "grammarDecl".
            // All lines and columns are zero based in LSP.
            int line = 46;
            int character = 18;
            int index = LanguageServer.Module.GetIndex(line, character, document);
            (int, int) back = LanguageServer.Module.GetLineColumn(index, document);
            if (back.Item1 != line || back.Item2 != character) throw new Exception();
            IList<Location> found = LanguageServer.Module.FindDefs(index, document);
            if (found.Count != 1) throw new Exception();
            (int, int) back_start = LanguageServer.Module.GetLineColumn(found.First().Range.Start.Value, document);
            if (back_start.Item1 != 49 || back_start.Item2 != 0) throw new Exception();
            (int, int) back_end = LanguageServer.Module.GetLineColumn(found.First().Range.End.Value, document);
            if (back_end.Item1 != 49 || back_end.Item2 != 10) throw new Exception();
        }

        [TestMethod]
        public void TestFindAllRefs()
        {
            var cwd = Directory.GetCurrentDirectory();
            Document document = CheckDoc("../../../../corpus-for-codebuff/A.g4");
            // Position at the "grammarSpec" rule, beginning of RHS symbol "grammarDecl".
            // All lines and columns are zero based in LSP.
            int line = 3;
            int character = 6;
            int index = LanguageServer.Module.GetIndex(line, character, document);
            (int, int) back = LanguageServer.Module.GetLineColumn(index, document);
            if (back.Item1 != line || back.Item2 != character) throw new Exception();
            var found = LanguageServer.Module.FindRefsAndDefs(index, document).ToList();
            if (found.Count != 4) throw new Exception();
            List<Pair<int, int>> r = new List<Pair<int, int>>()
            {
                new Pair<int, int>(3, 6),
                new Pair<int, int>(6, 0),
                new Pair<int, int>(7, 6),
                new Pair<int, int>(7, 12),
            };
            var ordered_found = found.Select(t => t.Range.Start.Value).OrderBy(t => t).ToList();
            for (int i = 0; i < ordered_found.Count; ++i)
            {
                var start = ordered_found[i];
                (int, int) back_start = LanguageServer.Module.GetLineColumn(start, document);
                if (back_start.Item1 != r[i].a || back_start.Item2 != r[i].b) throw new Exception();
            }
        }

        [TestMethod]
        public void TestKeywordFun()
        {
            var cwd = Directory.GetCurrentDirectory();
            Document document = CheckDoc("../../../../corpus-for-codebuff/keywordfun.g4"); // purposefully erroneously all lc.
            // Convert all string literals on RHS of lexer rule into uc/lc equivalent.
            int line = 5;
            int character = 0;
            int index = LanguageServer.Module.GetIndex(line, character, document);
            (int, int) back = LanguageServer.Module.GetLineColumn(index, document);
            if (back.Item1 != line || back.Item2 != character) throw new Exception();
            var found = LanguageServer.Transform.UpperLowerCaseLiteral(index, index, document);
            if (found.Count != 1) throw new Exception();
            var should_be = @"grammar KeywordFun;

a : 'abc';
b : 'def';

A: [aA] [bB] [cC];
B: [dD] [eE] [fF];
C: 'uvw' 'xyz'?;
D: 'uvw' 'xyz'+;
";
            var got = found.First().Value;
            if (got != should_be) throw new Exception();
        }

        [TestMethod]
        public void TestReplaceParserLiterals()
        {
            var cwd = Directory.GetCurrentDirectory();
            Document document = CheckDoc("../../../../corpus-for-codebuff/keywordfun.g4"); // purposefully erroneously all lc.
            // Convert all string literals on RHS of lexer rule into uc/lc equivalent.
            int line = 0;
            int character = 0;
            int index = LanguageServer.Module.GetIndex(line, character, document);
            var found = LanguageServer.Transform.ReplaceLiterals(index, index, document);
            if (found.Count != 1) throw new Exception();
            var should_be = @"grammar KeywordFun;

a : A;
b : B;

A: 'abc';
B: 'def';
C: 'uvw' 'xyz'?;
D: 'uvw' 'xyz'+;
";
            var got = found.First().Value;
            if (got != should_be) throw new Exception();
        }

    }
}

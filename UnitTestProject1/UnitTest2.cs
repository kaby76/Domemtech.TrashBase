using LanguageServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Workspaces;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void Kleene1()
        {
            Workspace _workspace = new Workspace();
            {
                Document document = Document.CreateStringDocument(@"
grammar kleene;
a : | 'a' a;
");
                _ = ParsingResultsFactory.Create(document);
                var workspace = document.Workspace;
                _ = new LanguageServer.Module().Compile(workspace);
                Project project = _workspace.FindProject("Misc");
                if (project == null)
                {
                    project = new Project("Misc", "Misc", "Misc");
                    _workspace.AddChild(project);
                }
                project.AddDocument(document);
                var pr = LanguageServer.ParsingResultsFactory.Create(document);
                if (document.ParseTree == null)
                {
                    new LanguageServer.Module().Compile(_workspace);
                }
                var result = LanguageServer.Transform.ConvertRecursionToKleeneOperator(document);
                if (!(result.Count == 1 && result.First().Value == @"
grammar kleene;
a : 'a' * ;
")) throw new Exception();
            }
        }

        [TestMethod]
        public void Kleene2()
        {
            {
                Workspace _workspace = new Workspace();
                Document document = Document.CreateStringDocument(@"
grammar kleene;
b : | b 'b';
");
                _ = ParsingResultsFactory.Create(document);
                var workspace = document.Workspace;
                _ = new LanguageServer.Module().Compile(workspace);
                Project project = _workspace.FindProject("Misc");
                if (project == null)
                {
                    project = new Project("Misc", "Misc", "Misc");
                    _workspace.AddChild(project);
                }
                project.AddDocument(document);
                var pr = LanguageServer.ParsingResultsFactory.Create(document);
                if (document.ParseTree == null)
                {
                    new LanguageServer.Module().Compile(_workspace);
                }
                var result = LanguageServer.Transform.ConvertRecursionToKleeneOperator(document);
                if (!(result.Count == 1 && result.First().Value == @"
grammar kleene;
b : 'b' * ;
")) throw new Exception();
            }
        }

        [TestMethod]
        public void Kleene3()
        {
            {
                Workspace _workspace = new Workspace();
                Document document = Document.CreateStringDocument(@"
grammar kleene;
xx  : xx yy | ;
yy: 'b' ;
");
                _ = ParsingResultsFactory.Create(document);
                var workspace = document.Workspace;
                _ = new LanguageServer.Module().Compile(workspace);
                Project project = _workspace.FindProject("Misc");
                if (project == null)
                {
                    project = new Project("Misc", "Misc", "Misc");
                    _workspace.AddChild(project);
                }
                project.AddDocument(document);
                var pr = LanguageServer.ParsingResultsFactory.Create(document);
                if (document.ParseTree == null)
                {
                    new LanguageServer.Module().Compile(_workspace);
                }
                var result = LanguageServer.Transform.ConvertRecursionToKleeneOperator(document);
                if (!(result.Count == 1 && result.First().Value == @"
grammar kleene;
xx : yy * ;
yy: 'b' ;
")) throw new Exception();
            }
        }

        [TestMethod]
        public void Kleene4()
        {
            {
                Workspace _workspace = new Workspace();
                Document document = Document.CreateStringDocument(@"
grammar kleene;
xx : 'a' xx | 'a';
yy : yy 'b' | 'b' ;
zz : | 'a' | 'a' zz;
z2 : | 'b' | z2 'b';
");

                // The Kleene rewrite currently produces
                // xx : 'a' * 'a' ;
                // yy: 'b' 'b' * ;
                // zz: 'a' * ( | 'a');
                // z2: ( | 'b') 'b' * ;
                //
                // This should be instead
                // xx : 'a' + ;
                // yy : 'b' + ;
                // zz : 'a' * ;
                // z2 : 'b' * ;

                _ = ParsingResultsFactory.Create(document);
                var workspace = document.Workspace;
                _ = new LanguageServer.Module().Compile(workspace);
                Project project = _workspace.FindProject("Misc");
                if (project == null)
                {
                    project = new Project("Misc", "Misc", "Misc");
                    _workspace.AddChild(project);
                }
                project.AddDocument(document);
                var pr = LanguageServer.ParsingResultsFactory.Create(document);
                if (document.ParseTree == null)
                {
                    new LanguageServer.Module().Compile(_workspace);
                }
                var result = LanguageServer.Transform.ConvertRecursionToKleeneOperator(document);
                if (!(result.Count == 1 && result.First().Value == @"
grammar kleene;
xx : 'a' + ;
yy : 'b' + ;
zz : 'a' * ;
z2 : 'b' * ;
")) throw new Exception();
            }
        }
    }
}

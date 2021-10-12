using LanguageServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Workspaces;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void Rup1()
        {
            Workspace _workspace = new Workspace();
            {
                Document document = Document.CreateStringDocument(@"
grammar temp;
foo: (bar)?; // <- can be safely replaced with `bar?`
bar: 'baz';
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
                var result = LanguageServer.Transform.RemoveUselessParentheses(document);
                if (!(result.Count == 1 && result.First().Value == @"
grammar temp;
foo:bar?; // <- can be safely replaced with `bar?`
bar: 'baz';
")) throw new Exception();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using Algorithms;
using System.Linq;
using Workspaces;

namespace ConsoleApp1
{
    public class SymbolEdge<T> : DirectedEdge<T>
    {
        public SymbolEdge() { }

        public string _symbol { get; set; }

        public override string ToString()
        {
            return From + "->" + To + (_symbol == null ? " [ label=\"&#1013;\" ]" : " [label=\"" + _symbol + "\" ]") + ";";
        }
    }
    public class MyHashSet<T> : HashSet<T>
    {
        public MyHashSet(IEnumerable<T> o) : base(o) { }
        //public MyHashSet(T o) : base(o) { }
        public MyHashSet() : base() { }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            var o = obj as MyHashSet<T>;
            if (o == null) return false;
            if (o.Count != this.Count) return false;
            foreach (var c in this)
            {
                if (!o.Contains(c)) return false;
            }
            foreach (var c in o)
            {
                if (!this.Contains(c)) return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            return this.Count;
        }
    }
    class Program
    {
        private static MyHashSet<string> EpsilonClosureOf(Digraph<string, SymbolEdge<string>> graph, string theState)
        {
            MyHashSet<string> result = new MyHashSet<string>();
            Stack<string> s = new Stack<string>();
            MyHashSet<string> visited = new MyHashSet<string>();
            s.Push(theState);
            while (s.Any())
            {
                var v = s.Pop();
                if (visited.Contains(v)) continue;
                visited.Add(v);
                result.Add(v);
                foreach (var o in graph.SuccessorEdges(v))
                {
                    if (!(o._symbol == null || o._symbol == "")) continue;
                    s.Push(o.To);
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            var file_name = args[0];
            Workspace _workspace = new Workspace();
            Document document = new Workspaces.Document(file_name);
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

        }
    }
}

using System;
using System.Collections.Generic;
using Algorithms;
using System.Linq;

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
            Digraph<string, SymbolEdge<string>> t = new Digraph<string, SymbolEdge<string>>();
            t.AddVertex("1");
            t.AddVertex("2");
            t.AddVertex("3");
            t.AddVertex("4");
            t.AddStart("1");
            t.AddEnd("3");
            t.AddEnd("4");
            t.AddEdge(new SymbolEdge<string>() { From = "1", To = "2", _symbol = "0" });
            t.AddEdge(new SymbolEdge<string>() { From = "1", To = "3", _symbol = "" });
            t.AddEdge(new SymbolEdge<string>() { From = "3", To = "2", _symbol = "" });
            t.AddEdge(new SymbolEdge<string>() { From = "3", To = "4", _symbol = "0" });
            t.AddEdge(new SymbolEdge<string>() { From = "4", To = "3", _symbol = "0" });
            t.AddEdge(new SymbolEdge<string>() { From = "2", To = "2", _symbol = "1" });
            t.AddEdge(new SymbolEdge<string>() { From = "2", To = "4", _symbol = "1" });
            Digraph<MyHashSet<string>, SymbolEdge<MyHashSet<string>>> DFA = new Digraph<MyHashSet<string>, SymbolEdge<MyHashSet<string>>>();
            MyHashSet<MyHashSet<string>> marked = new MyHashSet<MyHashSet<string>>();
            MyHashSet<MyHashSet<string>> unmarked = new MyHashSet<MyHashSet<string>>();
            foreach (var s in t.StartVertices)
            {
                var startingState = new MyHashSet<string>(new List<string> { s });
                var new_dfa_state = EpsilonClosureOf(t, s);
                DFA.AddVertex(new_dfa_state);
                var hs = new MyHashSet<string>();
                for (int i = new_dfa_state.Count - 1; i >= 0; --i) hs.Add(new_dfa_state.ElementAt(i));
                DFA.AddVertex(hs);
            }
        }
    }
}

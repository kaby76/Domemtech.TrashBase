﻿namespace LanguageServer
{
    using Antlr4.Runtime;
    using Antlr4.Runtime.Tree;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    // Class to offer Antlr tree edits, both in-place and out-of-place,
    // and tree copying.
    public class TreeEdits
    {

        public delegate IParseTree Fun(in IParseTree arg1, out bool arg2);


        public static void AddChildren(IParseTree parent, List<IParseTree> list)
        {
            foreach (var mc in list)
            {
                if (mc is TerminalNodeImpl)
                {
                    var _mc = mc as TerminalNodeImpl;
                    var _mapped_node = parent as ParserRuleContext;
                    _mc.Parent = _mapped_node;
                    _mapped_node.AddChild(_mc);
                }
                else
                {
                    var _mc = mc as ParserRuleContext;
                    var _mapped_node = parent as ParserRuleContext;
                    _mc.Parent = _mapped_node;
                    _mapped_node.AddChild(_mc);
                }
            }

        }

        public static void AddChildren(IParseTree parent, IParseTree child)
        {
            var mc = child;
            {
                if (mc is TerminalNodeImpl)
                {
                    var _mc = mc as TerminalNodeImpl;
                    var _mapped_node = parent as ParserRuleContext;
                    _mc.Parent = _mapped_node;
                    _mapped_node.AddChild(_mc);
                }
                else
                {
                    var _mc = mc as ParserRuleContext;
                    var _mapped_node = parent as ParserRuleContext;
                    _mc.Parent = _mapped_node;
                    _mapped_node.AddChild(_mc);
                }
            }
        }

        public static void Delete(IParseTree tree, Fun find)
        {
            if (tree == null) return;
            Stack<IParseTree> stack = new Stack<IParseTree>();
            stack.Push(tree);
            while (stack.Any())
            {
                var n = stack.Pop();
                var found = find(n, out bool @continue);
                if (found != null)
                {
                    IParseTree parent = n.Parent;
                    var c = parent as ParserRuleContext;
                    if (c != null)
                    {
                        for (int i = 0; i < c.ChildCount; ++i)
                        {
                            var child = c.children[i];
                            if (child == n)
                            {
                                var temp = c.children[i];
                                if (temp is TerminalNodeImpl)
                                {
                                    var t = temp as TerminalNodeImpl;
                                    t.Parent = null;
                                    c.children.RemoveAt(i);
                                }
                                else if (temp is ParserRuleContext)
                                {
                                    var t = temp as ParserRuleContext;
                                    t.Parent = null;
                                    c.children.RemoveAt(i);
                                }
                                else
                                    throw new Exception("Tree contains something other than TerminalNodeImpl or ParserRuleContext");
                                break;
                            }
                        }
                    }
                }
                if (!@continue) { }
                else if (n as TerminalNodeImpl != null) { }
                else
                {
                    for (int i = n.ChildCount - 1; i >= 0; --i)
                    {
                        var c = n.GetChild(i);
                        stack.Push(c);
                    }
                }
            }
        }

        public static void Delete(IParseTree tree)
        {
            if (tree == null) return;
            var n = tree;
            IParseTree parent = n.Parent;
            var c = parent as ParserRuleContext;
            if (c != null)
            {
                for (int i = 0; i < c.ChildCount; ++i)
                {
                    var child = c.children[i];
                    if (child == n)
                    {
                        var temp = c.children[i];
                        if (temp is TerminalNodeImpl)
                        {
                            var t = temp as TerminalNodeImpl;
                            t.Parent = null;
                            c.children.RemoveAt(i);
                        }
                        else if (temp is ParserRuleContext)
                        {
                            var t = temp as ParserRuleContext;
                            t.Parent = null;
                            c.children.RemoveAt(i);
                        }
                        else
                            throw new Exception("Tree contains something other than TerminalNodeImpl or ParserRuleContext");
                        break;
                    }
                }
            }
        }

        public static void Delete(IEnumerable<IParseTree> trees)
        {
            foreach (var t in trees) Delete(t);
        }

        public static void Delete(AltAntlr.MyTokenStream tokstream, IParseTree node)
        {
            AltAntlr.MyCharStream cs;
            AltAntlr.MyToken t2;
            // Gather all information before modifying the token and char streams.
            if (node is TerminalNodeImpl)
            {
                t2 = node.Payload as AltAntlr.MyToken;
                cs = t2.InputStream as AltAntlr.MyCharStream;
            }
            else
            {
                var lmf = TreeEdits.LeftMostToken(node);
                t2 = lmf.Payload as AltAntlr.MyToken;
                cs = t2.InputStream as AltAntlr.MyCharStream;
            }
            AltAntlr.MyCharStream ts = null;
            var leaves = TreeEdits.Frontier(node);
            var first = leaves.First() as AltAntlr.MyTerminalNodeImpl;
            var first_token = first.Payload as AltAntlr.MyToken;
            var last = leaves.Last() as AltAntlr.MyTerminalNodeImpl;
            var last_token = last.Payload as AltAntlr.MyToken;
            int sub = 0;
            int index = 0;
            var s = first_token.StartIndex; // Char stream index
            var e = last_token.StopIndex; // Char stream index
            sub = 1 + e - s;
            index = s;
            ts = first_token.InputStream as AltAntlr.MyCharStream;
            var old_buffer = ts.Text;
            var new_buffer = old_buffer.Remove(index, sub);
            var start = last.Payload.TokenIndex + 1;
            Dictionary<int, int> old_indices = new Dictionary<int, int>();
            var i = start;
            tokstream.Seek(i);
            for (; ; )
            {
                if (i >= tokstream.Size) break;
                var tt = tokstream.Get(i);
                var tok = tt as AltAntlr.MyToken;
                var line = tok.Line;
                var col = tok.Column;
                var i2 = AltAntlr.Util.GetIndex(line, col, old_buffer);
                old_indices[i] = i2;
                if (tt.Type == -1) break;
                ++i;
            }
            i = start;
            tokstream.Seek(i);
            ts.Text = new_buffer;
            tokstream.Text = new_buffer;
            for (; ; )
            {
                if (i >= tokstream.Size) break;
                var tt = tokstream.Get(i);
                var tok = tt as AltAntlr.MyToken;
                var new_index = old_indices[i] - sub;
                if (new_index >= 0)
                {
                    var (line, col) = AltAntlr.Util.GetLineColumn(new_index, new_buffer);
                    tok.Line = line;
                    tok.Column = col;
                }
                tok.StartIndex -= sub;
                tok.StopIndex -= sub;
                if (tt.Type == -1) break;
                ++i;
            }
            cs.Text = new_buffer;
            TreeEdits.Delete(node);
            // Nuke tokens in token stream.
            tokstream.Seek(first_token.TokenIndex);
            for (i = first_token.TokenIndex; i <= last_token.TokenIndex; ++i)
                tokstream.Delete();

            for (i = 0; i < tokstream.Size; ++i)
            {
                var t = tokstream.Get(i) as AltAntlr.MyToken;
                t.TokenIndex = i;
            }

            // Adjust intervals up the tree.
            Reset(node);
        }

        public static IEnumerable<IParseTree> FindTopDown(IParseTree tree, Fun find)
        {
            Stack<IParseTree> stack = new Stack<IParseTree>();
            stack.Push(tree);
            while (stack.Any())
            {
                var n = stack.Pop();
                var found = find(n, out bool @continue);
                if (found != null)
                    yield return found;
                if (!@continue) { }
                else if (n as TerminalNodeImpl != null) { }
                else
                {
                    for (int i = n.ChildCount - 1; i >= 0; --i)
                    {
                        var c = n.GetChild(i);
                        stack.Push(c);
                    }
                }
            }
        }

        public static IEnumerable<TerminalNodeImpl> Frontier(IParseTree tree)
        {
            Stack<IParseTree> stack = new Stack<IParseTree>();
            stack.Push(tree);
            while (stack.Any())
            {
                var n = stack.Pop();
                if (n is TerminalNodeImpl term)
                {
                    yield return term;
                }
                else
                {
                    for (int i = n.ChildCount - 1; i >= 0; --i)
                    {
                        var c = n.GetChild(i);
                        stack.Push(c);
                    }
                }
            }
        }

        // Insert the string as a token, with the expectation that the entire tree
        // will be printed and re-parsed in the target language.
        public static TerminalNodeImpl InsertBefore(IParseTree node, string arbitrary_string)
        {
            var token = new CommonToken(0) { Line = -1, Column = -1, Text = arbitrary_string };
            var leaf = new TerminalNodeImpl(token);

            IParseTree parent = node.Parent;
            var c = parent as ParserRuleContext;
            for (int i = 0; i < c.ChildCount; ++i)
            {
                var child = c.children[i];
                if (child == node)
                {
                    c.children.Insert(i, leaf);
                    var r = leaf as TerminalNodeImpl;
                    r.Parent = c;
                    break;
                }
            }
            return leaf;
        }

        public static void InsertBeforeInStreams(AltAntlr.MyTokenStream tokstream, IParseTree node, string arbitrary_string)
        {
            TerminalNodeImpl leaf = TreeEdits.Frontier(node).First();
            // 'node' is either a terminal node or an internal node.
            // Payload means different things for the two.
            AltAntlr.MyCharStream cs;
            AltAntlr.MyToken t;
            // Gather all information before modifying the token and char streams.
            if (node is TerminalNodeImpl)
            {
                t = node.Payload as AltAntlr.MyToken;
                cs = t.InputStream as AltAntlr.MyCharStream;
            }
            else
            {
                var lmf = TreeEdits.LeftMostToken(node);
                t = lmf.Payload as AltAntlr.MyToken;
                cs = t.InputStream as AltAntlr.MyCharStream;
            }
            var old_buffer = cs.Text;
            var index = AltAntlr.Util.GetIndex(t.Line, t.Column, old_buffer);
            var add = arbitrary_string.Length;
            var new_buffer = old_buffer.Insert(index, arbitrary_string);
            var start = leaf.Payload.TokenIndex;
            Dictionary<int, int> old_indices = new Dictionary<int, int>();
            var i = start;
            tokstream.Seek(i);
            for (; ; )
            {
                if (i >= tokstream.Size) break;
                var tt = tokstream.Get(i);
                if (tt.Type == -1) break;
                var tok = tt as AltAntlr.MyToken;
                var line = tok.Line;
                var col = tok.Column;
                var i2 = AltAntlr.Util.GetIndex(line, col, old_buffer);
                old_indices[i] = i2;
                ++i;
            }
            i = start;
            tokstream.Seek(i);
            cs.Text = new_buffer;
            tokstream.Text = new_buffer;
            for (; ; )
            {
                if (i >= tokstream.Size) break;
                var tt = tokstream.Get(i);
                if (tt.Type == -1) break;
                var tok = tt as AltAntlr.MyToken;
                var new_index = old_indices[i] + add;
                var (line, col) = AltAntlr.Util.GetLineColumn(new_index, new_buffer);
                tok.Line = line;
                tok.Column = col;
                tok.StartIndex += add;
                tok.StopIndex += add;
                ++i;
            }
        }

        public static void InsertAfterInStreams(AltAntlr.MyTokenStream tokstream, IParseTree node, string arbitrary_string)
        {
            TerminalNodeImpl leaf = TreeEdits.Frontier(node).First();
            // 'node' is either a terminal node or an internal node.
            // Payload means different things for the two.
            AltAntlr.MyCharStream cs;
            AltAntlr.MyToken t;
            // Gather all information before modifying the token and char streams.
            if (node is TerminalNodeImpl)
            {
                t = node.Payload as AltAntlr.MyToken;
                cs = t.InputStream as AltAntlr.MyCharStream;
            }
            else
            {
                var lmf = TreeEdits.LeftMostToken(node);
                t = lmf.Payload as AltAntlr.MyToken;
                cs = t.InputStream as AltAntlr.MyCharStream;
            }
            var old_buffer = cs.Text;
            var index = AltAntlr.Util.GetIndex(t.Line, t.Column, old_buffer);
            index += t.Text.Length;
            var add = arbitrary_string.Length;
            var new_buffer = old_buffer.Insert(index, arbitrary_string);
            var start = leaf.Payload.TokenIndex;
            start += +1;
            Dictionary<int, int> old_indices = new Dictionary<int, int>();
            var i = start;
            tokstream.Seek(i);
            for (; ; )
            {
                if (i >= tokstream.Size) break;
                var tt = tokstream.Get(i);
                if (tt.Type == -1) break;
                var tok = tt as AltAntlr.MyToken;
                var line = tok.Line;
                var col = tok.Column;
                var i2 = AltAntlr.Util.GetIndex(line, col, old_buffer);
                old_indices[i] = i2;
                ++i;
            }
            i = start;
            tokstream.Seek(i);
            cs.Text = new_buffer;
            tokstream.Text = new_buffer;
            for (; ; )
            {
                if (i >= tokstream.Size) break;
                var tt = tokstream.Get(i);
                if (tt.Type == -1) break;
                var tok = tt as AltAntlr.MyToken;
                var new_index = old_indices[i] + add;
                var (line, col) = AltAntlr.Util.GetLineColumn(new_index, new_buffer);
                tok.Line = line;
                tok.Column = col;
                tok.StartIndex += add;
                tok.StopIndex += add;
                ++i;
            }
        }

        // Insert the string as a token, with the expectation that the entire tree
        // will be printed and re-parsed in the target language.
        public static TerminalNodeImpl InsertAfter(IParseTree node, string arbitrary_string)
        {
            var token = new CommonToken(0) { Line = -1, Column = -1, Text = arbitrary_string };
            var leaf = new TerminalNodeImpl(token);

            IParseTree parent = node.Parent;
            var c = parent as ParserRuleContext;
            for (int i = 0; i < c.ChildCount; ++i)
            {
                var child = c.children[i];
                if (child == node)
                {
                    c.children.Insert(i + 1, leaf);
                    var r = leaf as TerminalNodeImpl;
                    r.Parent = c;
                    break;
                }
            }
            return leaf;
        }

        public static IParseTree InsertAfter(IParseTree node, IParseTree node_to_insert)
        {
            IParseTree parent = node.Parent;
            var c = parent as ParserRuleContext;
            for (int i = 0; i < c.ChildCount; ++i)
            {
                var child = c.children[i];
                if (child == node)
                {
                    c.children.Insert(i + 1, node_to_insert);
                    var r1 = node_to_insert as TerminalNodeImpl;
                    var r2 = node_to_insert as ParserRuleContext;
                    if (r1 != null) r1.Parent = c;
                    else if (r2 != null) r2.Parent = c;
                    break;
                }
            }
            return node_to_insert;
        }

        public static bool InsertAfter(IParseTree tree, Func<IParseTree, IParseTree> insert_point)
        {
            var insert_this = insert_point(tree);
            if (insert_this != null)
            {
                IParseTree parent = tree.Parent;
                var c = parent as ParserRuleContext;
                for (int i = 0; i < c.ChildCount; ++i)
                {
                    var child = c.children[i];
                    if (child == tree)
                    {
                        c.children.Insert(i + 1, insert_this);
                        var r = insert_this as ParserRuleContext;
                        r.Parent = c;
                        break;
                    }
                }
                return true; // done.
            }
            if (tree as TerminalNodeImpl != null)
            {
                TerminalNodeImpl tok = tree as TerminalNodeImpl;
                if (tok.Symbol.Type == TokenConstants.EOF)
                    return true;
                else
                    return false;
            }
            else
            {
                for (int i = 0; i < tree.ChildCount; ++i)
                {
                    var c = tree.GetChild(i);
                    if (InsertAfter(c, insert_point))
                        return true;
                }
            }
            return false;
        }

        public static IParseTree InsertBefore(IParseTree node, IParseTree node_to_insert)
        {
            IParseTree parent = node.Parent;
            var c = parent as ParserRuleContext;
            for (int i = 0; i < c.ChildCount; ++i)
            {
                var child = c.children[i];
                if (child == node)
                {
                    c.children.Insert(i, node_to_insert);
                    var r1 = node_to_insert as TerminalNodeImpl;
                    var r2 = node_to_insert as ParserRuleContext;
                    if (r1 != null) r1.Parent = c;
                    else if (r2 != null) r2.Parent = c;
                    break;
                }
            }
            return node_to_insert;
        }

        private static void Reset(IParseTree tree)
        {
            if (tree is AltAntlr.MyTerminalNodeImpl l)
            {
                var t = l.Payload as AltAntlr.MyToken;
                l.Start = t.TokenIndex;
                l.Stop = t.TokenIndex;
                l._sourceInterval = new Antlr4.Runtime.Misc.Interval(t.TokenIndex, t.TokenIndex);
            }
            else if (tree is AltAntlr.MyParserRuleContext p)
            {
                var res = p.SourceInterval;
                int min = int.MaxValue;
                int max = int.MinValue;
                for (int i = 0; i < tree.ChildCount; ++i)
                {
                    var c = tree.GetChild(i);
                    Reset(c);
                    min = Math.Min(min, c.SourceInterval.a);
                    max = Math.Max(max, c.SourceInterval.b);
                }
                p._sourceInterval = res;
            }
        }

        private static void Adjust(IParseTree tree)
        {
            Reset(tree);
            var leaves = TreeEdits.Frontier(tree);
            Stack<IParseTree> stack = new Stack<IParseTree>();
            foreach (var leaf in leaves) stack.Push(leaf);
            while (stack.Count > 0)
            {
                var leaf = stack.Pop();
                if (leaf is AltAntlr.MyTerminalNodeImpl l)
                {
                    var t = l.Payload as AltAntlr.MyToken;
                    l._sourceInterval = new Antlr4.Runtime.Misc.Interval(t.TokenIndex, t.TokenIndex);
                }
                else if (leaf is AltAntlr.MyParserRuleContext p)
                {
                    var s = p.Start;
                    var e = p.Stop;

                }
            }
        }

        public static TerminalNodeImpl LeftMostToken(IParseTree tree)
        {
            if (tree is TerminalNodeImpl)
                return tree as TerminalNodeImpl;
            for (int i = 0; i < tree.ChildCount; ++i)
            {
                var c = tree.GetChild(i);
                if (c == null)
                    return null;
                var lmt = LeftMostToken(c);
                if (lmt != null)
                    return lmt;
            }
            return null;
        }

        public static TerminalNodeImpl RightMostToken(IParseTree tree)
        {
            if (tree is TerminalNodeImpl)
                return tree as TerminalNodeImpl;
            for (int i = tree.ChildCount - 1; i >= 0; --i)
            {
                var c = tree.GetChild(i);
                if (c == null)
                    return null;
                var lmt = RightMostToken(c);
                if (lmt != null)
                    return lmt;
            }
            return null;
        }

        public static TerminalNodeImpl NextToken(TerminalNodeImpl leaf)
        {
            if (leaf == null)
                throw new ArgumentNullException(nameof(leaf));
            for (IParseTree v = leaf as IParseTree; v != null; v = v.Parent as IParseTree)
            {
                if (v == null) return null;
                var p = v.Parent as ParserRuleContext;
                int start = -1;
                for (int i = 0; i < p.children.Count; ++i)
                {
                    if (p.children[i] == v && i + 1 < p.children.Count)
                    {
                        start = i + 1;
                        break;
                    }
                }
                if (start < 0) continue;
                for (; start < p.children.Count; ++start)
                {
                    var found = LeftMostToken(p.children[start]);
                    if (found != null)
                        return found;
                }
            }
            return null;
        }

        public static string GetText(IList<IToken> list)
        {
            if (list == null)
                return "";
            StringBuilder sb = new StringBuilder();
            foreach (var l in list)
            {
                sb.Append(l.Text);
            }
            return sb.ToString();
        }

        public static (Dictionary<TerminalNodeImpl, string>, List<string>) TextToLeftOfLeaves(BufferedTokenStream stream, IParseTree tree)
        {
            var result = new Dictionary<TerminalNodeImpl, string>();
            var result2 = new List<string>();
            Stack<IParseTree> stack = new Stack<IParseTree>();
            stack.Push(tree);
            while (stack.Any())
            {
                var n = stack.Pop();
                if (n is TerminalNodeImpl)
                {
                    var nn = n as TerminalNodeImpl;
                    {
                        var p1 = TreeEdits.LeftMostToken(nn);
                        var pp1 = p1.SourceInterval;
                        var pp2 = p1.Payload;
                        var index = pp2.TokenIndex;
                        if (index >= 0)
                        {
                            var p2 = stream.GetHiddenTokensToLeft(index);
                            var p3 = TreeEdits.GetText(p2);
                            result.Add(nn, p3);
                        }
                        result2.Add(nn.GetText());
                    }
                }
                else
                {
                    if (!(n is ParserRuleContext p))
                        continue;
                    if (p.children == null)
                        continue;
                    if (p.children.Count == 0)
                        continue;
                    foreach (var c in p.children.Reverse())
                    {
                        stack.Push(c);
                    }
                }
            }
            return (result, result2);
        }

        public static (Dictionary<TerminalNodeImpl, string>, List<string>) TextToLeftOfLeaves(BufferedTokenStream stream, IEnumerable<IParseTree> trees)
        {
            var result = new Dictionary<TerminalNodeImpl, string>();
            var result2 = new List<string>();
            Stack<IParseTree> stack = new Stack<IParseTree>();
            foreach (var tree in trees)
            {
                stack.Push(tree);
                while (stack.Any())
                {
                    var n = stack.Pop();
                    if (n is TerminalNodeImpl)
                    {
                        var nn = n as TerminalNodeImpl;
                        {
                            var p1 = TreeEdits.LeftMostToken(nn);
                            var pp1 = p1.SourceInterval;
                            var pp2 = p1.Payload;
                            var index = pp2.TokenIndex;
                            if (index >= 0)
                            {
                                var p2 = stream.GetHiddenTokensToLeft(index);
                                var p3 = TreeEdits.GetText(p2);
                                result.Add(nn, p3);
                            }
                            result2.Add(nn.GetText());
                        }
                    }
                    else
                    {
                        if (!(n is ParserRuleContext p))
                            continue;
                        if (p.children == null)
                            continue;
                        if (p.children.Count == 0)
                            continue;
                        foreach (var c in p.children.Reverse())
                        {
                            stack.Push(c);
                        }
                    }
                }
            }
            return (result, result2);
        }

        public static IParseTree CopyTreeRecursive(IParseTree original, IParseTree parent, Dictionary<TerminalNodeImpl, string> text_to_left)
        {
            if (original == null) return null;
            else if (original is TerminalNodeImpl)
            {
                var o = original as TerminalNodeImpl;
                var new_node = new TerminalNodeImpl(o.Symbol);
                if (text_to_left != null)
                {
                    if (text_to_left.TryGetValue(o, out string value))
                        text_to_left.Add(new_node, value);
                }
                if (parent != null)
                {
                    var parent_rule_context = (ParserRuleContext)parent;
                    new_node.Parent = parent_rule_context;
                    parent_rule_context.AddChild(new_node);
                }
                return new_node;
            }
            else if (original is ParserRuleContext)
            {
                var type = original.GetType();
                var new_node = (ParserRuleContext)Activator.CreateInstance(type, null, 0);
                if (parent != null)
                {
                    var parent_rule_context = (ParserRuleContext)parent;
                    new_node.Parent = parent_rule_context;
                    parent_rule_context.AddChild(new_node);
                }
                int child_count = original.ChildCount;
                for (int i = 0; i < child_count; ++i)
                {
                    var child = original.GetChild(i);
                    CopyTreeRecursive(child, new_node, text_to_left);
                }
                return new_node;
            }
            else return null;
        }

        public static void Reconstruct(StringBuilder sb, IEnumerable<IParseTree> trees, Dictionary<TerminalNodeImpl, string> text_to_left)
        {
            foreach (var tree in trees)
            {
                if (tree as TerminalNodeImpl != null)
                {
                    TerminalNodeImpl tok = tree as TerminalNodeImpl;
                    text_to_left.TryGetValue(tok, out string inter);
                    if (inter == null)
                        sb.Append(" ");
                    else
                        sb.Append(inter);
                    if (tok.Symbol.Type == TokenConstants.EOF)
                        return;
                    sb.Append(tok.GetText());
                }
                else
                {
                    for (int i = 0; i < tree.ChildCount; ++i)
                    {
                        var c = tree.GetChild(i);
                        Reconstruct(sb, c, text_to_left);
                    }
                }
            }
        }

        public static void Reconstruct(StringBuilder sb, IParseTree tree, Dictionary<TerminalNodeImpl, string> text_to_left)
        {
            if (tree as TerminalNodeImpl != null)
            {
                TerminalNodeImpl tok = tree as TerminalNodeImpl;
                text_to_left.TryGetValue(tok, out string inter);
                if (inter == null)
                    sb.Append(" ");
                else
                    sb.Append(inter);
                if (tok.Symbol.Type == TokenConstants.EOF)
                    return;
                sb.Append(tok.GetText());
            }
            else
            {
                for (int i = 0; i < tree.ChildCount; ++i)
                {
                    var c = tree.GetChild(i);
                    Reconstruct(sb, c, text_to_left);
                }
            }
        }

        public static TerminalNodeImpl Find(IToken token, IParseTree tree)
        {
            if (tree == null) return null;
            Stack<IParseTree> stack = new Stack<IParseTree>();
            stack.Push(tree);
            while (stack.Any())
            {
                var n = stack.Pop();
                if (n is TerminalNodeImpl term)
                {
                    if (term.Symbol == token)
                        return term;
                }
                else
                {
                    for (int i = n.ChildCount - 1; i >= 0; --i)
                    {
                        var c = n.GetChild(i);
                        stack.Push(c);
                    }
                }
            }
            return null;
        }

        public static void MoveAfter(IEnumerable<IParseTree> from_list, IParseTree to)
        {
            if (from_list == null) return;
			if (to == null) return;
            foreach (var from in from_list.Reverse())
            {
                IParseTree parent_from = from.Parent;
                var ctx_parent_from = parent_from as ParserRuleContext;
                if (ctx_parent_from != null)
                {
                    for (int i = 0; i < ctx_parent_from.ChildCount; ++i)
                    {
                        var child = ctx_parent_from.children[i];
                        if (child == from)
                        {
                            var temp = ctx_parent_from.children[i];
                            if (temp is TerminalNodeImpl)
                            {
                                var t = temp as TerminalNodeImpl;
                                t.Parent = null;
                                ctx_parent_from.children.RemoveAt(i);
                            }
                            else if (temp is ParserRuleContext)
                            {
                                var t = temp as ParserRuleContext;
                                t.Parent = null;
                                ctx_parent_from.children.RemoveAt(i);
                            }
                            else
                                throw new Exception("Tree contains something other than TerminalNodeImpl or ParserRuleContext");
                            break;
                        }
                    }
                }
                IParseTree parent_to = to.Parent;
                var ctx_parent_to = parent_to as ParserRuleContext;
                for (int i = 0; i < ctx_parent_to.ChildCount; ++i)
                {
                    var child = ctx_parent_to.children[i];
                    if (child == to)
                    {
                        ctx_parent_to.children.Insert(i + 1, from);
                        var r1 = from as TerminalNodeImpl;
                        var r2 = from as ParserRuleContext;
                        if (r1 != null) r1.Parent = ctx_parent_to;
                        else if (r2 != null) r2.Parent = ctx_parent_to;
                        break;
                    }
                }
            }
        }

        public static void MoveBefore(IEnumerable<IParseTree> from_list, IParseTree to)
        {
            if (from_list == null) return;
            if (to == null) return;
            foreach (var from in from_list)
            {
                IParseTree parent_from = from.Parent;
                var ctx_parent_from = parent_from as ParserRuleContext;
                if (ctx_parent_from != null)
                {
                    for (int i = 0; i < ctx_parent_from.ChildCount; ++i)
                    {
                        var child = ctx_parent_from.children[i];
                        if (child == from)
                        {
                            var temp = ctx_parent_from.children[i];
                            if (temp is TerminalNodeImpl)
                            {
                                var t = temp as TerminalNodeImpl;
                                t.Parent = null;
                                ctx_parent_from.children.RemoveAt(i);
                            }
                            else if (temp is ParserRuleContext)
                            {
                                var t = temp as ParserRuleContext;
                                t.Parent = null;
                                ctx_parent_from.children.RemoveAt(i);
                            }
                            else
                                throw new Exception("Tree contains something other than TerminalNodeImpl or ParserRuleContext");
                            break;
                        }
                    }
                }
                IParseTree parent_to = to.Parent;
                var ctx_parent_to = parent_to as ParserRuleContext;
                for (int i = 0; i < ctx_parent_to.ChildCount; ++i)
                {
                    var child = ctx_parent_to.children[i];
                    if (child == to)
                    {
                        ctx_parent_to.children.Insert(i, from);
                        var r1 = from as TerminalNodeImpl;
                        var r2 = from as ParserRuleContext;
                        if (r1 != null) r1.Parent = ctx_parent_to;
                        else if (r2 != null) r2.Parent = ctx_parent_to;
                        break;
                    }
                }
            }
        }
        // Insert the string as a token, with the expectation that the entire tree
        // will be printed and re-parsed in the target language.
        public static TerminalNodeImpl Replace(IParseTree node, string arbitrary_string)
        {
            var token = new CommonToken(0) { Line = -1, Column = -1, Text = arbitrary_string };
            var leaf = new TerminalNodeImpl(token);

            IParseTree parent = node.Parent;
            var c = parent as ParserRuleContext;
            for (int i = 0; i < c.ChildCount; ++i)
            {
                var child = c.children[i];
                if (child == node)
                {
                    var temp = c.children[i];
                    if (temp is TerminalNodeImpl)
                    {
                        var t = temp as TerminalNodeImpl;
                        t.Parent = null;
                        c.children[i] = leaf;
                        var r = leaf;
                        r.Parent = c;
                    }
                    else if (temp is ParserRuleContext)
                    {
                        var t = temp as ParserRuleContext;
                        t.Parent = null;
                        c.children[i] = leaf;
                        var r = leaf;
                        r.Parent = c;
                    }
                    else
                        throw new Exception("Tree contains something other than TerminalNodeImpl or ParserRuleContext");
                    break;
                }
            }
            return leaf;
        }

        public static void Replace(AltAntlr.MyTokenStream tokstream, IParseTree node, string arbitrary_string)
        {
            InsertBeforeInStreams(tokstream, node, arbitrary_string);
            Delete(tokstream, node);
        }

        public static void Replace(AltAntlr.MyTokenStream tokstream, IEnumerable<IParseTree> nodes, string arbitrary_string)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var node in nodes)
            {
                Replace(tokstream, node, arbitrary_string);
            }
        }

        public static void Replace(IParseTree tree, Fun find)
        {
            if (tree == null) return;
            Stack<IParseTree> stack = new Stack<IParseTree>();
            stack.Push(tree);
            while (stack.Any())
            {
                var n = stack.Pop();
                var found = find(n, out bool @continue);
                if (found != null)
                {
                    IParseTree parent = n.Parent;
                    var c = parent as ParserRuleContext;
                    if (c != null)
                    {
                        for (int i = 0; i < c.ChildCount; ++i)
                        {
                            var child = c.children[i];
                            if (child == n)
                            {
                                var temp = c.children[i];
                                if (temp is TerminalNodeImpl)
                                {
                                    var t = temp as TerminalNodeImpl;
                                    t.Parent = null;
                                    c.children[i] = found;
                                    var rt = found as TerminalNodeImpl;
                                    if (rt != null) rt.Parent = c;
                                    var rp = found as ParserRuleContext;
                                    if (rp != null) rp.Parent = c;
                                }
                                else if (temp is ParserRuleContext)
                                {
                                    var t = temp as ParserRuleContext;
                                    t.Parent = null;
                                    c.children[i] = found;
                                    var rt = found as TerminalNodeImpl;
                                    if (rt != null) rt.Parent = c;
                                    var rp = found as ParserRuleContext;
                                    if (rp != null) rp.Parent = c;
                                }
                                else
                                    throw new Exception("Tree contains something other than TerminalNodeImpl or ParserRuleContext");
                                break;
                            }
                        }
                    }
                }
                if (!@continue) { }
                else if (n as TerminalNodeImpl != null) { }
                else
                {
                    for (int i = n.ChildCount - 1; i >= 0; --i)
                    {
                        var c = n.GetChild(i);
                        stack.Push(c);
                    }
                }
            }
        }

        public static void Replace(IParseTree replace_this, IParseTree with_this)
        {
            if (replace_this == null) return;
            if (with_this == null) return;
            var n = replace_this;
            IParseTree parent = n.Parent;
            var c = parent as ParserRuleContext;
            if (c != null)
            {
                for (int i = 0; i < c.ChildCount; ++i)
                {
                    var child = c.children[i];
                    if (child == n)
                    {
                        var temp = c.children[i];
                        if (temp is TerminalNodeImpl)
                        {
                            var t = temp as TerminalNodeImpl;
                            t.Parent = null;
                            c.children[i] = with_this;
                            var rt = with_this as TerminalNodeImpl;
                            if (rt != null) rt.Parent = c;
                            var rp = with_this as ParserRuleContext;
                            if (rp != null) rp.Parent = c;
                        }
                        else if (temp is ParserRuleContext)
                        {
                            var t = temp as ParserRuleContext;
                            t.Parent = null;
                            c.children[i] = with_this;
                            var rt = with_this as TerminalNodeImpl;
                            if (rt != null) rt.Parent = c;
                            var rp = with_this as ParserRuleContext;
                            if (rp != null) rp.Parent = c;
                        }
                        else
                            throw new Exception("Tree contains something other than TerminalNodeImpl or ParserRuleContext");
                        break;
                    }
                }
                // Shift all tokens over.
                // Shift text over.
            }
        }
    }
}

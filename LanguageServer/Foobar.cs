﻿namespace LanguageServer
{
    using Antlr4.Runtime;
    using Antlr4.Runtime.Misc;
    using Antlr4.Runtime.Tree;
    using System;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    class Foobar
    {

        //public IParseTree Find(int index, Document document)
        //{
        //    ITextBuffer tb = point.Snapshot.TextBuffer;
        //    string ffn = tb.GetFilePath();
        //    var pd = ParserDetails._per_file_parser_details[ffn];
        //    foreach (var node in DFSVisitor.DFS(pd._ant_tree as ParserRuleContext))
        //    {
        //        if (node as TerminalNodeImpl == null)
        //            continue;
        //        var leaf = node as TerminalNodeImpl;
        //        if (leaf.Symbol.StartIndex <= point.Position && point.Position <= leaf.Symbol.StopIndex)
        //            return leaf;
        //    }
        //    return null;
        //}
    }
}

﻿namespace LanguageServer
{
    using System.Collections.Generic;

    public class Import
    {

        public static Dictionary<string, string> ImportGrammars(List<string> args)
        {
            Dictionary<string, string> results = new Dictionary<string, string>();
            foreach (string f in args)
            {
                if (!System.IO.File.Exists(f)) continue;
                var input = System.IO.File.ReadAllText(f);
                if (f.EndsWith(".y"))
                {
                    var imp = new BisonImport();
                    results = imp.Try(f, input);
                }
                else if (f.EndsWith(".ebnf"))
                {
                    var imp = new W3CebnfImport();
                    results = imp.Try(f, input);
                }
                else if (f.EndsWith(".g2"))
                {
                    var imp = new Antlr2Import();
                    results = imp.Try(f, input);
                }
                else if (f.EndsWith(".g3"))
                {
                    var imp = new Antlr3Import();
                    results = imp.Try(f, input);
                }
            }
            return results;
        }
    }
}

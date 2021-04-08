﻿namespace AltAntlr
{
    using Antlr4.Runtime;

    public class MyToken : IToken
    {
        public string Text { get; set; }
        public int Type { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
        public int Channel { get; set; }
        public int TokenIndex { get; set; }
        public int StartIndex { get; set; }
        public int StopIndex { get; set; }
        public ITokenSource TokenSource { get; set; }
        public ICharStream InputStream { get; set; }

        public override string ToString()
        {
            string channelStr = string.Empty;
            if (Channel > 0)
            {
                channelStr = ",channel=" + Channel;
            }
            string txt = Text;
            if (txt != null)
            {
                txt = txt.Replace("\n", "\\n");
                txt = txt.Replace("\r", "\\r");
                txt = txt.Replace("\t", "\\t");
            }
            else
            {
                txt = "<no text>";
            }
            return "[@" + TokenIndex + "," + StartIndex + ":" + StopIndex + "='" + txt + "',<" + Type + ">" + channelStr + "," + Line + ":" + Column + "]";
        }
    }
}

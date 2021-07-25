// Template generated code from trgen 0.8.7

using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ErrorListener<S> : ConsoleErrorListener<S>
{
    public bool had_error;
    private int _quiet_after;

    public ErrorListener(int quiet_after = 100)
    {
        _quiet_after = quiet_after;
    }

    public override void SyntaxError(TextWriter output, IRecognizer recognizer, S offendingSymbol, int line,
        int col, string msg, RecognitionException e)
    {
        had_error = true;
        _quiet_after--;
        if (_quiet_after <= 0) return;
        base.SyntaxError(output, recognizer, offendingSymbol, line, col, msg, e);
    }
}

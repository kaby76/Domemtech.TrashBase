//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.10
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from LarkLexer.g4 by ANTLR 4.10

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace LanguageServer {
using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.10")]
[System.CLSCompliant(false)]
public partial class LarkLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		COLON=1, LC=2, RC=3, LP=4, RP=5, LB=6, RB=7, COMMA=8, DOT=9, ARROW=10, 
		IGNORE=11, IMPORT=12, OVERRIDE=13, DECLARE=14, DD=15, SQ=16, VBAR=17, 
		OP=18, RULE=19, TOKEN=20, STRING=21, REGEXP=22, NL=23, NUMBER=24, WS_INLINE=25, 
		COMMENT=26;
	public const int
		OFF_CHANNEL=2;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN", "OFF_CHANNEL"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"COLON", "LC", "RC", "LP", "RP", "LB", "RB", "COMMA", "DOT", "ARROW", 
		"IGNORE", "IMPORT", "OVERRIDE", "DECLARE", "DD", "SQ", "VBAR", "OP", "RULE", 
		"TOKEN", "STRING", "REGEXP", "NL", "ESC", "STRING_INNER", "STRING_ESC_INNER", 
		"FSTRING", "DIGIT", "HEXDIGIT", "INT", "NUMBER", "WS_INLINE", "COMMENT", 
		"Space"
	};


	public LarkLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public LarkLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "':'", "'{'", "'}'", "'('", "')'", "'['", "']'", "','", "'.'", "'->'", 
		"'%ignore'", "'%import'", "'%override'", "'%declare'", "'..'", "'~'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "COLON", "LC", "RC", "LP", "RP", "LB", "RB", "COMMA", "DOT", "ARROW", 
		"IGNORE", "IMPORT", "OVERRIDE", "DECLARE", "DD", "SQ", "VBAR", "OP", "RULE", 
		"TOKEN", "STRING", "REGEXP", "NL", "NUMBER", "WS_INLINE", "COMMENT"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "LarkLexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static LarkLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,26,263,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,2,33,7,33,1,0,1,0,1,1,1,1,
		1,2,1,2,1,3,1,3,1,4,1,4,1,5,1,5,1,6,1,6,1,7,1,7,1,8,1,8,1,9,1,9,1,9,1,
		10,1,10,1,10,1,10,1,10,1,10,1,10,1,10,1,11,1,11,1,11,1,11,1,11,1,11,1,
		11,1,11,1,12,1,12,1,12,1,12,1,12,1,12,1,12,1,12,1,12,1,12,1,13,1,13,1,
		13,1,13,1,13,1,13,1,13,1,13,1,13,1,14,1,14,1,14,1,15,1,15,1,16,3,16,132,
		8,16,1,16,1,16,1,17,3,17,137,8,17,1,18,3,18,140,8,18,1,18,3,18,143,8,18,
		1,18,1,18,5,18,147,8,18,10,18,12,18,150,9,18,1,19,3,19,153,8,19,1,19,1,
		19,5,19,157,8,19,10,19,12,19,160,9,19,1,20,1,20,3,20,164,8,20,1,21,1,21,
		1,21,1,21,1,21,1,21,5,21,172,8,21,10,21,12,21,175,9,21,1,21,1,21,5,21,
		179,8,21,10,21,12,21,182,9,21,1,22,3,22,185,8,22,1,22,4,22,188,8,22,11,
		22,12,22,189,1,22,5,22,193,8,22,10,22,12,22,196,9,22,1,23,1,23,1,23,3,
		23,201,8,23,1,24,1,24,1,25,1,25,5,25,207,8,25,10,25,12,25,210,9,25,1,26,
		1,26,1,26,1,26,1,27,1,27,1,28,1,28,3,28,220,8,28,1,29,4,29,223,8,29,11,
		29,12,29,224,1,30,3,30,228,8,30,1,30,1,30,1,31,4,31,233,8,31,11,31,12,
		31,234,1,31,1,31,1,32,5,32,240,8,32,10,32,12,32,243,9,32,1,32,1,32,1,32,
		1,32,5,32,249,8,32,10,32,12,32,252,9,32,1,32,1,32,1,33,1,33,1,33,1,33,
		1,33,1,33,3,33,262,8,33,1,173,0,34,1,1,3,2,5,3,7,4,9,5,11,6,13,7,15,8,
		17,9,19,10,21,11,23,12,25,13,27,14,29,15,31,16,33,17,35,18,37,19,39,20,
		41,21,43,22,45,23,47,0,49,0,51,0,53,0,55,0,57,0,59,0,61,24,63,25,65,26,
		67,0,1,0,15,2,0,42,43,63,63,2,0,63,63,95,95,1,0,97,122,3,0,48,57,95,95,
		97,122,1,0,65,90,3,0,48,57,65,90,95,95,1,0,47,47,5,0,105,105,108,109,115,
		115,117,117,120,120,9,0,34,34,39,39,62,62,92,92,98,98,102,102,110,110,
		114,114,116,116,2,0,34,34,92,92,2,0,65,70,97,102,2,0,43,43,45,45,2,0,9,
		9,32,32,1,0,10,10,3,0,9,10,12,13,32,32,278,0,1,1,0,0,0,0,3,1,0,0,0,0,5,
		1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,
		0,17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,0,0,27,
		1,0,0,0,0,29,1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,0,0,35,1,0,0,0,0,37,1,0,0,
		0,0,39,1,0,0,0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,1,0,0,0,0,61,1,0,0,0,0,63,
		1,0,0,0,0,65,1,0,0,0,1,69,1,0,0,0,3,71,1,0,0,0,5,73,1,0,0,0,7,75,1,0,0,
		0,9,77,1,0,0,0,11,79,1,0,0,0,13,81,1,0,0,0,15,83,1,0,0,0,17,85,1,0,0,0,
		19,87,1,0,0,0,21,90,1,0,0,0,23,98,1,0,0,0,25,106,1,0,0,0,27,116,1,0,0,
		0,29,125,1,0,0,0,31,128,1,0,0,0,33,131,1,0,0,0,35,136,1,0,0,0,37,139,1,
		0,0,0,39,152,1,0,0,0,41,161,1,0,0,0,43,165,1,0,0,0,45,187,1,0,0,0,47,197,
		1,0,0,0,49,202,1,0,0,0,51,208,1,0,0,0,53,211,1,0,0,0,55,215,1,0,0,0,57,
		219,1,0,0,0,59,222,1,0,0,0,61,227,1,0,0,0,63,232,1,0,0,0,65,241,1,0,0,
		0,67,261,1,0,0,0,69,70,5,58,0,0,70,2,1,0,0,0,71,72,5,123,0,0,72,4,1,0,
		0,0,73,74,5,125,0,0,74,6,1,0,0,0,75,76,5,40,0,0,76,8,1,0,0,0,77,78,5,41,
		0,0,78,10,1,0,0,0,79,80,5,91,0,0,80,12,1,0,0,0,81,82,5,93,0,0,82,14,1,
		0,0,0,83,84,5,44,0,0,84,16,1,0,0,0,85,86,5,46,0,0,86,18,1,0,0,0,87,88,
		5,45,0,0,88,89,5,62,0,0,89,20,1,0,0,0,90,91,5,37,0,0,91,92,5,105,0,0,92,
		93,5,103,0,0,93,94,5,110,0,0,94,95,5,111,0,0,95,96,5,114,0,0,96,97,5,101,
		0,0,97,22,1,0,0,0,98,99,5,37,0,0,99,100,5,105,0,0,100,101,5,109,0,0,101,
		102,5,112,0,0,102,103,5,111,0,0,103,104,5,114,0,0,104,105,5,116,0,0,105,
		24,1,0,0,0,106,107,5,37,0,0,107,108,5,111,0,0,108,109,5,118,0,0,109,110,
		5,101,0,0,110,111,5,114,0,0,111,112,5,114,0,0,112,113,5,105,0,0,113,114,
		5,100,0,0,114,115,5,101,0,0,115,26,1,0,0,0,116,117,5,37,0,0,117,118,5,
		100,0,0,118,119,5,101,0,0,119,120,5,99,0,0,120,121,5,108,0,0,121,122,5,
		97,0,0,122,123,5,114,0,0,123,124,5,101,0,0,124,28,1,0,0,0,125,126,5,46,
		0,0,126,127,5,46,0,0,127,30,1,0,0,0,128,129,5,126,0,0,129,32,1,0,0,0,130,
		132,3,45,22,0,131,130,1,0,0,0,131,132,1,0,0,0,132,133,1,0,0,0,133,134,
		5,124,0,0,134,34,1,0,0,0,135,137,7,0,0,0,136,135,1,0,0,0,137,36,1,0,0,
		0,138,140,5,33,0,0,139,138,1,0,0,0,139,140,1,0,0,0,140,142,1,0,0,0,141,
		143,7,1,0,0,142,141,1,0,0,0,142,143,1,0,0,0,143,144,1,0,0,0,144,148,7,
		2,0,0,145,147,7,3,0,0,146,145,1,0,0,0,147,150,1,0,0,0,148,146,1,0,0,0,
		148,149,1,0,0,0,149,38,1,0,0,0,150,148,1,0,0,0,151,153,5,95,0,0,152,151,
		1,0,0,0,152,153,1,0,0,0,153,154,1,0,0,0,154,158,7,4,0,0,155,157,7,5,0,
		0,156,155,1,0,0,0,157,160,1,0,0,0,158,156,1,0,0,0,158,159,1,0,0,0,159,
		40,1,0,0,0,160,158,1,0,0,0,161,163,3,53,26,0,162,164,5,105,0,0,163,162,
		1,0,0,0,163,164,1,0,0,0,164,42,1,0,0,0,165,173,5,47,0,0,166,167,5,92,0,
		0,167,172,5,47,0,0,168,169,5,92,0,0,169,172,5,92,0,0,170,172,8,6,0,0,171,
		166,1,0,0,0,171,168,1,0,0,0,171,170,1,0,0,0,172,175,1,0,0,0,173,174,1,
		0,0,0,173,171,1,0,0,0,174,176,1,0,0,0,175,173,1,0,0,0,176,180,5,47,0,0,
		177,179,7,7,0,0,178,177,1,0,0,0,179,182,1,0,0,0,180,178,1,0,0,0,180,181,
		1,0,0,0,181,44,1,0,0,0,182,180,1,0,0,0,183,185,5,13,0,0,184,183,1,0,0,
		0,184,185,1,0,0,0,185,186,1,0,0,0,186,188,5,10,0,0,187,184,1,0,0,0,188,
		189,1,0,0,0,189,187,1,0,0,0,189,190,1,0,0,0,190,194,1,0,0,0,191,193,3,
		67,33,0,192,191,1,0,0,0,193,196,1,0,0,0,194,192,1,0,0,0,194,195,1,0,0,
		0,195,46,1,0,0,0,196,194,1,0,0,0,197,200,5,92,0,0,198,201,7,8,0,0,199,
		201,9,0,0,0,200,198,1,0,0,0,200,199,1,0,0,0,201,48,1,0,0,0,202,203,8,9,
		0,0,203,50,1,0,0,0,204,207,3,47,23,0,205,207,3,49,24,0,206,204,1,0,0,0,
		206,205,1,0,0,0,207,210,1,0,0,0,208,206,1,0,0,0,208,209,1,0,0,0,209,52,
		1,0,0,0,210,208,1,0,0,0,211,212,5,34,0,0,212,213,3,51,25,0,213,214,5,34,
		0,0,214,54,1,0,0,0,215,216,2,48,57,0,216,56,1,0,0,0,217,220,7,10,0,0,218,
		220,3,55,27,0,219,217,1,0,0,0,219,218,1,0,0,0,220,58,1,0,0,0,221,223,3,
		55,27,0,222,221,1,0,0,0,223,224,1,0,0,0,224,222,1,0,0,0,224,225,1,0,0,
		0,225,60,1,0,0,0,226,228,7,11,0,0,227,226,1,0,0,0,227,228,1,0,0,0,228,
		229,1,0,0,0,229,230,3,59,29,0,230,62,1,0,0,0,231,233,7,12,0,0,232,231,
		1,0,0,0,233,234,1,0,0,0,234,232,1,0,0,0,234,235,1,0,0,0,235,236,1,0,0,
		0,236,237,6,31,0,0,237,64,1,0,0,0,238,240,3,67,33,0,239,238,1,0,0,0,240,
		243,1,0,0,0,241,239,1,0,0,0,241,242,1,0,0,0,242,244,1,0,0,0,243,241,1,
		0,0,0,244,245,5,47,0,0,245,246,5,47,0,0,246,250,1,0,0,0,247,249,8,13,0,
		0,248,247,1,0,0,0,249,252,1,0,0,0,250,248,1,0,0,0,250,251,1,0,0,0,251,
		253,1,0,0,0,252,250,1,0,0,0,253,254,6,32,0,0,254,66,1,0,0,0,255,262,7,
		14,0,0,256,257,5,117,0,0,257,258,5,50,0,0,258,259,5,66,0,0,259,260,5,55,
		0,0,260,262,5,70,0,0,261,255,1,0,0,0,261,256,1,0,0,0,262,68,1,0,0,0,25,
		0,131,136,139,142,148,152,158,163,171,173,180,184,189,194,200,206,208,
		219,224,227,234,241,250,261,1,0,2,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace LanguageServer

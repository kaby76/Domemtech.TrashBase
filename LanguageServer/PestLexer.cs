//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.10
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from PestLexer.g4 by ANTLR 4.10

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
public partial class PestLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		UNDERSCORE=1, AT=2, DOLLAR=3, NOT=4, AMP=5, TILDE=6, VBAR=7, QUESTION=8, 
		STAR=9, PLUS=10, ASSIGNMENT_OPERATOR=11, OPENING_BRACE=12, CLOSING_BRACE=13, 
		OPENING_PAREN=14, CLOSING_PAREN=15, OPENING_BRACK=16, CLOSING_BRACK=17, 
		PUSH=18, PEEK=19, NUMBER=20, INTEGER=21, COMMA=22, IDENTIFIER=23, STRING=24, 
		INSENSITIVE_STRING=25, RANGE=26, CHARACTER=27, ESCAPE=28, CODE=29, UNICODE=30, 
		HEX_DIGIT=31, QUOTE=32, SINGLE_QUOTE=33, RANGE_OPERATOR=34, WHITESPACE=35, 
		BLOCK_COMMENT=36, COMMENT=37;
	public const int
		OFF_CHANNEL=2;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN", "OFF_CHANNEL"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"UNDERSCORE", "AT", "DOLLAR", "NOT", "AMP", "TILDE", "VBAR", "QUESTION", 
		"STAR", "PLUS", "ASSIGNMENT_OPERATOR", "OPENING_BRACE", "CLOSING_BRACE", 
		"OPENING_PAREN", "CLOSING_PAREN", "OPENING_BRACK", "CLOSING_BRACK", "PUSH", 
		"PEEK", "NUMBER", "INTEGER", "COMMA", "IDENTIFIER", "ALPHA", "ALPHA_NUM", 
		"STRING", "INSENSITIVE_STRING", "RANGE", "CHARACTER", "INNER_STR", "INNER_CHR", 
		"ESCAPE", "CODE", "UNICODE", "HEX_DIGIT", "QUOTE", "SINGLE_QUOTE", "RANGE_OPERATOR", 
		"WHITESPACE", "BLOCK_COMMENT", "COMMENT", "BLOCK_COMMENT_F", "NEWLINE", 
		"ANY"
	};


	public PestLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public PestLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'_'", "'@'", "'$'", "'!'", "'&'", "'~'", "'|'", "'?'", "'*'", "'+'", 
		"'='", "'{'", "'}'", "'('", "')'", "'['", "']'", "'PUSH'", "'PEEK'", null, 
		null, "','", null, null, null, null, null, null, null, null, null, "'\"'", 
		"'''", "'..'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "UNDERSCORE", "AT", "DOLLAR", "NOT", "AMP", "TILDE", "VBAR", "QUESTION", 
		"STAR", "PLUS", "ASSIGNMENT_OPERATOR", "OPENING_BRACE", "CLOSING_BRACE", 
		"OPENING_PAREN", "CLOSING_PAREN", "OPENING_BRACK", "CLOSING_BRACK", "PUSH", 
		"PEEK", "NUMBER", "INTEGER", "COMMA", "IDENTIFIER", "STRING", "INSENSITIVE_STRING", 
		"RANGE", "CHARACTER", "ESCAPE", "CODE", "UNICODE", "HEX_DIGIT", "QUOTE", 
		"SINGLE_QUOTE", "RANGE_OPERATOR", "WHITESPACE", "BLOCK_COMMENT", "COMMENT"
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

	public override string GrammarFileName { get { return "PestLexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static PestLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,37,281,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,2,33,7,33,2,34,7,34,2,35,
		7,35,2,36,7,36,2,37,7,37,2,38,7,38,2,39,7,39,2,40,7,40,2,41,7,41,2,42,
		7,42,2,43,7,43,1,0,1,0,1,1,1,1,1,2,1,2,1,3,1,3,1,4,1,4,1,5,1,5,1,6,1,6,
		1,7,1,7,1,8,1,8,1,9,1,9,1,10,1,10,1,11,1,11,1,12,1,12,1,13,1,13,1,14,1,
		14,1,15,1,15,1,16,1,16,1,17,1,17,1,17,1,17,1,17,1,18,1,18,1,18,1,18,1,
		18,1,19,4,19,135,8,19,11,19,12,19,136,1,20,1,20,1,20,5,20,142,8,20,10,
		20,12,20,145,9,20,1,20,1,20,3,20,149,8,20,3,20,151,8,20,1,21,1,21,1,22,
		1,22,3,22,157,8,22,1,22,1,22,5,22,161,8,22,10,22,12,22,164,9,22,1,23,1,
		23,1,24,1,24,3,24,170,8,24,1,25,1,25,1,25,5,25,175,8,25,10,25,12,25,178,
		9,25,1,25,1,25,1,26,1,26,1,26,1,27,1,27,1,27,1,27,1,28,1,28,1,28,1,28,
		1,29,1,29,3,29,195,8,29,1,30,1,30,3,30,199,8,30,1,31,1,31,1,31,1,31,3,
		31,205,8,31,1,32,1,32,1,32,1,32,1,33,1,33,1,33,1,33,1,33,1,33,1,33,1,33,
		1,33,1,33,1,33,1,33,3,33,223,8,33,1,33,1,33,1,34,1,34,1,35,1,35,1,36,1,
		36,1,37,1,37,1,37,1,38,1,38,4,38,238,8,38,11,38,12,38,239,1,38,1,38,1,
		39,1,39,1,39,1,39,1,40,1,40,1,40,1,40,1,40,5,40,253,8,40,10,40,12,40,256,
		9,40,3,40,258,8,40,1,40,1,40,1,41,1,41,1,41,1,41,1,41,5,41,267,8,41,10,
		41,12,41,270,9,41,1,41,1,41,1,41,1,42,4,42,276,8,42,11,42,12,42,277,1,
		43,1,43,1,268,0,44,1,1,3,2,5,3,7,4,9,5,11,6,13,7,15,8,17,9,19,10,21,11,
		23,12,25,13,27,14,29,15,31,16,33,17,35,18,37,19,39,20,41,21,43,22,45,23,
		47,0,49,0,51,24,53,25,55,26,57,27,59,0,61,0,63,28,65,29,67,30,69,31,71,
		32,73,33,75,34,77,35,79,36,81,37,83,0,85,0,87,0,1,0,6,2,0,65,90,97,122,
		4,0,10,10,13,13,34,34,92,92,7,0,34,34,39,39,48,48,92,92,110,110,114,114,
		116,116,3,0,48,57,65,70,97,102,2,0,9,9,32,32,2,0,10,10,13,13,295,0,1,1,
		0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,
		1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,
		0,0,25,1,0,0,0,0,27,1,0,0,0,0,29,1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,0,0,35,
		1,0,0,0,0,37,1,0,0,0,0,39,1,0,0,0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,1,0,0,
		0,0,51,1,0,0,0,0,53,1,0,0,0,0,55,1,0,0,0,0,57,1,0,0,0,0,63,1,0,0,0,0,65,
		1,0,0,0,0,67,1,0,0,0,0,69,1,0,0,0,0,71,1,0,0,0,0,73,1,0,0,0,0,75,1,0,0,
		0,0,77,1,0,0,0,0,79,1,0,0,0,0,81,1,0,0,0,1,89,1,0,0,0,3,91,1,0,0,0,5,93,
		1,0,0,0,7,95,1,0,0,0,9,97,1,0,0,0,11,99,1,0,0,0,13,101,1,0,0,0,15,103,
		1,0,0,0,17,105,1,0,0,0,19,107,1,0,0,0,21,109,1,0,0,0,23,111,1,0,0,0,25,
		113,1,0,0,0,27,115,1,0,0,0,29,117,1,0,0,0,31,119,1,0,0,0,33,121,1,0,0,
		0,35,123,1,0,0,0,37,128,1,0,0,0,39,134,1,0,0,0,41,150,1,0,0,0,43,152,1,
		0,0,0,45,156,1,0,0,0,47,165,1,0,0,0,49,169,1,0,0,0,51,171,1,0,0,0,53,181,
		1,0,0,0,55,184,1,0,0,0,57,188,1,0,0,0,59,194,1,0,0,0,61,198,1,0,0,0,63,
		200,1,0,0,0,65,206,1,0,0,0,67,210,1,0,0,0,69,226,1,0,0,0,71,228,1,0,0,
		0,73,230,1,0,0,0,75,232,1,0,0,0,77,237,1,0,0,0,79,243,1,0,0,0,81,257,1,
		0,0,0,83,261,1,0,0,0,85,275,1,0,0,0,87,279,1,0,0,0,89,90,5,95,0,0,90,2,
		1,0,0,0,91,92,5,64,0,0,92,4,1,0,0,0,93,94,5,36,0,0,94,6,1,0,0,0,95,96,
		5,33,0,0,96,8,1,0,0,0,97,98,5,38,0,0,98,10,1,0,0,0,99,100,5,126,0,0,100,
		12,1,0,0,0,101,102,5,124,0,0,102,14,1,0,0,0,103,104,5,63,0,0,104,16,1,
		0,0,0,105,106,5,42,0,0,106,18,1,0,0,0,107,108,5,43,0,0,108,20,1,0,0,0,
		109,110,5,61,0,0,110,22,1,0,0,0,111,112,5,123,0,0,112,24,1,0,0,0,113,114,
		5,125,0,0,114,26,1,0,0,0,115,116,5,40,0,0,116,28,1,0,0,0,117,118,5,41,
		0,0,118,30,1,0,0,0,119,120,5,91,0,0,120,32,1,0,0,0,121,122,5,93,0,0,122,
		34,1,0,0,0,123,124,5,80,0,0,124,125,5,85,0,0,125,126,5,83,0,0,126,127,
		5,72,0,0,127,36,1,0,0,0,128,129,5,80,0,0,129,130,5,69,0,0,130,131,5,69,
		0,0,131,132,5,75,0,0,132,38,1,0,0,0,133,135,2,48,57,0,134,133,1,0,0,0,
		135,136,1,0,0,0,136,134,1,0,0,0,136,137,1,0,0,0,137,40,1,0,0,0,138,151,
		3,39,19,0,139,143,5,45,0,0,140,142,5,48,0,0,141,140,1,0,0,0,142,145,1,
		0,0,0,143,141,1,0,0,0,143,144,1,0,0,0,144,146,1,0,0,0,145,143,1,0,0,0,
		146,148,2,49,57,0,147,149,3,39,19,0,148,147,1,0,0,0,148,149,1,0,0,0,149,
		151,1,0,0,0,150,138,1,0,0,0,150,139,1,0,0,0,151,42,1,0,0,0,152,153,5,44,
		0,0,153,44,1,0,0,0,154,157,5,95,0,0,155,157,3,47,23,0,156,154,1,0,0,0,
		156,155,1,0,0,0,157,162,1,0,0,0,158,161,5,95,0,0,159,161,3,49,24,0,160,
		158,1,0,0,0,160,159,1,0,0,0,161,164,1,0,0,0,162,160,1,0,0,0,162,163,1,
		0,0,0,163,46,1,0,0,0,164,162,1,0,0,0,165,166,7,0,0,0,166,48,1,0,0,0,167,
		170,3,47,23,0,168,170,2,48,57,0,169,167,1,0,0,0,169,168,1,0,0,0,170,50,
		1,0,0,0,171,176,3,71,35,0,172,175,3,63,31,0,173,175,8,1,0,0,174,172,1,
		0,0,0,174,173,1,0,0,0,175,178,1,0,0,0,176,174,1,0,0,0,176,177,1,0,0,0,
		177,179,1,0,0,0,178,176,1,0,0,0,179,180,3,71,35,0,180,52,1,0,0,0,181,182,
		5,94,0,0,182,183,3,51,25,0,183,54,1,0,0,0,184,185,3,57,28,0,185,186,3,
		75,37,0,186,187,3,57,28,0,187,56,1,0,0,0,188,189,3,73,36,0,189,190,3,61,
		30,0,190,191,3,73,36,0,191,58,1,0,0,0,192,195,3,87,43,0,193,195,3,63,31,
		0,194,192,1,0,0,0,194,193,1,0,0,0,195,60,1,0,0,0,196,199,3,63,31,0,197,
		199,3,87,43,0,198,196,1,0,0,0,198,197,1,0,0,0,199,62,1,0,0,0,200,204,5,
		92,0,0,201,205,7,2,0,0,202,205,3,65,32,0,203,205,3,67,33,0,204,201,1,0,
		0,0,204,202,1,0,0,0,204,203,1,0,0,0,205,64,1,0,0,0,206,207,5,88,0,0,207,
		208,3,69,34,0,208,209,3,69,34,0,209,66,1,0,0,0,210,211,5,85,0,0,211,222,
		3,23,11,0,212,213,3,69,34,0,213,214,3,69,34,0,214,223,1,0,0,0,215,216,
		3,69,34,0,216,217,3,69,34,0,217,218,3,69,34,0,218,219,3,69,34,0,219,220,
		3,69,34,0,220,221,3,69,34,0,221,223,1,0,0,0,222,212,1,0,0,0,222,215,1,
		0,0,0,223,224,1,0,0,0,224,225,3,25,12,0,225,68,1,0,0,0,226,227,7,3,0,0,
		227,70,1,0,0,0,228,229,5,34,0,0,229,72,1,0,0,0,230,231,5,39,0,0,231,74,
		1,0,0,0,232,233,5,46,0,0,233,234,5,46,0,0,234,76,1,0,0,0,235,238,7,4,0,
		0,236,238,3,85,42,0,237,235,1,0,0,0,237,236,1,0,0,0,238,239,1,0,0,0,239,
		237,1,0,0,0,239,240,1,0,0,0,240,241,1,0,0,0,241,242,6,38,0,0,242,78,1,
		0,0,0,243,244,3,83,41,0,244,245,1,0,0,0,245,246,6,39,0,0,246,80,1,0,0,
		0,247,258,3,83,41,0,248,249,5,47,0,0,249,250,5,47,0,0,250,254,1,0,0,0,
		251,253,8,5,0,0,252,251,1,0,0,0,253,256,1,0,0,0,254,252,1,0,0,0,254,255,
		1,0,0,0,255,258,1,0,0,0,256,254,1,0,0,0,257,247,1,0,0,0,257,248,1,0,0,
		0,258,259,1,0,0,0,259,260,6,40,0,0,260,82,1,0,0,0,261,262,5,47,0,0,262,
		263,5,42,0,0,263,268,1,0,0,0,264,267,3,81,40,0,265,267,3,87,43,0,266,264,
		1,0,0,0,266,265,1,0,0,0,267,270,1,0,0,0,268,269,1,0,0,0,268,266,1,0,0,
		0,269,271,1,0,0,0,270,268,1,0,0,0,271,272,5,42,0,0,272,273,5,47,0,0,273,
		84,1,0,0,0,274,276,7,5,0,0,275,274,1,0,0,0,276,277,1,0,0,0,277,275,1,0,
		0,0,277,278,1,0,0,0,278,86,1,0,0,0,279,280,9,0,0,0,280,88,1,0,0,0,22,0,
		136,143,148,150,156,160,162,169,174,176,194,198,204,222,237,239,254,257,
		266,268,277,1,0,2,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace LanguageServer

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.10
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from ANTLRv3Lexer.g4 by ANTLR 4.10

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
public partial class ANTLRv3Lexer : Antlr3LexerAdaptor {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		DOC_COMMENT=1, PARSER=2, LEXER=3, RULE=4, BLOCK=5, OPTIONAL=6, CLOSURE=7, 
		POSITIVE_CLOSURE=8, SYNPRED=9, RANGE=10, CHAR_RANGE=11, EPSILON=12, ALT=13, 
		EOR=14, EOB=15, EOA=16, ID=17, ARG=18, ARGLIST=19, RET=20, LEXER_GRAMMAR=21, 
		PARSER_GRAMMAR=22, TREE_GRAMMAR=23, COMBINED_GRAMMAR=24, INITACTION=25, 
		LABEL=26, TEMPLATE=27, SCOPE=28, SEMPRED=29, GATED_SEMPRED=30, SYN_SEMPRED=31, 
		BACKTRACK_SEMPRED=32, FRAGMENT=33, TREE_BEGIN=34, ROOT=35, BANG=36, REWRITE=37, 
		ACTION_CONTENT=38, SL_COMMENT=39, ML_COMMENT=40, INT=41, CHAR_LITERAL=42, 
		STRING_LITERAL=43, DOUBLE_QUOTE_STRING_LITERAL=44, DOUBLE_ANGLE_STRING_LITERAL=45, 
		BEGIN_ARGUMENT=46, BEGIN_ACTION=47, OPTIONS=48, TOKENS=49, CATCH=50, FINALLY=51, 
		GRAMMAR=52, PRIVATE=53, PROTECTED=54, PUBLIC=55, RETURNS=56, THROWS=57, 
		TREE=58, AT=59, CLOSE_ELEMENT_OPTION=60, COLON=61, COLONCOLON=62, COMMA=63, 
		DOT=64, EQUAL=65, LBRACE=66, LBRACK=67, LPAREN=68, OPEN_ELEMENT_OPTION=69, 
		OR=70, PLUS=71, QM=72, RBRACE=73, RBRACK=74, RPAREN=75, SEMI=76, SEMPREDOP=77, 
		STAR=78, DOLLAR=79, PEQ=80, NOT=81, WS=82, TOKEN_REF=83, RULE_REF=84, 
		END_ARGUMENT=85, UNTERMINATED_ARGUMENT=86, ARGUMENT_CONTENT=87, END_ACTION=88, 
		UNTERMINATED_ACTION=89, OPT_LBRACE=90, LEXER_CHAR_SET=91, UNTERMINATED_CHAR_SET=92;
	public const int
		OFF_CHANNEL=2;
	public const int
		Argument=1, Actionx=2, Options=3, Tokens=4, LexerCharSet=5;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN", "OFF_CHANNEL"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE", "Argument", "Actionx", "Options", "Tokens", "LexerCharSet"
	};

	public static readonly string[] ruleNames = {
		"DOC_COMMENT", "SL_COMMENT", "ML_COMMENT", "INT", "CHAR_LITERAL", "STRING_LITERAL", 
		"LITERAL_CHAR", "DOUBLE_QUOTE_STRING_LITERAL", "DOUBLE_ANGLE_STRING_LITERAL", 
		"ESC", "XDIGIT", "BEGIN_ARGUMENT", "BEGIN_ACTION", "OPTIONS", "TOKENS", 
		"CATCH", "FINALLY", "FRAGMENT", "GRAMMAR", "LEXER", "PARSER", "PRIVATE", 
		"PROTECTED", "PUBLIC", "RETURNS", "SCOPE", "THROWS", "TREE", "WS_LOOP", 
		"AT", "BANG", "CLOSE_ELEMENT_OPTION", "COLON", "COLONCOLON", "COMMA", 
		"DOT", "EQUAL", "LBRACE", "LBRACK", "LPAREN", "OPEN_ELEMENT_OPTION", "OR", 
		"PLUS", "QM", "RANGE", "RBRACE", "RBRACK", "REWRITE", "ROOT", "RPAREN", 
		"SEMI", "SEMPREDOP", "STAR", "TREE_BEGIN", "DOLLAR", "PEQ", "NOT", "WS", 
		"TOKEN_REF", "RULE_REF", "Ws", "Hws", "Vws", "BlockComment", "DocComment", 
		"LineComment", "EscSeq", "EscAny", "UnicodeEsc", "DecimalNumeral", "HexDigit", 
		"DecDigit", "BoolLiteral", "CharLiteral", "SQuoteLiteral", "DQuoteLiteral", 
		"USQuoteLiteral", "NameChar", "NameStartChar", "Int", "Esc", "Colon", 
		"DColon", "SQuote", "DQuote", "LParen", "RParen", "LBrace", "RBrace", 
		"LBrack", "RBrack", "RArrow", "Lt", "Gt", "Equal", "Question", "Star", 
		"Plus", "PlusAssign", "Underscore", "Pipe", "Dollar", "Comma", "Semi", 
		"Dot", "Range", "At", "Pound", "Tilde", "NESTED_ARGUMENT", "ARGUMENT_ESCAPE", 
		"ARGUMENT_STRING_LITERAL", "ARGUMENT_CHAR_LITERAL", "END_ARGUMENT", "UNTERMINATED_ARGUMENT", 
		"ARGUMENT_CONTENT", "NESTED_ACTION", "ACTION_ESCAPE", "ACTION_STRING_LITERAL", 
		"ACTION_CHAR_LITERAL", "ACTION_DOC_COMMENT", "ACTION_BLOCK_COMMENT", "ACTION_LINE_COMMENT", 
		"END_ACTION", "UNTERMINATED_ACTION", "ACTION_CONTENT", "OPT_DOC_COMMENT", 
		"OPT_BLOCK_COMMENT", "OPT_LINE_COMMENT", "OPT_LBRACE", "OPT_RBRACE", "OPT_ID", 
		"OPT_DOT", "OPT_ASSIGN", "OPT_STRING_LITERAL", "OPT_INT", "OPT_STAR", 
		"OPT_SEMI", "OPT_WS", "TOK_DOC_COMMENT", "TOK_BLOCK_COMMENT", "TOK_LINE_COMMENT", 
		"TOK_LBRACE", "TOK_RBRACE", "TOK_ID", "TOK_EQ", "TOK_CL", "TOK_SL", "TOK_SEMI", 
		"TOK_WS", "LEXER_CHAR_SET_BODY", "LEXER_CHAR_SET", "UNTERMINATED_CHAR_SET", 
		"Id"
	};


	public ANTLRv3Lexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public ANTLRv3Lexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, null, "'parser'", "'lexer'", null, null, null, null, null, null, 
		"'..'", null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, "'scope'", null, null, null, null, 
		"'fragment'", "'^('", "'^'", "'!'", null, null, null, null, null, null, 
		null, null, null, null, null, "'options'", "'tokens'", "'catch'", "'finally'", 
		"'grammar'", "'private'", "'protected'", "'public'", "'returns'", "'throws'", 
		"'tree'", null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, "'=>'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "DOC_COMMENT", "PARSER", "LEXER", "RULE", "BLOCK", "OPTIONAL", "CLOSURE", 
		"POSITIVE_CLOSURE", "SYNPRED", "RANGE", "CHAR_RANGE", "EPSILON", "ALT", 
		"EOR", "EOB", "EOA", "ID", "ARG", "ARGLIST", "RET", "LEXER_GRAMMAR", "PARSER_GRAMMAR", 
		"TREE_GRAMMAR", "COMBINED_GRAMMAR", "INITACTION", "LABEL", "TEMPLATE", 
		"SCOPE", "SEMPRED", "GATED_SEMPRED", "SYN_SEMPRED", "BACKTRACK_SEMPRED", 
		"FRAGMENT", "TREE_BEGIN", "ROOT", "BANG", "REWRITE", "ACTION_CONTENT", 
		"SL_COMMENT", "ML_COMMENT", "INT", "CHAR_LITERAL", "STRING_LITERAL", "DOUBLE_QUOTE_STRING_LITERAL", 
		"DOUBLE_ANGLE_STRING_LITERAL", "BEGIN_ARGUMENT", "BEGIN_ACTION", "OPTIONS", 
		"TOKENS", "CATCH", "FINALLY", "GRAMMAR", "PRIVATE", "PROTECTED", "PUBLIC", 
		"RETURNS", "THROWS", "TREE", "AT", "CLOSE_ELEMENT_OPTION", "COLON", "COLONCOLON", 
		"COMMA", "DOT", "EQUAL", "LBRACE", "LBRACK", "LPAREN", "OPEN_ELEMENT_OPTION", 
		"OR", "PLUS", "QM", "RBRACE", "RBRACK", "RPAREN", "SEMI", "SEMPREDOP", 
		"STAR", "DOLLAR", "PEQ", "NOT", "WS", "TOKEN_REF", "RULE_REF", "END_ARGUMENT", 
		"UNTERMINATED_ARGUMENT", "ARGUMENT_CONTENT", "END_ACTION", "UNTERMINATED_ACTION", 
		"OPT_LBRACE", "LEXER_CHAR_SET", "UNTERMINATED_CHAR_SET"
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

	public override string GrammarFileName { get { return "ANTLRv3Lexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static ANTLRv3Lexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	public override void Action(RuleContext _localctx, int ruleIndex, int actionIndex) {
		switch (ruleIndex) {
		case 11 : BEGIN_ARGUMENT_action(_localctx, actionIndex); break;
		case 113 : END_ARGUMENT_action(_localctx, actionIndex); break;
		case 123 : END_ACTION_action(_localctx, actionIndex); break;
		case 129 : OPT_LBRACE_action(_localctx, actionIndex); break;
		}
	}
	private void BEGIN_ARGUMENT_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 0:  handleBeginArgument();  break;
		}
	}
	private void END_ARGUMENT_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 1:  handleEndArgument();  break;
		}
	}
	private void END_ACTION_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 2:  handleEndAction();  break;
		}
	}
	private void OPT_LBRACE_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 3:  handleOptionsLBrace();  break;
		}
	}

	private static int[] _serializedATN = {
		4,0,92,1038,6,-1,6,-1,6,-1,6,-1,6,-1,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,
		7,3,2,4,7,4,2,5,7,5,2,6,7,6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,
		2,12,7,12,2,13,7,13,2,14,7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,
		2,19,7,19,2,20,7,20,2,21,7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,
		2,26,7,26,2,27,7,27,2,28,7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,
		2,33,7,33,2,34,7,34,2,35,7,35,2,36,7,36,2,37,7,37,2,38,7,38,2,39,7,39,
		2,40,7,40,2,41,7,41,2,42,7,42,2,43,7,43,2,44,7,44,2,45,7,45,2,46,7,46,
		2,47,7,47,2,48,7,48,2,49,7,49,2,50,7,50,2,51,7,51,2,52,7,52,2,53,7,53,
		2,54,7,54,2,55,7,55,2,56,7,56,2,57,7,57,2,58,7,58,2,59,7,59,2,60,7,60,
		2,61,7,61,2,62,7,62,2,63,7,63,2,64,7,64,2,65,7,65,2,66,7,66,2,67,7,67,
		2,68,7,68,2,69,7,69,2,70,7,70,2,71,7,71,2,72,7,72,2,73,7,73,2,74,7,74,
		2,75,7,75,2,76,7,76,2,77,7,77,2,78,7,78,2,79,7,79,2,80,7,80,2,81,7,81,
		2,82,7,82,2,83,7,83,2,84,7,84,2,85,7,85,2,86,7,86,2,87,7,87,2,88,7,88,
		2,89,7,89,2,90,7,90,2,91,7,91,2,92,7,92,2,93,7,93,2,94,7,94,2,95,7,95,
		2,96,7,96,2,97,7,97,2,98,7,98,2,99,7,99,2,100,7,100,2,101,7,101,2,102,
		7,102,2,103,7,103,2,104,7,104,2,105,7,105,2,106,7,106,2,107,7,107,2,108,
		7,108,2,109,7,109,2,110,7,110,2,111,7,111,2,112,7,112,2,113,7,113,2,114,
		7,114,2,115,7,115,2,116,7,116,2,117,7,117,2,118,7,118,2,119,7,119,2,120,
		7,120,2,121,7,121,2,122,7,122,2,123,7,123,2,124,7,124,2,125,7,125,2,126,
		7,126,2,127,7,127,2,128,7,128,2,129,7,129,2,130,7,130,2,131,7,131,2,132,
		7,132,2,133,7,133,2,134,7,134,2,135,7,135,2,136,7,136,2,137,7,137,2,138,
		7,138,2,139,7,139,2,140,7,140,2,141,7,141,2,142,7,142,2,143,7,143,2,144,
		7,144,2,145,7,145,2,146,7,146,2,147,7,147,2,148,7,148,2,149,7,149,2,150,
		7,150,2,151,7,151,2,152,7,152,2,153,7,153,1,0,1,0,1,0,1,0,1,0,5,0,320,
		8,0,10,0,12,0,323,9,0,1,0,1,0,1,0,3,0,328,8,0,1,0,1,0,1,1,1,1,1,1,1,1,
		5,1,336,8,1,10,1,12,1,339,9,1,1,1,1,1,1,2,1,2,1,2,1,2,5,2,347,8,2,10,2,
		12,2,350,9,2,1,2,1,2,1,2,1,2,1,2,1,3,4,3,358,8,3,11,3,12,3,359,1,4,1,4,
		1,4,1,4,1,5,1,5,1,5,5,5,369,8,5,10,5,12,5,372,9,5,1,5,1,5,1,6,1,6,3,6,
		378,8,6,1,7,1,7,1,7,5,7,383,8,7,10,7,12,7,386,9,7,1,7,1,7,1,8,1,8,1,8,
		1,8,5,8,394,8,8,10,8,12,8,397,9,8,1,8,1,8,1,8,1,9,1,9,1,9,1,9,1,9,1,9,
		1,9,1,9,1,9,3,9,411,8,9,1,10,1,10,1,11,1,11,1,11,1,12,1,12,1,12,1,12,1,
		13,1,13,1,13,1,13,1,13,1,13,1,13,1,13,1,13,1,13,1,14,1,14,1,14,1,14,1,
		14,1,14,1,14,1,14,1,14,1,15,1,15,1,15,1,15,1,15,1,15,1,16,1,16,1,16,1,
		16,1,16,1,16,1,16,1,16,1,17,1,17,1,17,1,17,1,17,1,17,1,17,1,17,1,17,1,
		18,1,18,1,18,1,18,1,18,1,18,1,18,1,18,1,19,1,19,1,19,1,19,1,19,1,19,1,
		20,1,20,1,20,1,20,1,20,1,20,1,20,1,21,1,21,1,21,1,21,1,21,1,21,1,21,1,
		21,1,22,1,22,1,22,1,22,1,22,1,22,1,22,1,22,1,22,1,22,1,23,1,23,1,23,1,
		23,1,23,1,23,1,23,1,24,1,24,1,24,1,24,1,24,1,24,1,24,1,24,1,25,1,25,1,
		25,1,25,1,25,1,25,1,26,1,26,1,26,1,26,1,26,1,26,1,26,1,27,1,27,1,27,1,
		27,1,27,1,28,1,28,1,28,5,28,539,8,28,10,28,12,28,542,9,28,1,29,1,29,1,
		30,1,30,1,31,1,31,1,32,1,32,1,33,1,33,1,34,1,34,1,35,1,35,1,36,1,36,1,
		37,1,37,1,38,1,38,1,39,1,39,1,40,1,40,1,41,1,41,1,42,1,42,1,43,1,43,1,
		44,1,44,1,44,1,45,1,45,1,46,1,46,1,47,1,47,1,48,1,48,1,49,1,49,1,50,1,
		50,1,51,1,51,1,51,1,52,1,52,1,53,1,53,1,53,1,54,1,54,1,55,1,55,1,56,1,
		56,1,57,1,57,3,57,605,8,57,1,57,4,57,608,8,57,11,57,12,57,609,1,57,1,57,
		1,58,1,58,5,58,616,8,58,10,58,12,58,619,9,58,1,59,1,59,5,59,623,8,59,10,
		59,12,59,626,9,59,1,60,1,60,3,60,630,8,60,1,61,1,61,1,62,1,62,1,63,1,63,
		1,63,1,63,5,63,640,8,63,10,63,12,63,643,9,63,1,63,1,63,1,63,3,63,648,8,
		63,1,64,1,64,1,64,1,64,1,64,5,64,655,8,64,10,64,12,64,658,9,64,1,64,1,
		64,1,64,3,64,663,8,64,1,65,1,65,1,65,1,65,5,65,669,8,65,10,65,12,65,672,
		9,65,1,66,1,66,1,66,1,66,1,66,3,66,679,8,66,1,67,1,67,1,67,1,68,1,68,1,
		68,1,68,1,68,3,68,689,8,68,3,68,691,8,68,3,68,693,8,68,3,68,695,8,68,1,
		69,1,69,1,69,5,69,700,8,69,10,69,12,69,703,9,69,3,69,705,8,69,1,70,1,70,
		1,71,1,71,1,72,1,72,1,72,1,72,1,72,1,72,1,72,1,72,1,72,3,72,720,8,72,1,
		73,1,73,1,73,3,73,725,8,73,1,73,1,73,1,74,1,74,1,74,5,74,732,8,74,10,74,
		12,74,735,9,74,1,74,1,74,1,75,1,75,1,75,5,75,742,8,75,10,75,12,75,745,
		9,75,1,75,1,75,1,76,1,76,1,76,5,76,752,8,76,10,76,12,76,755,9,76,1,77,
		1,77,1,77,1,77,3,77,761,8,77,1,78,1,78,1,79,1,79,1,79,1,79,1,80,1,80,1,
		81,1,81,1,82,1,82,1,82,1,83,1,83,1,84,1,84,1,85,1,85,1,86,1,86,1,87,1,
		87,1,88,1,88,1,89,1,89,1,90,1,90,1,91,1,91,1,91,1,92,1,92,1,93,1,93,1,
		94,1,94,1,95,1,95,1,96,1,96,1,97,1,97,1,98,1,98,1,98,1,99,1,99,1,100,1,
		100,1,101,1,101,1,102,1,102,1,103,1,103,1,104,1,104,1,105,1,105,1,105,
		1,106,1,106,1,107,1,107,1,108,1,108,1,109,1,109,1,109,1,109,1,109,1,110,
		1,110,1,110,1,110,1,111,1,111,1,111,1,111,1,112,1,112,1,112,1,112,1,113,
		1,113,1,113,1,114,1,114,1,114,1,114,1,115,1,115,1,116,1,116,1,116,1,116,
		1,116,1,117,1,117,1,117,1,117,1,118,1,118,1,118,1,118,1,119,1,119,1,119,
		1,119,1,120,1,120,1,120,1,120,1,121,1,121,1,121,1,121,1,122,1,122,1,122,
		1,122,1,123,1,123,1,123,1,124,1,124,1,124,1,124,1,125,1,125,1,126,1,126,
		1,126,1,126,1,126,1,127,1,127,1,127,1,127,1,127,1,128,1,128,1,128,1,128,
		1,128,1,129,1,129,1,129,1,130,1,130,1,130,1,130,1,130,1,131,1,131,1,131,
		1,131,1,132,1,132,1,132,1,132,1,133,1,133,1,133,1,133,1,134,1,134,1,134,
		1,134,1,135,1,135,1,135,1,135,1,136,1,136,1,136,1,136,1,137,1,137,1,137,
		1,137,1,138,4,138,947,8,138,11,138,12,138,948,1,138,1,138,1,138,1,139,
		1,139,1,139,1,139,1,139,1,140,1,140,1,140,1,140,1,140,1,141,1,141,1,141,
		1,141,1,141,1,142,1,142,1,142,1,142,1,143,1,143,1,143,1,143,1,143,1,144,
		1,144,1,144,1,144,1,145,1,145,1,145,1,145,1,146,1,146,1,146,1,146,1,146,
		1,146,1,147,1,147,1,147,5,147,995,8,147,10,147,12,147,998,9,147,1,147,
		1,147,1,147,1,147,1,148,1,148,1,148,1,148,1,149,4,149,1009,8,149,11,149,
		12,149,1010,1,149,1,149,1,149,1,150,1,150,4,150,1018,8,150,11,150,12,150,
		1019,1,150,1,150,1,151,1,151,1,151,1,151,1,152,1,152,1,152,1,152,1,153,
		1,153,5,153,1034,8,153,10,153,12,153,1037,9,153,5,321,348,395,641,656,
		0,154,6,1,8,39,10,40,12,41,14,42,16,43,18,0,20,44,22,45,24,0,26,0,28,46,
		30,47,32,48,34,49,36,50,38,51,40,33,42,52,44,3,46,2,48,53,50,54,52,55,
		54,56,56,28,58,57,60,58,62,0,64,59,66,36,68,60,70,61,72,62,74,63,76,64,
		78,65,80,66,82,67,84,68,86,69,88,70,90,71,92,72,94,10,96,73,98,74,100,
		37,102,35,104,75,106,76,108,77,110,78,112,34,114,79,116,80,118,81,120,
		82,122,83,124,84,126,0,128,0,130,0,132,0,134,0,136,0,138,0,140,0,142,0,
		144,0,146,0,148,0,150,0,152,0,154,0,156,0,158,0,160,0,162,0,164,0,166,
		0,168,0,170,0,172,0,174,0,176,0,178,0,180,0,182,0,184,0,186,0,188,0,190,
		0,192,0,194,0,196,0,198,0,200,0,202,0,204,0,206,0,208,0,210,0,212,0,214,
		0,216,0,218,0,220,0,222,0,224,0,226,0,228,0,230,0,232,85,234,86,236,87,
		238,0,240,0,242,0,244,0,246,0,248,0,250,0,252,88,254,89,256,38,258,0,260,
		0,262,0,264,90,266,0,268,0,270,0,272,0,274,0,276,0,278,0,280,0,282,0,284,
		0,286,0,288,0,290,0,292,0,294,0,296,0,298,0,300,0,302,0,304,0,306,0,308,
		91,310,92,312,0,6,0,1,2,3,4,5,16,2,0,10,10,13,13,2,0,39,39,92,92,2,0,34,
		34,92,92,9,0,34,34,39,39,62,62,92,92,98,98,102,102,110,110,114,114,116,
		116,3,0,48,57,65,70,97,102,2,0,9,9,32,32,4,0,48,57,65,90,95,95,97,122,
		2,0,10,10,12,13,8,0,34,34,39,39,92,92,98,98,102,102,110,110,114,114,116,
		116,1,0,49,57,1,0,48,57,4,0,10,10,13,13,39,39,92,92,4,0,10,10,13,13,34,
		34,92,92,3,0,183,183,768,879,8255,8256,13,0,65,90,97,122,192,214,216,246,
		248,767,880,893,895,8191,8204,8205,8304,8591,11264,12271,12289,55295,63744,
		64975,65008,65533,1,0,92,93,1030,0,6,1,0,0,0,0,8,1,0,0,0,0,10,1,0,0,0,
		0,12,1,0,0,0,0,14,1,0,0,0,0,16,1,0,0,0,0,20,1,0,0,0,0,22,1,0,0,0,0,28,
		1,0,0,0,0,30,1,0,0,0,0,32,1,0,0,0,0,34,1,0,0,0,0,36,1,0,0,0,0,38,1,0,0,
		0,0,40,1,0,0,0,0,42,1,0,0,0,0,44,1,0,0,0,0,46,1,0,0,0,0,48,1,0,0,0,0,50,
		1,0,0,0,0,52,1,0,0,0,0,54,1,0,0,0,0,56,1,0,0,0,0,58,1,0,0,0,0,60,1,0,0,
		0,0,64,1,0,0,0,0,66,1,0,0,0,0,68,1,0,0,0,0,70,1,0,0,0,0,72,1,0,0,0,0,74,
		1,0,0,0,0,76,1,0,0,0,0,78,1,0,0,0,0,80,1,0,0,0,0,82,1,0,0,0,0,84,1,0,0,
		0,0,86,1,0,0,0,0,88,1,0,0,0,0,90,1,0,0,0,0,92,1,0,0,0,0,94,1,0,0,0,0,96,
		1,0,0,0,0,98,1,0,0,0,0,100,1,0,0,0,0,102,1,0,0,0,0,104,1,0,0,0,0,106,1,
		0,0,0,0,108,1,0,0,0,0,110,1,0,0,0,0,112,1,0,0,0,0,114,1,0,0,0,0,116,1,
		0,0,0,0,118,1,0,0,0,0,120,1,0,0,0,0,122,1,0,0,0,0,124,1,0,0,0,1,224,1,
		0,0,0,1,226,1,0,0,0,1,228,1,0,0,0,1,230,1,0,0,0,1,232,1,0,0,0,1,234,1,
		0,0,0,1,236,1,0,0,0,2,238,1,0,0,0,2,240,1,0,0,0,2,242,1,0,0,0,2,244,1,
		0,0,0,2,246,1,0,0,0,2,248,1,0,0,0,2,250,1,0,0,0,2,252,1,0,0,0,2,254,1,
		0,0,0,2,256,1,0,0,0,3,258,1,0,0,0,3,260,1,0,0,0,3,262,1,0,0,0,3,264,1,
		0,0,0,3,266,1,0,0,0,3,268,1,0,0,0,3,270,1,0,0,0,3,272,1,0,0,0,3,274,1,
		0,0,0,3,276,1,0,0,0,3,278,1,0,0,0,3,280,1,0,0,0,3,282,1,0,0,0,4,284,1,
		0,0,0,4,286,1,0,0,0,4,288,1,0,0,0,4,290,1,0,0,0,4,292,1,0,0,0,4,294,1,
		0,0,0,4,296,1,0,0,0,4,298,1,0,0,0,4,300,1,0,0,0,4,302,1,0,0,0,4,304,1,
		0,0,0,5,306,1,0,0,0,5,308,1,0,0,0,5,310,1,0,0,0,6,314,1,0,0,0,8,331,1,
		0,0,0,10,342,1,0,0,0,12,357,1,0,0,0,14,361,1,0,0,0,16,365,1,0,0,0,18,377,
		1,0,0,0,20,379,1,0,0,0,22,389,1,0,0,0,24,401,1,0,0,0,26,412,1,0,0,0,28,
		414,1,0,0,0,30,417,1,0,0,0,32,421,1,0,0,0,34,431,1,0,0,0,36,440,1,0,0,
		0,38,446,1,0,0,0,40,454,1,0,0,0,42,463,1,0,0,0,44,471,1,0,0,0,46,477,1,
		0,0,0,48,484,1,0,0,0,50,492,1,0,0,0,52,502,1,0,0,0,54,509,1,0,0,0,56,517,
		1,0,0,0,58,523,1,0,0,0,60,530,1,0,0,0,62,540,1,0,0,0,64,543,1,0,0,0,66,
		545,1,0,0,0,68,547,1,0,0,0,70,549,1,0,0,0,72,551,1,0,0,0,74,553,1,0,0,
		0,76,555,1,0,0,0,78,557,1,0,0,0,80,559,1,0,0,0,82,561,1,0,0,0,84,563,1,
		0,0,0,86,565,1,0,0,0,88,567,1,0,0,0,90,569,1,0,0,0,92,571,1,0,0,0,94,573,
		1,0,0,0,96,576,1,0,0,0,98,578,1,0,0,0,100,580,1,0,0,0,102,582,1,0,0,0,
		104,584,1,0,0,0,106,586,1,0,0,0,108,588,1,0,0,0,110,591,1,0,0,0,112,593,
		1,0,0,0,114,596,1,0,0,0,116,598,1,0,0,0,118,600,1,0,0,0,120,607,1,0,0,
		0,122,613,1,0,0,0,124,620,1,0,0,0,126,629,1,0,0,0,128,631,1,0,0,0,130,
		633,1,0,0,0,132,635,1,0,0,0,134,649,1,0,0,0,136,664,1,0,0,0,138,673,1,
		0,0,0,140,680,1,0,0,0,142,683,1,0,0,0,144,704,1,0,0,0,146,706,1,0,0,0,
		148,708,1,0,0,0,150,719,1,0,0,0,152,721,1,0,0,0,154,728,1,0,0,0,156,738,
		1,0,0,0,158,748,1,0,0,0,160,760,1,0,0,0,162,762,1,0,0,0,164,764,1,0,0,
		0,166,768,1,0,0,0,168,770,1,0,0,0,170,772,1,0,0,0,172,775,1,0,0,0,174,
		777,1,0,0,0,176,779,1,0,0,0,178,781,1,0,0,0,180,783,1,0,0,0,182,785,1,
		0,0,0,184,787,1,0,0,0,186,789,1,0,0,0,188,791,1,0,0,0,190,794,1,0,0,0,
		192,796,1,0,0,0,194,798,1,0,0,0,196,800,1,0,0,0,198,802,1,0,0,0,200,804,
		1,0,0,0,202,806,1,0,0,0,204,809,1,0,0,0,206,811,1,0,0,0,208,813,1,0,0,
		0,210,815,1,0,0,0,212,817,1,0,0,0,214,819,1,0,0,0,216,821,1,0,0,0,218,
		824,1,0,0,0,220,826,1,0,0,0,222,828,1,0,0,0,224,830,1,0,0,0,226,835,1,
		0,0,0,228,839,1,0,0,0,230,843,1,0,0,0,232,847,1,0,0,0,234,850,1,0,0,0,
		236,854,1,0,0,0,238,856,1,0,0,0,240,861,1,0,0,0,242,865,1,0,0,0,244,869,
		1,0,0,0,246,873,1,0,0,0,248,877,1,0,0,0,250,881,1,0,0,0,252,885,1,0,0,
		0,254,888,1,0,0,0,256,892,1,0,0,0,258,894,1,0,0,0,260,899,1,0,0,0,262,
		904,1,0,0,0,264,909,1,0,0,0,266,912,1,0,0,0,268,917,1,0,0,0,270,921,1,
		0,0,0,272,925,1,0,0,0,274,929,1,0,0,0,276,933,1,0,0,0,278,937,1,0,0,0,
		280,941,1,0,0,0,282,946,1,0,0,0,284,953,1,0,0,0,286,958,1,0,0,0,288,963,
		1,0,0,0,290,968,1,0,0,0,292,972,1,0,0,0,294,977,1,0,0,0,296,981,1,0,0,
		0,298,985,1,0,0,0,300,991,1,0,0,0,302,1003,1,0,0,0,304,1008,1,0,0,0,306,
		1017,1,0,0,0,308,1023,1,0,0,0,310,1027,1,0,0,0,312,1031,1,0,0,0,314,315,
		5,47,0,0,315,316,5,42,0,0,316,317,5,42,0,0,317,321,1,0,0,0,318,320,9,0,
		0,0,319,318,1,0,0,0,320,323,1,0,0,0,321,322,1,0,0,0,321,319,1,0,0,0,322,
		327,1,0,0,0,323,321,1,0,0,0,324,325,5,42,0,0,325,328,5,47,0,0,326,328,
		5,0,0,1,327,324,1,0,0,0,327,326,1,0,0,0,328,329,1,0,0,0,329,330,6,0,0,
		0,330,7,1,0,0,0,331,332,5,47,0,0,332,333,5,47,0,0,333,337,1,0,0,0,334,
		336,8,0,0,0,335,334,1,0,0,0,336,339,1,0,0,0,337,335,1,0,0,0,337,338,1,
		0,0,0,338,340,1,0,0,0,339,337,1,0,0,0,340,341,6,1,0,0,341,9,1,0,0,0,342,
		343,5,47,0,0,343,344,5,42,0,0,344,348,1,0,0,0,345,347,9,0,0,0,346,345,
		1,0,0,0,347,350,1,0,0,0,348,349,1,0,0,0,348,346,1,0,0,0,349,351,1,0,0,
		0,350,348,1,0,0,0,351,352,5,42,0,0,352,353,5,47,0,0,353,354,1,0,0,0,354,
		355,6,2,0,0,355,11,1,0,0,0,356,358,2,48,57,0,357,356,1,0,0,0,358,359,1,
		0,0,0,359,357,1,0,0,0,359,360,1,0,0,0,360,13,1,0,0,0,361,362,5,39,0,0,
		362,363,3,18,6,0,363,364,5,39,0,0,364,15,1,0,0,0,365,366,5,39,0,0,366,
		370,3,18,6,0,367,369,3,18,6,0,368,367,1,0,0,0,369,372,1,0,0,0,370,368,
		1,0,0,0,370,371,1,0,0,0,371,373,1,0,0,0,372,370,1,0,0,0,373,374,5,39,0,
		0,374,17,1,0,0,0,375,378,3,24,9,0,376,378,8,1,0,0,377,375,1,0,0,0,377,
		376,1,0,0,0,378,19,1,0,0,0,379,384,5,34,0,0,380,383,3,24,9,0,381,383,8,
		2,0,0,382,380,1,0,0,0,382,381,1,0,0,0,383,386,1,0,0,0,384,382,1,0,0,0,
		384,385,1,0,0,0,385,387,1,0,0,0,386,384,1,0,0,0,387,388,5,34,0,0,388,21,
		1,0,0,0,389,390,5,60,0,0,390,391,5,60,0,0,391,395,1,0,0,0,392,394,9,0,
		0,0,393,392,1,0,0,0,394,397,1,0,0,0,395,396,1,0,0,0,395,393,1,0,0,0,396,
		398,1,0,0,0,397,395,1,0,0,0,398,399,5,62,0,0,399,400,5,62,0,0,400,23,1,
		0,0,0,401,410,5,92,0,0,402,411,7,3,0,0,403,404,5,117,0,0,404,405,3,26,
		10,0,405,406,3,26,10,0,406,407,3,26,10,0,407,408,3,26,10,0,408,411,1,0,
		0,0,409,411,9,0,0,0,410,402,1,0,0,0,410,403,1,0,0,0,410,409,1,0,0,0,411,
		25,1,0,0,0,412,413,7,4,0,0,413,27,1,0,0,0,414,415,3,184,89,0,415,416,6,
		11,1,0,416,29,1,0,0,0,417,418,3,180,87,0,418,419,1,0,0,0,419,420,6,12,
		2,0,420,31,1,0,0,0,421,422,5,111,0,0,422,423,5,112,0,0,423,424,5,116,0,
		0,424,425,5,105,0,0,425,426,5,111,0,0,426,427,5,110,0,0,427,428,5,115,
		0,0,428,429,1,0,0,0,429,430,6,13,3,0,430,33,1,0,0,0,431,432,5,116,0,0,
		432,433,5,111,0,0,433,434,5,107,0,0,434,435,5,101,0,0,435,436,5,110,0,
		0,436,437,5,115,0,0,437,438,1,0,0,0,438,439,6,14,4,0,439,35,1,0,0,0,440,
		441,5,99,0,0,441,442,5,97,0,0,442,443,5,116,0,0,443,444,5,99,0,0,444,445,
		5,104,0,0,445,37,1,0,0,0,446,447,5,102,0,0,447,448,5,105,0,0,448,449,5,
		110,0,0,449,450,5,97,0,0,450,451,5,108,0,0,451,452,5,108,0,0,452,453,5,
		121,0,0,453,39,1,0,0,0,454,455,5,102,0,0,455,456,5,114,0,0,456,457,5,97,
		0,0,457,458,5,103,0,0,458,459,5,109,0,0,459,460,5,101,0,0,460,461,5,110,
		0,0,461,462,5,116,0,0,462,41,1,0,0,0,463,464,5,103,0,0,464,465,5,114,0,
		0,465,466,5,97,0,0,466,467,5,109,0,0,467,468,5,109,0,0,468,469,5,97,0,
		0,469,470,5,114,0,0,470,43,1,0,0,0,471,472,5,108,0,0,472,473,5,101,0,0,
		473,474,5,120,0,0,474,475,5,101,0,0,475,476,5,114,0,0,476,45,1,0,0,0,477,
		478,5,112,0,0,478,479,5,97,0,0,479,480,5,114,0,0,480,481,5,115,0,0,481,
		482,5,101,0,0,482,483,5,114,0,0,483,47,1,0,0,0,484,485,5,112,0,0,485,486,
		5,114,0,0,486,487,5,105,0,0,487,488,5,118,0,0,488,489,5,97,0,0,489,490,
		5,116,0,0,490,491,5,101,0,0,491,49,1,0,0,0,492,493,5,112,0,0,493,494,5,
		114,0,0,494,495,5,111,0,0,495,496,5,116,0,0,496,497,5,101,0,0,497,498,
		5,99,0,0,498,499,5,116,0,0,499,500,5,101,0,0,500,501,5,100,0,0,501,51,
		1,0,0,0,502,503,5,112,0,0,503,504,5,117,0,0,504,505,5,98,0,0,505,506,5,
		108,0,0,506,507,5,105,0,0,507,508,5,99,0,0,508,53,1,0,0,0,509,510,5,114,
		0,0,510,511,5,101,0,0,511,512,5,116,0,0,512,513,5,117,0,0,513,514,5,114,
		0,0,514,515,5,110,0,0,515,516,5,115,0,0,516,55,1,0,0,0,517,518,5,115,0,
		0,518,519,5,99,0,0,519,520,5,111,0,0,520,521,5,112,0,0,521,522,5,101,0,
		0,522,57,1,0,0,0,523,524,5,116,0,0,524,525,5,104,0,0,525,526,5,114,0,0,
		526,527,5,111,0,0,527,528,5,119,0,0,528,529,5,115,0,0,529,59,1,0,0,0,530,
		531,5,116,0,0,531,532,5,114,0,0,532,533,5,101,0,0,533,534,5,101,0,0,534,
		61,1,0,0,0,535,539,3,120,57,0,536,539,3,8,1,0,537,539,3,10,2,0,538,535,
		1,0,0,0,538,536,1,0,0,0,538,537,1,0,0,0,539,542,1,0,0,0,540,538,1,0,0,
		0,540,541,1,0,0,0,541,63,1,0,0,0,542,540,1,0,0,0,543,544,3,218,106,0,544,
		65,1,0,0,0,545,546,5,33,0,0,546,67,1,0,0,0,547,548,3,192,93,0,548,69,1,
		0,0,0,549,550,3,168,81,0,550,71,1,0,0,0,551,552,3,170,82,0,552,73,1,0,
		0,0,553,554,3,210,102,0,554,75,1,0,0,0,555,556,3,214,104,0,556,77,1,0,
		0,0,557,558,3,194,94,0,558,79,1,0,0,0,559,560,3,180,87,0,560,81,1,0,0,
		0,561,562,3,184,89,0,562,83,1,0,0,0,563,564,3,176,85,0,564,85,1,0,0,0,
		565,566,3,190,92,0,566,87,1,0,0,0,567,568,3,206,100,0,568,89,1,0,0,0,569,
		570,3,200,97,0,570,91,1,0,0,0,571,572,3,196,95,0,572,93,1,0,0,0,573,574,
		5,46,0,0,574,575,5,46,0,0,575,95,1,0,0,0,576,577,3,182,88,0,577,97,1,0,
		0,0,578,579,3,186,90,0,579,99,1,0,0,0,580,581,3,188,91,0,581,101,1,0,0,
		0,582,583,5,94,0,0,583,103,1,0,0,0,584,585,3,178,86,0,585,105,1,0,0,0,
		586,587,3,212,103,0,587,107,1,0,0,0,588,589,5,61,0,0,589,590,5,62,0,0,
		590,109,1,0,0,0,591,592,3,198,96,0,592,111,1,0,0,0,593,594,5,94,0,0,594,
		595,5,40,0,0,595,113,1,0,0,0,596,597,3,208,101,0,597,115,1,0,0,0,598,599,
		3,202,98,0,599,117,1,0,0,0,600,601,3,222,108,0,601,119,1,0,0,0,602,608,
		7,5,0,0,603,605,5,13,0,0,604,603,1,0,0,0,604,605,1,0,0,0,605,606,1,0,0,
		0,606,608,5,10,0,0,607,602,1,0,0,0,607,604,1,0,0,0,608,609,1,0,0,0,609,
		607,1,0,0,0,609,610,1,0,0,0,610,611,1,0,0,0,611,612,6,57,0,0,612,121,1,
		0,0,0,613,617,2,65,90,0,614,616,7,6,0,0,615,614,1,0,0,0,616,619,1,0,0,
		0,617,615,1,0,0,0,617,618,1,0,0,0,618,123,1,0,0,0,619,617,1,0,0,0,620,
		624,2,97,122,0,621,623,7,6,0,0,622,621,1,0,0,0,623,626,1,0,0,0,624,622,
		1,0,0,0,624,625,1,0,0,0,625,125,1,0,0,0,626,624,1,0,0,0,627,630,3,128,
		61,0,628,630,3,130,62,0,629,627,1,0,0,0,629,628,1,0,0,0,630,127,1,0,0,
		0,631,632,7,5,0,0,632,129,1,0,0,0,633,634,7,7,0,0,634,131,1,0,0,0,635,
		636,5,47,0,0,636,637,5,42,0,0,637,641,1,0,0,0,638,640,9,0,0,0,639,638,
		1,0,0,0,640,643,1,0,0,0,641,642,1,0,0,0,641,639,1,0,0,0,642,647,1,0,0,
		0,643,641,1,0,0,0,644,645,5,42,0,0,645,648,5,47,0,0,646,648,5,0,0,1,647,
		644,1,0,0,0,647,646,1,0,0,0,648,133,1,0,0,0,649,650,5,47,0,0,650,651,5,
		42,0,0,651,652,5,42,0,0,652,656,1,0,0,0,653,655,9,0,0,0,654,653,1,0,0,
		0,655,658,1,0,0,0,656,657,1,0,0,0,656,654,1,0,0,0,657,662,1,0,0,0,658,
		656,1,0,0,0,659,660,5,42,0,0,660,663,5,47,0,0,661,663,5,0,0,1,662,659,
		1,0,0,0,662,661,1,0,0,0,663,135,1,0,0,0,664,665,5,47,0,0,665,666,5,47,
		0,0,666,670,1,0,0,0,667,669,8,0,0,0,668,667,1,0,0,0,669,672,1,0,0,0,670,
		668,1,0,0,0,670,671,1,0,0,0,671,137,1,0,0,0,672,670,1,0,0,0,673,678,3,
		166,80,0,674,679,7,8,0,0,675,679,3,142,68,0,676,679,9,0,0,0,677,679,5,
		0,0,1,678,674,1,0,0,0,678,675,1,0,0,0,678,676,1,0,0,0,678,677,1,0,0,0,
		679,139,1,0,0,0,680,681,3,166,80,0,681,682,9,0,0,0,682,141,1,0,0,0,683,
		694,5,117,0,0,684,692,3,146,70,0,685,690,3,146,70,0,686,688,3,146,70,0,
		687,689,3,146,70,0,688,687,1,0,0,0,688,689,1,0,0,0,689,691,1,0,0,0,690,
		686,1,0,0,0,690,691,1,0,0,0,691,693,1,0,0,0,692,685,1,0,0,0,692,693,1,
		0,0,0,693,695,1,0,0,0,694,684,1,0,0,0,694,695,1,0,0,0,695,143,1,0,0,0,
		696,705,5,48,0,0,697,701,7,9,0,0,698,700,3,148,71,0,699,698,1,0,0,0,700,
		703,1,0,0,0,701,699,1,0,0,0,701,702,1,0,0,0,702,705,1,0,0,0,703,701,1,
		0,0,0,704,696,1,0,0,0,704,697,1,0,0,0,705,145,1,0,0,0,706,707,7,4,0,0,
		707,147,1,0,0,0,708,709,7,10,0,0,709,149,1,0,0,0,710,711,5,116,0,0,711,
		712,5,114,0,0,712,713,5,117,0,0,713,720,5,101,0,0,714,715,5,102,0,0,715,
		716,5,97,0,0,716,717,5,108,0,0,717,718,5,115,0,0,718,720,5,101,0,0,719,
		710,1,0,0,0,719,714,1,0,0,0,720,151,1,0,0,0,721,724,3,172,83,0,722,725,
		3,138,66,0,723,725,8,11,0,0,724,722,1,0,0,0,724,723,1,0,0,0,725,726,1,
		0,0,0,726,727,3,172,83,0,727,153,1,0,0,0,728,733,3,172,83,0,729,732,3,
		138,66,0,730,732,8,11,0,0,731,729,1,0,0,0,731,730,1,0,0,0,732,735,1,0,
		0,0,733,731,1,0,0,0,733,734,1,0,0,0,734,736,1,0,0,0,735,733,1,0,0,0,736,
		737,3,172,83,0,737,155,1,0,0,0,738,743,3,174,84,0,739,742,3,138,66,0,740,
		742,8,12,0,0,741,739,1,0,0,0,741,740,1,0,0,0,742,745,1,0,0,0,743,741,1,
		0,0,0,743,744,1,0,0,0,744,746,1,0,0,0,745,743,1,0,0,0,746,747,3,174,84,
		0,747,157,1,0,0,0,748,753,3,172,83,0,749,752,3,138,66,0,750,752,8,11,0,
		0,751,749,1,0,0,0,751,750,1,0,0,0,752,755,1,0,0,0,753,751,1,0,0,0,753,
		754,1,0,0,0,754,159,1,0,0,0,755,753,1,0,0,0,756,761,3,162,78,0,757,761,
		2,48,57,0,758,761,3,204,99,0,759,761,7,13,0,0,760,756,1,0,0,0,760,757,
		1,0,0,0,760,758,1,0,0,0,760,759,1,0,0,0,761,161,1,0,0,0,762,763,7,14,0,
		0,763,163,1,0,0,0,764,765,5,105,0,0,765,766,5,110,0,0,766,767,5,116,0,
		0,767,165,1,0,0,0,768,769,5,92,0,0,769,167,1,0,0,0,770,771,5,58,0,0,771,
		169,1,0,0,0,772,773,5,58,0,0,773,774,5,58,0,0,774,171,1,0,0,0,775,776,
		5,39,0,0,776,173,1,0,0,0,777,778,5,34,0,0,778,175,1,0,0,0,779,780,5,40,
		0,0,780,177,1,0,0,0,781,782,5,41,0,0,782,179,1,0,0,0,783,784,5,123,0,0,
		784,181,1,0,0,0,785,786,5,125,0,0,786,183,1,0,0,0,787,788,5,91,0,0,788,
		185,1,0,0,0,789,790,5,93,0,0,790,187,1,0,0,0,791,792,5,45,0,0,792,793,
		5,62,0,0,793,189,1,0,0,0,794,795,5,60,0,0,795,191,1,0,0,0,796,797,5,62,
		0,0,797,193,1,0,0,0,798,799,5,61,0,0,799,195,1,0,0,0,800,801,5,63,0,0,
		801,197,1,0,0,0,802,803,5,42,0,0,803,199,1,0,0,0,804,805,5,43,0,0,805,
		201,1,0,0,0,806,807,5,43,0,0,807,808,5,61,0,0,808,203,1,0,0,0,809,810,
		5,95,0,0,810,205,1,0,0,0,811,812,5,124,0,0,812,207,1,0,0,0,813,814,5,36,
		0,0,814,209,1,0,0,0,815,816,5,44,0,0,816,211,1,0,0,0,817,818,5,59,0,0,
		818,213,1,0,0,0,819,820,5,46,0,0,820,215,1,0,0,0,821,822,5,46,0,0,822,
		823,5,46,0,0,823,217,1,0,0,0,824,825,5,64,0,0,825,219,1,0,0,0,826,827,
		5,35,0,0,827,221,1,0,0,0,828,829,5,126,0,0,829,223,1,0,0,0,830,831,3,184,
		89,0,831,832,1,0,0,0,832,833,6,109,5,0,833,834,6,109,6,0,834,225,1,0,0,
		0,835,836,3,140,67,0,836,837,1,0,0,0,837,838,6,110,5,0,838,227,1,0,0,0,
		839,840,3,156,75,0,840,841,1,0,0,0,841,842,6,111,5,0,842,229,1,0,0,0,843,
		844,3,154,74,0,844,845,1,0,0,0,845,846,6,112,5,0,846,231,1,0,0,0,847,848,
		3,186,90,0,848,849,6,113,7,0,849,233,1,0,0,0,850,851,5,0,0,1,851,852,1,
		0,0,0,852,853,6,114,8,0,853,235,1,0,0,0,854,855,9,0,0,0,855,237,1,0,0,
		0,856,857,3,180,87,0,857,858,1,0,0,0,858,859,6,116,9,0,859,860,6,116,2,
		0,860,239,1,0,0,0,861,862,3,140,67,0,862,863,1,0,0,0,863,864,6,117,9,0,
		864,241,1,0,0,0,865,866,3,156,75,0,866,867,1,0,0,0,867,868,6,118,9,0,868,
		243,1,0,0,0,869,870,3,154,74,0,870,871,1,0,0,0,871,872,6,119,9,0,872,245,
		1,0,0,0,873,874,3,134,64,0,874,875,1,0,0,0,875,876,6,120,9,0,876,247,1,
		0,0,0,877,878,3,132,63,0,878,879,1,0,0,0,879,880,6,121,9,0,880,249,1,0,
		0,0,881,882,3,136,65,0,882,883,1,0,0,0,883,884,6,122,9,0,884,251,1,0,0,
		0,885,886,3,182,88,0,886,887,6,123,10,0,887,253,1,0,0,0,888,889,5,0,0,
		1,889,890,1,0,0,0,890,891,6,124,8,0,891,255,1,0,0,0,892,893,9,0,0,0,893,
		257,1,0,0,0,894,895,3,134,64,0,895,896,1,0,0,0,896,897,6,126,11,0,897,
		898,6,126,0,0,898,259,1,0,0,0,899,900,3,132,63,0,900,901,1,0,0,0,901,902,
		6,127,12,0,902,903,6,127,0,0,903,261,1,0,0,0,904,905,3,136,65,0,905,906,
		1,0,0,0,906,907,6,128,13,0,907,908,6,128,0,0,908,263,1,0,0,0,909,910,3,
		180,87,0,910,911,6,129,14,0,911,265,1,0,0,0,912,913,3,182,88,0,913,914,
		1,0,0,0,914,915,6,130,15,0,915,916,6,130,8,0,916,267,1,0,0,0,917,918,3,
		312,153,0,918,919,1,0,0,0,919,920,6,131,16,0,920,269,1,0,0,0,921,922,3,
		214,104,0,922,923,1,0,0,0,923,924,6,132,17,0,924,271,1,0,0,0,925,926,3,
		194,94,0,926,927,1,0,0,0,927,928,6,133,18,0,928,273,1,0,0,0,929,930,3,
		154,74,0,930,931,1,0,0,0,931,932,6,134,19,0,932,275,1,0,0,0,933,934,3,
		144,69,0,934,935,1,0,0,0,935,936,6,135,20,0,936,277,1,0,0,0,937,938,3,
		198,96,0,938,939,1,0,0,0,939,940,6,136,21,0,940,279,1,0,0,0,941,942,3,
		212,103,0,942,943,1,0,0,0,943,944,6,137,22,0,944,281,1,0,0,0,945,947,3,
		126,60,0,946,945,1,0,0,0,947,948,1,0,0,0,948,946,1,0,0,0,948,949,1,0,0,
		0,949,950,1,0,0,0,950,951,6,138,23,0,951,952,6,138,0,0,952,283,1,0,0,0,
		953,954,3,134,64,0,954,955,1,0,0,0,955,956,6,139,11,0,956,957,6,139,0,
		0,957,285,1,0,0,0,958,959,3,132,63,0,959,960,1,0,0,0,960,961,6,140,12,
		0,961,962,6,140,0,0,962,287,1,0,0,0,963,964,3,136,65,0,964,965,1,0,0,0,
		965,966,6,141,13,0,966,967,6,141,0,0,967,289,1,0,0,0,968,969,3,180,87,
		0,969,970,1,0,0,0,970,971,6,142,24,0,971,291,1,0,0,0,972,973,3,182,88,
		0,973,974,1,0,0,0,974,975,6,143,15,0,975,976,6,143,8,0,976,293,1,0,0,0,
		977,978,3,312,153,0,978,979,1,0,0,0,979,980,6,144,25,0,980,295,1,0,0,0,
		981,982,3,194,94,0,982,983,1,0,0,0,983,984,6,145,18,0,984,297,1,0,0,0,
		985,986,5,39,0,0,986,987,3,18,6,0,987,988,5,39,0,0,988,989,1,0,0,0,989,
		990,6,146,26,0,990,299,1,0,0,0,991,992,5,39,0,0,992,996,3,18,6,0,993,995,
		3,18,6,0,994,993,1,0,0,0,995,998,1,0,0,0,996,994,1,0,0,0,996,997,1,0,0,
		0,997,999,1,0,0,0,998,996,1,0,0,0,999,1000,5,39,0,0,1000,1001,1,0,0,0,
		1001,1002,6,147,19,0,1002,301,1,0,0,0,1003,1004,3,212,103,0,1004,1005,
		1,0,0,0,1005,1006,6,148,22,0,1006,303,1,0,0,0,1007,1009,3,126,60,0,1008,
		1007,1,0,0,0,1009,1010,1,0,0,0,1010,1008,1,0,0,0,1010,1011,1,0,0,0,1011,
		1012,1,0,0,0,1012,1013,6,149,23,0,1013,1014,6,149,0,0,1014,305,1,0,0,0,
		1015,1018,8,15,0,0,1016,1018,3,140,67,0,1017,1015,1,0,0,0,1017,1016,1,
		0,0,0,1018,1019,1,0,0,0,1019,1017,1,0,0,0,1019,1020,1,0,0,0,1020,1021,
		1,0,0,0,1021,1022,6,150,27,0,1022,307,1,0,0,0,1023,1024,3,186,90,0,1024,
		1025,1,0,0,0,1025,1026,6,151,8,0,1026,309,1,0,0,0,1027,1028,5,0,0,1,1028,
		1029,1,0,0,0,1029,1030,6,152,8,0,1030,311,1,0,0,0,1031,1035,3,162,78,0,
		1032,1034,3,160,77,0,1033,1032,1,0,0,0,1034,1037,1,0,0,0,1035,1033,1,0,
		0,0,1035,1036,1,0,0,0,1036,313,1,0,0,0,1037,1035,1,0,0,0,52,0,1,2,3,4,
		5,321,327,337,348,359,370,377,382,384,395,410,538,540,604,607,609,617,
		624,629,641,647,656,662,670,678,688,690,692,694,701,704,719,724,731,733,
		741,743,751,753,760,948,996,1010,1017,1019,1035,28,0,2,0,1,11,0,5,2,0,
		5,3,0,5,4,0,7,87,0,5,1,0,1,113,1,4,0,0,7,38,0,1,123,2,7,1,0,7,40,0,7,39,
		0,1,129,3,7,73,0,7,17,0,7,64,0,7,65,0,7,43,0,7,41,0,7,78,0,7,76,0,7,82,
		0,7,66,0,7,83,0,7,42,0,3,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace LanguageServer

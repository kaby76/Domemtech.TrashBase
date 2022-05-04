//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.10.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from ANTLRv2Lexer.g4 by ANTLR 4.10.1

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

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.10.1")]
[System.CLSCompliant(false)]
public partial class ANTLRv2Lexer : Antlr2LexerAdaptor {
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
		STRING_LITERAL=43, BEGIN_ARGUMENT=44, BEGIN_ACTION=45, OPTIONS=46, TOKENS=47, 
		HEADER=48, CLASS=49, EXTENDS=50, LEXCLASS=51, TREEPARSER=52, EXCEPTION=53, 
		CATCH=54, FINALLY=55, GRAMMAR=56, PRIVATE=57, PROTECTED=58, PUBLIC=59, 
		RETURNS=60, THROWS=61, TREE=62, OPEN_ELEMENT_OPTION=63, CLOSE_ELEMENT_OPTION=64, 
		AT=65, COLON=66, COLONCOLON=67, COMMA=68, DOT=69, EQUAL=70, LBRACE=71, 
		LBRACK=72, LPAREN=73, OR=74, PLUS=75, QM=76, RBRACE=77, RBRACK=78, RPAREN=79, 
		SEMI=80, SEMPREDOP=81, STAR=82, DOLLAR=83, PEQ=84, NOT=85, WS=86, TOKEN_REF=87, 
		RULE_REF=88, END_ARGUMENT=89, UNTERMINATED_ARGUMENT=90, ARGUMENT_CONTENT=91, 
		END_ACTION=92, UNTERMINATED_ACTION=93, OPT_LBRACE=94, LEXER_CHAR_SET=95, 
		UNTERMINATED_CHAR_SET=96;
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
		"DOC_COMMENT", "SL_COMMENT", "ML_COMMENT", "INT", "CHAR_LITERAL", "LITERAL_CHAR", 
		"STRING_LITERAL", "LIT_STR", "ESC", "XDIGIT", "BEGIN_ARGUMENT", "BEGIN_ACTION", 
		"OPTIONS", "TOKENS", "HEADER", "CLASS", "EXTENDS", "LEXCLASS", "TREEPARSER", 
		"EXCEPTION", "CATCH", "FINALLY", "FRAGMENT", "GRAMMAR", "LEXER", "PARSER", 
		"PRIVATE", "PROTECTED", "PUBLIC", "RETURNS", "SCOPE", "THROWS", "TREE", 
		"WS_LOOP", "OPEN_ELEMENT_OPTION", "CLOSE_ELEMENT_OPTION", "AT", "BANG", 
		"COLON", "COLONCOLON", "COMMA", "DOT", "EQUAL", "LBRACE", "LBRACK", "LPAREN", 
		"OR", "PLUS", "QM", "RANGE", "RBRACE", "RBRACK", "REWRITE", "ROOT", "RPAREN", 
		"SEMI", "SEMPREDOP", "STAR", "TREE_BEGIN", "DOLLAR", "PEQ", "NOT", "WS", 
		"TOKEN_REF", "RULE_REF", "Ws", "Hws", "Vws", "BlockComment", "DocComment", 
		"LineComment", "EscSeq", "EscAny", "UnicodeEsc", "OctEsc", "DecimalNumeral", 
		"HexDigit", "DecDigit", "OctDigit", "BoolLiteral", "CharLiteral", "SQuoteLiteral", 
		"DQuoteLiteral", "USQuoteLiteral", "NameChar", "NameStartChar", "Int", 
		"Esc", "Colon", "DColon", "SQuote", "DQuote", "LParen", "RParen", "LBrace", 
		"RBrace", "LBrack", "RBrack", "RArrow", "Lt", "Gt", "Equal", "Question", 
		"Star", "Plus", "PlusAssign", "Underscore", "Pipe", "Dollar", "Comma", 
		"Semi", "Dot", "Range", "At", "Pound", "Tilde", "NESTED_ARGUMENT", "ARGUMENT_ESCAPE", 
		"ARGUMENT_STRING_LITERAL", "ARGUMENT_CHAR_LITERAL", "END_ARGUMENT", "UNTERMINATED_ARGUMENT", 
		"ARGUMENT_CONTENT", "NESTED_ACTION", "ACTION_ESCAPE", "ACTION_STRING_LITERAL", 
		"ACTION_CHAR_LITERAL", "ACTION_DOC_COMMENT", "ACTION_BLOCK_COMMENT", "ACTION_LINE_COMMENT", 
		"END_ACTION", "UNTERMINATED_ACTION", "ACTION_CONTENT", "OPT_DOC_COMMENT", 
		"OPT_BLOCK_COMMENT", "OPT_LINE_COMMENT", "OPT_LBRACE", "OPT_RBRACE", "OPT_ID", 
		"OPT_DOT", "OPT_ASSIGN", "OPT_STRING_LITERAL", "OPT_STRING_LITERAL2", 
		"OPT_RANGE", "OPT_INT", "OPT_STAR", "OPT_SEMI", "OPT_WS", "TOK_DOC_COMMENT", 
		"TOK_BLOCK_COMMENT", "TOK_LINE_COMMENT", "TOK_LBRACE", "TOK_RBRACE", "TOK_ID", 
		"TOK_EQ", "TOK_CL", "TOK_SL", "TOK_SEMI", "TOK_RANGE", "TOK_WS", "LEXER_CHAR_SET_BODY", 
		"LEXER_CHAR_SET", "UNTERMINATED_CHAR_SET", "Id"
	};


	public ANTLRv2Lexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public ANTLRv2Lexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, null, "'Parser'", "'Lexer'", null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, "'scope'", null, null, null, null, 
		"'fragment'", "'^('", "'^'", "'!'", null, null, null, null, null, null, 
		null, null, null, "'options'", "'tokens'", "'header'", "'class'", "'extends'", 
		"'lexclass'", "'treeparser'", "'exception'", "'catch'", "'finally'", "'grammar'", 
		"'private'", "'protected'", "'public'", "'returns'", "'throws'", "'tree'", 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, "'=>'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "DOC_COMMENT", "PARSER", "LEXER", "RULE", "BLOCK", "OPTIONAL", "CLOSURE", 
		"POSITIVE_CLOSURE", "SYNPRED", "RANGE", "CHAR_RANGE", "EPSILON", "ALT", 
		"EOR", "EOB", "EOA", "ID", "ARG", "ARGLIST", "RET", "LEXER_GRAMMAR", "PARSER_GRAMMAR", 
		"TREE_GRAMMAR", "COMBINED_GRAMMAR", "INITACTION", "LABEL", "TEMPLATE", 
		"SCOPE", "SEMPRED", "GATED_SEMPRED", "SYN_SEMPRED", "BACKTRACK_SEMPRED", 
		"FRAGMENT", "TREE_BEGIN", "ROOT", "BANG", "REWRITE", "ACTION_CONTENT", 
		"SL_COMMENT", "ML_COMMENT", "INT", "CHAR_LITERAL", "STRING_LITERAL", "BEGIN_ARGUMENT", 
		"BEGIN_ACTION", "OPTIONS", "TOKENS", "HEADER", "CLASS", "EXTENDS", "LEXCLASS", 
		"TREEPARSER", "EXCEPTION", "CATCH", "FINALLY", "GRAMMAR", "PRIVATE", "PROTECTED", 
		"PUBLIC", "RETURNS", "THROWS", "TREE", "OPEN_ELEMENT_OPTION", "CLOSE_ELEMENT_OPTION", 
		"AT", "COLON", "COLONCOLON", "COMMA", "DOT", "EQUAL", "LBRACE", "LBRACK", 
		"LPAREN", "OR", "PLUS", "QM", "RBRACE", "RBRACK", "RPAREN", "SEMI", "SEMPREDOP", 
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

	public override string GrammarFileName { get { return "ANTLRv2Lexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static ANTLRv2Lexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	public override void Action(RuleContext _localctx, int ruleIndex, int actionIndex) {
		switch (ruleIndex) {
		case 10 : BEGIN_ARGUMENT_action(_localctx, actionIndex); break;
		case 120 : END_ARGUMENT_action(_localctx, actionIndex); break;
		case 130 : END_ACTION_action(_localctx, actionIndex); break;
		case 136 : OPT_LBRACE_action(_localctx, actionIndex); break;
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
		4,0,96,1117,6,-1,6,-1,6,-1,6,-1,6,-1,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,
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
		7,150,2,151,7,151,2,152,7,152,2,153,7,153,2,154,7,154,2,155,7,155,2,156,
		7,156,2,157,7,157,2,158,7,158,2,159,7,159,2,160,7,160,2,161,7,161,2,162,
		7,162,2,163,7,163,1,0,1,0,1,0,1,0,1,0,5,0,340,8,0,10,0,12,0,343,9,0,1,
		0,1,0,1,0,3,0,348,8,0,1,0,1,0,1,1,1,1,1,1,1,1,5,1,356,8,1,10,1,12,1,359,
		9,1,1,1,1,1,1,2,1,2,1,2,1,2,5,2,367,8,2,10,2,12,2,370,9,2,1,2,1,2,1,2,
		1,2,1,2,1,3,4,3,378,8,3,11,3,12,3,379,1,4,1,4,1,4,1,4,1,5,1,5,3,5,388,
		8,5,1,6,1,6,5,6,392,8,6,10,6,12,6,395,9,6,1,6,1,6,1,7,1,7,3,7,401,8,7,
		1,8,1,8,1,8,1,8,1,8,1,8,1,8,1,8,1,8,1,8,1,8,3,8,414,8,8,3,8,416,8,8,1,
		8,3,8,419,8,8,1,9,1,9,1,10,1,10,1,10,1,11,1,11,1,11,1,11,1,12,1,12,1,12,
		1,12,1,12,1,12,1,12,1,12,1,12,1,12,1,13,1,13,1,13,1,13,1,13,1,13,1,13,
		1,13,1,13,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,15,1,15,1,15,1,15,1,15,
		1,15,1,16,1,16,1,16,1,16,1,16,1,16,1,16,1,16,1,17,1,17,1,17,1,17,1,17,
		1,17,1,17,1,17,1,17,1,18,1,18,1,18,1,18,1,18,1,18,1,18,1,18,1,18,1,18,
		1,18,1,19,1,19,1,19,1,19,1,19,1,19,1,19,1,19,1,19,1,19,1,20,1,20,1,20,
		1,20,1,20,1,20,1,21,1,21,1,21,1,21,1,21,1,21,1,21,1,21,1,22,1,22,1,22,
		1,22,1,22,1,22,1,22,1,22,1,22,1,23,1,23,1,23,1,23,1,23,1,23,1,23,1,23,
		1,24,1,24,1,24,1,24,1,24,1,24,1,25,1,25,1,25,1,25,1,25,1,25,1,25,1,26,
		1,26,1,26,1,26,1,26,1,26,1,26,1,26,1,27,1,27,1,27,1,27,1,27,1,27,1,27,
		1,27,1,27,1,27,1,28,1,28,1,28,1,28,1,28,1,28,1,28,1,29,1,29,1,29,1,29,
		1,29,1,29,1,29,1,29,1,30,1,30,1,30,1,30,1,30,1,30,1,31,1,31,1,31,1,31,
		1,31,1,31,1,31,1,32,1,32,1,32,1,32,1,32,1,33,1,33,1,33,5,33,598,8,33,10,
		33,12,33,601,9,33,1,34,1,34,1,35,1,35,1,36,1,36,1,37,1,37,1,38,1,38,1,
		39,1,39,1,40,1,40,1,41,1,41,1,42,1,42,1,43,1,43,1,44,1,44,1,45,1,45,1,
		46,1,46,1,47,1,47,1,48,1,48,1,49,1,49,1,50,1,50,1,51,1,51,1,52,1,52,1,
		53,1,53,1,54,1,54,1,55,1,55,1,56,1,56,1,56,1,57,1,57,1,58,1,58,1,58,1,
		59,1,59,1,60,1,60,1,61,1,61,1,62,1,62,3,62,663,8,62,1,62,4,62,666,8,62,
		11,62,12,62,667,1,62,1,62,1,63,1,63,5,63,674,8,63,10,63,12,63,677,9,63,
		1,64,1,64,5,64,681,8,64,10,64,12,64,684,9,64,1,65,1,65,3,65,688,8,65,1,
		66,1,66,1,67,1,67,1,68,1,68,1,68,1,68,5,68,698,8,68,10,68,12,68,701,9,
		68,1,68,1,68,1,68,3,68,706,8,68,1,69,1,69,1,69,1,69,1,69,5,69,713,8,69,
		10,69,12,69,716,9,69,1,69,1,69,1,69,3,69,721,8,69,1,70,1,70,1,70,1,70,
		5,70,727,8,70,10,70,12,70,730,9,70,1,71,1,71,1,71,1,71,1,71,1,71,3,71,
		738,8,71,1,72,1,72,1,72,1,73,1,73,1,73,1,73,1,73,3,73,748,8,73,3,73,750,
		8,73,3,73,752,8,73,3,73,754,8,73,1,74,1,74,1,74,3,74,759,8,74,3,74,761,
		8,74,1,75,1,75,1,75,5,75,766,8,75,10,75,12,75,769,9,75,3,75,771,8,75,1,
		76,1,76,1,77,1,77,1,78,1,78,1,79,1,79,1,79,1,79,1,79,1,79,1,79,1,79,1,
		79,3,79,788,8,79,1,80,1,80,1,80,3,80,793,8,80,1,80,1,80,1,81,1,81,1,81,
		5,81,800,8,81,10,81,12,81,803,9,81,1,81,1,81,1,82,1,82,1,82,5,82,810,8,
		82,10,82,12,82,813,9,82,1,82,1,82,1,83,1,83,1,83,5,83,820,8,83,10,83,12,
		83,823,9,83,1,84,1,84,1,84,1,84,3,84,829,8,84,1,85,1,85,1,86,1,86,1,86,
		1,86,1,87,1,87,1,88,1,88,1,89,1,89,1,89,1,90,1,90,1,91,1,91,1,92,1,92,
		1,93,1,93,1,94,1,94,1,95,1,95,1,96,1,96,1,97,1,97,1,98,1,98,1,98,1,99,
		1,99,1,100,1,100,1,101,1,101,1,102,1,102,1,103,1,103,1,104,1,104,1,105,
		1,105,1,105,1,106,1,106,1,107,1,107,1,108,1,108,1,109,1,109,1,110,1,110,
		1,111,1,111,1,112,1,112,1,112,1,113,1,113,1,114,1,114,1,115,1,115,1,116,
		1,116,1,116,1,116,1,116,1,117,1,117,1,117,1,117,1,118,1,118,1,118,1,118,
		1,119,1,119,1,119,1,119,1,120,1,120,1,120,1,121,1,121,1,121,1,121,1,122,
		1,122,1,123,1,123,1,123,1,123,1,123,1,124,1,124,1,124,1,124,1,125,1,125,
		1,125,1,125,1,126,1,126,1,126,1,126,1,127,1,127,1,127,1,127,1,128,1,128,
		1,128,1,128,1,129,1,129,1,129,1,129,1,130,1,130,1,130,1,131,1,131,1,131,
		1,131,1,132,1,132,1,133,1,133,1,133,1,133,1,133,1,134,1,134,1,134,1,134,
		1,134,1,135,1,135,1,135,1,135,1,135,1,136,1,136,1,136,1,137,1,137,1,137,
		1,137,1,137,1,138,1,138,1,138,1,138,1,139,1,139,1,139,1,139,1,140,1,140,
		1,140,1,140,1,141,1,141,1,141,1,141,1,142,1,142,1,142,1,142,1,143,1,143,
		1,143,1,143,1,144,1,144,1,144,1,144,1,145,1,145,1,145,1,145,1,146,1,146,
		1,146,1,146,1,147,4,147,1023,8,147,11,147,12,147,1024,1,147,1,147,1,147,
		1,148,1,148,1,148,1,148,1,148,1,149,1,149,1,149,1,149,1,149,1,150,1,150,
		1,150,1,150,1,150,1,151,1,151,1,151,1,151,1,152,1,152,1,152,1,152,1,152,
		1,153,1,153,1,153,1,153,1,154,1,154,1,154,1,154,1,155,1,155,1,155,1,155,
		1,155,1,155,1,156,1,156,5,156,1070,8,156,10,156,12,156,1073,9,156,1,156,
		1,156,1,156,1,156,1,157,1,157,1,157,1,157,1,158,1,158,1,158,1,158,1,159,
		4,159,1088,8,159,11,159,12,159,1089,1,159,1,159,1,159,1,160,1,160,4,160,
		1097,8,160,11,160,12,160,1098,1,160,1,160,1,161,1,161,1,161,1,161,1,162,
		1,162,1,162,1,162,1,163,1,163,5,163,1113,8,163,10,163,12,163,1116,9,163,
		4,341,368,699,714,0,164,6,1,8,39,10,40,12,41,14,42,16,0,18,43,20,0,22,
		0,24,0,26,44,28,45,30,46,32,47,34,48,36,49,38,50,40,51,42,52,44,53,46,
		54,48,55,50,33,52,56,54,3,56,2,58,57,60,58,62,59,64,60,66,28,68,61,70,
		62,72,0,74,63,76,64,78,65,80,36,82,66,84,67,86,68,88,69,90,70,92,71,94,
		72,96,73,98,74,100,75,102,76,104,10,106,77,108,78,110,37,112,35,114,79,
		116,80,118,81,120,82,122,34,124,83,126,84,128,85,130,86,132,87,134,88,
		136,0,138,0,140,0,142,0,144,0,146,0,148,0,150,0,152,0,154,0,156,0,158,
		0,160,0,162,0,164,0,166,0,168,0,170,0,172,0,174,0,176,0,178,0,180,0,182,
		0,184,0,186,0,188,0,190,0,192,0,194,0,196,0,198,0,200,0,202,0,204,0,206,
		0,208,0,210,0,212,0,214,0,216,0,218,0,220,0,222,0,224,0,226,0,228,0,230,
		0,232,0,234,0,236,0,238,0,240,0,242,0,244,0,246,89,248,90,250,91,252,0,
		254,0,256,0,258,0,260,0,262,0,264,0,266,92,268,93,270,38,272,0,274,0,276,
		0,278,94,280,0,282,0,284,0,286,0,288,0,290,0,292,0,294,0,296,0,298,0,300,
		0,302,0,304,0,306,0,308,0,310,0,312,0,314,0,316,0,318,0,320,0,322,0,324,
		0,326,0,328,95,330,96,332,0,6,0,1,2,3,4,5,17,2,0,10,10,13,13,2,0,39,39,
		92,92,2,0,34,34,92,92,9,0,34,34,39,39,62,62,92,92,98,98,102,102,110,110,
		114,114,116,116,3,0,48,57,65,70,97,102,2,0,9,9,32,32,4,0,48,57,65,90,95,
		95,97,122,2,0,10,10,12,13,8,0,34,34,39,39,92,92,98,98,102,102,110,110,
		114,114,116,116,1,0,49,57,1,0,48,57,1,0,48,55,4,0,10,10,13,13,39,39,92,
		92,4,0,10,10,13,13,34,34,92,92,3,0,183,183,768,879,8255,8256,13,0,65,90,
		97,122,192,214,216,246,248,767,880,893,895,8191,8204,8205,8304,8591,11264,
		12271,12289,55295,63744,64975,65008,65533,1,0,92,93,1110,0,6,1,0,0,0,0,
		8,1,0,0,0,0,10,1,0,0,0,0,12,1,0,0,0,0,14,1,0,0,0,0,18,1,0,0,0,0,26,1,0,
		0,0,0,28,1,0,0,0,0,30,1,0,0,0,0,32,1,0,0,0,0,34,1,0,0,0,0,36,1,0,0,0,0,
		38,1,0,0,0,0,40,1,0,0,0,0,42,1,0,0,0,0,44,1,0,0,0,0,46,1,0,0,0,0,48,1,
		0,0,0,0,50,1,0,0,0,0,52,1,0,0,0,0,54,1,0,0,0,0,56,1,0,0,0,0,58,1,0,0,0,
		0,60,1,0,0,0,0,62,1,0,0,0,0,64,1,0,0,0,0,66,1,0,0,0,0,68,1,0,0,0,0,70,
		1,0,0,0,0,74,1,0,0,0,0,76,1,0,0,0,0,78,1,0,0,0,0,80,1,0,0,0,0,82,1,0,0,
		0,0,84,1,0,0,0,0,86,1,0,0,0,0,88,1,0,0,0,0,90,1,0,0,0,0,92,1,0,0,0,0,94,
		1,0,0,0,0,96,1,0,0,0,0,98,1,0,0,0,0,100,1,0,0,0,0,102,1,0,0,0,0,104,1,
		0,0,0,0,106,1,0,0,0,0,108,1,0,0,0,0,110,1,0,0,0,0,112,1,0,0,0,0,114,1,
		0,0,0,0,116,1,0,0,0,0,118,1,0,0,0,0,120,1,0,0,0,0,122,1,0,0,0,0,124,1,
		0,0,0,0,126,1,0,0,0,0,128,1,0,0,0,0,130,1,0,0,0,0,132,1,0,0,0,0,134,1,
		0,0,0,1,238,1,0,0,0,1,240,1,0,0,0,1,242,1,0,0,0,1,244,1,0,0,0,1,246,1,
		0,0,0,1,248,1,0,0,0,1,250,1,0,0,0,2,252,1,0,0,0,2,254,1,0,0,0,2,256,1,
		0,0,0,2,258,1,0,0,0,2,260,1,0,0,0,2,262,1,0,0,0,2,264,1,0,0,0,2,266,1,
		0,0,0,2,268,1,0,0,0,2,270,1,0,0,0,3,272,1,0,0,0,3,274,1,0,0,0,3,276,1,
		0,0,0,3,278,1,0,0,0,3,280,1,0,0,0,3,282,1,0,0,0,3,284,1,0,0,0,3,286,1,
		0,0,0,3,288,1,0,0,0,3,290,1,0,0,0,3,292,1,0,0,0,3,294,1,0,0,0,3,296,1,
		0,0,0,3,298,1,0,0,0,3,300,1,0,0,0,4,302,1,0,0,0,4,304,1,0,0,0,4,306,1,
		0,0,0,4,308,1,0,0,0,4,310,1,0,0,0,4,312,1,0,0,0,4,314,1,0,0,0,4,316,1,
		0,0,0,4,318,1,0,0,0,4,320,1,0,0,0,4,322,1,0,0,0,4,324,1,0,0,0,5,326,1,
		0,0,0,5,328,1,0,0,0,5,330,1,0,0,0,6,334,1,0,0,0,8,351,1,0,0,0,10,362,1,
		0,0,0,12,377,1,0,0,0,14,381,1,0,0,0,16,387,1,0,0,0,18,389,1,0,0,0,20,400,
		1,0,0,0,22,402,1,0,0,0,24,420,1,0,0,0,26,422,1,0,0,0,28,425,1,0,0,0,30,
		429,1,0,0,0,32,439,1,0,0,0,34,448,1,0,0,0,36,455,1,0,0,0,38,461,1,0,0,
		0,40,469,1,0,0,0,42,478,1,0,0,0,44,489,1,0,0,0,46,499,1,0,0,0,48,505,1,
		0,0,0,50,513,1,0,0,0,52,522,1,0,0,0,54,530,1,0,0,0,56,536,1,0,0,0,58,543,
		1,0,0,0,60,551,1,0,0,0,62,561,1,0,0,0,64,568,1,0,0,0,66,576,1,0,0,0,68,
		582,1,0,0,0,70,589,1,0,0,0,72,599,1,0,0,0,74,602,1,0,0,0,76,604,1,0,0,
		0,78,606,1,0,0,0,80,608,1,0,0,0,82,610,1,0,0,0,84,612,1,0,0,0,86,614,1,
		0,0,0,88,616,1,0,0,0,90,618,1,0,0,0,92,620,1,0,0,0,94,622,1,0,0,0,96,624,
		1,0,0,0,98,626,1,0,0,0,100,628,1,0,0,0,102,630,1,0,0,0,104,632,1,0,0,0,
		106,634,1,0,0,0,108,636,1,0,0,0,110,638,1,0,0,0,112,640,1,0,0,0,114,642,
		1,0,0,0,116,644,1,0,0,0,118,646,1,0,0,0,120,649,1,0,0,0,122,651,1,0,0,
		0,124,654,1,0,0,0,126,656,1,0,0,0,128,658,1,0,0,0,130,665,1,0,0,0,132,
		671,1,0,0,0,134,678,1,0,0,0,136,687,1,0,0,0,138,689,1,0,0,0,140,691,1,
		0,0,0,142,693,1,0,0,0,144,707,1,0,0,0,146,722,1,0,0,0,148,731,1,0,0,0,
		150,739,1,0,0,0,152,742,1,0,0,0,154,755,1,0,0,0,156,770,1,0,0,0,158,772,
		1,0,0,0,160,774,1,0,0,0,162,776,1,0,0,0,164,787,1,0,0,0,166,789,1,0,0,
		0,168,796,1,0,0,0,170,806,1,0,0,0,172,816,1,0,0,0,174,828,1,0,0,0,176,
		830,1,0,0,0,178,832,1,0,0,0,180,836,1,0,0,0,182,838,1,0,0,0,184,840,1,
		0,0,0,186,843,1,0,0,0,188,845,1,0,0,0,190,847,1,0,0,0,192,849,1,0,0,0,
		194,851,1,0,0,0,196,853,1,0,0,0,198,855,1,0,0,0,200,857,1,0,0,0,202,859,
		1,0,0,0,204,862,1,0,0,0,206,864,1,0,0,0,208,866,1,0,0,0,210,868,1,0,0,
		0,212,870,1,0,0,0,214,872,1,0,0,0,216,874,1,0,0,0,218,877,1,0,0,0,220,
		879,1,0,0,0,222,881,1,0,0,0,224,883,1,0,0,0,226,885,1,0,0,0,228,887,1,
		0,0,0,230,889,1,0,0,0,232,892,1,0,0,0,234,894,1,0,0,0,236,896,1,0,0,0,
		238,898,1,0,0,0,240,903,1,0,0,0,242,907,1,0,0,0,244,911,1,0,0,0,246,915,
		1,0,0,0,248,918,1,0,0,0,250,922,1,0,0,0,252,924,1,0,0,0,254,929,1,0,0,
		0,256,933,1,0,0,0,258,937,1,0,0,0,260,941,1,0,0,0,262,945,1,0,0,0,264,
		949,1,0,0,0,266,953,1,0,0,0,268,956,1,0,0,0,270,960,1,0,0,0,272,962,1,
		0,0,0,274,967,1,0,0,0,276,972,1,0,0,0,278,977,1,0,0,0,280,980,1,0,0,0,
		282,985,1,0,0,0,284,989,1,0,0,0,286,993,1,0,0,0,288,997,1,0,0,0,290,1001,
		1,0,0,0,292,1005,1,0,0,0,294,1009,1,0,0,0,296,1013,1,0,0,0,298,1017,1,
		0,0,0,300,1022,1,0,0,0,302,1029,1,0,0,0,304,1034,1,0,0,0,306,1039,1,0,
		0,0,308,1044,1,0,0,0,310,1048,1,0,0,0,312,1053,1,0,0,0,314,1057,1,0,0,
		0,316,1061,1,0,0,0,318,1067,1,0,0,0,320,1078,1,0,0,0,322,1082,1,0,0,0,
		324,1087,1,0,0,0,326,1096,1,0,0,0,328,1102,1,0,0,0,330,1106,1,0,0,0,332,
		1110,1,0,0,0,334,335,5,47,0,0,335,336,5,42,0,0,336,337,5,42,0,0,337,341,
		1,0,0,0,338,340,9,0,0,0,339,338,1,0,0,0,340,343,1,0,0,0,341,342,1,0,0,
		0,341,339,1,0,0,0,342,347,1,0,0,0,343,341,1,0,0,0,344,345,5,42,0,0,345,
		348,5,47,0,0,346,348,5,0,0,1,347,344,1,0,0,0,347,346,1,0,0,0,348,349,1,
		0,0,0,349,350,6,0,0,0,350,7,1,0,0,0,351,352,5,47,0,0,352,353,5,47,0,0,
		353,357,1,0,0,0,354,356,8,0,0,0,355,354,1,0,0,0,356,359,1,0,0,0,357,355,
		1,0,0,0,357,358,1,0,0,0,358,360,1,0,0,0,359,357,1,0,0,0,360,361,6,1,0,
		0,361,9,1,0,0,0,362,363,5,47,0,0,363,364,5,42,0,0,364,368,1,0,0,0,365,
		367,9,0,0,0,366,365,1,0,0,0,367,370,1,0,0,0,368,369,1,0,0,0,368,366,1,
		0,0,0,369,371,1,0,0,0,370,368,1,0,0,0,371,372,5,42,0,0,372,373,5,47,0,
		0,373,374,1,0,0,0,374,375,6,2,0,0,375,11,1,0,0,0,376,378,2,48,57,0,377,
		376,1,0,0,0,378,379,1,0,0,0,379,377,1,0,0,0,379,380,1,0,0,0,380,13,1,0,
		0,0,381,382,5,39,0,0,382,383,3,16,5,0,383,384,5,39,0,0,384,15,1,0,0,0,
		385,388,3,22,8,0,386,388,8,1,0,0,387,385,1,0,0,0,387,386,1,0,0,0,388,17,
		1,0,0,0,389,393,5,34,0,0,390,392,3,20,7,0,391,390,1,0,0,0,392,395,1,0,
		0,0,393,391,1,0,0,0,393,394,1,0,0,0,394,396,1,0,0,0,395,393,1,0,0,0,396,
		397,5,34,0,0,397,19,1,0,0,0,398,401,3,22,8,0,399,401,8,2,0,0,400,398,1,
		0,0,0,400,399,1,0,0,0,401,21,1,0,0,0,402,418,5,92,0,0,403,419,7,3,0,0,
		404,405,5,117,0,0,405,406,3,24,9,0,406,407,3,24,9,0,407,408,3,24,9,0,408,
		409,3,24,9,0,409,419,1,0,0,0,410,415,3,162,78,0,411,413,3,162,78,0,412,
		414,3,162,78,0,413,412,1,0,0,0,413,414,1,0,0,0,414,416,1,0,0,0,415,411,
		1,0,0,0,415,416,1,0,0,0,416,419,1,0,0,0,417,419,9,0,0,0,418,403,1,0,0,
		0,418,404,1,0,0,0,418,410,1,0,0,0,418,417,1,0,0,0,419,23,1,0,0,0,420,421,
		7,4,0,0,421,25,1,0,0,0,422,423,3,198,96,0,423,424,6,10,1,0,424,27,1,0,
		0,0,425,426,3,194,94,0,426,427,1,0,0,0,427,428,6,11,2,0,428,29,1,0,0,0,
		429,430,5,111,0,0,430,431,5,112,0,0,431,432,5,116,0,0,432,433,5,105,0,
		0,433,434,5,111,0,0,434,435,5,110,0,0,435,436,5,115,0,0,436,437,1,0,0,
		0,437,438,6,12,3,0,438,31,1,0,0,0,439,440,5,116,0,0,440,441,5,111,0,0,
		441,442,5,107,0,0,442,443,5,101,0,0,443,444,5,110,0,0,444,445,5,115,0,
		0,445,446,1,0,0,0,446,447,6,13,4,0,447,33,1,0,0,0,448,449,5,104,0,0,449,
		450,5,101,0,0,450,451,5,97,0,0,451,452,5,100,0,0,452,453,5,101,0,0,453,
		454,5,114,0,0,454,35,1,0,0,0,455,456,5,99,0,0,456,457,5,108,0,0,457,458,
		5,97,0,0,458,459,5,115,0,0,459,460,5,115,0,0,460,37,1,0,0,0,461,462,5,
		101,0,0,462,463,5,120,0,0,463,464,5,116,0,0,464,465,5,101,0,0,465,466,
		5,110,0,0,466,467,5,100,0,0,467,468,5,115,0,0,468,39,1,0,0,0,469,470,5,
		108,0,0,470,471,5,101,0,0,471,472,5,120,0,0,472,473,5,99,0,0,473,474,5,
		108,0,0,474,475,5,97,0,0,475,476,5,115,0,0,476,477,5,115,0,0,477,41,1,
		0,0,0,478,479,5,116,0,0,479,480,5,114,0,0,480,481,5,101,0,0,481,482,5,
		101,0,0,482,483,5,112,0,0,483,484,5,97,0,0,484,485,5,114,0,0,485,486,5,
		115,0,0,486,487,5,101,0,0,487,488,5,114,0,0,488,43,1,0,0,0,489,490,5,101,
		0,0,490,491,5,120,0,0,491,492,5,99,0,0,492,493,5,101,0,0,493,494,5,112,
		0,0,494,495,5,116,0,0,495,496,5,105,0,0,496,497,5,111,0,0,497,498,5,110,
		0,0,498,45,1,0,0,0,499,500,5,99,0,0,500,501,5,97,0,0,501,502,5,116,0,0,
		502,503,5,99,0,0,503,504,5,104,0,0,504,47,1,0,0,0,505,506,5,102,0,0,506,
		507,5,105,0,0,507,508,5,110,0,0,508,509,5,97,0,0,509,510,5,108,0,0,510,
		511,5,108,0,0,511,512,5,121,0,0,512,49,1,0,0,0,513,514,5,102,0,0,514,515,
		5,114,0,0,515,516,5,97,0,0,516,517,5,103,0,0,517,518,5,109,0,0,518,519,
		5,101,0,0,519,520,5,110,0,0,520,521,5,116,0,0,521,51,1,0,0,0,522,523,5,
		103,0,0,523,524,5,114,0,0,524,525,5,97,0,0,525,526,5,109,0,0,526,527,5,
		109,0,0,527,528,5,97,0,0,528,529,5,114,0,0,529,53,1,0,0,0,530,531,5,76,
		0,0,531,532,5,101,0,0,532,533,5,120,0,0,533,534,5,101,0,0,534,535,5,114,
		0,0,535,55,1,0,0,0,536,537,5,80,0,0,537,538,5,97,0,0,538,539,5,114,0,0,
		539,540,5,115,0,0,540,541,5,101,0,0,541,542,5,114,0,0,542,57,1,0,0,0,543,
		544,5,112,0,0,544,545,5,114,0,0,545,546,5,105,0,0,546,547,5,118,0,0,547,
		548,5,97,0,0,548,549,5,116,0,0,549,550,5,101,0,0,550,59,1,0,0,0,551,552,
		5,112,0,0,552,553,5,114,0,0,553,554,5,111,0,0,554,555,5,116,0,0,555,556,
		5,101,0,0,556,557,5,99,0,0,557,558,5,116,0,0,558,559,5,101,0,0,559,560,
		5,100,0,0,560,61,1,0,0,0,561,562,5,112,0,0,562,563,5,117,0,0,563,564,5,
		98,0,0,564,565,5,108,0,0,565,566,5,105,0,0,566,567,5,99,0,0,567,63,1,0,
		0,0,568,569,5,114,0,0,569,570,5,101,0,0,570,571,5,116,0,0,571,572,5,117,
		0,0,572,573,5,114,0,0,573,574,5,110,0,0,574,575,5,115,0,0,575,65,1,0,0,
		0,576,577,5,115,0,0,577,578,5,99,0,0,578,579,5,111,0,0,579,580,5,112,0,
		0,580,581,5,101,0,0,581,67,1,0,0,0,582,583,5,116,0,0,583,584,5,104,0,0,
		584,585,5,114,0,0,585,586,5,111,0,0,586,587,5,119,0,0,587,588,5,115,0,
		0,588,69,1,0,0,0,589,590,5,116,0,0,590,591,5,114,0,0,591,592,5,101,0,0,
		592,593,5,101,0,0,593,71,1,0,0,0,594,598,3,130,62,0,595,598,3,8,1,0,596,
		598,3,10,2,0,597,594,1,0,0,0,597,595,1,0,0,0,597,596,1,0,0,0,598,601,1,
		0,0,0,599,597,1,0,0,0,599,600,1,0,0,0,600,73,1,0,0,0,601,599,1,0,0,0,602,
		603,3,204,99,0,603,75,1,0,0,0,604,605,3,206,100,0,605,77,1,0,0,0,606,607,
		3,232,113,0,607,79,1,0,0,0,608,609,5,33,0,0,609,81,1,0,0,0,610,611,3,182,
		88,0,611,83,1,0,0,0,612,613,3,184,89,0,613,85,1,0,0,0,614,615,3,224,109,
		0,615,87,1,0,0,0,616,617,3,228,111,0,617,89,1,0,0,0,618,619,3,208,101,
		0,619,91,1,0,0,0,620,621,3,194,94,0,621,93,1,0,0,0,622,623,3,198,96,0,
		623,95,1,0,0,0,624,625,3,190,92,0,625,97,1,0,0,0,626,627,3,220,107,0,627,
		99,1,0,0,0,628,629,3,214,104,0,629,101,1,0,0,0,630,631,3,210,102,0,631,
		103,1,0,0,0,632,633,3,230,112,0,633,105,1,0,0,0,634,635,3,196,95,0,635,
		107,1,0,0,0,636,637,3,200,97,0,637,109,1,0,0,0,638,639,3,202,98,0,639,
		111,1,0,0,0,640,641,5,94,0,0,641,113,1,0,0,0,642,643,3,192,93,0,643,115,
		1,0,0,0,644,645,3,226,110,0,645,117,1,0,0,0,646,647,5,61,0,0,647,648,5,
		62,0,0,648,119,1,0,0,0,649,650,3,212,103,0,650,121,1,0,0,0,651,652,5,94,
		0,0,652,653,5,40,0,0,653,123,1,0,0,0,654,655,3,222,108,0,655,125,1,0,0,
		0,656,657,3,216,105,0,657,127,1,0,0,0,658,659,3,236,115,0,659,129,1,0,
		0,0,660,666,7,5,0,0,661,663,5,13,0,0,662,661,1,0,0,0,662,663,1,0,0,0,663,
		664,1,0,0,0,664,666,5,10,0,0,665,660,1,0,0,0,665,662,1,0,0,0,666,667,1,
		0,0,0,667,665,1,0,0,0,667,668,1,0,0,0,668,669,1,0,0,0,669,670,6,62,0,0,
		670,131,1,0,0,0,671,675,2,65,90,0,672,674,7,6,0,0,673,672,1,0,0,0,674,
		677,1,0,0,0,675,673,1,0,0,0,675,676,1,0,0,0,676,133,1,0,0,0,677,675,1,
		0,0,0,678,682,2,97,122,0,679,681,7,6,0,0,680,679,1,0,0,0,681,684,1,0,0,
		0,682,680,1,0,0,0,682,683,1,0,0,0,683,135,1,0,0,0,684,682,1,0,0,0,685,
		688,3,138,66,0,686,688,3,140,67,0,687,685,1,0,0,0,687,686,1,0,0,0,688,
		137,1,0,0,0,689,690,7,5,0,0,690,139,1,0,0,0,691,692,7,7,0,0,692,141,1,
		0,0,0,693,694,5,47,0,0,694,695,5,42,0,0,695,699,1,0,0,0,696,698,9,0,0,
		0,697,696,1,0,0,0,698,701,1,0,0,0,699,700,1,0,0,0,699,697,1,0,0,0,700,
		705,1,0,0,0,701,699,1,0,0,0,702,703,5,42,0,0,703,706,5,47,0,0,704,706,
		5,0,0,1,705,702,1,0,0,0,705,704,1,0,0,0,706,143,1,0,0,0,707,708,5,47,0,
		0,708,709,5,42,0,0,709,710,5,42,0,0,710,714,1,0,0,0,711,713,9,0,0,0,712,
		711,1,0,0,0,713,716,1,0,0,0,714,715,1,0,0,0,714,712,1,0,0,0,715,720,1,
		0,0,0,716,714,1,0,0,0,717,718,5,42,0,0,718,721,5,47,0,0,719,721,5,0,0,
		1,720,717,1,0,0,0,720,719,1,0,0,0,721,145,1,0,0,0,722,723,5,47,0,0,723,
		724,5,47,0,0,724,728,1,0,0,0,725,727,8,0,0,0,726,725,1,0,0,0,727,730,1,
		0,0,0,728,726,1,0,0,0,728,729,1,0,0,0,729,147,1,0,0,0,730,728,1,0,0,0,
		731,737,3,180,87,0,732,738,7,8,0,0,733,738,3,152,73,0,734,738,3,154,74,
		0,735,738,9,0,0,0,736,738,5,0,0,1,737,732,1,0,0,0,737,733,1,0,0,0,737,
		734,1,0,0,0,737,735,1,0,0,0,737,736,1,0,0,0,738,149,1,0,0,0,739,740,3,
		180,87,0,740,741,9,0,0,0,741,151,1,0,0,0,742,753,5,117,0,0,743,751,3,158,
		76,0,744,749,3,158,76,0,745,747,3,158,76,0,746,748,3,158,76,0,747,746,
		1,0,0,0,747,748,1,0,0,0,748,750,1,0,0,0,749,745,1,0,0,0,749,750,1,0,0,
		0,750,752,1,0,0,0,751,744,1,0,0,0,751,752,1,0,0,0,752,754,1,0,0,0,753,
		743,1,0,0,0,753,754,1,0,0,0,754,153,1,0,0,0,755,760,3,162,78,0,756,758,
		3,162,78,0,757,759,3,162,78,0,758,757,1,0,0,0,758,759,1,0,0,0,759,761,
		1,0,0,0,760,756,1,0,0,0,760,761,1,0,0,0,761,155,1,0,0,0,762,771,5,48,0,
		0,763,767,7,9,0,0,764,766,3,160,77,0,765,764,1,0,0,0,766,769,1,0,0,0,767,
		765,1,0,0,0,767,768,1,0,0,0,768,771,1,0,0,0,769,767,1,0,0,0,770,762,1,
		0,0,0,770,763,1,0,0,0,771,157,1,0,0,0,772,773,7,4,0,0,773,159,1,0,0,0,
		774,775,7,10,0,0,775,161,1,0,0,0,776,777,7,11,0,0,777,163,1,0,0,0,778,
		779,5,116,0,0,779,780,5,114,0,0,780,781,5,117,0,0,781,788,5,101,0,0,782,
		783,5,102,0,0,783,784,5,97,0,0,784,785,5,108,0,0,785,786,5,115,0,0,786,
		788,5,101,0,0,787,778,1,0,0,0,787,782,1,0,0,0,788,165,1,0,0,0,789,792,
		3,186,90,0,790,793,3,148,71,0,791,793,8,12,0,0,792,790,1,0,0,0,792,791,
		1,0,0,0,793,794,1,0,0,0,794,795,3,186,90,0,795,167,1,0,0,0,796,801,3,186,
		90,0,797,800,3,148,71,0,798,800,8,12,0,0,799,797,1,0,0,0,799,798,1,0,0,
		0,800,803,1,0,0,0,801,799,1,0,0,0,801,802,1,0,0,0,802,804,1,0,0,0,803,
		801,1,0,0,0,804,805,3,186,90,0,805,169,1,0,0,0,806,811,3,188,91,0,807,
		810,3,148,71,0,808,810,8,13,0,0,809,807,1,0,0,0,809,808,1,0,0,0,810,813,
		1,0,0,0,811,809,1,0,0,0,811,812,1,0,0,0,812,814,1,0,0,0,813,811,1,0,0,
		0,814,815,3,188,91,0,815,171,1,0,0,0,816,821,3,186,90,0,817,820,3,148,
		71,0,818,820,8,12,0,0,819,817,1,0,0,0,819,818,1,0,0,0,820,823,1,0,0,0,
		821,819,1,0,0,0,821,822,1,0,0,0,822,173,1,0,0,0,823,821,1,0,0,0,824,829,
		3,176,85,0,825,829,2,48,57,0,826,829,3,218,106,0,827,829,7,14,0,0,828,
		824,1,0,0,0,828,825,1,0,0,0,828,826,1,0,0,0,828,827,1,0,0,0,829,175,1,
		0,0,0,830,831,7,15,0,0,831,177,1,0,0,0,832,833,5,105,0,0,833,834,5,110,
		0,0,834,835,5,116,0,0,835,179,1,0,0,0,836,837,5,92,0,0,837,181,1,0,0,0,
		838,839,5,58,0,0,839,183,1,0,0,0,840,841,5,58,0,0,841,842,5,58,0,0,842,
		185,1,0,0,0,843,844,5,39,0,0,844,187,1,0,0,0,845,846,5,34,0,0,846,189,
		1,0,0,0,847,848,5,40,0,0,848,191,1,0,0,0,849,850,5,41,0,0,850,193,1,0,
		0,0,851,852,5,123,0,0,852,195,1,0,0,0,853,854,5,125,0,0,854,197,1,0,0,
		0,855,856,5,91,0,0,856,199,1,0,0,0,857,858,5,93,0,0,858,201,1,0,0,0,859,
		860,5,45,0,0,860,861,5,62,0,0,861,203,1,0,0,0,862,863,5,60,0,0,863,205,
		1,0,0,0,864,865,5,62,0,0,865,207,1,0,0,0,866,867,5,61,0,0,867,209,1,0,
		0,0,868,869,5,63,0,0,869,211,1,0,0,0,870,871,5,42,0,0,871,213,1,0,0,0,
		872,873,5,43,0,0,873,215,1,0,0,0,874,875,5,43,0,0,875,876,5,61,0,0,876,
		217,1,0,0,0,877,878,5,95,0,0,878,219,1,0,0,0,879,880,5,124,0,0,880,221,
		1,0,0,0,881,882,5,36,0,0,882,223,1,0,0,0,883,884,5,44,0,0,884,225,1,0,
		0,0,885,886,5,59,0,0,886,227,1,0,0,0,887,888,5,46,0,0,888,229,1,0,0,0,
		889,890,5,46,0,0,890,891,5,46,0,0,891,231,1,0,0,0,892,893,5,64,0,0,893,
		233,1,0,0,0,894,895,5,35,0,0,895,235,1,0,0,0,896,897,5,126,0,0,897,237,
		1,0,0,0,898,899,3,198,96,0,899,900,1,0,0,0,900,901,6,116,5,0,901,902,6,
		116,6,0,902,239,1,0,0,0,903,904,3,150,72,0,904,905,1,0,0,0,905,906,6,117,
		5,0,906,241,1,0,0,0,907,908,3,170,82,0,908,909,1,0,0,0,909,910,6,118,5,
		0,910,243,1,0,0,0,911,912,3,168,81,0,912,913,1,0,0,0,913,914,6,119,5,0,
		914,245,1,0,0,0,915,916,3,200,97,0,916,917,6,120,7,0,917,247,1,0,0,0,918,
		919,5,0,0,1,919,920,1,0,0,0,920,921,6,121,8,0,921,249,1,0,0,0,922,923,
		9,0,0,0,923,251,1,0,0,0,924,925,3,194,94,0,925,926,1,0,0,0,926,927,6,123,
		9,0,927,928,6,123,2,0,928,253,1,0,0,0,929,930,3,150,72,0,930,931,1,0,0,
		0,931,932,6,124,9,0,932,255,1,0,0,0,933,934,3,170,82,0,934,935,1,0,0,0,
		935,936,6,125,9,0,936,257,1,0,0,0,937,938,3,168,81,0,938,939,1,0,0,0,939,
		940,6,126,9,0,940,259,1,0,0,0,941,942,3,144,69,0,942,943,1,0,0,0,943,944,
		6,127,9,0,944,261,1,0,0,0,945,946,3,142,68,0,946,947,1,0,0,0,947,948,6,
		128,9,0,948,263,1,0,0,0,949,950,3,146,70,0,950,951,1,0,0,0,951,952,6,129,
		9,0,952,265,1,0,0,0,953,954,3,196,95,0,954,955,6,130,10,0,955,267,1,0,
		0,0,956,957,5,0,0,1,957,958,1,0,0,0,958,959,6,131,8,0,959,269,1,0,0,0,
		960,961,9,0,0,0,961,271,1,0,0,0,962,963,3,144,69,0,963,964,1,0,0,0,964,
		965,6,133,11,0,965,966,6,133,0,0,966,273,1,0,0,0,967,968,3,142,68,0,968,
		969,1,0,0,0,969,970,6,134,12,0,970,971,6,134,0,0,971,275,1,0,0,0,972,973,
		3,146,70,0,973,974,1,0,0,0,974,975,6,135,13,0,975,976,6,135,0,0,976,277,
		1,0,0,0,977,978,3,194,94,0,978,979,6,136,14,0,979,279,1,0,0,0,980,981,
		3,196,95,0,981,982,1,0,0,0,982,983,6,137,15,0,983,984,6,137,8,0,984,281,
		1,0,0,0,985,986,3,332,163,0,986,987,1,0,0,0,987,988,6,138,16,0,988,283,
		1,0,0,0,989,990,3,228,111,0,990,991,1,0,0,0,991,992,6,139,17,0,992,285,
		1,0,0,0,993,994,3,208,101,0,994,995,1,0,0,0,995,996,6,140,18,0,996,287,
		1,0,0,0,997,998,3,168,81,0,998,999,1,0,0,0,999,1000,6,141,19,0,1000,289,
		1,0,0,0,1001,1002,3,170,82,0,1002,1003,1,0,0,0,1003,1004,6,142,20,0,1004,
		291,1,0,0,0,1005,1006,3,230,112,0,1006,1007,1,0,0,0,1007,1008,6,143,21,
		0,1008,293,1,0,0,0,1009,1010,3,156,75,0,1010,1011,1,0,0,0,1011,1012,6,
		144,22,0,1012,295,1,0,0,0,1013,1014,3,212,103,0,1014,1015,1,0,0,0,1015,
		1016,6,145,23,0,1016,297,1,0,0,0,1017,1018,3,226,110,0,1018,1019,1,0,0,
		0,1019,1020,6,146,24,0,1020,299,1,0,0,0,1021,1023,3,136,65,0,1022,1021,
		1,0,0,0,1023,1024,1,0,0,0,1024,1022,1,0,0,0,1024,1025,1,0,0,0,1025,1026,
		1,0,0,0,1026,1027,6,147,25,0,1027,1028,6,147,0,0,1028,301,1,0,0,0,1029,
		1030,3,144,69,0,1030,1031,1,0,0,0,1031,1032,6,148,11,0,1032,1033,6,148,
		0,0,1033,303,1,0,0,0,1034,1035,3,142,68,0,1035,1036,1,0,0,0,1036,1037,
		6,149,12,0,1037,1038,6,149,0,0,1038,305,1,0,0,0,1039,1040,3,146,70,0,1040,
		1041,1,0,0,0,1041,1042,6,150,13,0,1042,1043,6,150,0,0,1043,307,1,0,0,0,
		1044,1045,3,194,94,0,1045,1046,1,0,0,0,1046,1047,6,151,26,0,1047,309,1,
		0,0,0,1048,1049,3,196,95,0,1049,1050,1,0,0,0,1050,1051,6,152,15,0,1051,
		1052,6,152,8,0,1052,311,1,0,0,0,1053,1054,3,332,163,0,1054,1055,1,0,0,
		0,1055,1056,6,153,27,0,1056,313,1,0,0,0,1057,1058,3,208,101,0,1058,1059,
		1,0,0,0,1059,1060,6,154,18,0,1060,315,1,0,0,0,1061,1062,5,39,0,0,1062,
		1063,3,16,5,0,1063,1064,5,39,0,0,1064,1065,1,0,0,0,1065,1066,6,155,19,
		0,1066,317,1,0,0,0,1067,1071,5,34,0,0,1068,1070,3,20,7,0,1069,1068,1,0,
		0,0,1070,1073,1,0,0,0,1071,1069,1,0,0,0,1071,1072,1,0,0,0,1072,1074,1,
		0,0,0,1073,1071,1,0,0,0,1074,1075,5,34,0,0,1075,1076,1,0,0,0,1076,1077,
		6,156,20,0,1077,319,1,0,0,0,1078,1079,3,226,110,0,1079,1080,1,0,0,0,1080,
		1081,6,157,24,0,1081,321,1,0,0,0,1082,1083,3,230,112,0,1083,1084,1,0,0,
		0,1084,1085,6,158,21,0,1085,323,1,0,0,0,1086,1088,3,136,65,0,1087,1086,
		1,0,0,0,1088,1089,1,0,0,0,1089,1087,1,0,0,0,1089,1090,1,0,0,0,1090,1091,
		1,0,0,0,1091,1092,6,159,25,0,1092,1093,6,159,0,0,1093,325,1,0,0,0,1094,
		1097,8,16,0,0,1095,1097,3,150,72,0,1096,1094,1,0,0,0,1096,1095,1,0,0,0,
		1097,1098,1,0,0,0,1098,1096,1,0,0,0,1098,1099,1,0,0,0,1099,1100,1,0,0,
		0,1100,1101,6,160,28,0,1101,327,1,0,0,0,1102,1103,3,200,97,0,1103,1104,
		1,0,0,0,1104,1105,6,161,8,0,1105,329,1,0,0,0,1106,1107,5,0,0,1,1107,1108,
		1,0,0,0,1108,1109,6,162,8,0,1109,331,1,0,0,0,1110,1114,3,176,85,0,1111,
		1113,3,174,84,0,1112,1111,1,0,0,0,1113,1116,1,0,0,0,1114,1112,1,0,0,0,
		1114,1115,1,0,0,0,1115,333,1,0,0,0,1116,1114,1,0,0,0,54,0,1,2,3,4,5,341,
		347,357,368,379,387,393,400,413,415,418,597,599,662,665,667,675,682,687,
		699,705,714,720,728,737,747,749,751,753,758,760,767,770,787,792,799,801,
		809,811,819,821,828,1024,1071,1089,1096,1098,1114,29,0,2,0,1,10,0,5,2,
		0,5,3,0,5,4,0,7,91,0,5,1,0,1,120,1,4,0,0,7,38,0,1,130,2,7,1,0,7,40,0,7,
		39,0,1,136,3,7,77,0,7,17,0,7,69,0,7,70,0,7,42,0,7,43,0,7,10,0,7,41,0,7,
		82,0,7,80,0,7,86,0,7,71,0,7,87,0,3,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace LanguageServer

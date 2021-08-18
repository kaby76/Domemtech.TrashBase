//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from PestLexer.g4 by ANTLR 4.9.2

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

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
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

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static PestLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\'', '\x11B', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', '\x1F', '\x4', 
		' ', '\t', ' ', '\x4', '!', '\t', '!', '\x4', '\"', '\t', '\"', '\x4', 
		'#', '\t', '#', '\x4', '$', '\t', '$', '\x4', '%', '\t', '%', '\x4', '&', 
		'\t', '&', '\x4', '\'', '\t', '\'', '\x4', '(', '\t', '(', '\x4', ')', 
		'\t', ')', '\x4', '*', '\t', '*', '\x4', '+', '\t', '+', '\x4', ',', '\t', 
		',', '\x4', '-', '\t', '-', '\x3', '\x2', '\x3', '\x2', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', 
		'\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\b', '\x3', 
		'\b', '\x3', '\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', '\x3', '\v', 
		'\x3', '\v', '\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', '\x3', 
		'\xE', '\x3', '\xE', '\x3', '\xF', '\x3', '\xF', '\x3', '\x10', '\x3', 
		'\x10', '\x3', '\x11', '\x3', '\x11', '\x3', '\x12', '\x3', '\x12', '\x3', 
		'\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', 
		'\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', 
		'\x15', '\x6', '\x15', '\x89', '\n', '\x15', '\r', '\x15', '\xE', '\x15', 
		'\x8A', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\a', '\x16', '\x90', 
		'\n', '\x16', '\f', '\x16', '\xE', '\x16', '\x93', '\v', '\x16', '\x3', 
		'\x16', '\x3', '\x16', '\x5', '\x16', '\x97', '\n', '\x16', '\x5', '\x16', 
		'\x99', '\n', '\x16', '\x3', '\x17', '\x3', '\x17', '\x3', '\x18', '\x3', 
		'\x18', '\x5', '\x18', '\x9F', '\n', '\x18', '\x3', '\x18', '\x3', '\x18', 
		'\a', '\x18', '\xA3', '\n', '\x18', '\f', '\x18', '\xE', '\x18', '\xA6', 
		'\v', '\x18', '\x3', '\x19', '\x3', '\x19', '\x3', '\x1A', '\x3', '\x1A', 
		'\x5', '\x1A', '\xAC', '\n', '\x1A', '\x3', '\x1B', '\x3', '\x1B', '\x3', 
		'\x1B', '\a', '\x1B', '\xB1', '\n', '\x1B', '\f', '\x1B', '\xE', '\x1B', 
		'\xB4', '\v', '\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1C', '\x3', 
		'\x1C', '\x3', '\x1C', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', 
		'\x1D', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1E', '\x3', 
		'\x1F', '\x3', '\x1F', '\x5', '\x1F', '\xC5', '\n', '\x1F', '\x3', ' ', 
		'\x3', ' ', '\x5', ' ', '\xC9', '\n', ' ', '\x3', '!', '\x3', '!', '\x3', 
		'!', '\x3', '!', '\x5', '!', '\xCF', '\n', '!', '\x3', '\"', '\x3', '\"', 
		'\x3', '\"', '\x3', '\"', '\x3', '#', '\x3', '#', '\x3', '#', '\x3', '#', 
		'\x3', '#', '\x3', '#', '\x3', '#', '\x3', '#', '\x3', '#', '\x3', '#', 
		'\x3', '#', '\x3', '#', '\x5', '#', '\xE1', '\n', '#', '\x3', '#', '\x3', 
		'#', '\x3', '$', '\x3', '$', '\x3', '%', '\x3', '%', '\x3', '&', '\x3', 
		'&', '\x3', '\'', '\x3', '\'', '\x3', '\'', '\x3', '(', '\x3', '(', '\x6', 
		'(', '\xF0', '\n', '(', '\r', '(', '\xE', '(', '\xF1', '\x3', '(', '\x3', 
		'(', '\x3', ')', '\x3', ')', '\x3', ')', '\x3', ')', '\x3', '*', '\x3', 
		'*', '\x3', '*', '\x3', '*', '\x3', '*', '\a', '*', '\xFF', '\n', '*', 
		'\f', '*', '\xE', '*', '\x102', '\v', '*', '\x5', '*', '\x104', '\n', 
		'*', '\x3', '*', '\x3', '*', '\x3', '+', '\x3', '+', '\x3', '+', '\x3', 
		'+', '\x3', '+', '\a', '+', '\x10D', '\n', '+', '\f', '+', '\xE', '+', 
		'\x110', '\v', '+', '\x3', '+', '\x3', '+', '\x3', '+', '\x3', ',', '\x6', 
		',', '\x116', '\n', ',', '\r', ',', '\xE', ',', '\x117', '\x3', '-', '\x3', 
		'-', '\x3', '\x10E', '\x2', '.', '\x3', '\x3', '\x5', '\x4', '\a', '\x5', 
		'\t', '\x6', '\v', '\a', '\r', '\b', '\xF', '\t', '\x11', '\n', '\x13', 
		'\v', '\x15', '\f', '\x17', '\r', '\x19', '\xE', '\x1B', '\xF', '\x1D', 
		'\x10', '\x1F', '\x11', '!', '\x12', '#', '\x13', '%', '\x14', '\'', '\x15', 
		')', '\x16', '+', '\x17', '-', '\x18', '/', '\x19', '\x31', '\x2', '\x33', 
		'\x2', '\x35', '\x1A', '\x37', '\x1B', '\x39', '\x1C', ';', '\x1D', '=', 
		'\x2', '?', '\x2', '\x41', '\x1E', '\x43', '\x1F', '\x45', ' ', 'G', '!', 
		'I', '\"', 'K', '#', 'M', '$', 'O', '%', 'Q', '&', 'S', '\'', 'U', '\x2', 
		'W', '\x2', 'Y', '\x2', '\x3', '\x2', '\b', '\x4', '\x2', '\x43', '\\', 
		'\x63', '|', '\x6', '\x2', '\f', '\f', '\xF', '\xF', '$', '$', '^', '^', 
		'\t', '\x2', '$', '$', ')', ')', '\x32', '\x32', '^', '^', 'p', 'p', 't', 
		't', 'v', 'v', '\x5', '\x2', '\x32', ';', '\x43', 'H', '\x63', 'h', '\x4', 
		'\x2', '\v', '\v', '\"', '\"', '\x4', '\x2', '\f', '\f', '\xF', '\xF', 
		'\x2', '\x129', '\x2', '\x3', '\x3', '\x2', '\x2', '\x2', '\x2', '\x5', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', '\xF', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x11', '\x3', '\x2', '\x2', '\x2', '\x2', '\x13', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x15', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x17', '\x3', '\x2', '\x2', '\x2', '\x2', '\x19', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1D', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x1F', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'!', '\x3', '\x2', '\x2', '\x2', '\x2', '#', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '%', '\x3', '\x2', '\x2', '\x2', '\x2', '\'', '\x3', '\x2', '\x2', 
		'\x2', '\x2', ')', '\x3', '\x2', '\x2', '\x2', '\x2', '+', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '-', '\x3', '\x2', '\x2', '\x2', '\x2', '/', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x35', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x37', '\x3', '\x2', '\x2', '\x2', '\x2', '\x39', '\x3', '\x2', '\x2', 
		'\x2', '\x2', ';', '\x3', '\x2', '\x2', '\x2', '\x2', '\x41', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x43', '\x3', '\x2', '\x2', '\x2', '\x2', '\x45', 
		'\x3', '\x2', '\x2', '\x2', '\x2', 'G', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'I', '\x3', '\x2', '\x2', '\x2', '\x2', 'K', '\x3', '\x2', '\x2', '\x2', 
		'\x2', 'M', '\x3', '\x2', '\x2', '\x2', '\x2', 'O', '\x3', '\x2', '\x2', 
		'\x2', '\x2', 'Q', '\x3', '\x2', '\x2', '\x2', '\x2', 'S', '\x3', '\x2', 
		'\x2', '\x2', '\x3', '[', '\x3', '\x2', '\x2', '\x2', '\x5', ']', '\x3', 
		'\x2', '\x2', '\x2', '\a', '_', '\x3', '\x2', '\x2', '\x2', '\t', '\x61', 
		'\x3', '\x2', '\x2', '\x2', '\v', '\x63', '\x3', '\x2', '\x2', '\x2', 
		'\r', '\x65', '\x3', '\x2', '\x2', '\x2', '\xF', 'g', '\x3', '\x2', '\x2', 
		'\x2', '\x11', 'i', '\x3', '\x2', '\x2', '\x2', '\x13', 'k', '\x3', '\x2', 
		'\x2', '\x2', '\x15', 'm', '\x3', '\x2', '\x2', '\x2', '\x17', 'o', '\x3', 
		'\x2', '\x2', '\x2', '\x19', 'q', '\x3', '\x2', '\x2', '\x2', '\x1B', 
		's', '\x3', '\x2', '\x2', '\x2', '\x1D', 'u', '\x3', '\x2', '\x2', '\x2', 
		'\x1F', 'w', '\x3', '\x2', '\x2', '\x2', '!', 'y', '\x3', '\x2', '\x2', 
		'\x2', '#', '{', '\x3', '\x2', '\x2', '\x2', '%', '}', '\x3', '\x2', '\x2', 
		'\x2', '\'', '\x82', '\x3', '\x2', '\x2', '\x2', ')', '\x88', '\x3', '\x2', 
		'\x2', '\x2', '+', '\x98', '\x3', '\x2', '\x2', '\x2', '-', '\x9A', '\x3', 
		'\x2', '\x2', '\x2', '/', '\x9E', '\x3', '\x2', '\x2', '\x2', '\x31', 
		'\xA7', '\x3', '\x2', '\x2', '\x2', '\x33', '\xAB', '\x3', '\x2', '\x2', 
		'\x2', '\x35', '\xAD', '\x3', '\x2', '\x2', '\x2', '\x37', '\xB7', '\x3', 
		'\x2', '\x2', '\x2', '\x39', '\xBA', '\x3', '\x2', '\x2', '\x2', ';', 
		'\xBE', '\x3', '\x2', '\x2', '\x2', '=', '\xC4', '\x3', '\x2', '\x2', 
		'\x2', '?', '\xC8', '\x3', '\x2', '\x2', '\x2', '\x41', '\xCA', '\x3', 
		'\x2', '\x2', '\x2', '\x43', '\xD0', '\x3', '\x2', '\x2', '\x2', '\x45', 
		'\xD4', '\x3', '\x2', '\x2', '\x2', 'G', '\xE4', '\x3', '\x2', '\x2', 
		'\x2', 'I', '\xE6', '\x3', '\x2', '\x2', '\x2', 'K', '\xE8', '\x3', '\x2', 
		'\x2', '\x2', 'M', '\xEA', '\x3', '\x2', '\x2', '\x2', 'O', '\xEF', '\x3', 
		'\x2', '\x2', '\x2', 'Q', '\xF5', '\x3', '\x2', '\x2', '\x2', 'S', '\x103', 
		'\x3', '\x2', '\x2', '\x2', 'U', '\x107', '\x3', '\x2', '\x2', '\x2', 
		'W', '\x115', '\x3', '\x2', '\x2', '\x2', 'Y', '\x119', '\x3', '\x2', 
		'\x2', '\x2', '[', '\\', '\a', '\x61', '\x2', '\x2', '\\', '\x4', '\x3', 
		'\x2', '\x2', '\x2', ']', '^', '\a', '\x42', '\x2', '\x2', '^', '\x6', 
		'\x3', '\x2', '\x2', '\x2', '_', '`', '\a', '&', '\x2', '\x2', '`', '\b', 
		'\x3', '\x2', '\x2', '\x2', '\x61', '\x62', '\a', '#', '\x2', '\x2', '\x62', 
		'\n', '\x3', '\x2', '\x2', '\x2', '\x63', '\x64', '\a', '(', '\x2', '\x2', 
		'\x64', '\f', '\x3', '\x2', '\x2', '\x2', '\x65', '\x66', '\a', '\x80', 
		'\x2', '\x2', '\x66', '\xE', '\x3', '\x2', '\x2', '\x2', 'g', 'h', '\a', 
		'~', '\x2', '\x2', 'h', '\x10', '\x3', '\x2', '\x2', '\x2', 'i', 'j', 
		'\a', '\x41', '\x2', '\x2', 'j', '\x12', '\x3', '\x2', '\x2', '\x2', 'k', 
		'l', '\a', ',', '\x2', '\x2', 'l', '\x14', '\x3', '\x2', '\x2', '\x2', 
		'm', 'n', '\a', '-', '\x2', '\x2', 'n', '\x16', '\x3', '\x2', '\x2', '\x2', 
		'o', 'p', '\a', '?', '\x2', '\x2', 'p', '\x18', '\x3', '\x2', '\x2', '\x2', 
		'q', 'r', '\a', '}', '\x2', '\x2', 'r', '\x1A', '\x3', '\x2', '\x2', '\x2', 
		's', 't', '\a', '\x7F', '\x2', '\x2', 't', '\x1C', '\x3', '\x2', '\x2', 
		'\x2', 'u', 'v', '\a', '*', '\x2', '\x2', 'v', '\x1E', '\x3', '\x2', '\x2', 
		'\x2', 'w', 'x', '\a', '+', '\x2', '\x2', 'x', ' ', '\x3', '\x2', '\x2', 
		'\x2', 'y', 'z', '\a', ']', '\x2', '\x2', 'z', '\"', '\x3', '\x2', '\x2', 
		'\x2', '{', '|', '\a', '_', '\x2', '\x2', '|', '$', '\x3', '\x2', '\x2', 
		'\x2', '}', '~', '\a', 'R', '\x2', '\x2', '~', '\x7F', '\a', 'W', '\x2', 
		'\x2', '\x7F', '\x80', '\a', 'U', '\x2', '\x2', '\x80', '\x81', '\a', 
		'J', '\x2', '\x2', '\x81', '&', '\x3', '\x2', '\x2', '\x2', '\x82', '\x83', 
		'\a', 'R', '\x2', '\x2', '\x83', '\x84', '\a', 'G', '\x2', '\x2', '\x84', 
		'\x85', '\a', 'G', '\x2', '\x2', '\x85', '\x86', '\a', 'M', '\x2', '\x2', 
		'\x86', '(', '\x3', '\x2', '\x2', '\x2', '\x87', '\x89', '\x4', '\x32', 
		';', '\x2', '\x88', '\x87', '\x3', '\x2', '\x2', '\x2', '\x89', '\x8A', 
		'\x3', '\x2', '\x2', '\x2', '\x8A', '\x88', '\x3', '\x2', '\x2', '\x2', 
		'\x8A', '\x8B', '\x3', '\x2', '\x2', '\x2', '\x8B', '*', '\x3', '\x2', 
		'\x2', '\x2', '\x8C', '\x99', '\x5', ')', '\x15', '\x2', '\x8D', '\x91', 
		'\a', '/', '\x2', '\x2', '\x8E', '\x90', '\a', '\x32', '\x2', '\x2', '\x8F', 
		'\x8E', '\x3', '\x2', '\x2', '\x2', '\x90', '\x93', '\x3', '\x2', '\x2', 
		'\x2', '\x91', '\x8F', '\x3', '\x2', '\x2', '\x2', '\x91', '\x92', '\x3', 
		'\x2', '\x2', '\x2', '\x92', '\x94', '\x3', '\x2', '\x2', '\x2', '\x93', 
		'\x91', '\x3', '\x2', '\x2', '\x2', '\x94', '\x96', '\x4', '\x33', ';', 
		'\x2', '\x95', '\x97', '\x5', ')', '\x15', '\x2', '\x96', '\x95', '\x3', 
		'\x2', '\x2', '\x2', '\x96', '\x97', '\x3', '\x2', '\x2', '\x2', '\x97', 
		'\x99', '\x3', '\x2', '\x2', '\x2', '\x98', '\x8C', '\x3', '\x2', '\x2', 
		'\x2', '\x98', '\x8D', '\x3', '\x2', '\x2', '\x2', '\x99', ',', '\x3', 
		'\x2', '\x2', '\x2', '\x9A', '\x9B', '\a', '.', '\x2', '\x2', '\x9B', 
		'.', '\x3', '\x2', '\x2', '\x2', '\x9C', '\x9F', '\a', '\x61', '\x2', 
		'\x2', '\x9D', '\x9F', '\x5', '\x31', '\x19', '\x2', '\x9E', '\x9C', '\x3', 
		'\x2', '\x2', '\x2', '\x9E', '\x9D', '\x3', '\x2', '\x2', '\x2', '\x9F', 
		'\xA4', '\x3', '\x2', '\x2', '\x2', '\xA0', '\xA3', '\a', '\x61', '\x2', 
		'\x2', '\xA1', '\xA3', '\x5', '\x33', '\x1A', '\x2', '\xA2', '\xA0', '\x3', 
		'\x2', '\x2', '\x2', '\xA2', '\xA1', '\x3', '\x2', '\x2', '\x2', '\xA3', 
		'\xA6', '\x3', '\x2', '\x2', '\x2', '\xA4', '\xA2', '\x3', '\x2', '\x2', 
		'\x2', '\xA4', '\xA5', '\x3', '\x2', '\x2', '\x2', '\xA5', '\x30', '\x3', 
		'\x2', '\x2', '\x2', '\xA6', '\xA4', '\x3', '\x2', '\x2', '\x2', '\xA7', 
		'\xA8', '\t', '\x2', '\x2', '\x2', '\xA8', '\x32', '\x3', '\x2', '\x2', 
		'\x2', '\xA9', '\xAC', '\x5', '\x31', '\x19', '\x2', '\xAA', '\xAC', '\x4', 
		'\x32', ';', '\x2', '\xAB', '\xA9', '\x3', '\x2', '\x2', '\x2', '\xAB', 
		'\xAA', '\x3', '\x2', '\x2', '\x2', '\xAC', '\x34', '\x3', '\x2', '\x2', 
		'\x2', '\xAD', '\xB2', '\x5', 'I', '%', '\x2', '\xAE', '\xB1', '\x5', 
		'\x41', '!', '\x2', '\xAF', '\xB1', '\n', '\x3', '\x2', '\x2', '\xB0', 
		'\xAE', '\x3', '\x2', '\x2', '\x2', '\xB0', '\xAF', '\x3', '\x2', '\x2', 
		'\x2', '\xB1', '\xB4', '\x3', '\x2', '\x2', '\x2', '\xB2', '\xB0', '\x3', 
		'\x2', '\x2', '\x2', '\xB2', '\xB3', '\x3', '\x2', '\x2', '\x2', '\xB3', 
		'\xB5', '\x3', '\x2', '\x2', '\x2', '\xB4', '\xB2', '\x3', '\x2', '\x2', 
		'\x2', '\xB5', '\xB6', '\x5', 'I', '%', '\x2', '\xB6', '\x36', '\x3', 
		'\x2', '\x2', '\x2', '\xB7', '\xB8', '\a', '`', '\x2', '\x2', '\xB8', 
		'\xB9', '\x5', '\x35', '\x1B', '\x2', '\xB9', '\x38', '\x3', '\x2', '\x2', 
		'\x2', '\xBA', '\xBB', '\x5', ';', '\x1E', '\x2', '\xBB', '\xBC', '\x5', 
		'M', '\'', '\x2', '\xBC', '\xBD', '\x5', ';', '\x1E', '\x2', '\xBD', ':', 
		'\x3', '\x2', '\x2', '\x2', '\xBE', '\xBF', '\x5', 'K', '&', '\x2', '\xBF', 
		'\xC0', '\x5', '?', ' ', '\x2', '\xC0', '\xC1', '\x5', 'K', '&', '\x2', 
		'\xC1', '<', '\x3', '\x2', '\x2', '\x2', '\xC2', '\xC5', '\x5', 'Y', '-', 
		'\x2', '\xC3', '\xC5', '\x5', '\x41', '!', '\x2', '\xC4', '\xC2', '\x3', 
		'\x2', '\x2', '\x2', '\xC4', '\xC3', '\x3', '\x2', '\x2', '\x2', '\xC5', 
		'>', '\x3', '\x2', '\x2', '\x2', '\xC6', '\xC9', '\x5', '\x41', '!', '\x2', 
		'\xC7', '\xC9', '\x5', 'Y', '-', '\x2', '\xC8', '\xC6', '\x3', '\x2', 
		'\x2', '\x2', '\xC8', '\xC7', '\x3', '\x2', '\x2', '\x2', '\xC9', '@', 
		'\x3', '\x2', '\x2', '\x2', '\xCA', '\xCE', '\a', '^', '\x2', '\x2', '\xCB', 
		'\xCF', '\t', '\x4', '\x2', '\x2', '\xCC', '\xCF', '\x5', '\x43', '\"', 
		'\x2', '\xCD', '\xCF', '\x5', '\x45', '#', '\x2', '\xCE', '\xCB', '\x3', 
		'\x2', '\x2', '\x2', '\xCE', '\xCC', '\x3', '\x2', '\x2', '\x2', '\xCE', 
		'\xCD', '\x3', '\x2', '\x2', '\x2', '\xCF', '\x42', '\x3', '\x2', '\x2', 
		'\x2', '\xD0', '\xD1', '\a', 'Z', '\x2', '\x2', '\xD1', '\xD2', '\x5', 
		'G', '$', '\x2', '\xD2', '\xD3', '\x5', 'G', '$', '\x2', '\xD3', '\x44', 
		'\x3', '\x2', '\x2', '\x2', '\xD4', '\xD5', '\a', 'W', '\x2', '\x2', '\xD5', 
		'\xE0', '\x5', '\x19', '\r', '\x2', '\xD6', '\xD7', '\x5', 'G', '$', '\x2', 
		'\xD7', '\xD8', '\x5', 'G', '$', '\x2', '\xD8', '\xE1', '\x3', '\x2', 
		'\x2', '\x2', '\xD9', '\xDA', '\x5', 'G', '$', '\x2', '\xDA', '\xDB', 
		'\x5', 'G', '$', '\x2', '\xDB', '\xDC', '\x5', 'G', '$', '\x2', '\xDC', 
		'\xDD', '\x5', 'G', '$', '\x2', '\xDD', '\xDE', '\x5', 'G', '$', '\x2', 
		'\xDE', '\xDF', '\x5', 'G', '$', '\x2', '\xDF', '\xE1', '\x3', '\x2', 
		'\x2', '\x2', '\xE0', '\xD6', '\x3', '\x2', '\x2', '\x2', '\xE0', '\xD9', 
		'\x3', '\x2', '\x2', '\x2', '\xE1', '\xE2', '\x3', '\x2', '\x2', '\x2', 
		'\xE2', '\xE3', '\x5', '\x1B', '\xE', '\x2', '\xE3', '\x46', '\x3', '\x2', 
		'\x2', '\x2', '\xE4', '\xE5', '\t', '\x5', '\x2', '\x2', '\xE5', 'H', 
		'\x3', '\x2', '\x2', '\x2', '\xE6', '\xE7', '\a', '$', '\x2', '\x2', '\xE7', 
		'J', '\x3', '\x2', '\x2', '\x2', '\xE8', '\xE9', '\a', ')', '\x2', '\x2', 
		'\xE9', 'L', '\x3', '\x2', '\x2', '\x2', '\xEA', '\xEB', '\a', '\x30', 
		'\x2', '\x2', '\xEB', '\xEC', '\a', '\x30', '\x2', '\x2', '\xEC', 'N', 
		'\x3', '\x2', '\x2', '\x2', '\xED', '\xF0', '\t', '\x6', '\x2', '\x2', 
		'\xEE', '\xF0', '\x5', 'W', ',', '\x2', '\xEF', '\xED', '\x3', '\x2', 
		'\x2', '\x2', '\xEF', '\xEE', '\x3', '\x2', '\x2', '\x2', '\xF0', '\xF1', 
		'\x3', '\x2', '\x2', '\x2', '\xF1', '\xEF', '\x3', '\x2', '\x2', '\x2', 
		'\xF1', '\xF2', '\x3', '\x2', '\x2', '\x2', '\xF2', '\xF3', '\x3', '\x2', 
		'\x2', '\x2', '\xF3', '\xF4', '\b', '(', '\x2', '\x2', '\xF4', 'P', '\x3', 
		'\x2', '\x2', '\x2', '\xF5', '\xF6', '\x5', 'U', '+', '\x2', '\xF6', '\xF7', 
		'\x3', '\x2', '\x2', '\x2', '\xF7', '\xF8', '\b', ')', '\x2', '\x2', '\xF8', 
		'R', '\x3', '\x2', '\x2', '\x2', '\xF9', '\x104', '\x5', 'U', '+', '\x2', 
		'\xFA', '\xFB', '\a', '\x31', '\x2', '\x2', '\xFB', '\xFC', '\a', '\x31', 
		'\x2', '\x2', '\xFC', '\x100', '\x3', '\x2', '\x2', '\x2', '\xFD', '\xFF', 
		'\n', '\a', '\x2', '\x2', '\xFE', '\xFD', '\x3', '\x2', '\x2', '\x2', 
		'\xFF', '\x102', '\x3', '\x2', '\x2', '\x2', '\x100', '\xFE', '\x3', '\x2', 
		'\x2', '\x2', '\x100', '\x101', '\x3', '\x2', '\x2', '\x2', '\x101', '\x104', 
		'\x3', '\x2', '\x2', '\x2', '\x102', '\x100', '\x3', '\x2', '\x2', '\x2', 
		'\x103', '\xF9', '\x3', '\x2', '\x2', '\x2', '\x103', '\xFA', '\x3', '\x2', 
		'\x2', '\x2', '\x104', '\x105', '\x3', '\x2', '\x2', '\x2', '\x105', '\x106', 
		'\b', '*', '\x2', '\x2', '\x106', 'T', '\x3', '\x2', '\x2', '\x2', '\x107', 
		'\x108', '\a', '\x31', '\x2', '\x2', '\x108', '\x109', '\a', ',', '\x2', 
		'\x2', '\x109', '\x10E', '\x3', '\x2', '\x2', '\x2', '\x10A', '\x10D', 
		'\x5', 'S', '*', '\x2', '\x10B', '\x10D', '\x5', 'Y', '-', '\x2', '\x10C', 
		'\x10A', '\x3', '\x2', '\x2', '\x2', '\x10C', '\x10B', '\x3', '\x2', '\x2', 
		'\x2', '\x10D', '\x110', '\x3', '\x2', '\x2', '\x2', '\x10E', '\x10F', 
		'\x3', '\x2', '\x2', '\x2', '\x10E', '\x10C', '\x3', '\x2', '\x2', '\x2', 
		'\x10F', '\x111', '\x3', '\x2', '\x2', '\x2', '\x110', '\x10E', '\x3', 
		'\x2', '\x2', '\x2', '\x111', '\x112', '\a', ',', '\x2', '\x2', '\x112', 
		'\x113', '\a', '\x31', '\x2', '\x2', '\x113', 'V', '\x3', '\x2', '\x2', 
		'\x2', '\x114', '\x116', '\t', '\a', '\x2', '\x2', '\x115', '\x114', '\x3', 
		'\x2', '\x2', '\x2', '\x116', '\x117', '\x3', '\x2', '\x2', '\x2', '\x117', 
		'\x115', '\x3', '\x2', '\x2', '\x2', '\x117', '\x118', '\x3', '\x2', '\x2', 
		'\x2', '\x118', 'X', '\x3', '\x2', '\x2', '\x2', '\x119', '\x11A', '\v', 
		'\x2', '\x2', '\x2', '\x11A', 'Z', '\x3', '\x2', '\x2', '\x2', '\x18', 
		'\x2', '\x8A', '\x91', '\x96', '\x98', '\x9E', '\xA2', '\xA4', '\xAB', 
		'\xB0', '\xB2', '\xC4', '\xC8', '\xCE', '\xE0', '\xEF', '\xF1', '\x100', 
		'\x103', '\x10C', '\x10E', '\x117', '\x3', '\x2', '\x4', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace LanguageServer

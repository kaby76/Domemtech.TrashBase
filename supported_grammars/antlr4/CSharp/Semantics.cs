using Antlr4.Runtime.Tree;
using Domemtech.Symtab;
using System;
using System.Collections.Generic;
using System.Linq;

public class Semantics
{
	public string GrammarName { get; } = "Antlr4";

	public string FileExtensions { get; } = ".g4;.g";

	public List<string> Classes = new List<string>() {
			"nonterminal def",
			"nonterminal ref",
			"terminal def",
			"terminal ref",
			"comment",
			"keyword",
			"literal",
			"mode def",
			"mode ref",
			"channel def",
			"channel ref",
			"punctuation",
			"operator",
		};

	private enum ClassesEnum : int
	{
		ClassificationNonterminalDef = 0,
		ClassificationNonterminalRef,
		ClassificationTerminalDef,
		ClassificationTerminalRef,
		ClassificationComment,
		ClassificationKeyword,
		ClassificationLiteral,
		ClassificationModeDef,
		ClassificationModeRef,
		ClassificationChannelDef,
		ClassificationChannelRef,
		ClassificationPunctuation,
		ClassificationOperator,
	}

	public List<bool> CanFindAllRefs { get; } = new List<bool>()
	{
		true, // nonterminal
		true, // nonterminal
		true, // Terminal
		true, // Terminal
		false, // comment
		false, // keyword
		true, // literal
		true, // mode
		true, // mode
		true, // channel
		true, // channel
		false, // punctuation
		false, // operator
	};

	public List<bool> CanGotodef { get; } = new List<bool>()
	{
		true, // nonterminal
		true, // nonterminal
		true, // Terminal
		true, // Terminal
		false, // comment
		false, // keyword
		false, // literal
		true, // mode
		true, // mode
		true, // channel
		true, // channel
		false, // punctuation
		false, // operator
	};

	public List<bool> CanGotovisitor { get; } = new List<bool>()
	{
		true, // nonterminal
		true, // nonterminal
		false, // Terminal
		false, // Terminal
		false, // comment
		false, // keyword
		false, // literal
		false, // mode
		false, // mode
		false, // channel
		false, // channel
		false, // punctuation
		false, // operator
	};

	public bool CanNextRule
	{
		get
		{
			return true;
		}
	}

	public List<bool> CanRename { get; } = new List<bool>()
	{
		true, // nonterminal
		true, // nonterminal
		true, // Terminal
		true, // Terminal
		false, // comment
		false, // keyword
		false, // literal
		true, // mode
		true, // mode
		true, // channel
		true, // channel
		false, // punctuation
		false, // operator
	};

	public bool CanReformat
	{
		get
		{
			return true;
		}
	}

	public int Classify(TerminalNodeImpl term)
	{
		Antlr4.Runtime.Tree.IParseTree p = term;
		st.TryGetValue(p, out IList<CombinedScopeSymbol> list_value);
		if (list_value != null)
		{
			// There's a symbol table entry for the leaf node.
			// So, it is either a terminal, nonterminal,
			// channel, mode.
			// We don't care if it's a defining occurrence or
			// applied occurrence, just what type of symbol it
			// is.
			foreach (CombinedScopeSymbol value in list_value)
			{
				if (value is RefSymbol)
				{
					List<ISymbol> defs = ((RefSymbol)value).Def;
					foreach (var d in defs)
					{
						if (d is NonterminalSymbol)
						{
							return (int)ClassesEnum.ClassificationNonterminalRef;
						}
						else if (d is TerminalSymbol)
						{
							return (int)ClassesEnum.ClassificationNonterminalRef;
						}
						else if (d is ModeSymbol)
						{
							return (int)ClassesEnum.ClassificationModeRef; ;
						}
						else if (d is ChannelSymbol)
						{
							return (int)ClassesEnum.ClassificationChannelRef; ;
						}
					}
				}
				else if (value is NonterminalSymbol)
				{
					return (int)ClassesEnum.ClassificationNonterminalDef;
				}
				else if (value is TerminalSymbol)
				{
					return (int)ClassesEnum.ClassificationTerminalDef;
				}
				else if (value is ModeSymbol)
				{
					return (int)ClassesEnum.ClassificationModeDef;
				}
				else if (value is ChannelSymbol)
				{
					return (int)ClassesEnum.ClassificationChannelDef;
				}
			}
		}
		else
		{
			// It is either a keyword, literal, comment.
			string text = term.GetText();
			if (_antlr_keywords.Contains(text))
			{
				return (int)ClassesEnum.ClassificationKeyword;
			}
			if ((term.Symbol.Type == ANTLRv4Parser.STRING_LITERAL
				 || term.Symbol.Type == ANTLRv4Parser.INT
				 || term.Symbol.Type == ANTLRv4Parser.LEXER_CHAR_SET))
			{
				return (int)ClassesEnum.ClassificationLiteral;
			}
			// The token could be part of parserRuleSpec context.
			//for (IRuleNode r = term.Parent; r != null; r = r.Parent)
			//{
			//    if (r is ANTLRv4Parser.ParserRuleSpecContext ||
			//          r is ANTLRv4Parser.LexerRuleSpecContext)
			//    {
			//        return 4;
			//    }
			//}
			if (term.Payload.Channel == ANTLRv4Lexer.OFF_CHANNEL
				|| term.Symbol.Type == ANTLRv4Lexer.DOC_COMMENT
				|| term.Symbol.Type == ANTLRv4Lexer.BLOCK_COMMENT
				|| term.Symbol.Type == ANTLRv4Lexer.LINE_COMMENT)
			{
				return (int)ClassesEnum.ClassificationComment;
			}
		}
		return -1;
	}

	private static readonly List<string> _antlr_keywords = new List<string>() {
			"options",
			"tokens",
			"channels",
			"import",
			"fragment",
			"lexer",
			"parser",
			"grammar",
			"protected",
			"public",
			"returns",
			"locals",
			"throws",
			"catch",
			"finally",
			"mode",
			"pushMode",
			"popMode",
			"type",
			"skip",
			"channel"
		};
}

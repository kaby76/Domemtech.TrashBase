//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.10.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from BisonParser.g4 by ANTLR 4.10.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace LanguageServer {
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="BisonParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.10.1")]
[System.CLSCompliant(false)]
public interface IBisonParserListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.input"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInput([NotNull] BisonParser.InputContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.input"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInput([NotNull] BisonParser.InputContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.prologue_declarations"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrologue_declarations([NotNull] BisonParser.Prologue_declarationsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.prologue_declarations"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrologue_declarations([NotNull] BisonParser.Prologue_declarationsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.prologue_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrologue_declaration([NotNull] BisonParser.Prologue_declarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.prologue_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrologue_declaration([NotNull] BisonParser.Prologue_declarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.params"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParams([NotNull] BisonParser.ParamsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.params"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParams([NotNull] BisonParser.ParamsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.grammar_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGrammar_declaration([NotNull] BisonParser.Grammar_declarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.grammar_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGrammar_declaration([NotNull] BisonParser.Grammar_declarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.code_props_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCode_props_type([NotNull] BisonParser.Code_props_typeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.code_props_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCode_props_type([NotNull] BisonParser.Code_props_typeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.union_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnion_name([NotNull] BisonParser.Union_nameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.union_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnion_name([NotNull] BisonParser.Union_nameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.symbol_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSymbol_declaration([NotNull] BisonParser.Symbol_declarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.symbol_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSymbol_declaration([NotNull] BisonParser.Symbol_declarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.precedence_declarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrecedence_declarator([NotNull] BisonParser.Precedence_declaratorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.precedence_declarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrecedence_declarator([NotNull] BisonParser.Precedence_declaratorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.tag_opt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTag_opt([NotNull] BisonParser.Tag_optContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.tag_opt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTag_opt([NotNull] BisonParser.Tag_optContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.generic_symlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGeneric_symlist([NotNull] BisonParser.Generic_symlistContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.generic_symlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGeneric_symlist([NotNull] BisonParser.Generic_symlistContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.generic_symlist_item"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGeneric_symlist_item([NotNull] BisonParser.Generic_symlist_itemContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.generic_symlist_item"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGeneric_symlist_item([NotNull] BisonParser.Generic_symlist_itemContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.tag"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTag([NotNull] BisonParser.TagContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.tag"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTag([NotNull] BisonParser.TagContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.nterm_decls"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNterm_decls([NotNull] BisonParser.Nterm_declsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.nterm_decls"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNterm_decls([NotNull] BisonParser.Nterm_declsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.token_decls"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterToken_decls([NotNull] BisonParser.Token_declsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.token_decls"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitToken_decls([NotNull] BisonParser.Token_declsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.token_decl_1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterToken_decl_1([NotNull] BisonParser.Token_decl_1Context context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.token_decl_1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitToken_decl_1([NotNull] BisonParser.Token_decl_1Context context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.token_decl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterToken_decl([NotNull] BisonParser.Token_declContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.token_decl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitToken_decl([NotNull] BisonParser.Token_declContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.int_opt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInt_opt([NotNull] BisonParser.Int_optContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.int_opt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInt_opt([NotNull] BisonParser.Int_optContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.alias"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAlias([NotNull] BisonParser.AliasContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.alias"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAlias([NotNull] BisonParser.AliasContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.token_decls_for_prec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterToken_decls_for_prec([NotNull] BisonParser.Token_decls_for_precContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.token_decls_for_prec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitToken_decls_for_prec([NotNull] BisonParser.Token_decls_for_precContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.token_decl_for_prec_1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterToken_decl_for_prec_1([NotNull] BisonParser.Token_decl_for_prec_1Context context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.token_decl_for_prec_1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitToken_decl_for_prec_1([NotNull] BisonParser.Token_decl_for_prec_1Context context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.token_decl_for_prec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterToken_decl_for_prec([NotNull] BisonParser.Token_decl_for_precContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.token_decl_for_prec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitToken_decl_for_prec([NotNull] BisonParser.Token_decl_for_precContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.symbol_decls"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSymbol_decls([NotNull] BisonParser.Symbol_declsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.symbol_decls"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSymbol_decls([NotNull] BisonParser.Symbol_declsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.symbol_decl_1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSymbol_decl_1([NotNull] BisonParser.Symbol_decl_1Context context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.symbol_decl_1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSymbol_decl_1([NotNull] BisonParser.Symbol_decl_1Context context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.bison_grammar"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBison_grammar([NotNull] BisonParser.Bison_grammarContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.bison_grammar"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBison_grammar([NotNull] BisonParser.Bison_grammarContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.rules_or_grammar_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRules_or_grammar_declaration([NotNull] BisonParser.Rules_or_grammar_declarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.rules_or_grammar_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRules_or_grammar_declaration([NotNull] BisonParser.Rules_or_grammar_declarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.rules"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRules([NotNull] BisonParser.RulesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.rules"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRules([NotNull] BisonParser.RulesContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.rhses_1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRhses_1([NotNull] BisonParser.Rhses_1Context context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.rhses_1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRhses_1([NotNull] BisonParser.Rhses_1Context context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.rhs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRhs([NotNull] BisonParser.RhsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.rhs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRhs([NotNull] BisonParser.RhsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.named_ref_opt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNamed_ref_opt([NotNull] BisonParser.Named_ref_optContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.named_ref_opt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNamed_ref_opt([NotNull] BisonParser.Named_ref_optContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.variable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVariable([NotNull] BisonParser.VariableContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.variable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVariable([NotNull] BisonParser.VariableContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterValue([NotNull] BisonParser.ValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitValue([NotNull] BisonParser.ValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterId([NotNull] BisonParser.IdContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitId([NotNull] BisonParser.IdContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSymbol([NotNull] BisonParser.SymbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSymbol([NotNull] BisonParser.SymbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.string_as_id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterString_as_id([NotNull] BisonParser.String_as_idContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.string_as_id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitString_as_id([NotNull] BisonParser.String_as_idContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.epilogue_opt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEpilogue_opt([NotNull] BisonParser.Epilogue_optContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.epilogue_opt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEpilogue_opt([NotNull] BisonParser.Epilogue_optContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="BisonParser.actionBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterActionBlock([NotNull] BisonParser.ActionBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="BisonParser.actionBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitActionBlock([NotNull] BisonParser.ActionBlockContext context);
}
} // namespace LanguageServer

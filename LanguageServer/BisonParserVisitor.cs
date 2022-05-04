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
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="BisonParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.10.1")]
[System.CLSCompliant(false)]
public interface IBisonParserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.input"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInput([NotNull] BisonParser.InputContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.prologue_declarations"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrologue_declarations([NotNull] BisonParser.Prologue_declarationsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.prologue_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrologue_declaration([NotNull] BisonParser.Prologue_declarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.params"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParams([NotNull] BisonParser.ParamsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.grammar_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGrammar_declaration([NotNull] BisonParser.Grammar_declarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.code_props_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCode_props_type([NotNull] BisonParser.Code_props_typeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.union_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnion_name([NotNull] BisonParser.Union_nameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.symbol_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSymbol_declaration([NotNull] BisonParser.Symbol_declarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.precedence_declarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrecedence_declarator([NotNull] BisonParser.Precedence_declaratorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.tag_opt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTag_opt([NotNull] BisonParser.Tag_optContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.generic_symlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGeneric_symlist([NotNull] BisonParser.Generic_symlistContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.generic_symlist_item"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGeneric_symlist_item([NotNull] BisonParser.Generic_symlist_itemContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.tag"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTag([NotNull] BisonParser.TagContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.nterm_decls"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNterm_decls([NotNull] BisonParser.Nterm_declsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.token_decls"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitToken_decls([NotNull] BisonParser.Token_declsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.token_decl_1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitToken_decl_1([NotNull] BisonParser.Token_decl_1Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.token_decl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitToken_decl([NotNull] BisonParser.Token_declContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.int_opt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInt_opt([NotNull] BisonParser.Int_optContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.alias"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAlias([NotNull] BisonParser.AliasContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.token_decls_for_prec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitToken_decls_for_prec([NotNull] BisonParser.Token_decls_for_precContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.token_decl_for_prec_1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitToken_decl_for_prec_1([NotNull] BisonParser.Token_decl_for_prec_1Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.token_decl_for_prec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitToken_decl_for_prec([NotNull] BisonParser.Token_decl_for_precContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.symbol_decls"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSymbol_decls([NotNull] BisonParser.Symbol_declsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.symbol_decl_1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSymbol_decl_1([NotNull] BisonParser.Symbol_decl_1Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.bison_grammar"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBison_grammar([NotNull] BisonParser.Bison_grammarContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.rules_or_grammar_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRules_or_grammar_declaration([NotNull] BisonParser.Rules_or_grammar_declarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.rules"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRules([NotNull] BisonParser.RulesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.rhses_1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRhses_1([NotNull] BisonParser.Rhses_1Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.rhs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRhs([NotNull] BisonParser.RhsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.named_ref_opt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNamed_ref_opt([NotNull] BisonParser.Named_ref_optContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.variable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariable([NotNull] BisonParser.VariableContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitValue([NotNull] BisonParser.ValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitId([NotNull] BisonParser.IdContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSymbol([NotNull] BisonParser.SymbolContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.string_as_id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitString_as_id([NotNull] BisonParser.String_as_idContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.epilogue_opt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEpilogue_opt([NotNull] BisonParser.Epilogue_optContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="BisonParser.actionBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitActionBlock([NotNull] BisonParser.ActionBlockContext context);
}
} // namespace LanguageServer

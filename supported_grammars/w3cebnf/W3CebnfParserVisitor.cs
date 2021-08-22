//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from W3CebnfParser.g4 by ANTLR 4.9.2

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
/// by <see cref="W3CebnfParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public interface IW3CebnfParserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="W3CebnfParser.prods"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProds([NotNull] W3CebnfParser.ProdsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="W3CebnfParser.prod"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProd([NotNull] W3CebnfParser.ProdContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="W3CebnfParser.lhs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLhs([NotNull] W3CebnfParser.LhsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="W3CebnfParser.rhs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRhs([NotNull] W3CebnfParser.RhsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="W3CebnfParser.symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSymbol([NotNull] W3CebnfParser.SymbolContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="W3CebnfParser.alts"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAlts([NotNull] W3CebnfParser.AltsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="W3CebnfParser.alt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAlt([NotNull] W3CebnfParser.AltContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="W3CebnfParser.element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElement([NotNull] W3CebnfParser.ElementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="W3CebnfParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlock([NotNull] W3CebnfParser.BlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="W3CebnfParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAtom([NotNull] W3CebnfParser.AtomContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="W3CebnfParser.suffix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSuffix([NotNull] W3CebnfParser.SuffixContext context);
}
} // namespace LanguageServer
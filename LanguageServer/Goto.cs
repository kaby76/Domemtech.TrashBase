namespace LanguageServer
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Goto
    {
        public static CMGotoResult main(bool is_visitor, bool is_enter, Workspaces.Document document, int pos)
        {
            string main_suffix = Path.GetExtension(document.FullPath);
            bool in_grammar = main_suffix == ".g4"
                || main_suffix == ".g3"
                || main_suffix == ".g2"
                || main_suffix == ".g"
                || main_suffix == ".ebnf"
                ;
            bool in_cs = main_suffix == ".cs";

            if (in_grammar)
            {
                string g4_file_path = document.FullPath;
                string current_dir = Path.GetDirectoryName(g4_file_path);
                if (current_dir == null)
                {
                    return null;
                }

                DocumentSymbol sym = new Module().GetDocumentSymbol(pos, document);
                if (sym == null)
                {
                    return null;
                }

                // Get the symbol name as a string.
                string symbol_name = sym.name;
                string capitalized_symbol_name = Capitalized(symbol_name);

                // Parse all the C# files in the current directory.
                Dictionary<string, SyntaxTree> trees = new Dictionary<string, SyntaxTree>();
                foreach (string f in Directory.EnumerateFiles(current_dir))
                {
                    if (Path.GetExtension(f).ToLower() != ".cs")
                    {
                        continue;
                    }

                    string file_name = f;
                    string suffix = Path.GetExtension(file_name);
                    if (suffix != ".cs")
                    {
                        continue;
                    }

                    try
                    {
                        string ffn = file_name;
                        StreamReader sr = new StreamReader(ffn);
                        string code = sr.ReadToEnd();
                        SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
                        trees[ffn] = tree;
                    }
                    catch (Exception)
                    {
                    }
                }

                // Get name of base class for listener and visitor. These are generated by Antlr,
                // constructed from the name of the file.
                string grammar_name = Path.GetFileName(g4_file_path);
                grammar_name = Path.GetFileNameWithoutExtension(grammar_name);
                string listener_baseclass_name =
                    is_visitor ? (grammar_name + "BaseVisitor") : (grammar_name + "BaseListener");
                string listener_class_name =
                    is_visitor ? ("My" + grammar_name + "Visitor") : ("My" + grammar_name + "Listener");

                // Find all occurrences of visitor class.
                List<ClassDeclarationSyntax> found_class = new List<ClassDeclarationSyntax>();
                string class_file_path = null;
                try
                {
                    foreach (KeyValuePair<string, SyntaxTree> kvp in trees)
                    {
                        string file_name = kvp.Key;
                        SyntaxTree tree = kvp.Value;

                        // Look for IParseTreeListener or IParseTreeVisitor classes.
                        CompilationUnitSyntax root = (CompilationUnitSyntax)tree.GetRoot();
                        if (root == null)
                        {
                            continue;
                        }

                        foreach (MemberDeclarationSyntax nm in root.Members)
                        {
                            NamespaceDeclarationSyntax namespace_member = nm as NamespaceDeclarationSyntax;
                            if (namespace_member == null)
                            {
                                continue;
                            }

                            foreach (MemberDeclarationSyntax cm in namespace_member.Members)
                            {
                                ClassDeclarationSyntax class_member = cm as ClassDeclarationSyntax;
                                if (class_member == null)
                                {
                                    continue;
                                }

                                BaseListSyntax bls = class_member.BaseList;
                                if (bls == null)
                                {
                                    continue;
                                }

                                SeparatedSyntaxList<BaseTypeSyntax> types = bls.Types;
                                Regex reg = new Regex("[<].+[>]");
                                foreach (BaseTypeSyntax type in types)
                                {
                                    string s = type.ToString();
                                    s = reg.Replace(s, "");
                                    if (s.ToString() == listener_baseclass_name)
                                    {
                                        // Found the right class.
                                        found_class.Add(class_member);
                                        class_file_path = file_name;
                                        throw new Exception();
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                }

                if (found_class.Count == 0)
                {
                    if (!Options.Option.GetBoolean("GenerateVisitorListener"))
                    {
                        return null;
                    }

                    // Look in grammar directory for any C# files.
                    string name_space = null;
                    string ffn = Path.GetFullPath(g4_file_path);
                    ffn = Path.GetDirectoryName(ffn);
                    foreach (string f in Directory.EnumerateFiles(current_dir))
                    {
                        if (Path.GetExtension(f).ToLower() != ".cs")
                        {
                            continue;
                        }

                        string file_name = f;
                        try
                        {
                            // Look for namespace.
                            SyntaxTree t = trees[file_name];
                            if (t == null)
                            {
                                continue;
                            }

                            CompilationUnitSyntax root = t.GetCompilationUnitRoot();
                            foreach (MemberDeclarationSyntax nm in root.Members)
                            {
                                NamespaceDeclarationSyntax namespace_member = nm as NamespaceDeclarationSyntax;
                                if (namespace_member == null)
                                {
                                    continue;
                                }

                                name_space = namespace_member.Name.ToString();
                                break;
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }

                    if (name_space == null)
                    {
                        name_space = "Generated";
                    }

                    // Create class.
                    string clazz = is_visitor
                        ? $@"
using System;
using System.Collections.Generic;
using System.Text;

namespace {name_space}
{{
    class {listener_class_name}<Result> : {listener_baseclass_name}<Result>
    {{
        //public override Result VisitA([NotNull] A3Parser.AContext context)
        //{{
        //  return VisitChildren(context);
        //}}
    }}
}}
"
                        : $@"
using System;
using System.Collections.Generic;
using System.Text;

namespace {name_space}
{{
    class {listener_class_name} : {listener_baseclass_name}
    {{
        //public override void EnterA(A3Parser.AContext context)
        //{{
        //    base.EnterA(context);
        //}}
        //public override void ExitA(A3Parser.AContext context)
        //{{
        //    base.ExitA(context);
        //}}
    }}
}}
";

                    class_file_path = ffn + Path.DirectorySeparatorChar + listener_class_name + ".cs";
                    System.IO.File.WriteAllText(class_file_path, clazz);

                    // Redo parse.
                    try
                    {
                        StreamReader sr = new StreamReader(class_file_path);
                        string code = sr.ReadToEnd();
                        SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
                        trees[class_file_path] = tree;
                    }
                    catch (Exception)
                    {
                    }

                    // Redo find class.
                    try
                    {
                        SyntaxTree tree = trees[class_file_path];
                        // Look for IParseTreeListener or IParseTreeVisitor classes.
                        CompilationUnitSyntax root = (CompilationUnitSyntax)tree.GetRoot();
                        foreach (MemberDeclarationSyntax nm in root.Members)
                        {
                            NamespaceDeclarationSyntax namespace_member = nm as NamespaceDeclarationSyntax;
                            if (namespace_member == null)
                            {
                                continue;
                            }

                            foreach (MemberDeclarationSyntax cm in namespace_member.Members)
                            {
                                ClassDeclarationSyntax class_member = cm as ClassDeclarationSyntax;
                                if (class_member == null)
                                {
                                    continue;
                                }

                                BaseListSyntax bls = class_member.BaseList;
                                if (bls == null)
                                {
                                    continue;
                                }

                                SeparatedSyntaxList<BaseTypeSyntax> types = bls.Types;
                                Regex reg = new Regex("[<].+[>]");
                                foreach (BaseTypeSyntax type in types)
                                {
                                    string s = type.ToString();
                                    s = reg.Replace(s, "");
                                    if (s.ToString() == listener_baseclass_name)
                                    {
                                        // Found the right class.
                                        found_class.Add(class_member);
                                        throw new Exception();
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }

                // Look for enter or exit method for symbol.
                MethodDeclarationSyntax found_member = null;
                string capitalized_member_name = "";
                if (is_visitor)
                {
                    capitalized_member_name = "Visit" + capitalized_symbol_name;
                }
                else if (is_enter)
                {
                    capitalized_member_name = "Enter" + capitalized_symbol_name;
                }
                else
                {
                    capitalized_member_name = "Exit" + capitalized_symbol_name;
                }

                string capitalized_grammar_name = Capitalized(grammar_name);
                try
                {
                    foreach (ClassDeclarationSyntax fc in found_class)
                    {
                        foreach (MemberDeclarationSyntax me in fc.Members)
                        {
                            MethodDeclarationSyntax method_member = me as MethodDeclarationSyntax;
                            if (method_member == null)
                            {
                                continue;
                            }

                            if (method_member.Identifier.ValueText.ToLower() == capitalized_member_name.ToLower())
                            {
                                found_member = method_member;
                                throw new Exception();
                            }
                        }
                    }
                }
                catch
                {
                }

                if (found_member == null)
                {
                    if (!Options.Option.GetBoolean("GenerateVisitorListener"))
                    {
                        return null;
                    }

                    // Find point for edit.
                    ClassDeclarationSyntax fc = found_class.First();
                    SyntaxToken here = fc.OpenBraceToken;
                    Microsoft.CodeAnalysis.Text.TextSpan spn = here.FullSpan;
                    int end = spn.End;

                    StreamReader sr = new StreamReader(class_file_path);
                    string code = sr.ReadToEnd();

                    // Create class.
                    string member = is_visitor
                        ? $@"
public override Result {capitalized_member_name}([NotNull] {capitalized_grammar_name}Parser.{capitalized_symbol_name}Context context)
{{
    return VisitChildren(context);
}}
"
                        : $@"
public override void {capitalized_member_name}({capitalized_grammar_name}Parser.{capitalized_symbol_name}Context context)
{{
    base.{capitalized_member_name}(context);
}}
";
                    code = code.Insert(end, member);

                    // Redo parse.
                    try
                    {
                        SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
                        trees[class_file_path] = tree;
                    }
                    catch (Exception)
                    {
                    }

                    // Redo find class.
                    try
                    {
                        SyntaxTree tree = trees[class_file_path];
                        // Look for IParseTreeListener or IParseTreeVisitor classes.
                        CompilationUnitSyntax root = (CompilationUnitSyntax)tree.GetRoot();
                        foreach (MemberDeclarationSyntax nm in root.Members)
                        {
                            NamespaceDeclarationSyntax namespace_member = nm as NamespaceDeclarationSyntax;
                            if (namespace_member == null)
                            {
                                continue;
                            }

                            foreach (MemberDeclarationSyntax cm in namespace_member.Members)
                            {
                                ClassDeclarationSyntax class_member = cm as ClassDeclarationSyntax;
                                if (class_member == null)
                                {
                                    continue;
                                }

                                BaseListSyntax bls = class_member.BaseList;
                                if (bls == null)
                                {
                                    continue;
                                }

                                SeparatedSyntaxList<BaseTypeSyntax> types = bls.Types;
                                Regex reg = new Regex("[<].+[>]");
                                foreach (BaseTypeSyntax type in types)
                                {
                                    string s = type.ToString();
                                    s = reg.Replace(s, "");
                                    if (s.ToString() == listener_baseclass_name)
                                    {
                                        // Found the right class.
                                        found_class.Add(class_member);
                                        throw new Exception();
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                    }

                    try
                    {
                        foreach (ClassDeclarationSyntax fcc in found_class)
                        {
                            foreach (MemberDeclarationSyntax me in fcc.Members)
                            {
                                MethodDeclarationSyntax method_member = me as MethodDeclarationSyntax;
                                if (method_member == null)
                                {
                                    continue;
                                }

                                if (method_member.Identifier.ValueText.ToLower() == capitalized_member_name.ToLower())
                                {
                                    found_member = method_member;
                                    throw new Exception();
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }

                CMGotoResult result = new CMGotoResult
                {
                    TextDocument = new Uri(class_file_path),
                    Start = found_member.Identifier.SpanStart
                };
                return result;
            }
            else if (in_cs)
            {
            }
            return null;
        }

        private static string Capitalized(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}

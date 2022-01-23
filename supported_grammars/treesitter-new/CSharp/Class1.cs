using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using org.eclipse.wst.xml.xpath2.processor.util;
using System.Linq;
using System.Text;


// Best discussion of code that converts json to ebnf.
// https://github.com/tree-sitter/tree-sitter/issues/1013#issuecomment-805787544

public class Class1 : JSON5BaseVisitor<object>
{
    public void Start(JSON5Parser.Json5Context node)
    {
        if (node == null) return;
        using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext = new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(_tree, _parser))
        {
            org.eclipse.wst.xml.xpath2.processor.Engine engine = new org.eclipse.wst.xml.xpath2.processor.Engine();
            var nodes = engine.parseExpression(
                "/json5/value/obj/pair[key/STRING/text()='\\\"rules\\\"']/value/obj/pair",
                new StaticContextBuilder()).evaluate(dynamicContext, new object[] { dynamicContext.Document })
                .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree as JSON5Parser.PairContext).ToList();

            foreach (var r in nodes)
            {
                var lhs = r.key()?.GetText().Replace("\"","");
                var rhs = r.value();
                System.Console.Write(lhs + " : ");
				var sb = new StringBuilder();
				manageRule(rhs, sb);
                System.Console.Write(sb.ToString());
                System.Console.Write(" ;");
                System.Console.WriteLine();
            }
        }
    }

    private IParseTree _tree;
    private Parser _parser;
    private Class1(IParseTree tree, Parser parser)
    {
        _tree = tree;
        _parser = parser;
    }
    public static void MyMain(IParseTree tree, Parser parser)
    {
        var visitor = new Class1(tree, parser);
        visitor.Start(tree as JSON5Parser.Json5Context);
    }

    public string TypeOf(JSON5Parser.ValueContext value)
    {
        return value.obj().pair().Where(p => p.key().STRING().GetText() == "\"type\"").Select(x => x.value().STRING().GetText().Replace("\"", "").ToUpper()).First();
    }

    public string NameOf(JSON5Parser.ValueContext value)
    {
        return value.obj().pair().Where(p => p.key().STRING().GetText() == "\"name\"").Select(x => x.value().STRING().GetText().Replace("\"", "").ToUpper()).First();
    }

    public JSON5Parser.ValueContext Context(JSON5Parser.ValueContext value)
	{
        var v1 = value.obj();
        var v2 = v1.pair();
        var v3 = v2.Where(p => p.key().STRING().GetText() == "\"content\"").ToList();
        var v4 = v3.Select(p => p.value()).ToList();
        var v5 = v4.First();
        return v5;
		//return value.obj().pair().Where(p => p.key().STRING().GetText() == "\"context\"").Select(x => x.value()).First();
	}

	public System.Collections.Generic.List<JSON5Parser.ValueContext> Members(JSON5Parser.ValueContext value)
	{
        System.Collections.Generic.List<JSON5Parser.ValueContext> z = value.obj().pair().Where(p => p.key().STRING().GetText() == "\"members\"").Select(x => x.value().arr()).SelectMany(a => a.value()).ToList();
		return z;
	}


	private void manageRule(JSON5Parser.ValueContext value, StringBuilder sb)
	{
		var t = TypeOf(value);
		switch (t)
		{
			case "ALIAS":
				sb.Append(" ( ");
				manageRule(Context(value), sb);
				sb.Append(" ) ");
				break;
//			case "BLANK":
//				print(rule.type);
//				break;
			case "CHOICE":
				{
					var members = Members(value);
					sb.Append(" ( ");
					bool first = true;
					foreach (var v in members)
					{
						if (first) sb.Append(" | ");
						manageRule(v, sb);
                        first = false;
					}
					sb.Append(" ) ");
				}
				break;
            case "REPEAT":
                sb.Append(" ( ");
                manageRule(Context(value), sb);
                sb.Append(" )* ");
                break;


            //case "FIELD":
            //	//print(rule.type, rule.name);
            //	std.printf(" ( ");
            //	manageRule(rule.type, rule.content);
            //	std.printf(" ) ");
            //	break;
            //case "IMMEDIATE_TOKEN":
            //	std.printf(" ( ");
            //	manageRule(rule.type, rule.content);
            //	std.printf(" ) ");
            //	break;
            //case "PATTERN":
            //	{
            //		let value = rule.value.replace("\\d", "[0-9]");
            //		std.printf(" %s", value);
            //	}
            //	break;
            //case "PREC":
            //case "PREC_DYNAMIC":
            //case "PREC_LEFT":
            //case "PREC_RIGHT":
            //	std.printf("  ( ");
            //	manageRule(rule.type, rule.content);
            //	std.printf(" ) ");
            //	break;
            //case "REPEAT1":
            //	std.printf(" (");
            //	manageRule(rule.type, rule.content);
            //	std.printf(" )+ ");
            //	break;
            case "SEQ":
				{
					var members = Members(value);
					sb.Append(" ( ");
					bool first = true;
					foreach (var v in members)
					{
						if (first) sb.Append(" | ");
						manageRule(v, sb);
                        first = false;
					}
					sb.Append(" ) ");
				}
				break;

            //case "STRING":
            //    {
            //        let value = rule.value;
            //        print(rule.type, value);
            //        value = value.replace("\\", "\\\\");
            //        if (value.indexOf("'") >= 0) std.printf(" \"%s\" ", value);
            //        else std.printf(" '%s' ", value);
            //    }
            //    break;

            //case "SYMBOL":
            //    print(rule.type, rule.name);
            //    std.printf(" %s", rule.name);
            //    break;

            //case "TOKEN":
            //    std.printf(" ( ");
            //    manageRule(rule.type, rule.content);
            //    std.printf(" )* ");
            //    break;

            case "SYMBOL":
                sb.Append(NameOf(value));
                break;

            default:
				break;
            //    throw ("Unknown rule type: " + rule.type);
        }
	}
}

//public class Class1 : JSON5BaseVisitor<object>
//{
//    public override object VisitSingleExpression([NotNull] JavaScriptParser.SingleExpressionContext context)
//    {
//        var name = context?.singleExpression()?.FirstOrDefault()?.identifier()?.Identifier()?.GetText();
//        var name2 = context?.singleExpression()?.FirstOrDefault()?.singleExpression()?.FirstOrDefault()?.identifier()?.Identifier()?.GetText();
//        if (name == "seq")
//        {
//            var args = context.arguments().argument();
//            System.Console.Write("(");
//            foreach (var a in args)
//            {
//                Visit(a);
//            }
//            System.Console.Write(" )");
//        }
//        else if (name == "choice")
//        {
//            var args = context.arguments().argument();
//            System.Console.Write("(");
//            bool first = true;
//            foreach (var a in args)
//            {
//                if (!first) System.Console.Write(" | ");
//                first = false;
//                Visit(a);
//            }
//            System.Console.Write(" )");
//        }
//        else if (name == "repeat")
//        {
//            var args = context.arguments().argument();
//            System.Console.Write("(");
//            foreach (var a in args)
//            {
//                Visit(a);
//            }
//            System.Console.Write(" )* ");
//        }
//        else if (name == "repeat1")
//        {
//            var args = context.arguments().argument();
//            System.Console.Write("(");
//            foreach (var a in args)
//            {
//                Visit(a);
//            }
//            System.Console.Write(" )+ ");
//        }
//        else if (name == "optional")
//        {
//            var args = context.arguments().argument();
//            System.Console.Write("(");
//            foreach (var a in args)
//            {
//                Visit(a);
//            }
//            System.Console.Write(" )? ");
//        }
//        else if (name2 == "prec")
//        {
//            var args = context.arguments().argument();
//            System.Console.Write("(");
//            var count = args.Count();
//            var rest = args;
//            if (count == 0)
//            { }
//            else if (count == 1)
//            {
//                Visit(rest.First());
//            }
//            else
//            {
//                foreach (var a in args.Skip(1))
//                {
//                    Visit(a);
//                }
//            }
//            System.Console.Write(" ) ");
//        }
//        else if (name == "prec")
//        {
//            var args = context.arguments().argument();
//            System.Console.Write("(");
//            foreach (var a in args.Skip(1))
//            {
//                Visit(a);
//            }
//            System.Console.Write(" ) ");
//        }
//        else if (name == "token")
//        {
//            var args = context.arguments().argument();
//            System.Console.Write("(");
//            foreach (var a in args)
//            {
//                Visit(a);
//            }
//            System.Console.Write(" ) ");
//        }
//        else if (name == "field")
//        {
//            var args = context.arguments().argument();
//            System.Console.Write("(");
//            foreach (var a in args)
//            {
//                Visit(a);
//            }
//            System.Console.Write(" ) ");
//        }
//        else if (name == "$")
//        {
//            var nt = context.identifierName()?.identifier()?.Identifier()?.GetText();
//            System.Console.Write(" " + nt);
//        }
//        else if (context.literal() != null)
//        {
//            Visit(context.literal());
//        }
//        return null;
//    }

//    public override object VisitLiteral([NotNull] JavaScriptParser.LiteralContext context)
//    {
//        System.Console.Write(" " + context.GetText());
//        return Visit(context.GetChild(0));
//    }

//    public static void MyMain(IParseTree tree, Parser parser)
//    {
//        var visitor = new Class1();
//        using (AntlrTreeEditing.AntlrDOM.AntlrDynamicContext dynamicContext = new AntlrTreeEditing.AntlrDOM.ConvertToDOM().Try(tree, parser))
//        {
//            org.eclipse.wst.xml.xpath2.processor.Engine engine = new org.eclipse.wst.xml.xpath2.processor.Engine();
//            var nodes = engine.parseExpression(
//                @"
//	//propertyAssignment[propertyName/identifierName/identifier/Identifier[text()='rules']]
//			    /singleExpression/objectLiteral/propertyAssignment
//			    ",
//                new StaticContextBuilder()).evaluate(dynamicContext, new object[] { dynamicContext.Document })
//                .Select(x => (x.NativeValue as AntlrTreeEditing.AntlrDOM.AntlrElement).AntlrIParseTree).ToList();

//            foreach (var r in nodes)
//            {
//                var lhs = (r as JavaScriptParser.PropertyAssignmentContext)?.propertyName()?.identifierName()?.identifier()?.Identifier()?.GetText();
//                var rhs = (r as JavaScriptParser.PropertyAssignmentContext)?
//                      .singleExpression()?.FirstOrDefault()?.anonymousFunction()?.arrowFunctionBody();
//                System.Console.Write(lhs + " : ");
//                visitor.Visit(rhs);
//                System.Console.Write(" ;");
//                System.Console.WriteLine();
//            }
//        }
//    }
//}

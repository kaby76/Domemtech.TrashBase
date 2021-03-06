using System.Collections;
using org.w3c.dom;

/// <summary>
///*****************************************************************************
/// Copyright (c) 2009, 2011 Standard for Technology in Automotive Retail, and others
/// All rights reserved. This program and the accompanying materials
/// are made available under the terms of the Eclipse Public License 2.0
/// which accompanies this distribution, and is available at
/// https://www.eclipse.org/legal/epl-2.0/
/// 
/// SPDX-License-Identifier: EPL-2.0
/// 
/// Contributors:
/// 	   David Carver (STAR) - bug 281168 - initial API and implementation
///     David Carver  - bug 281186 - implementation of fn:id and fn:idref
///     Mukul Gandhi - bug 280798 - PsychoPath support for JDK 1.4
/// ******************************************************************************
/// </summary>

namespace org.eclipse.wst.xml.xpath2.processor.@internal.function
{


	using EvaluationContext = org.eclipse.wst.xml.xpath2.api.EvaluationContext;
	using ResultBuffer = org.eclipse.wst.xml.xpath2.api.ResultBuffer;
	using ResultSequence = org.eclipse.wst.xml.xpath2.api.ResultSequence;
	using AttrType = org.eclipse.wst.xml.xpath2.processor.@internal.types.AttrType;
	using ElementType = org.eclipse.wst.xml.xpath2.processor.@internal.types.ElementType;
	using NodeType = org.eclipse.wst.xml.xpath2.processor.@internal.types.NodeType;
	using QName = org.eclipse.wst.xml.xpath2.processor.@internal.types.QName;
	using XSIDREF = org.eclipse.wst.xml.xpath2.processor.@internal.types.XSIDREF;
	using XSString = org.eclipse.wst.xml.xpath2.processor.@internal.types.XSString;
	using Attr = org.w3c.dom.Attr;
	using Element = org.w3c.dom.Element;
	using NamedNodeMap = org.w3c.dom.NamedNodeMap;
	using Node = org.w3c.dom.Node;
	using NodeList = org.w3c.dom.NodeList;

	/// <summary>
	/// Returns the sequence of element nodes that have an ID value matching the value of one
	/// or more of the IDREF values supplied in $arg .
	/// </summary>
	public class FnID : Function
	{
		private static ArrayList _expected_args = null;

		/// <summary>
		/// Constructor for FnInsertBefore.
		/// </summary>
		public FnID() : base(new QName("id"), 1, 2)
		{
		}

		/// <summary>
		/// Evaluate arguments.
		/// </summary>
		/// <param name="args">
		///            argument expressions. </param>
		/// <exception cref="DynamicError">
		///             Dynamic error. </exception>
		/// <returns> Result of evaluation. </returns>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public org.eclipse.wst.xml.xpath2.api.ResultSequence evaluate(java.util.Collection args, org.eclipse.wst.xml.xpath2.api.EvaluationContext ec) throws org.eclipse.wst.xml.xpath2.processor.DynamicError
		public override ResultSequence evaluate(ICollection args, EvaluationContext ec)
		{
			return id(args, ec);
		}

		/// <summary>
		/// Insert-Before operation.
		/// </summary>
		/// <param name="args">
		///            Result from the expressions evaluation. </param>
		/// <exception cref="DynamicError">
		///             Dynamic error. </exception>
		/// <returns> Result of fn:insert-before operation. </returns>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static org.eclipse.wst.xml.xpath2.api.ResultSequence id(java.util.Collection args, org.eclipse.wst.xml.xpath2.api.EvaluationContext context) throws org.eclipse.wst.xml.xpath2.processor.DynamicError
		public static ResultSequence id(ICollection args, EvaluationContext context)
		{
			ICollection cargs = Function.convert_arguments(args, expected_args());

			ResultBuffer rs = new ResultBuffer();

			IEnumerator argIt = cargs.GetEnumerator();
            argIt.MoveNext();
            ResultSequence idrefRS = (ResultSequence) argIt.Current;
			string[] idrefst = idrefRS.first().StringValue.Split(" ", true);

			ArrayList idrefs = createIDRefs(idrefst);
			ResultSequence nodeArg = null;
			NodeType nodeType = null;
			if (argIt.MoveNext())
            {
                nodeArg = (ResultSequence) argIt.Current;
				nodeType = (NodeType)nodeArg.first();
			}
			else
			{
				if (context.ContextItem == null)
				{
					throw DynamicError.contextUndefined();
				}
				if (!(context.ContextItem is NodeType))
				{
					throw new DynamicError(TypeError.invalid_type(null));
				}
				nodeType = (NodeType) context.ContextItem;
				if (nodeType.node_value().OwnerDocument == null)
				{
					throw DynamicError.contextUndefined();
				}
			}

			Node node = nodeType.node_value();
			if (node.OwnerDocument == null)
			{
				// W3C Test suite seems to want XPDY0002
				throw DynamicError.contextUndefined();
				//throw DynamicError.noContextDoc();
			}

			if (hasIDREF(idrefs, node))
			{
				ElementType element = new ElementType((Element) node, context.StaticContext.TypeModel);
				rs.add(element);
			}

			processAttributes(node, idrefs, rs, context);
			processChildNodes(node, idrefs, rs, context);

			return rs.Sequence;
		}

		private static ArrayList createIDRefs(string[] idReftokens)
		{
			ArrayList xsidRef = new ArrayList();
			for (int i = 0; i < idReftokens.Length; i++)
			{
				XSIDREF idref = new XSIDREF(idReftokens[i]);
				xsidRef.Add(idref);
			}
			return xsidRef;
		}

		private static void processChildNodes(Node node, IList idrefs, ResultBuffer rs, EvaluationContext context)
		{
			if (!node.hasChildNodes())
			{
				return;
			}

			NodeList nodeList = node.ChildNodes;
			for (int nodecnt = 0; nodecnt < nodeList.Length; nodecnt++)
			{
				Node childNode = nodeList.item(nodecnt);
				if (childNode.NodeType == NodeConstants.ELEMENT_NODE && !isDuplicate(childNode, rs))
				{
					ElementType element = new ElementType((Element)childNode, context.StaticContext.TypeModel);
					if (element.ID)
					{
						if (hasIDREF(idrefs, childNode))
						{
							rs.add(element);
						}
					}
					processAttributes(childNode, idrefs, rs, context);
					processChildNodes(childNode, idrefs, rs, context);
				}
			}

		}

		private static void processAttributes(Node node, IList idrefs, ResultBuffer rs, EvaluationContext context)
		{
			if (!node.hasAttributes())
			{
				return;
			}

			NamedNodeMap attributeList = node.Attributes;
			for (int atsub = 0; atsub < attributeList.Length; atsub++)
			{
				Attr atNode = (Attr) attributeList.item(atsub);
				NodeType atType = new AttrType(atNode, context.StaticContext.TypeModel);
				if (atType.ID)
				{
					if (hasIDREF(idrefs, atNode))
					{
						if (!isDuplicate(node, rs))
						{
							ElementType element = new ElementType((Element)node, context.StaticContext.TypeModel);
							rs.add(element);
						}
					}
				}
			}
		}

		private static bool hasIDREF(IList idrefs, Node node)
		{
			for (int i = 0; i < idrefs.Count; i++)
			{
				XSIDREF idref = (XSIDREF) idrefs[i];
				if (idref.StringValue.Equals(node.NodeValue))
				{
					return true;
				}
			}
			return false;
		}

		private static bool isDuplicate(Node node, ResultBuffer rs)
		{
			IEnumerator it = rs.iterator();
			while (it.MoveNext())
			{
				if (it.Current.Equals(node))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Obtain a list of expected arguments.
		/// </summary>
		/// <returns> Result of operation. </returns>
		public static ICollection expected_args()
		{
			lock (typeof(FnID))
			{
				if (_expected_args == null)
				{
					_expected_args = new ArrayList();
					SeqType arg = new SeqType(new XSString(), SeqType.OCC_STAR);
					_expected_args.Add(arg);
					_expected_args.Add(new SeqType(SeqType.OCC_NONE));
				}
        
				return _expected_args;
			}
		}

	}

}
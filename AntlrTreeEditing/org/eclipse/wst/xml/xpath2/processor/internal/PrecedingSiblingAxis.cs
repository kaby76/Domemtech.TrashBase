/// <summary>
///*****************************************************************************
/// Copyright (c) 2005, 2012 Andrea Bittau, University College London, and others
/// All rights reserved. This program and the accompanying materials
/// are made available under the terms of the Eclipse Public License 2.0
/// which accompanies this distribution, and is available at
/// https://www.eclipse.org/legal/epl-2.0/
/// 
/// SPDX-License-Identifier: EPL-2.0
/// 
/// Contributors:
///     Andrea Bittau - initial API and implementation from the PsychoPath XPath 2.0 
///     Lukasz Wycisk - bug 361803 - NodeType:dom_to_xpath and null value
/// ******************************************************************************
/// </summary>

namespace org.eclipse.wst.xml.xpath2.processor.@internal
{

	using ResultBuffer = org.eclipse.wst.xml.xpath2.api.ResultBuffer;
	using NodeType = org.eclipse.wst.xml.xpath2.processor.@internal.types.NodeType;
	using Node = org.w3c.dom.Node;

	/// <summary>
	/// the preceding axis contains all nodes that are descendants of the root of the
	/// tree in which the context node is found including the context node itself
	/// </summary>
	public class PrecedingSiblingAxis : ReverseAxis
	{
		// XXX again, unify with following

		/// <summary>
		/// returns preceding nodes of the context node
		/// </summary>
		/// <param name="node">
		///            is the node type. </param>
		/// <exception cref="dc">
		///             is the Dynamic context. </exception>
		public override void iterate(NodeType node, ResultBuffer copyInto, Node limitNode)
		{
			// XXX check for attribute / namespace node... if so return
			// empty sequence

			int pos = copyInto.size();
			Node iterNode = node.node_value();
			// get the children of the parent [siblings]
			do
			{
				iterNode = iterNode.PreviousSibling;
				if (iterNode != null)
				{
					NodeType nodeType = NodeType.dom_to_xpath(iterNode, node.TypeModel);
					if (nodeType != null)
					{
						copyInto.addAt(pos, nodeType);
					}
				}
			} while (iterNode != null);
		}

		public override string name()
		{
			return "preceding-sibling";
		}

	}

}
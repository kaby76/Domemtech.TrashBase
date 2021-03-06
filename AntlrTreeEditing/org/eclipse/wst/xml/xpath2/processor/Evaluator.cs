/// <summary>
///*****************************************************************************
/// Copyright (c) 2005, 2009 Andrea Bittau, University College London, and others
/// All rights reserved. This program and the accompanying materials
/// are made available under the terms of the Eclipse Public License 2.0
/// which accompanies this distribution, and is available at
/// https://www.eclipse.org/legal/epl-2.0/
/// 
/// SPDX-License-Identifier: EPL-2.0
/// 
/// Contributors:
///     Andrea Bittau - initial API and implementation from the PsychoPath XPath 2.0 
/// ******************************************************************************
/// </summary>

namespace org.eclipse.wst.xml.xpath2.processor
{

	using org.eclipse.wst.xml.xpath2.processor.@internal.ast;

	/// <summary>
	/// interface to Evaluator
	/// </summary>
	public interface Evaluator
	{

		/// <summary>
		/// Evaluate the root node.
		/// </summary>
		/// <param name="root">
		///            is the XPath node. </param>
		/// <exception cref="DynamicError">
		///             dynamic error. </exception>
		/// <returns> Result of evaluation. </returns>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public ResultSequence evaluate(XPathNode root) throws DynamicError;
		ResultSequence evaluate(XPathNode root);
	}

}
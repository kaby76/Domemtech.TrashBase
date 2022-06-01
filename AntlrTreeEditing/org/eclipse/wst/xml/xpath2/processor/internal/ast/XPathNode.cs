﻿/// <summary>
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

using System.Collections.Generic;

namespace org.eclipse.wst.xml.xpath2.processor.@internal.ast
{
    using System.Text;


	/// <summary>
	/// Class for a XPathNode object.
	/// </summary>
	public abstract class XPathNode
	{
		/// <summary>
		/// Support for Visitor interface.
		/// </summary>
		public abstract object accept(XPathVisitor v);

        public abstract ICollection<XPathNode> GetAllChildren();

        public abstract string QuickInfo();
    }

}
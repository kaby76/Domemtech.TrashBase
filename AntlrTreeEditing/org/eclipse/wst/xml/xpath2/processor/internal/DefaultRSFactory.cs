using System;

/// <summary>
///*****************************************************************************
/// Copyright (c) 2005, 2011 Andrea Bittau, University College London, and others
/// All rights reserved. This program and the accompanying materials
/// are made available under the terms of the Eclipse Public License 2.0
/// which accompanies this distribution, and is available at
/// https://www.eclipse.org/legal/epl-2.0/
/// 
/// SPDX-License-Identifier: EPL-2.0
/// 
/// Contributors:
///     Andrea Bittau - initial API and implementation from the PsychoPath XPath 2.0 
///     Mukul Gandhi - bug 280798 - PsychoPath support for JDK 1.4
/// ******************************************************************************
/// </summary>

namespace org.eclipse.wst.xml.xpath2.processor.@internal
{


	/// <summary>
	/// Factory implementation which creates sequences of type DefaultResultSequence.
	/// 
	/// </summary>
	public class DefaultRSFactory : ResultSequenceFactory
	{
		private static readonly ResultSequence _rs_creator = new DefaultResultSequence();

		public const int POOL_SIZE = 50;

		private ResultSequence[] _rs_pool = new ResultSequence[POOL_SIZE];
		private int _head_pos;

		/// <summary>
		/// Constructor of factory.
		/// 
		/// </summary>
		public DefaultRSFactory()
		{
			for (int i = 0; i < POOL_SIZE; i++)
			{
				_rs_pool[i] = _rs_creator.create_new();
			}

			_head_pos = POOL_SIZE - 1;
		}

		protected internal override ResultSequence fact_create_new()
		{
			if (_head_pos > 0)
			{
				return _rs_pool[_head_pos--];
			}

			return _rs_creator.create_new();
		}

		protected internal override void fact_release(ResultSequence rs)
		{
			int new_pos = _head_pos + 1;

			if (new_pos < POOL_SIZE)
			{
				rs.clear();

				_head_pos = new_pos;
				_rs_pool[new_pos] = rs;
			}
		}

		protected internal override void fact_print_debug()
		{
			Console.WriteLine("Head pos: " + _head_pos);
		}
	}

}
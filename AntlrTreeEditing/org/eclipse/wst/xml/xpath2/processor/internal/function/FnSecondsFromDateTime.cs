using System.Collections;

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
///     David Carver - bug 277774 - XSDEcimal returning wrong values. 
///     Mukul Gandhi - bug 280798 - PsychoPath support for JDK 1.4
/// ******************************************************************************
/// </summary>

namespace org.eclipse.wst.xml.xpath2.processor.@internal.function
{


	using ResultBuffer = org.eclipse.wst.xml.xpath2.api.ResultBuffer;
	using ResultSequence = org.eclipse.wst.xml.xpath2.api.ResultSequence;
	using QName = org.eclipse.wst.xml.xpath2.processor.@internal.types.QName;
	using XSDateTime = org.eclipse.wst.xml.xpath2.processor.@internal.types.XSDateTime;
	using XSDecimal = org.eclipse.wst.xml.xpath2.processor.@internal.types.XSDecimal;

	/// <summary>
	/// Returns an xs:decimal value between 0 and 60.999..., both inclusive
	/// representing the seconds and fractional seconds in the localized value of
	/// $arg. Note that the value can be greater than 60 seconds to accommodate
	/// occasional leap seconds used to keep human time synchronized with the
	/// rotation of the planet. If $arg is the empty sequence, returns the empty
	/// sequence.
	/// </summary>
	public class FnSecondsFromDateTime : Function
	{
		private static ArrayList _expected_args = null;

		/// <summary>
		/// Constructor for FnSecondsFromDateTime.
		/// </summary>
		public FnSecondsFromDateTime() : base(new QName("seconds-from-dateTime"), 1)
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
		public override ResultSequence evaluate(ICollection args, org.eclipse.wst.xml.xpath2.api.EvaluationContext ec)
		{
			return seconds_from_date_time(args);
		}

		/// <summary>
		/// Seconds-from-dateTime operation.
		/// </summary>
		/// <param name="args">
		///            Result from the expressions evaluation. </param>
		/// <exception cref="DynamicError">
		///             Dynamic error. </exception>
		/// <returns> Result of fn:seconds-from-dateTime operation. </returns>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static org.eclipse.wst.xml.xpath2.api.ResultSequence seconds_from_date_time(java.util.Collection args) throws org.eclipse.wst.xml.xpath2.processor.DynamicError
		public static ResultSequence seconds_from_date_time(ICollection args)
		{
			ICollection cargs = Function.convert_arguments(args, expected_args());
            var i = cargs.GetEnumerator();
            i.MoveNext();
            ResultSequence arg1 = (ResultSequence) i.Current;

			if (arg1.empty())
			{
				return ResultBuffer.EMPTY;
			}

			XSDateTime dt = (XSDateTime) arg1.first();
			double res = dt.second();
			return new XSDecimal(new decimal(res));
		}

		/// <summary>
		/// Obtain a list of expected arguments.
		/// </summary>
		/// <returns> Result of operation. </returns>
		public static ICollection expected_args()
		{
			lock (typeof(FnSecondsFromDateTime))
			{
				if (_expected_args == null)
				{
					_expected_args = new ArrayList();
					_expected_args.Add(new SeqType(new XSDateTime(), SeqType.OCC_QMARK));
				}
        
				return _expected_args;
			}
		}
	}

}
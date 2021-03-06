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
///     David Carver - bug 262765 - eased restriction on data type...convert numerics to XSDouble.
///     Jesper S Moller - bug 285806 - fixed fn:subsequence for indexes starting before 1
///     Mukul Gandhi - bug 280798 - PsychoPath support for JDK 1.4
///     Mukul Gandhi - bug 338999 - improving compliance of function 'fn:subsequence'. implementing full arity support.
/// ******************************************************************************
/// </summary>

namespace org.eclipse.wst.xml.xpath2.processor.@internal.function
{


	using Item = org.eclipse.wst.xml.xpath2.api.Item;
	using ResultBuffer = org.eclipse.wst.xml.xpath2.api.ResultBuffer;
	using ResultSequence = org.eclipse.wst.xml.xpath2.api.ResultSequence;
	using AnyType = org.eclipse.wst.xml.xpath2.processor.@internal.types.AnyType;
	using NumericType = org.eclipse.wst.xml.xpath2.processor.@internal.types.NumericType;
	using QName = org.eclipse.wst.xml.xpath2.processor.@internal.types.QName;
	using XSDouble = org.eclipse.wst.xml.xpath2.processor.@internal.types.XSDouble;

	/// <summary>
	/// Returns the contiguous sequence of items in the value of $sourceSeq beginning
	/// at the position indicated by the value of $startingLoc and continuing for the
	/// number of items indicated by the value of $length. More specifically, returns
	/// the items in $sourceString whose position $p obeys: - fn:round($startingLoc)
	/// <= $p < fn:round($startingLoc) + fn:round($length)
	/// </summary>
	public class FnSubsequence : Function
	{

		/// <summary>
		/// Constructor for FnSubsequence.
		/// </summary>
		public FnSubsequence() : base(new QName("subsequence"), 2, 3)
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
			return subsequence(args);
		}

		/// <summary>
		/// Subsequence operation.
		/// </summary>
		/// <param name="args">
		///            Result from the expressions evaluation. </param>
		/// <exception cref="DynamicError">
		///             Dynamic error. </exception>
		/// <returns> Result of fn:subsequence operation. </returns>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static org.eclipse.wst.xml.xpath2.api.ResultSequence subsequence(java.util.Collection args) throws org.eclipse.wst.xml.xpath2.processor.DynamicError
		public static ResultSequence subsequence(ICollection args)
		{
			ResultBuffer rs = new ResultBuffer();

			// get args
			IEnumerator citer = args.GetEnumerator();
            citer.MoveNext();
            ResultSequence seq = (ResultSequence) citer.Current;
			if (seq.empty())
			{
				return ResultBuffer.EMPTY;
			}

            citer.MoveNext();
            ResultSequence startLoc = (ResultSequence) citer.Current;
			ResultSequence length = null;
			if (citer.MoveNext())
			{
                length = (ResultSequence) citer.Current;
            }

			Item at = startLoc.first();
			if (!(at is NumericType))
			{
				DynamicError.throw_type_error();
			}

			at = new XSDouble(at.StringValue);

			int start = (int)((XSDouble) at).double_value();
			int effectiveNoItems = 0; // no of items beyond index >= 1 that are added to the result

			if (length != null)
			{
				// the 3rd argument is present
				if (length.size() != 1)
				{
					DynamicError.throw_type_error();
				}
				at = length.first();
				if (!(at is NumericType))
				{
					DynamicError.throw_type_error();
				}
				at = new XSDouble(at.StringValue);
				int len = (int)((XSDouble) at).double_value();
				if (len < 0)
				{
					DynamicError.throw_type_error();
				}

				if (start <= 0)
				{
					effectiveNoItems = start + len - 1;
					start = 1;
				}
				else
				{
					effectiveNoItems = len;
				}
			}
			else
			{
				// 3rd argument is absent
				if (start <= 0)
				{
					start = 1;
					effectiveNoItems = seq.size();
				}
				else
				{
					effectiveNoItems = seq.size() - start + 1;
				}
			}

			int pos = 1; // index running parallel to the iterator
			int addedItems = 0;
			if (effectiveNoItems > 0)
			{
				for (var seqIter = seq.iterator(); seqIter.MoveNext();)
				{
					at = (AnyType) seqIter.Current;
					if (start <= pos && addedItems < effectiveNoItems)
					{
						rs.add(at);
						addedItems++;
					}
					pos++;
				}
			}

			return rs.Sequence;
		}

	}
}
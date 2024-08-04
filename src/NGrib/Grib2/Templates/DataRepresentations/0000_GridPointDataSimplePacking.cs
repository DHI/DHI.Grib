﻿/*
 * This file is part of NGrib.
 *
 * Copyright © 2020 Nicolas Mangué
 * 
 * Copyright 2006-2010 Seaware AB, PO Box 1244, SE-131 28 
 * Nacka Strand, Sweden, info@seaware.se.
 * 
 * Copyright 1997-2006 Unidata Program Center/University 
 * Corporation for Atmospheric Research, P.O. Box 3000, Boulder, CO 80307,
 * support@unidata.ucar.edu.
 * 
 * NGrib is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 * 
 * NGrib is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public License
 * along with NGrib.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using NGrib.Grib2.CodeTables;
using NGrib.Grib2.Sections;

namespace NGrib.Grib2.Templates.DataRepresentations
{
	/// <summary>
	/// Data Representation Template 5.0: Grid point data - simple packing
	/// </summary>
	public class GridPointDataSimplePacking : DataRepresentation
	{
		/// <summary>
		/// Reference value (R) .
		/// </summary>
		public float ReferenceValue { get; }

		/// <summary>
		/// Binary scale factor (E).
		/// </summary>
		public int BinaryScaleFactor { get; }

		/// <summary>
		/// Decimal scale factor (D).
		/// </summary>
		public int DecimalScaleFactor { get; }

		/// <summary>
		/// Number of bits used for each packed value for simple packing, or for each group reference value for complex packing or spatial differencing.
		/// </summary>
		public int NumberOfBits { get; }

		/// <summary>
		/// Type of original field values.
		/// </summary>
		public OriginalFieldValuesType OriginalFieldValuesType { get; }

		internal GridPointDataSimplePacking(BufferedBinaryReader reader)
		{
			ReferenceValue = reader.ReadSingle();
			BinaryScaleFactor = reader.ReadInt16();
			DecimalScaleFactor = reader.ReadInt16();
			NumberOfBits = reader.ReadUInt8();

			OriginalFieldValuesType = (OriginalFieldValuesType) reader.ReadUInt8();
		}

        internal GridPointDataSimplePacking(float referenceValue, int binaryScaleFactor, int decimalScaleFactor, int numberOfBits, OriginalFieldValuesType originalFieldValuesType)
        {
            ReferenceValue = referenceValue;
            BinaryScaleFactor = binaryScaleFactor;
            DecimalScaleFactor = decimalScaleFactor;
            NumberOfBits = numberOfBits;
            OriginalFieldValuesType = originalFieldValuesType;
        }

        private protected override IEnumerable<float> DoEnumerateDataValues(BufferedBinaryReader reader, DataSection dataSection, long dataPointsNumber)
		{
			return Unpack(ReadPackedValues(reader, dataSection, dataPointsNumber));
		}

        private protected virtual IEnumerable<int> ReadPackedValues(BufferedBinaryReader reader, DataSection dataSection, long dataPointsNumber)
        {
            reader.NextUIntN();
            for (var i = 0; i < dataPointsNumber; i++)
            {
                yield return reader.ReadUIntN(NumberOfBits);
            }
        }

        protected IEnumerable<float> Unpack(IEnumerable<int> packedValues)
		{
            // Special case
            if (NumberOfBits == 0)
            {
                foreach (var _ in packedValues)
                {
                    yield return ReferenceValue;
                }
				yield break;
            }

            var d = DecimalScaleFactor;

			var dd = Math.Pow(10, d);

			var r = ReferenceValue;

			var e = BinaryScaleFactor;

			var ee = Math.Pow(2.0, e);

			//  Y * 10**D = R + (X1 + X2) * 2**E
			//   E = binary scale factor
			//   D = decimal scale factor
			//   R = reference value
			//   X1 = 0
			//   X2 = scaled encoded value 
			foreach(var item in packedValues)
            {
                // (R + ( X1 + X2) * EE)/DD ;
                yield return (float) ((r + item * ee) / dd);
            }
		}
	}
}
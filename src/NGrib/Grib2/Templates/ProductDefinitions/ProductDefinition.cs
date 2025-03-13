﻿/*
 * This file is part of NGrib.
 *
 * Copyright © 2020 Nicolas Mangué
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

using NGrib.Grib2.CodeTables;

namespace NGrib.Grib2.Templates.ProductDefinitions
{
	/// <summary>
	/// Represents a GRIB2 Product Definition.
	/// </summary>
	public abstract class ProductDefinition : Template, IProductDefinition
	{
		/// <summary>
		/// Start position on the product definition.
		/// </summary>
		public long Offset { get; }

		/// <summary>
		/// Parameter category.
		/// </summary>
		public int ParameterCategory { get; }

		/// <summary>
		/// Parameter number.
		/// </summary>
		public int ParameterNumber { get; }

		/// <summary>
		/// Parameter informations.
		/// </summary>
		/// <remarks>
		/// <c>null</c> if a unknown discipline/category/number is used.
		/// </remarks>
		public Parameter? Parameter { get; }

		/// <summary>
		/// Type of generating process.
		/// </summary>
		public GeneratingProcessType GeneratingProcessType { get; }


		/// <inheritdoc />>
		public abstract TimeRangeUnit TimeRangeUnit { get; }

		/// <inheritdoc />>
		public abstract int ForecastTime { get; }

		private protected ProductDefinition(BufferedBinaryReader reader, Discipline discipline, int centerCode)
		{
			Offset = reader.Position;
			ParameterCategory = reader.ReadUInt8();
			ParameterNumber = reader.ReadUInt8();
			Parameter = CodeTables.Parameter.Get(discipline, centerCode, ParameterCategory, ParameterNumber);
			GeneratingProcessType = (GeneratingProcessType)reader.ReadUInt8();

			RegisterContent(ProductDefinitionContent.ParameterCategory, () => ParameterCategory);
			RegisterContent(ProductDefinitionContent.ParameterNumber, () => ParameterNumber);

			if (Parameter.HasValue)
			{
				RegisterContent(ProductDefinitionContent.Parameter, () => Parameter.Value);
			}

			RegisterContent(ProductDefinitionContent.GeneratingProcessType, () => GeneratingProcessType);
		}
	}
}
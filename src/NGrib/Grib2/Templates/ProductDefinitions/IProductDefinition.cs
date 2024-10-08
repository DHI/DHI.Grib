using NGrib.Grib2.CodeTables;

namespace NGrib.Grib2.Templates.ProductDefinitions;

/// <summary>
/// Represents a GRIB2 Product Definition.
/// </summary>
public interface IProductDefinition : ITemplate
{
	/// <summary>
	/// Start position on the product definition.
	/// </summary>
	long Offset { get; }

	/// <summary>
	/// Parameter category.
	/// </summary>
	int ParameterCategory { get; }

	/// <summary>
	/// Parameter number.
	/// </summary>
	int ParameterNumber { get; }

	/// <summary>
	/// Parameter informations.
	/// </summary>
	/// <remarks>
	/// <c>null</c> if a unknown discipline/category/number is used.
	/// </remarks>
	Parameter? Parameter { get; }

	/// <summary>
	/// Type of generating process.
	/// </summary>
	GeneratingProcessType GeneratingProcessType { get; }
}
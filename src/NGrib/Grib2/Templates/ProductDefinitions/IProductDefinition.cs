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
	/// Parameter information.
	/// </summary>
	/// <remarks>
	/// <c>null</c> if a unknown discipline/category/number is used.
	/// </remarks>
	Parameter? Parameter { get; }

	/// <summary>
	/// Type of generating process.
	/// </summary>
	GeneratingProcessType GeneratingProcessType { get; }

	/// <summary>
	/// Indicator of unit of time range.
	/// </summary>
	public TimeRangeUnit TimeRangeUnit { get; }

	/// <summary>
	/// Forecast time in units defined by indicator of unit of time range.
	/// </summary>
	public int ForecastTime { get; }
}

public interface ILeveledProductDefinition : IProductDefinition
{
	/// <summary>
	/// Type of first fixed surface.
	/// </summary>
	public FixedSurfaceType FirstFixedSurfaceType { get; }

	/// <summary>
	/// Value of first fixed surface.
	/// </summary>
	public double? FirstFixedSurfaceValue { get; }
}
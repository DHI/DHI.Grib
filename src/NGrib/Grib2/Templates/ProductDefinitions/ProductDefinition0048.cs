using System;
using NGrib.Grib2.CodeTables;

namespace NGrib.Grib2.Templates.ProductDefinitions;

/// <summary>
/// Product Definition Template 4.32: Analysis or Forecast at a horizontal level or in a horizontal layer at a point in time for simulated (synthetic) satellite data
/// </summary>
public class ProductDefinition0048 : Template, ILeveledProductDefinition
{
	/// <inheritdoc/>
	public long Offset { get; }

	/// <inheritdoc/>
	public int ParameterCategory { get; }

	/// <inheritdoc/>
	public int ParameterNumber { get; }

	/// <summary>
	/// Aerosol Type
	/// </summary>
	public AerosolType AerosolType { get; }

	/// <summary>
	/// Type of interval for first and second size
	/// </summary>
	public IntervalType IntervalTypeSize { get; }

	/// <summary>
	/// Scale factor of first size
	/// </summary>
	public double? ScaledValueFirstSize { get; }

	/// <summary>
	/// Scale factor of second size
	/// </summary>
	public double? ScaledValueSecondSize { get; }

	/// <summary>
	/// Type of interval for first and second size
	/// </summary>
	public IntervalType IntervalTypeWaveLength { get; }

	/// <summary>
	/// Scale factor of first wavelength
	/// </summary>
	public double? ScaledValueFirstWavelength { get; }

	/// <summary>
	/// Scale factor of second wavelength
	/// </summary>
	public double? ScaledValueSecondWavelength { get; }

	/// <summary>
	/// Background generating process identifier.
	/// </summary>
	public int BackgroundGeneratingProcessIdentifier { get; }

	/// <summary>
	/// Analysis or forecast generating process identifier.
	/// </summary>
	public int AnalysisGeneratingProcessIdentifier { get; }

	/// <summary>
	/// Hours of observational data cutoff after reference time.
	/// </summary>
	/// <remarks>Minutes greater than 65534 will be coded as 65534</remarks>
	public int HoursAfter { get; }

	/// <summary>
	/// Minutes of observational data cutoff after reference time.
	/// </summary>
	/// <remarks>Minutes greater than 65534 will be coded as 65534</remarks>
	public int MinutesAfter { get; }

	/// <summary>
	/// Timespan of observational data cutoff after reference time.
	/// </summary>
	public TimeSpan ObservationalDataCutoff { get; }

	/// <summary>
	/// Indicator of unit of time range.
	/// </summary>
	public TimeRangeUnit TimeRangeUnit { get; }

	/// <summary>
	/// Forecast time in units defined by indicator of unit of time range.
	/// </summary>
	public int ForecastTime { get; }

	/// <summary>
	/// Type of first fixed surface.
	/// </summary>
	public FixedSurfaceType FirstFixedSurfaceType { get; }

	/// <summary>
	/// Value of first fixed surface.
	/// </summary>
	public double? FirstFixedSurfaceValue { get; }

	/// <summary>
	/// Type of second fixed surface.
	/// </summary>
	public FixedSurfaceType SecondFixedSurfaceType { get; }

	/// <summary>
	/// Value of second fixed surface.
	/// </summary>
	public double? SecondFixedSurfaceValue { get; }

	/// <inheritdoc/>
	public Parameter? Parameter { get; }

	/// <inheritdoc/>
	public GeneratingProcessType GeneratingProcessType { get; }

	internal ProductDefinition0048(BufferedBinaryReader reader, Discipline discipline, int centerCode)
	{
		Offset = reader.Position;

		//10
		ParameterCategory = reader.ReadUInt8();

		//11
		ParameterNumber = reader.ReadUInt8();
		Parameter = CodeTables.Parameter.Get(discipline, centerCode, ParameterCategory, ParameterNumber);

		//12-13
		AerosolType = (AerosolType)reader.ReadUInt16();

		//14
		IntervalTypeSize = (IntervalType)reader.ReadInt8();

		//15-19
		ScaledValueFirstSize = reader.ReadScaledValue();

		//20-24
		ScaledValueSecondSize = reader.ReadScaledValue();

		//25 
		IntervalTypeWaveLength = (IntervalType)reader.ReadUInt8();

		//26-30
		ScaledValueFirstWavelength = reader.ReadScaledValue();

		//31-35
		ScaledValueSecondWavelength = reader.ReadScaledValue();

		//36
		GeneratingProcessType = (GeneratingProcessType)reader.ReadUInt8();

		//37
		BackgroundGeneratingProcessIdentifier = reader.ReadUInt8();

		//38
		AnalysisGeneratingProcessIdentifier = reader.ReadUInt8();

		//39-40
		HoursAfter = reader.ReadUInt16();
		//41
		MinutesAfter = reader.ReadUInt8();
		ObservationalDataCutoff = TimeSpan.FromHours(HoursAfter) + TimeSpan.FromMinutes(MinutesAfter);
		//42
		TimeRangeUnit = (TimeRangeUnit)reader.ReadUInt8();
		//43-46
		ForecastTime = reader.ReadInt32();

		//47
		FirstFixedSurfaceType = (FixedSurfaceType)reader.ReadUInt8();
		//48-52
		FirstFixedSurfaceValue = reader.ReadScaledValue();

		//53
		SecondFixedSurfaceType = (FixedSurfaceType)reader.ReadUInt8();
		//54-58
		SecondFixedSurfaceValue = reader.ReadScaledValue();

		RegisterContent(ProductDefinitionContent.ParameterCategory, () => ParameterCategory);
		RegisterContent(ProductDefinitionContent.ParameterNumber, () => ParameterNumber);

		if (Parameter.HasValue)
		{
			RegisterContent(ProductDefinitionContent.Parameter, () => Parameter.Value);
		}

		RegisterContent(ProductDefinitionContent.GeneratingProcessType, () => GeneratingProcessType);
	}
}
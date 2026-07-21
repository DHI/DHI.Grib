using System.IO;
using System.Linq;
using NFluent;
using NGrib.Grib2.CodeTables;
using Xunit;

namespace NGrib.Tests
{
	/// <summary>
	/// Regression tests for WMO GRIB2 parameter (discipline 0, category 5, number 3):
	/// "Surface long-wave (thermal) radiation downwards". This is how ECCC (Environment and
	/// Climate Change Canada) MSC HRDPS encodes downward long-wave radiation. Before it was added
	/// to <see cref="Parameter"/>, the table only had the NCEP-local variant (category 5, number
	/// 192), so this record resolved to no parameter and was dropped by consumers.
	/// </summary>
	public class Grib2Reader_HrdpsLongWave_Test
	{
		[Fact]
		public void ParameterTable_ResolvesSurfaceLongWaveRadiationDownwards()
		{
			// Discipline 0 (meteorological), category 5 (long-wave radiation), number 3.
			var parameter = Parameter.Get(Discipline.MeteorologicalProducts, centerCode: 54, parameterCategory: 5, parameterNumber: 3);

			Check.That(parameter).IsEqualTo(Parameter.SurfaceLongWaveRadiationDownwards);
			Check.That(parameter.Value.Name).IsEqualTo("Surface long-wave (thermal) radiation downwards");
			Check.That(parameter.Value.Unit).IsEqualTo("J m-2");
		}

		[Fact]
		public void Reads_Hrdps_SurfaceLongWaveRadiationDownwards()
		{
			using var stream = File.OpenRead(GribFileSamples.HrdpsLongWaveRadiationDownwardsFile);
			var reader = new Grib2Reader(stream);

			var dataset = reader.ReadAllDataSets().Single();
			Check.That(dataset.Parameter).IsEqualTo(Parameter.SurfaceLongWaveRadiationDownwards);

			// ReadDataSetRawData (values without paired coordinates) is used here because grid-point
			// coordinate enumeration is not implemented for this rotated-lat/lon grid; it is also the
			// path consumers take for these files.
			var values = reader.ReadDataSetRawData(dataset)
				.Where(v => v.HasValue)
				.Select(v => v.Value)
				.ToList();

			// The HRDPS 2.5 km east grid is 2540 x 1290 = 3 276 600 points, all present (no bitmap).
			Check.That(values.Count).IsEqualTo(3276600);

			// Min/max cross-checked with an independent OpenJPEG decode of the same file (the grib is
			// a Jpeg2000-packed hourly accumulation in J m-2, DRS template 5.40). The minimum equals the
			// reference value * 100 exactly (Jpeg2000 integer 0).
			Check.That(values.Min()).IsCloseTo(522543.5, 1.0);
			Check.That(values.Max()).IsCloseTo(1724543.5, 1.0);
			Check.That(values.All(v => v >= 0f)).IsTrue();
		}
	}
}

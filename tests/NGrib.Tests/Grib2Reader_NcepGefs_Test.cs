using System.IO;
using System.Linq;
using NFluent;
using NGrib.Grib2.CodeTables;
using NGrib.Grib2.Templates.ProductDefinitions;
using Xunit;

namespace NGrib.Tests
{
	public class Grib2Reader_NcepGefs_Test
	{
		[Fact]
		public void Read_AvgFile_Test()
		{
			using var stream = File.OpenRead(GribFileSamples.NcepGefsAvgFile);
			var reader = new Grib2Reader(stream);

			var datasets = reader.ReadAllDataSets().ToArray();

			var apcpDataset = datasets.Single(d => d.Parameter.Equals(Parameter.TotalPrecipitation));
			Check.That(apcpDataset.ProductDefinitionSection.ProductDefinition.TryGet(ProductDefinitionContent.EnsembleForecastsNumber, out var ensembleForecastsNumber)).IsTrue();
			Check.That(ensembleForecastsNumber).IsEqualTo(20);
		}

		[Fact]
		public void Read_PerturbationFile_Test()
		{
			using var stream = File.OpenRead(GribFileSamples.NcepGefsPerturbationFile);
			var reader = new Grib2Reader(stream);

			var datasets = reader.ReadAllDataSets().ToArray();

			const int expectedEnsembleForecastsNumber = 20;
			const int expectedPerturbationNumber = 8;

			int perturbationNumber;
			int ensembleForecastsNumber;

			var tmpDataSet = datasets.Single(datasets => datasets.Parameter.Equals(Parameter.Temperature));
			Check.That(tmpDataSet.ProductDefinitionSection.ProductDefinition.TryGet(ProductDefinitionContent.EnsembleForecastsNumber, out ensembleForecastsNumber)).IsTrue();
			Check.That(ensembleForecastsNumber).IsEqualTo(expectedEnsembleForecastsNumber);

			Check.That(tmpDataSet.ProductDefinitionSection.TryGet(ProductDefinitionContent.PerturbationNumber, out perturbationNumber)).IsTrue();
			Check.That(perturbationNumber).IsEqualTo(expectedPerturbationNumber);

			var apcpDataset = datasets.Single(d => d.Parameter.Equals(Parameter.TotalPrecipitation));
			Check.That(apcpDataset.ProductDefinitionSection.ProductDefinition.TryGet(ProductDefinitionContent.EnsembleForecastsNumber, out ensembleForecastsNumber)).IsTrue();
			Check.That(ensembleForecastsNumber).IsEqualTo(expectedEnsembleForecastsNumber);

			Check.That(apcpDataset.ProductDefinitionSection.TryGet(ProductDefinitionContent.PerturbationNumber, out perturbationNumber)).IsTrue();
			Check.That(perturbationNumber).IsEqualTo(expectedPerturbationNumber);
		}

		[Fact]
		public void Read_CombinedDataSets_Test()
		{
			using var stream = File.OpenRead(GribFileSamples.NcepGefsWaveFile);
			var reader = new Grib2Reader(stream);
			var dataSets = reader.ReadAllDataSets().ToArray();

			var parameters = dataSets.Select(ds => ds.Parameter).ToArray();
			Check.That(parameters).ContainsNoNull();

			var combinedDirection = parameters.First(p => p.Value.Code == 14);
			Check.That(combinedDirection.Value.Name).Equals("Direction of combined wind waves and swell");

			var combinedPeriod = parameters.First(p => p.Value.Code == 15);
			Check.That(combinedPeriod.Value.Name).Equals("Period of combined wind waves and swell");

			var inverseFrequency = parameters.First(p => p.Value.Code == 25);
			Check.That(inverseFrequency.Value.Name).Equals("Inverse mean wave frequency");
		}

		[Fact]
		public void Read_ProductDefinition48_Test()
		{
			using var stream = File.OpenRead(GribFileSamples.NcepGefsChemFile);
			var reader = new Grib2Reader(stream);

			var dataSets = reader.ReadAllDataSets().ToArray();

			Check.That(dataSets).CountIs(32);

			var parameters = dataSets.Select(ds => ds.Parameter).ToArray();
			Check.That(parameters).ContainsNoNull();

			Check.That(dataSets).ContainsOnlyElementsThatMatch(ds => ds.ProductDefinitionSection.ProductDefinitionTemplateNumber == 48);

			var productDefinitions = dataSets.Select(ds => ds.ProductDefinitionSection.ProductDefinition).ToArray();
			Check.That(productDefinitions).ContainsOnlyInstanceOfType(typeof(ProductDefinition0048));

			var productDefinitions48 = productDefinitions.OfType<ProductDefinition0048>().ToArray();
			Check.That(productDefinitions48).ContainsOnlyElementsThatMatch(pd => pd.GeneratingProcessType == GeneratingProcessType.Forecast);
			Check.That(productDefinitions48.Select(pd => pd.AerosolType)).Contains(AerosolType.TotalAerosol, AerosolType.DustDry, AerosolType.SeaSaltDry, AerosolType.BlackCarbonDry);
			Check.That(productDefinitions48.Select(pd => pd.ForecastTime)).Contains(0);

			var chemicals = productDefinitions48.Where(pd => pd.Parameter.Value.Category.Code == 20).ToArray();
			Check.That(chemicals).ContainsOnlyElementsThatMatch(pd => pd.FirstFixedSurfaceType == FixedSurfaceType.EntireAtmosphere);

			var opticalThickness = chemicals.First(c => c.Parameter.Value.Code == 102);
			Check.That(opticalThickness.Parameter.Value.Name).Equals("Aerosol Optical Thickness");

			var aerosols = productDefinitions48.Where(pd => pd.Parameter.Value.Category.Code == 13).ToArray();
			Check.That(aerosols).ContainsOnlyElementsThatMatch(pd => pd.FirstFixedSurfaceType == FixedSurfaceType.GroundOrWaterSurface);

			var particulateMatterCourse = aerosols.First(c => c.Parameter.Value.Code == 192);
			Check.That(particulateMatterCourse.Parameter.Value.Name).Equals("Particulate matter (coarse)");
		}
	}
}
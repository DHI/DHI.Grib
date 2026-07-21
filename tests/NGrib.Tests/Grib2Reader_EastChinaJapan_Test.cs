using System.Collections.Generic;
using System.Linq;
using NFluent;
using Xunit;

namespace NGrib.Tests;

public class Grib2Reader_EastChinaJapan_Test
{
    [Fact]
    public void ReadDataSetValues_Ice_ReturnsExpected()
    {
        var reader = new Grib2Reader(GribFileSamples.EastChina_Japan);

        var allDataSets = reader.ReadAllDataSets();
        var dsIce = allDataSets.First(ds => ds.ProductDefinitionSection.ProductDefinition.Parameter.Value.Name == "Ice cover");

        // Sea ice area fraction is a constant all-zero field (encoded with zero groups); every value
        // must decode to 0. eccodes confirms min = max = 0 for this record.
        var items = reader.ReadDataSetValues(dsIce).ToArray();
        Check.That(items).HasSize(45240);
        Check.That(items.All(kv => kv.Value == 0f)).IsTrue();
    }

    [Fact]
    public void ReadDataSetValues_U10_ReturnsExpected()
    {
        var reader = new Grib2Reader(GribFileSamples.EastChina_Japan);

        var allDataSets = reader.ReadAllDataSets();
        var dsU10 = allDataSets.First(ds => ds.ProductDefinitionSection.ProductDefinition.Parameter.Value.Name == "u-component of wind");

        // Expected min/max/average cross-checked with eccodes for this record.
        var items = reader.ReadDataSetRawData(dsU10).ToArray();
        Check.That(items.Min().Value).IsCloseTo(-10.2, 1e-1);
        Check.That(items.Max().Value).IsCloseTo(8.4, 1e-1);
        Check.That(items.Average().Value).IsCloseTo(-0.6774, 1e-4);
    }
}
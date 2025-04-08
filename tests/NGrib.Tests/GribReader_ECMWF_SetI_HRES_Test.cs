using System;
using System.IO;
using System.Linq;
using NFluent;
using Xunit;

namespace NGrib.Tests;

public class GribReader_ECMWF_SetI_HRES_Test
{
    [Fact]
    public void Test_A1S()
    {
        using var stream = File.OpenRead(GribFileSamples.ECMWFFileA1S);
        var reader = new Grib1Reader(stream);

        var records = reader.ReadRecords().ToArray();

        var record = records.First();

        Check.That(record.GridDefinitionSection.GridType).Equals(0);
        Check.That(record.GridDefinitionSection.dx).Equals(0.1);
        Check.That(record.GridDefinitionSection.dy).Equals(0.1);
        Check.That(record.GridDefinitionSection.lat1).Equals(90);
        Check.That(record.GridDefinitionSection.lat2).Equals(-90);
    }
    [Fact]
    public void Test_A1D()
    {
        using var stream = File.OpenRead(GribFileSamples.ECMWFFileA1D);
        var reader = new Grib1Reader(stream);

        var records = reader.ReadRecords().ToArray();

        var record = records.First();

        Check.That(record.GridDefinitionSection.GridType).Equals(0);
        Check.That(record.GridDefinitionSection.dx).Equals(0.1);
        Check.That(record.GridDefinitionSection.dy).Equals(0.1);
        Check.That(record.GridDefinitionSection.lat1).Equals(90);
        Check.That(record.GridDefinitionSection.lat2).Equals(-90);
    }

    [Fact]
    public void Test_A1M()
    {
        var reader = new Grib2Reader(GribFileSamples.ECMWFFileA1M);

        var synMsg = reader.ReadAllDataSets().First();

        Check.That(synMsg.ProductDefinitionSection.ProductDefinitionTemplateNumber).IsEqualTo(0);

        var data = reader.ReadDataSetRawData(synMsg).ToArray();

        Check.That(data.Length).IsEqualTo(6483600);
        Check.That(data.Max()).IsEqualTo(100.010757f);
    }
}

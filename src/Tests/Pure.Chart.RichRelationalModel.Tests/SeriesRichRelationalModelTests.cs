using Pure.Chart.RelationalModel.Abstractions;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;
using Guid = Pure.Primitives.Guid.Guid;

namespace Pure.Chart.RichRelationalModel.Tests;

public sealed record SeriesRichRelationalModelTests
{
    [Fact]
    public void InitializeIdCorrectly()
    {
        IGuid guid = new Guid();
        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            guid,
            new Guid(),
            new RandomString(),
            new RandomString(),
            new RandomString()
        );

        Assert.Equal(guid.GuidValue, model.Id.GuidValue);
    }

    [Fact]
    public void InitializeChartIdCorrectly()
    {
        IGuid guid = new Guid();
        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            new Guid(),
            guid,
            new RandomString(),
            new RandomString(),
            new RandomString()
        );

        Assert.Equal(guid.GuidValue, model.ChartId.GuidValue);
    }

    [Fact]
    public void InitializeLegendCorrectly()
    {
        IString legend = new RandomString();
        ISeriesRelationalModel model = new SeriesRichRelationalModel(
            new Guid(),
            new Guid(),
            legend,
            new RandomString(),
            new RandomString()
        );

        Assert.Equal(legend.TextValue, model.Legend.TextValue);
    }

    [Fact]
    public void InitializeXAxisSourceCorrectly()
    {
        IString source = new RandomString();
        ISeriesRelationalModel model = new SeriesRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString(),
            source,
            new RandomString()
        );

        Assert.Equal(source.TextValue, model.XAxisSource.TextValue);
    }

    [Fact]
    public void InitializeYAxisSourceCorrectly()
    {
        IString source = new RandomString();
        ISeriesRelationalModel model = new SeriesRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString(),
            new RandomString(),
            source
        );

        Assert.Equal(source.TextValue, model.YAxisSource.TextValue);
    }

    [Fact]
    public void InitializesIdCorrectlyByCopyCtor()
    {
        ISeriesRichRelationalModel source = new SeriesRichRelationalModel(new Guid(), new Guid(), new RandomString(), new RandomString(), new RandomString());
        ISeriesRichRelationalModel copy = new SeriesRichRelationalModel(source);

        Assert.Equal(source.Id.GuidValue, copy.Id.GuidValue);
    }

    [Fact]
    public void InitializesChartIdCorrectlyByCopyCtor()
    {
        ISeriesRichRelationalModel source = new SeriesRichRelationalModel(new Guid(), new Guid(), new RandomString(), new RandomString(), new RandomString());
        ISeriesRichRelationalModel copy = new SeriesRichRelationalModel(source);

        Assert.Equal(source.ChartId.GuidValue, copy.ChartId.GuidValue);
    }

    [Fact]
    public void InitializesLegendCorrectlyByCopyCtor()
    {
        ISeriesRichRelationalModel source = new SeriesRichRelationalModel(new Guid(), new Guid(), new RandomString(), new RandomString(), new RandomString());
        ISeriesRelationalModel copy = new SeriesRichRelationalModel(source);

        Assert.Equal(((ISeriesRelationalModel)source).Legend.TextValue, copy.Legend.TextValue);
    }

    [Fact]
    public void InitializesXAxisSourceCorrectlyByCopyCtor()
    {
        ISeriesRichRelationalModel source = new SeriesRichRelationalModel(new Guid(), new Guid(), new RandomString(), new RandomString(), new RandomString());
        ISeriesRelationalModel copy = new SeriesRichRelationalModel(source);

        Assert.Equal(((ISeriesRelationalModel)source).XAxisSource.TextValue, copy.XAxisSource.TextValue);
    }

    [Fact]
    public void InitializesYAxisSourceCorrectlyByCopyCtor()
    {
        ISeriesRichRelationalModel source = new SeriesRichRelationalModel(new Guid(), new Guid(), new RandomString(), new RandomString(), new RandomString());
        ISeriesRelationalModel copy = new SeriesRichRelationalModel(source);

        Assert.Equal(((ISeriesRelationalModel)source).YAxisSource.TextValue, copy.YAxisSource.TextValue);
    }
}

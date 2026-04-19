using Pure.Chart.RelationalModel.Abstractions;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;
using Guid = Pure.Primitives.Guid.Guid;

namespace Pure.Chart.RichRelationalModel.Tests;

public sealed record ChartSeriesRichRelationalModelTests
{
    [Fact]
    public void InitializeIdCorrectly()
    {
        IGuid guid = new Guid();
        IChartSeriesRichRelationalModel model = new ChartSeriesRichRelationalModel(
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
        IChartSeriesRichRelationalModel model = new ChartSeriesRichRelationalModel(
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
        IChartSeriesRelationalModel model = new ChartSeriesRichRelationalModel(
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
        IChartSeriesRelationalModel model = new ChartSeriesRichRelationalModel(
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
        IChartSeriesRelationalModel model = new ChartSeriesRichRelationalModel(
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
        IChartSeriesRichRelationalModel source = new ChartSeriesRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString(),
            new RandomString(),
            new RandomString()
        );
        IChartSeriesRichRelationalModel copy = new ChartSeriesRichRelationalModel(source);

        Assert.Equal(source.Id.GuidValue, copy.Id.GuidValue);
    }

    [Fact]
    public void InitializesChartIdCorrectlyByCopyCtor()
    {
        IChartSeriesRichRelationalModel source = new ChartSeriesRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString(),
            new RandomString(),
            new RandomString()
        );
        IChartSeriesRichRelationalModel copy = new ChartSeriesRichRelationalModel(source);

        Assert.Equal(source.ChartId.GuidValue, copy.ChartId.GuidValue);
    }

    [Fact]
    public void InitializesLegendCorrectlyByCopyCtor()
    {
        IChartSeriesRichRelationalModel source = new ChartSeriesRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString(),
            new RandomString(),
            new RandomString()
        );
        IChartSeriesRelationalModel copy = new ChartSeriesRichRelationalModel(source);

        Assert.Equal(
            ((IChartSeriesRelationalModel)source).Legend.TextValue,
            copy.Legend.TextValue
        );
    }

    [Fact]
    public void InitializesXAxisSourceCorrectlyByCopyCtor()
    {
        IChartSeriesRichRelationalModel source = new ChartSeriesRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString(),
            new RandomString(),
            new RandomString()
        );
        IChartSeriesRelationalModel copy = new ChartSeriesRichRelationalModel(source);

        Assert.Equal(
            ((IChartSeriesRelationalModel)source).XAxisSource.TextValue,
            copy.XAxisSource.TextValue
        );
    }

    [Fact]
    public void InitializesYAxisSourceCorrectlyByCopyCtor()
    {
        IChartSeriesRichRelationalModel source = new ChartSeriesRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString(),
            new RandomString(),
            new RandomString()
        );
        IChartSeriesRelationalModel copy = new ChartSeriesRichRelationalModel(source);

        Assert.Equal(
            ((IChartSeriesRelationalModel)source).YAxisSource.TextValue,
            copy.YAxisSource.TextValue
        );
    }
}

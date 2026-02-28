using Pure.Chart.RelationalModel.Abstractions;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;
using Guid = Pure.Primitives.Guid.Guid;

namespace Pure.Chart.RichRelationalModel.Tests;

public sealed record AxisRichRelationalModelTests
{
    [Fact]
    public void InitializeIdCorrectly()
    {
        IGuid guid = new Guid();
        IAxisRichRelationalModel model = new AxisRichRelationalModel(
            guid,
            new Guid(),
            new RandomString()
        );

        Assert.Equal(guid.GuidValue, model.Id.GuidValue);
    }

    [Fact]
    public void InitializeChartIdCorrectly()
    {
        IGuid guid = new Guid();
        IAxisRichRelationalModel model = new AxisRichRelationalModel(
            new Guid(),
            guid,
            new RandomString()
        );

        Assert.Equal(guid.GuidValue, model.ChartId.GuidValue);
    }

    [Fact]
    public void InitializeLegendCorrectly()
    {
        IString legend = new RandomString();
        IAxisRelationalModel model = new AxisRichRelationalModel(
            new Guid(),
            new Guid(),
            legend
        );

        Assert.Equal(legend.TextValue, model.Legend.TextValue);
    }
}

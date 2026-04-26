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
            new RandomString()
        );

        Assert.Equal(guid.GuidValue, model.Id.GuidValue);
    }

    [Fact]
    public void InitializeLegendCorrectly()
    {
        IString legend = new RandomString();
        IAxisRelationalModel model = new AxisRichRelationalModel(new Guid(), legend);

        Assert.Equal(legend.TextValue, model.Legend.TextValue);
    }

    [Fact]
    public void InitializesIdCorrectlyByCopyCtor()
    {
        IAxisRichRelationalModel source = new AxisRichRelationalModel(
            new Guid(),
            new RandomString()
        );
        IAxisRichRelationalModel copy = new AxisRichRelationalModel(source);

        Assert.Equal(source.Id.GuidValue, copy.Id.GuidValue);
    }

    [Fact]
    public void InitializesLegendCorrectlyByCopyCtor()
    {
        IAxisRichRelationalModel source = new AxisRichRelationalModel(
            new Guid(),
            new RandomString()
        );
        IAxisRelationalModel copy = new AxisRichRelationalModel(source);

        Assert.Equal(
            ((IAxisRelationalModel)source).Legend.TextValue,
            copy.Legend.TextValue
        );
    }
}

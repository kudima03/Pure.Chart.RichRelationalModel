using Pure.Chart.RelationalModel.Abstractions;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;
using Guid = Pure.Primitives.Guid.Guid;

namespace Pure.Chart.RichRelationalModel.Tests;

public sealed record ChartTypeRichRelationalModelTests
{
    [Fact]
    public void InitializeIdCorrectly()
    {
        IGuid guid = new Guid();
        IChartTypeRichRelationalModel model = new ChartTypeRichRelationalModel(
            guid,
            new RandomString()
        );

        Assert.Equal(guid.GuidValue, model.Id.GuidValue);
    }

    [Fact]
    public void InitializeNameCorrectly()
    {
        IString name = new RandomString();
        IChartTypeRelationalModel model = new ChartTypeRichRelationalModel(
            new Guid(),
            name
        );

        Assert.Equal(name.TextValue, model.Name.TextValue);
    }

    [Fact]
    public void InitializesIdCorrectlyByCopyCtor()
    {
        IChartTypeRichRelationalModel source = new ChartTypeRichRelationalModel(new Guid(), new RandomString());
        IChartTypeRichRelationalModel copy = new ChartTypeRichRelationalModel(source);

        Assert.Equal(source.Id.GuidValue, copy.Id.GuidValue);
    }

    [Fact]
    public void InitializesNameCorrectlyByCopyCtor()
    {
        IChartTypeRichRelationalModel source = new ChartTypeRichRelationalModel(new Guid(), new RandomString());
        IChartTypeRelationalModel copy = new ChartTypeRichRelationalModel(source);

        Assert.Equal(((IChartTypeRelationalModel)source).Name.TextValue, copy.Name.TextValue);
    }
}

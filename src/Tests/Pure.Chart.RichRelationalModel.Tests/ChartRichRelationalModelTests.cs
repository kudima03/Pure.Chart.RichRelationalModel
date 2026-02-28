using Pure.Chart.Model.Abstractions;
using Pure.Chart.RelationalModel.Abstractions;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;
using Guid = Pure.Primitives.Guid.Guid;

namespace Pure.Chart.RichRelationalModel.Tests;

public sealed record ChartRichRelationalModelTests
{
    [Fact]
    public void InitializeIdCorrectly()
    {
        IGuid guid = new Guid();
        IChartRichRelationalModel model = new ChartRichRelationalModel(
            guid,
            new RandomString(),
            new RandomString(),
            new Guid(),
            new ChartTypeRichRelationalModel(new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            []
        );

        Assert.Equal(guid.GuidValue, model.Id.GuidValue);
    }

    [Fact]
    public void InitializeTitleCorrectly()
    {
        IString title = new RandomString();
        IChartRelationalModel model = new ChartRichRelationalModel(
            new Guid(),
            title,
            new RandomString(),
            new Guid(),
            new ChartTypeRichRelationalModel(new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            []
        );

        Assert.Equal(title.TextValue, model.Title.TextValue);
    }

    [Fact]
    public void InitializeDescriptionCorrectly()
    {
        IString description = new RandomString();
        IChartRelationalModel model = new ChartRichRelationalModel(
            new Guid(),
            new RandomString(),
            description,
            new Guid(),
            new ChartTypeRichRelationalModel(new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            []
        );

        Assert.Equal(description.TextValue, model.Description.TextValue);
    }

    [Fact]
    public void InitializeTypeIdCorrectly()
    {
        IGuid guid = new Guid();
        IChartRichRelationalModel model = new ChartRichRelationalModel(
            new Guid(),
            new RandomString(),
            new RandomString(),
            guid,
            new ChartTypeRichRelationalModel(new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            []
        );

        Assert.Equal(guid.GuidValue, model.TypeId.GuidValue);
    }

    [Fact]
    public void InitializeTypeCorrectly()
    {
        IChartType type = new ChartTypeRichRelationalModel(
            new Guid(),
            new RandomString()
        );
        IChart model = new ChartRichRelationalModel(
            new Guid(),
            new RandomString(),
            new RandomString(),
            new Guid(),
            type,
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            []
        );

        Assert.Equal(type.Name.TextValue, model.Type.Name.TextValue);
    }

    [Fact]
    public void InitializeXAxisIdCorrectly()
    {
        IGuid guid = new Guid();
        IChartRichRelationalModel model = new ChartRichRelationalModel(
            new Guid(),
            new RandomString(),
            new RandomString(),
            new Guid(),
            new ChartTypeRichRelationalModel(new Guid(), new RandomString()),
            guid,
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            []
        );

        Assert.Equal(guid.GuidValue, model.XAxisId.GuidValue);
    }

    [Fact]
    public void InitializeXAxisCorrectly()
    {
        IAxisRichRelationalModel xAxis = new AxisRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString()
        );
        IChart model = new ChartRichRelationalModel(
            new Guid(),
            new RandomString(),
            new RandomString(),
            new Guid(),
            new ChartTypeRichRelationalModel(new Guid(), new RandomString()),
            new Guid(),
            xAxis,
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            []
        );

        Assert.Equal(
            xAxis.Id.GuidValue,
            ((IAxisRichRelationalModel)model.XAxis).Id.GuidValue
        );
        Assert.Equal(
            xAxis.ChartId.GuidValue,
            ((IAxisRichRelationalModel)model.XAxis).ChartId.GuidValue
        );
        Assert.Equal(
            ((IAxisRelationalModel)xAxis).Legend.TextValue,
            ((IAxisRelationalModel)model.XAxis).Legend.TextValue
        );
    }

    [Fact]
    public void InitializeYAxisIdCorrectly()
    {
        IGuid guid = new Guid();
        IChartRichRelationalModel model = new ChartRichRelationalModel(
            new Guid(),
            new RandomString(),
            new RandomString(),
            new Guid(),
            new ChartTypeRichRelationalModel(new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            guid,
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            []
        );

        Assert.Equal(guid.GuidValue, model.YAxisId.GuidValue);
    }

    [Fact]
    public void InitializeYAxisCorrectly()
    {
        IAxisRichRelationalModel yAxis = new AxisRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString()
        );
        IChart model = new ChartRichRelationalModel(
            new Guid(),
            new RandomString(),
            new RandomString(),
            new Guid(),
            new ChartTypeRichRelationalModel(new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            new Guid(),
            yAxis,
            []
        );

        Assert.Equal(
            yAxis.Id.GuidValue,
            ((IAxisRichRelationalModel)model.YAxis).Id.GuidValue
        );
        Assert.Equal(
            yAxis.ChartId.GuidValue,
            ((IAxisRichRelationalModel)model.YAxis).ChartId.GuidValue
        );
        Assert.Equal(
            ((IAxisRelationalModel)yAxis).Legend.TextValue,
            ((IAxisRelationalModel)model.YAxis).Legend.TextValue
        );
    }

    [Fact]
    public void InitializeSeriesCorrectly()
    {
        IReadOnlyCollection<ISeries> series =
        [
            new SeriesRichRelationalModel(
                new Guid(),
                new Guid(),
                new RandomString(),
                new RandomString(),
                new RandomString()
            ),
            new SeriesRichRelationalModel(
                new Guid(),
                new Guid(),
                new RandomString(),
                new RandomString(),
                new RandomString()
            ),
        ];
        IChart model = new ChartRichRelationalModel(
            new Guid(),
            new RandomString(),
            new RandomString(),
            new Guid(),
            new ChartTypeRichRelationalModel(new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            series
        );

        Assert.Equal(series, model.Series);
    }

    [Fact]
    public void InitializesIdCorrectlyByCopyCtor()
    {
        IChartRichRelationalModel source = new ChartRichRelationalModel(
            new Guid(),
            new RandomString(),
            new RandomString(),
            new Guid(),
            new ChartTypeRichRelationalModel(new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            []
        );
        IChartRichRelationalModel copy = new ChartRichRelationalModel(source);

        Assert.Equal(source.Id.GuidValue, copy.Id.GuidValue);
    }

    [Fact]
    public void InitializesTitleCorrectlyByCopyCtor()
    {
        IChartRichRelationalModel source = new ChartRichRelationalModel(
            new Guid(),
            new RandomString(),
            new RandomString(),
            new Guid(),
            new ChartTypeRichRelationalModel(new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            []
        );
        IChartRelationalModel copy = new ChartRichRelationalModel(source);

        Assert.Equal(((IChartRelationalModel)source).Title.TextValue, copy.Title.TextValue);
    }

    [Fact]
    public void InitializesDescriptionCorrectlyByCopyCtor()
    {
        IChartRichRelationalModel source = new ChartRichRelationalModel(
            new Guid(),
            new RandomString(),
            new RandomString(),
            new Guid(),
            new ChartTypeRichRelationalModel(new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            []
        );
        IChartRelationalModel copy = new ChartRichRelationalModel(source);

        Assert.Equal(((IChartRelationalModel)source).Description.TextValue, copy.Description.TextValue);
    }

    [Fact]
    public void InitializesTypeIdCorrectlyByCopyCtor()
    {
        IChartRichRelationalModel source = new ChartRichRelationalModel(
            new Guid(),
            new RandomString(),
            new RandomString(),
            new Guid(),
            new ChartTypeRichRelationalModel(new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            []
        );
        IChartRichRelationalModel copy = new ChartRichRelationalModel(source);

        Assert.Equal(source.TypeId.GuidValue, copy.TypeId.GuidValue);
    }

    [Fact]
    public void InitializesTypeCorrectlyByCopyCtor()
    {
        IChartRichRelationalModel source = new ChartRichRelationalModel(
            new Guid(),
            new RandomString(),
            new RandomString(),
            new Guid(),
            new ChartTypeRichRelationalModel(new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            []
        );
        IChart copy = new ChartRichRelationalModel(source);

        Assert.Equal(source.Type.Name.TextValue, copy.Type.Name.TextValue);
    }

    [Fact]
    public void InitializesXAxisIdCorrectlyByCopyCtor()
    {
        IChartRichRelationalModel source = new ChartRichRelationalModel(
            new Guid(),
            new RandomString(),
            new RandomString(),
            new Guid(),
            new ChartTypeRichRelationalModel(new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            []
        );
        IChartRichRelationalModel copy = new ChartRichRelationalModel(source);

        Assert.Equal(source.XAxisId.GuidValue, copy.XAxisId.GuidValue);
    }

    [Fact]
    public void InitializesXAxisCorrectlyByCopyCtor()
    {
        IChartRichRelationalModel source = new ChartRichRelationalModel(
            new Guid(),
            new RandomString(),
            new RandomString(),
            new Guid(),
            new ChartTypeRichRelationalModel(new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            []
        );
        IChart copy = new ChartRichRelationalModel(source);

        Assert.Equal(source.XAxis.Legend.TextValue, copy.XAxis.Legend.TextValue);
    }

    [Fact]
    public void InitializesYAxisIdCorrectlyByCopyCtor()
    {
        IChartRichRelationalModel source = new ChartRichRelationalModel(
            new Guid(),
            new RandomString(),
            new RandomString(),
            new Guid(),
            new ChartTypeRichRelationalModel(new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            []
        );
        IChartRichRelationalModel copy = new ChartRichRelationalModel(source);

        Assert.Equal(source.YAxisId.GuidValue, copy.YAxisId.GuidValue);
    }

    [Fact]
    public void InitializesYAxisCorrectlyByCopyCtor()
    {
        IChartRichRelationalModel source = new ChartRichRelationalModel(
            new Guid(),
            new RandomString(),
            new RandomString(),
            new Guid(),
            new ChartTypeRichRelationalModel(new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            []
        );
        IChart copy = new ChartRichRelationalModel(source);

        Assert.Equal(source.YAxis.Legend.TextValue, copy.YAxis.Legend.TextValue);
    }

    [Fact]
    public void InitializesSeriesCorrectlyByCopyCtor()
    {
        ISeries[] series =
        [
            new SeriesRichRelationalModel(new Guid(), new Guid(), new RandomString(), new RandomString(), new RandomString()),
            new SeriesRichRelationalModel(new Guid(), new Guid(), new RandomString(), new RandomString(), new RandomString()),
        ];
        IChartRichRelationalModel source = new ChartRichRelationalModel(
            new Guid(),
            new RandomString(),
            new RandomString(),
            new Guid(),
            new ChartTypeRichRelationalModel(new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            series
        );
        IChart copy = new ChartRichRelationalModel(source);

        Assert.Equal(source.Series, copy.Series);
    }
}

using Pure.Chart.RelationalModel.Abstractions;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

namespace Pure.Chart.RichRelationalModel;

public sealed record ChartSeriesRichRelationalModel : IChartSeriesRichRelationalModel
{
    public ChartSeriesRichRelationalModel(IChartSeriesRichRelationalModel richModel)
        : this(
            richModel.Id,
            richModel.ChartId,
            (richModel as IChartSeriesRelationalModel).Legend,
            (richModel as IChartSeriesRelationalModel).XAxisSource,
            (richModel as IChartSeriesRelationalModel).YAxisSource
        )
    { }

    public ChartSeriesRichRelationalModel(
        IGuid id,
        IGuid chartId,
        IString legend,
        IString xAxisSource,
        IString yAxisSource
    )
    {
        Id = id;
        ChartId = chartId;
        Legend = legend;
        XAxisSource = xAxisSource;
        YAxisSource = yAxisSource;
    }

    public IGuid Id { get; }

    public IGuid ChartId { get; }

    public IString Legend { get; }

    public IString XAxisSource { get; }

    public IString YAxisSource { get; }
}

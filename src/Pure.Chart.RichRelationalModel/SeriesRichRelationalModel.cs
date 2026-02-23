using Pure.Chart.RelationalModel.Abstractions;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

namespace Pure.Chart.RichRelationalModel;

public sealed record SeriesRichRelationalModel : ISeriesRichRelationalModel
{
    public SeriesRichRelationalModel(ISeriesRichRelationalModel richModel)
        : this(
            richModel.Id,
            richModel.ChartId,
            (richModel as ISeriesRelationalModel).Legend,
            (richModel as ISeriesRelationalModel).XAxisSource,
            (richModel as ISeriesRelationalModel).YAxisSource
        )
    { }

    public SeriesRichRelationalModel(
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

using Pure.Chart.Model.Abstractions;
using Pure.Chart.RelationalModel.Abstractions;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

namespace Pure.Chart.RichRelationalModel;

public sealed record ChartRichRelationalModel : IChartRichRelationalModel
{
    public ChartRichRelationalModel(IChartRichRelationalModel richModel)
        : this(
            richModel.Id,
            (richModel as IChartRelationalModel).Title,
            (richModel as IChartRelationalModel).Description,
            richModel.TypeId,
            richModel.Type,
            richModel.XAxisId,
            richModel.XAxis,
            richModel.YAxisId,
            richModel.YAxis,
            richModel.Series
        )
    { }

    public ChartRichRelationalModel(
        IGuid id,
        IString title,
        IString description,
        IGuid typeId,
        IChartType type,
        IGuid xAxisId,
        IAxis xAxis,
        IGuid yAxisId,
        IAxis yAxis,
        IEnumerable<ISeries> series
    )
    {
        Id = id;
        Title = title;
        Description = description;
        TypeId = typeId;
        Type = type;
        XAxisId = xAxisId;
        XAxis = xAxis;
        YAxisId = yAxisId;
        YAxis = yAxis;
        Series = series;
    }

    public IGuid Id { get; }

    public IString Title { get; }

    public IString Description { get; }

    public IGuid TypeId { get; }

    public IChartType Type { get; }

    public IGuid XAxisId { get; }

    public IAxis XAxis { get; }

    public IGuid YAxisId { get; }

    public IAxis YAxis { get; }

    public IEnumerable<ISeries> Series { get; }
}

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
            richModel.XAxis,
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
        IAxis xAxis,
        IAxis yAxis,
        IEnumerable<ISeries> series
    )
    {
        Id = id;
        Title = title;
        Description = description;
        TypeId = typeId;
        Type = type;
        XAxis = xAxis;
        YAxis = yAxis;
        Series = series;
    }

    public IGuid Id { get; }

    public IString Title { get; }

    public IString Description { get; }

    public IGuid TypeId { get; }

    public IChartType Type { get; }

    public IAxis XAxis { get; }

    public IAxis YAxis { get; }

    public IEnumerable<ISeries> Series { get; }
}

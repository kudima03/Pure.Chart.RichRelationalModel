using Pure.Chart.RelationalModel.Abstractions;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

namespace Pure.Chart.RichRelationalModel;

public sealed record AxisRichRelationalModel : IAxisRichRelationalModel
{
    public AxisRichRelationalModel(IAxisRichRelationalModel richModel)
        : this(
            richModel.Id,
            richModel.ChartId,
            (richModel as IAxisRelationalModel).Legend
        )
    { }

    public AxisRichRelationalModel(IGuid id, IGuid chartId, IString legend)
    {
        Id = id;
        ChartId = chartId;
        Legend = legend;
    }

    public IGuid Id { get; }

    public IGuid ChartId { get; }

    public IString Legend { get; }
}

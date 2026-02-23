using Pure.Chart.RelationalModel.Abstractions;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

namespace Pure.Chart.RichRelationalModel;

public sealed record ChartTypeRichRelationalModel : IChartTypeRichRelationalModel
{
    public ChartTypeRichRelationalModel(IChartTypeRichRelationalModel richModel)
        : this(richModel.Id, (richModel as IChartTypeRelationalModel).Name) { }

    public ChartTypeRichRelationalModel(IGuid id, IString name)
    {
        Id = id;
        Name = name;
    }

    public IGuid Id { get; }

    public IString Name { get; }
}

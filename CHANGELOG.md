# Changelog

All notable changes to Pure.Chart.RichRelationalModel are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [0.1.0-preview.3.0.0] — 2026-04-26

### Removed

- **`AxisRichRelationalModel`** no longer carries a `ChartId` property. The
  constructor is now `AxisRichRelationalModel(IGuid id, IString legend)`, and
  the copy constructor no longer reads `ChartId` from the source model.

## [0.1.0-preview.2.0.0] — 2026-04-19

### Changed

- **`SeriesRichRelationalModel`** (implementing `ISeriesRichRelationalModel`)
  renamed to **`ChartSeriesRichRelationalModel`** (implementing
  `IChartSeriesRichRelationalModel`).
- **`ChartRichRelationalModel.Series`** changed from
  `IEnumerable<ISeries>` to `IEnumerable<IChartSeries>`, and the constructor
  parameter type changed accordingly.

## [0.1.0-preview.1.0.0] — 2026-02-27

### Added

- **`ChartRichRelationalModel`** now exposes `XAxisId` and `YAxisId` guid
  properties alongside the existing `XAxis`/`YAxis` navigation properties.
  The full constructor gained matching `IGuid xAxisId` and `IGuid yAxisId`
  parameters.

## [0.1.0-preview.0.1.0] — 2026-02-23

Initial release.

### Added

Four sealed-record implementations of rich relational chart models, each
pairing a full-parameter constructor with a copy constructor that accepts
the corresponding interface:

- **`ChartRichRelationalModel`** — a chart carrying its `Id`, `Title`,
  `Description`, `TypeId`/`Type`, `XAxis`, `YAxis`, and `Series`
  (`IEnumerable<ISeries>`).
- **`AxisRichRelationalModel`** — a chart axis with `Id`, `ChartId`, and
  `Legend`.
- **`SeriesRichRelationalModel`** — a chart series with `Id`, `ChartId`,
  `Legend`, `XAxisSource`, and `YAxisSource`.
- **`ChartTypeRichRelationalModel`** — a chart type with `Id` and `Name`.

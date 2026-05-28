# Pure.Chart.RichRelationalModel

Concrete immutable record implementations of the rich relational chart model for the **Pure** ecosystem.

[![Build & test](https://github.com/kudima03/Pure.Chart.RichRelationalModel/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Chart.RichRelationalModel/actions/workflows/build-and-test.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.Chart.RichRelationalModel)](https://www.nuget.org/packages/Pure.Chart.RichRelationalModel)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.Chart.RichRelationalModel` provides sealed record implementations for chart domain entities that combine both the structural (model) and relational aspects of a chart into a single strongly-typed, immutable object. Each record implements a corresponding interface from `Pure.Chart.RichRelationalModel.Abstractions` and exposes primitive-typed properties via the `Pure.Primitives.Abstractions` contracts (`IGuid`, `IString`).

A "rich relational" model is one that carries not only foreign-key identifiers but also the fully resolved navigation objects — e.g. a `ChartRichRelationalModel` holds both `TypeId` (`IGuid`) and `Type` (`IChartType`), both `XAxisId`/`YAxisId` and the resolved `IAxis` instances.

## Types

All types live in the `Pure.Chart.RichRelationalModel` namespace.

| Type | Implements | Properties |
|------|-----------|------------|
| `ChartRichRelationalModel` | `IChartRichRelationalModel` | `Id`, `Title`, `Description`, `TypeId`, `Type`, `XAxisId`, `XAxis`, `YAxisId`, `YAxis`, `Series` |
| `AxisRichRelationalModel` | `IAxisRichRelationalModel` | `Id`, `Legend` |
| `ChartSeriesRichRelationalModel` | `IChartSeriesRichRelationalModel` | `Id`, `ChartId`, `Legend`, `XAxisSource`, `YAxisSource` |
| `ChartTypeRichRelationalModel` | `IChartTypeRichRelationalModel` | `Id`, `Name` |

Each record provides two constructors:
- **Copy constructor** — accepts the corresponding rich relational interface, copies all properties.
- **Full constructor** — accepts each property individually for explicit construction.

## Design Principles

- **Immutable** — all properties are init-only; records enforce value equality.
- **Composable** — each type implements the interface hierarchy from `Pure.Chart.RichRelationalModel.Abstractions`, which itself composes `IChart*` and `IChartRelationalModel*` interfaces.
- **AOT-compatible** — the library is trimming- and AOT-safe (`IsAotCompatible = true`).

## Dependencies

- [`Pure.Chart.RichRelationalModel.Abstractions`](https://github.com/kudima03/Pure.Chart.RichRelationalModel.Abstractions/tree/0.1.0-preview.4.0.0) — interface contracts for `IChartRichRelationalModel`, `IAxisRichRelationalModel`, `IChartSeriesRichRelationalModel`, and `IChartTypeRichRelationalModel`

## Target Frameworks

- .NET 7
- .NET 8
- .NET 9
- .NET 10

## Installation

```shell
dotnet add package Pure.Chart.RichRelationalModel
```

## Usage

```csharp
using Pure.Chart.RichRelationalModel;

// Construct from individual primitives
IChartRichRelationalModel chart = new ChartRichRelationalModel(
    id: myGuid,
    title: myTitle,
    description: myDescription,
    typeId: typeGuid,
    type: new ChartTypeRichRelationalModel(typeGuid, typeName),
    xAxisId: xGuid,
    xAxis: new AxisRichRelationalModel(xGuid, xLegend),
    yAxisId: yGuid,
    yAxis: new AxisRichRelationalModel(yGuid, yLegend),
    series: chartSeriesCollection
);

// Or copy-construct from any IChartRichRelationalModel
IChartRichRelationalModel copy = new ChartRichRelationalModel(existingChart);
```

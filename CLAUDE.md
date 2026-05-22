# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

All `dotnet` commands must be run from the `./src` directory.

```bash
dotnet restore
dotnet build --no-restore -warnaserror
dotnet test --no-restore                                      # runs xUnit tests
dotnet format --verify-no-changes                             # check code style (CI enforces this)
dotnet format && csharpier format .                           # auto-fix code style
dotnet pack --configuration Release -p:PackageVersion=<version> --output .
```

## Architecture

This is a **sealed-record NuGet library** — four concrete implementations, no abstractions defined here, no executables.

**Records (namespace `Pure.Chart.RichRelationalModel`):**

- `ChartRichRelationalModel` — a chart that carries both FK identifiers (`TypeId`, `XAxisId`, `YAxisId`) and their fully resolved navigation objects (`Type`, `XAxis`, `YAxis`, `Series`).
- `AxisRichRelationalModel` — a chart axis with its `Id` and `Legend`.
- `ChartSeriesRichRelationalModel` — a chart series with its parent `ChartId`, `Legend`, and axis source column names.
- `ChartTypeRichRelationalModel` — a chart type with its `Id` and `Name`.

**Interface hierarchy:** each record implements a `IChart*RichRelationalModel` interface from `Pure.Chart.RichRelationalModel.Abstractions`, which itself composes two parent interfaces — one from `Pure.Chart.Model.Abstractions` (structural shape) and one from `Pure.Chart.RelationalModel.Abstractions` (relational FK properties). All primitive properties use the `IGuid` / `IString` contracts from `Pure.Primitives.Abstractions`.

**Constructor pattern:** every record has a full-parameter constructor and a copy constructor that accepts the corresponding interface — useful when adapting an incoming DTO without re-specifying each field.

**Multi-targeting:** net7.0, net8.0, net9.0, net10.0. The library must remain AOT-compatible (`IsAotCompatible = true`).

**Package validation:** `EnablePackageValidation = true` with `PackageValidationBaselineVersion = 0.1.0-preview.3.0.0`. Breaking API changes fail the build.

**Publishing:** triggered by pushing a semver tag (pattern `*.*.*`). The tag value becomes the `PackageVersion`.

**Tests:** xUnit test project under `./src/Tests/Pure.Chart.RichRelationalModel.Tests/`, targeting net10.0. CI requires 99% line coverage and 99% mutation score (dotnet-stryker).

## Code Style

Enforced via `.editorconfig` and `dotnet format --verify-no-changes` in CI:

- No `var` — always use explicit types, even when the type is apparent.
- No expression-bodied methods, constructors, or operators — use block bodies. Expression-bodied properties and accessors are required.
- No implicit `new()` — always write `new FullTypeName(…)`.
- File-scoped namespaces (`namespace Foo.Bar;` not a block).
- Private fields: `_camelCase` prefix.
- Max line length: 90 characters.
- `using` directives outside the namespace.
- Explicit accessibility modifiers required on all members.

## Commit Messages

Do not mention Claude or AI assistance in commit messages.

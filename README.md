# demo-dotnet-rest-api

## Restore

```shell
dotnet restore
```

## Build

```shell
dotnet build
```

## Test

```shell
dotnet test
```

## Coverage Tool

```shell
dotnet tool restore
```

## Coverage Report

### Collect Coverage

```shell
dotnet test --collect:"XPlat Code Coverage" --settings tests/DemoRestApi.IntegrationTests/coverlet.collect.runsettings.xml
```

### Generate Report

{guid} は実行時に生成される GUID に置き換える。

```shell
dotnet reportgenerator -reports:"tests/DemoRestApi.IntegrationTests/TestResults/{guid}/coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
```

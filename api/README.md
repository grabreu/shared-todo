# api

ASP.NET Core API of [shared-todo](../README.md), Vertical Slice Architecture, EF Core + SQL Server.

## Development

Requires the .NET SDK version in `global.json` and SQL Server LocalDB (the Development connection string targets `(localdb)\mssqllocaldb`).

```bash
dotnet restore
dotnet run --project src/SharedTodo.Api
```

In Development the API applies EF Core migrations on startup and serves the API reference (Scalar) at `http://localhost:5152`.

Other commands: `dotnet build --no-restore` (build), `dotnet format --no-restore --verify-no-changes --severity info` (formatting check), `dotnet test` (no tests yet).

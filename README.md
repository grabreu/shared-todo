# shared-todo

[![API CI](https://github.com/grabreu/shared-todo/actions/workflows/api-ci.yml/badge.svg?branch=main)](https://github.com/grabreu/shared-todo/actions/workflows/api-ci.yml)
[![License](https://img.shields.io/github/license/grabreu/shared-todo?style=flat-square)](LICENSE)

A collaborative to-do list for small groups (family, a school group, a small team): a shared list of items, synced in real time for everyone looking at it. Not a project-management tool, no Trello-style boards.

Status: early scaffold (API skeleton only), no features implemented yet.

## Tech stack

.NET (ASP.NET Core), Vertical Slice Architecture · React SPA · SignalR · EF Core + SQL Server · Azure Container Apps (API) · Cloudflare Workers (frontend)

## Development

Requires the .NET 10 SDK.

```bash
cd api
dotnet restore
dotnet build --no-restore
```

Other commands: `dotnet format --verify-no-changes --severity info` (formatting check), `dotnet test` (no tests yet).

TODO: dev-server and local database setup (the Development connection string targets SQL Server LocalDB), and `web/` setup once it exists.

## Deployment

Planned split deploy: API on Azure Container Apps (`api.shared-todo.grabreu.dev`), frontend on Cloudflare Workers static assets (domain TODO). Not wired up yet: the Azure infrastructure doesn't exist and there is no CD workflow.

## License

Licensed under the [MIT License](LICENSE).

# shared-todo

[![License](https://img.shields.io/github/license/grabreu/shared-todo?style=flat-square)](LICENSE)

A collaborative to-do list for small groups (family, a school group, a small team): a shared list of items, synced in real time for everyone looking at it. Not a project-management tool, no Trello-style boards.

Status: early scaffold, no features implemented yet.

## Tech stack

.NET (ASP.NET Core), Vertical Slice Architecture · React SPA · SignalR · EF Core + SQL Server · Azure Container Apps (API) · Cloudflare Workers (frontend)

## Development

TODO: no scaffold yet. Install/setup commands and dev-server instructions will be added once `api/` and `web/` are scaffolded.

## Deployment

Planned split deploy: API on Azure Container Apps (`api.grabreu.dev`), frontend on Cloudflare Workers static assets (`app.grabreu.dev`), same parent domain. Not wired up yet.

## License

Licensed under the [MIT License](LICENSE).

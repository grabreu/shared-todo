# shared-todo

[![API CI](https://github.com/grabreu/shared-todo/actions/workflows/api-ci.yml/badge.svg?branch=main)](https://github.com/grabreu/shared-todo/actions/workflows/api-ci.yml)
[![Web CI](https://github.com/grabreu/shared-todo/actions/workflows/web-ci.yml/badge.svg?branch=main)](https://github.com/grabreu/shared-todo/actions/workflows/web-ci.yml)
[![License](https://img.shields.io/github/license/grabreu/shared-todo?style=flat-square)](LICENSE)

A collaborative to-do list for small groups (family, a school group, a small team): a shared list of items, synced in real time for everyone looking at it. Not a project-management tool, no Trello-style boards.

Status: early scaffold (API and web skeletons), no features implemented yet.

## Tech stack

.NET (ASP.NET Core), Vertical Slice Architecture · React SPA (Vite, TanStack Router, Tailwind) · SignalR · EF Core + SQL Server · Azure Container Apps (API) · Cloudflare Workers (frontend)

## Structure

Monorepo with one folder per app, each with its own setup instructions:

- [api/](api/README.md): ASP.NET Core API.
- [web/](web/README.md): React SPA.

## Deployment

Planned split deploy: API on Azure Container Apps (`api.shared-todo.grabreu.dev`), frontend on Cloudflare Workers static assets (domain TODO). Not wired up yet: the Azure infrastructure doesn't exist and there is no CD workflow.

## License

Licensed under the [MIT License](LICENSE).

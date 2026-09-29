# shared-todo

## Repository

Collaborative to-do list for small groups (family, school group, small team): a shared list of items, synced in real time for everyone viewing it. Not a project-management tool, no boards.

Read `README.md` before making changes: it documents the project pitch and business rules. `docs/architecture.md` (domain model, request flow) and `docs/adr/` (significant, hard-to-reverse decisions) don't exist yet; add them once the foundation milestone below lands, and check `docs/adr/` before revisiting a past decision from then on.

This is a monorepo. Each app has its own `CLAUDE.md` with its source layout, validation commands, and open questions; read the one for the app you are changing. The rules in this file apply to both.

## General Rules

- Keep changes scoped to the requested change.
- Prefer existing patterns over introducing new abstractions.
- Do not add dependencies unless they are necessary.
- Do not fill gaps with assumptions when the user hasn't given the information: ask, or mark it as pending.
- Do not claim a validation command passed unless it was actually run.
- Code, comments, commit messages, and documentation are always written in English.
- Do not use em dashes; use a comma, colon, semicolon, parentheses, or a separate sentence instead.

## Git

- Do not create or switch branches unless explicitly requested.
- Do not create commits unless explicitly requested.
- Do not push unless explicitly requested.
- Keep commits focused on the requested change.
- Commit messages follow [Conventional Commits](https://www.conventionalcommits.org/) (`type: summary`).

## Documentation

### Audience

Future-you revisiting this months later, or someone browsing the portfolio to see how it works. Not onboarding material; keep it concise and skimmable.

### Content Rules

- State facts concisely. Avoid unnecessary explanations or trailing rationale.
- Do not document information that is already obvious from the repository structure or configuration.
- Do not invent features, API shapes, or future direction: mark undecided things as TODO.
- Document a capability only after it is implemented and verified.
- Use proper Markdown headings (`##`, `###`), not bold text as headings.

---

## Project-Specific Guidelines

### Source

- `api/` - .NET (ASP.NET Core) API, Vertical Slice Architecture. See `api/CLAUDE.md`.
- `web/` - React SPA, feature-based folders, installable as a minimal PWA. See `web/CLAUDE.md`.
- `infra/` - Bicep for this project's own Azure resources (Container App, Container Apps Job, database). Shared resources (Container Apps environment, SQL Server) live in a separate repo, `azure-infra`, referenced here as `existing`. See `infra/README.md`.
- `.github/` - one CI workflow per app (`api-ci.yml`, `web-ci.yml`, `infra-ci.yml`), each path-filtered to its own folder and to its own workflow file, and `dependabot.yml` (actions, NuGet, npm).

Toolchain files (`CLAUDE.md`, `README.md`, tool config, toolchain-specific `.gitignore` patterns) live inside the app folder. The root only holds what spans both apps: `.gitignore` (env and OS files), `.vscode/`, `.gitattributes`, and `.github/`.

### Validation

Run the commands listed in the `CLAUDE.md` of each app you changed (`api/`, `web/`) or `infra/README.md` (`infra/`) before considering a change done; the matching CI workflow runs the same on push/PR to `main`.

### Open Questions

- TODO: add ASP.NET Core Identity issuing JWT access + rotated refresh tokens (email/password only, no Google yet), working end-to-end between the deployed SPA and API. Remaining work of milestone 0 (Foundation); see the project's idea draft for the full milestone order.
- TODO: API CD (image publish + Azure Container Apps deploy) and web CD (Cloudflare Workers) are not set up. `infra/` (Bicep) exists but hasn't been applied to Azure yet.
- TODO: the SQL grants for the API and migration job identities, and the GitHub OIDC identity for CD, are bootstrapped manually (not in Bicep), matching `azure-infra`'s own identity ADR.

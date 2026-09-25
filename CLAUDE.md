# shared-todo

## Repository

Collaborative to-do list for small groups (family, school group, small team): a shared list of items, synced in real time for everyone viewing it. Not a project-management tool, no boards.

Read `README.md` before making changes: it documents the project pitch and business rules. `docs/architecture.md` (domain model, request flow) and `docs/adr/` (significant, hard-to-reverse decisions) don't exist yet; add them once the foundation milestone below lands, and check `docs/adr/` before revisiting a past decision from then on.

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

Monorepo, not yet scaffolded:

- `api/` - .NET (ASP.NET Core) API, Vertical Slice Architecture (one slice per use case: command/query + handler + endpoint colocated under `Features/`).
- `web/` - React SPA, feature-based folders, installable as a minimal PWA.

### Validation

TODO: no scaffold, no commands yet. Once `api/` and `web/` exist, this section should list the build/test/lint commands to run before considering a change done; CI (`.github/workflows/api-ci.yml`, `web-ci.yml`) will run the same on push/PR to `main`.

### Open Questions

- TODO: scaffold `api/` (Vertical Slice API) and `web/` (React SPA), with ASP.NET Core Identity issuing JWT access + rotated refresh tokens (email/password only, no Google yet) working end-to-end between the deployed SPA and API. This is milestone 0 (Foundation); see the project's idea draft for the full milestone order.

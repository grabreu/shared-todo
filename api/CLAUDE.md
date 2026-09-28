# api

## Repository

.NET (ASP.NET Core) API of shared-todo, Vertical Slice Architecture: one slice per use case, with command/query + handler + endpoint colocated. General rules, Git, and Documentation conventions are in the root `CLAUDE.md`; this file only adds what is specific to `api/`.

---

## Project-Specific Guidelines

### Source

- `SharedTodo.slnx` - solution.
- `src/SharedTodo.Api/` - the API project.
  - `Features/` - one slice per use case (not created yet, no slices).
  - `Domain/` - entities and business rules; only `SeedWork` (domain event contracts) so far.
  - `Data/` - `ApplicationDbContext`, EF Core migrations, and `DispatchDomainEventsInterceptor` (publishes domain events after `SaveChanges`).
  - `Common/` - cross-cutting code: `ValidationBehavior` (FluentValidation in the Mediator pipeline) and `GlobalExceptionHandler`.
- `tests/` - test projects (none yet).

Commands and queries go through `Mediator` (source generator); packages are versioned centrally in `Directory.Packages.props`.

### Validation

Run from `api/`: `dotnet restore`, `dotnet build --no-restore -c Release`, `dotnet format --no-restore --verify-no-changes --severity info`, `dotnet test --no-build -c Release` (no test projects yet) before considering a change done; CI (`.github/workflows/api-ci.yml`) runs the same on push/PR to `main`, path-filtered to `api/`.

### Open Questions

- TODO: ASP.NET Core Identity with JWT access + rotated refresh tokens (see the root `CLAUDE.md`).
- TODO: no slices, tests, or CD yet.

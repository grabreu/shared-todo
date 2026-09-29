# Database migrations run via a dedicated Container Apps Job, not at API startup

Production migrations run through `caj-shared-todo-migration-prod`, a Container Apps Job whose image bundles a self-contained `efbundle` (`dotnet ef migrations bundle`) generated at build time; the job's command runs that executable directly. The API's own startup only migrates in Development.

The alternatives considered were calling `MigrateAsync()` at API startup, and running the bundle from CI against a dedicated SQL login. Startup migration is what EF Core's own docs discourage in production: every restart re-runs it, risking a race if more than one replica is ever live, and a failed migration blocks the API from starting instead of failing in an inspectable step of its own. A CI-run bundle would need a stored SQL login; the job instead uses its own system-assigned identity, granted only `db_ddladmin`, separate from the API's identity, which only has `db_datareader`/`db_datawriter`.

**Consequences**: the API image carries the bundled `efbundle` even though the running API never uses it; a schema change means CD must trigger the job and wait for it before rolling the API to the new image, not just push the image.

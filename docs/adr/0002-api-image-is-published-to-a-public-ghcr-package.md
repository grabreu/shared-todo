# The API image is published to a public GHCR package, not a private registry

`ghcr.io/grabreu/shared-todo-api` is public, so the API's Container App and its migration Container Apps Job pull it without any registry credential configured on either resource.

The alternative considered was a private GHCR package, or Azure Container Registry, either of which would need a pull secret on both resources. Since the `shared-todo` repository itself is already public, the built image carries no more exposure than the source it's built from.

**Consequences**: anyone can pull and inspect the published image; no secret, config value, or connection string can ever be baked into it, only passed at runtime through environment variables.

# infra

Bicep for this project's own Azure resources: the API's Container App, its migration Container Apps Job, and its SQL Database. Shared resources (the Container Apps environment, the SQL Server) live in a separate repo, [azure-infra](https://github.com/grabreu/azure-infra), referenced here as `existing`.

## Development

Requires the Azure CLI, logged in (`az login`) with Contributor on `rg-shared-prod`.

```powershell
az deployment group what-if --resource-group rg-shared-prod --template-file main.bicep --parameters main.bicepparam
az deployment group create --resource-group rg-shared-prod --template-file main.bicep --parameters main.bicepparam
```

Always run `what-if` first; it previews what would change without applying anything.

## Deployment

No CD; applying is manual, see Development above.

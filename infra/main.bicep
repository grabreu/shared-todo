@description('Location for the resources this deployment creates.')
param location string

@description('Container image for the API and its migration job. Placeholder until CD pushes a real one.')
param apiImage string

@description('Web app origin allowed by the API CORS policy.')
param webOrigin string

resource cae 'Microsoft.App/managedEnvironments@2026-01-01' existing = {
  name: 'cae-shared-prod'
}

resource sqlServer 'Microsoft.Sql/servers@2025-08-01-preview' existing = {
  name: 'sql-shared-prod-grabreu'
}

resource database 'Microsoft.Sql/servers/databases@2025-08-01-preview' = {
  parent: sqlServer
  name: 'sqldb-shared-todo-prod'
  location: location
  sku: {
    name: 'GP_S_Gen5_2'
    tier: 'GeneralPurpose'
  }
  properties: {
    collation: 'SQL_Latin1_General_CP1_CI_AS'
    useFreeLimit: true
    freeLimitExhaustionBehavior: 'AutoPause'
    autoPauseDelay: 60
    minCapacity: json('0.5')
    maxSizeBytes: 34359738368
    zoneRedundant: false
    requestedBackupStorageRedundancy: 'Local'
  }
}

var connectionString = 'Server=tcp:${sqlServer.properties.fullyQualifiedDomainName},1433;Initial Catalog=${database.name};Encrypt=True;TrustServerCertificate=False;Authentication="Active Directory Default";'

resource api 'Microsoft.App/containerApps@2026-01-01' = {
  name: 'ca-shared-todo-api-prod'
  location: location
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    environmentId: cae.id
    configuration: {
      ingress: {
        external: true
        targetPort: 8080
      }
    }
    template: {
      containers: [
        {
          name: 'api'
          image: apiImage
          resources: {
            cpu: json('0.25')
            memory: '0.5Gi'
          }
          env: [
            {
              name: 'ASPNETCORE_ENVIRONMENT'
              value: 'Production'
            }
            {
              name: 'ConnectionStrings__DefaultConnection'
              value: connectionString
            }
            {
              name: 'Cors__AllowedOrigins__0'
              value: webOrigin
            }
          ]
        }
      ]
      scale: {
        minReplicas: 0
        maxReplicas: 1
      }
    }
  }
}

resource migrationJob 'Microsoft.App/jobs@2026-01-01' = {
  name: 'caj-shared-todo-migration-prod'
  location: location
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    environmentId: cae.id
    configuration: {
      triggerType: 'Manual'
      replicaTimeout: 600
      replicaRetryLimit: 0
      manualTriggerConfig: {
        parallelism: 1
        replicaCompletionCount: 1
      }
    }
    template: {
      containers: [
        {
          name: 'migrate'
          image: apiImage
          command: [
            '/app/efbundle'
          ]
          args: [
            '--connection'
            connectionString
          ]
          resources: {
            cpu: json('0.25')
            memory: '0.5Gi'
          }
        }
      ]
    }
  }
}

output apiId string = api.id
output apiFqdn string = api.properties.configuration.ingress.fqdn
output migrationJobId string = migrationJob.id
output apiPrincipalId string = api.identity.principalId
output migrationJobPrincipalId string = migrationJob.identity.principalId

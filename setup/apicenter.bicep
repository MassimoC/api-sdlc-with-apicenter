@description('Specifies the location for resources.')
param location string = resourceGroup().location

@description('The name of the API center.')
param apiCenterName string = 'apicenter${uniqueString(resourceGroup().id)}'

resource apiCenterService 'Microsoft.ApiCenter/services@2024-03-15-preview' = {
  name: apiCenterName
  sku: {
    name: 'Free'
  }
  location: location
  properties: {}
}

resource apiCenterWorkspace 'Microsoft.ApiCenter/services/workspaces@2024-03-15-preview' = {
  parent: apiCenterService
  name: 'default'
  properties: {
    title: 'Default workspace'
    description: 'Default workspace'
  }
}

output apiCenterServiceId string = apiCenterService.id

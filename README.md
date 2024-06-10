# api-sdlc-with-apicenter

```
spectral lint design\salesapi\openapi_salesapi.json --ruleset rules\spectral-L1.oas.yaml

spectral lint design\rocketapi\openapi_rocketapi.json --ruleset rules\spectral-L1.oas.yaml

```


## APIC Single command 

```
az apic api register --api-location 'design\petstore\openapi_petstore.json' `
                     --resource-group 'rg-apicenter' `
                     --service 'myapicatalog'


az apic api register `
  --api-location 'design\conferenceapi\openapi_conferenceapi.json' `
  --resource-group 'rg-apicenter' `
  --service 'myapicatalog'


```
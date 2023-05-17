# GetUserManagerExtension

Get the details of the invoice creation in AloVoip.


**URL** : `/GetUserManagerExtension`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints
With the following parameters you can send your request:

???
            ExtendedProperties = new List<ExtendedPropertiesRequest>();
            ProductDetails = new List<ProductDetailsRequest>();

|Parameter|Type|Mandatory|Description|
|-|-|-|-|
|TsId |Int|Yes| شناسه منحصر به فرد سیستم تلفنی |
|UserExtenstion |String |Yes | داخلی کاربر|

## Request 


```json
{
     "TsId": "[]",
     "UserExtenstion": "[]",
}
```

## Success Response
If successful, you will receive back this response:

**Code** : `200 OK`

```json
{
    "???": ""
}

```
With the following parameters:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|??|? |? | ? |
## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`



# GetUserManagerExtension

Get the details of the invoice creation in AloVoip.


**URL** : `/GetUserManagerExtension`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints

???
            ExtendedProperties = new List<ExtendedPropertiesRequest>();
            ProductDetails = new List<ProductDetailsRequest>();

|Name|Type|Mandatory|Description|
|-|-|-|-| 
|TsId |String|Yes|  |
|UserExtenstion |String |Yes | |

## Request 


```json
{
     "TsId": "[]",
     "UserExtenstion": "[]",
}
```

## Success Response

**Code** : `200 OK`

```json
{
    "???": ""
}

```

## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`

` ` 



# CrmObjectUrl

???Get the details of the invoice creation in AloVoip.???


**URL** : `/CrmObjectUrl`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints


|Name|Type|Mandatory|Description|
|-|-|-|-| 
|Id |String|Yes|  |
|Type |String |Yes | |
|IdentityId |String |Yes | |

## Request 


```json
{
     "Id": "[]",
     "Type": "[]",
     "IdentityId": "[]",
     
}
```

## Success Response

**Code** : `200 OK`

```json
{

    "Id": "",
    "Url": ""
}

```

## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`

` ` 



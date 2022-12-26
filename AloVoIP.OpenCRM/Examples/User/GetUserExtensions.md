# GetUserExtensions

???Get the details of the invoice creation in AloVoip.???


**URL** : `/GetUserExtensions`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints

|Name|Type|Mandatory|Description|
|-|-|-|-| 
|Username |String|Yes|  |
|TelephonySystemKey |String |Yes | |

## Request 


```json
{
     "Username": "[]",
     "TelephonySystemKey": "[]"
}
```

## Success Response

**Code** : `200 OK`

```json
{
    "Extension": ""
}

```

## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`

` ` 



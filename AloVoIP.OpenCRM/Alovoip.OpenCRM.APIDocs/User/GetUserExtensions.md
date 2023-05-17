# GetUserExtensions

???Get the details of the invoice creation in AloVoip.???


**URL** : `/GetUserExtensions`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints
With the following parameters you can send your request:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|Username |String|Yes| نام کاربری کاربر |
|TelephonySystemKey |String |Yes | کلید سیستم تلفنی |

## Request 


```json
{
     "Username": "[]",
     "TelephonySystemKey": "[]"
}
```

## Success Response
If successful, you will receive back this response:

**Code** : `200 OK`

```json
{
    "Extension": ""
}

```
With the following parameters:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|Extension|? |? | ? |
## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`



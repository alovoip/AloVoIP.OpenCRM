# GetUserInfoByIdentityId

Get the details of the invoice creation in AloVoip.


**URL** : `/GetUserInfoByIdentityId`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints
With the following parameters you can send your request:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|IdentityId |String|Yes|  شناسه منحصر به فرد پروفایل مرتبط|

## Request 


```json
{
     "IdentityId": "[]",
}
```

## Success Response
If successful, you will receive back this response:

**Code** : `200 OK`

```json
{
    "????": ""
}

```
With the following parameters:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|??|? |? | ? |
## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`



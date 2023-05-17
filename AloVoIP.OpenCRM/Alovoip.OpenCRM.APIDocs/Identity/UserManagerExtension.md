# UserManagerExtension

???Get the details of the User Manager Extension in AloVoip.??


**URL** : `/UserManagerExtension`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints
With the following parameters you can send your request:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|TsId |Int|Yes|  شناسه منحصر به فرد سیستم تلفنی|
|UserExtention |Int|Yes|  کد داخلی کاربر|

## Request 


```json
{
     "TsId": "[]",
     "UserExtention": "[]",
}
```
## Success Response
If successful, you will receive back this response:

**Code** : `200 OK`

```json
{
    "??": "",
}

```
With the following parameters:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|??|? |? | ? |
## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`




# CrmObjectUrl

???Get the details of the invoice creation in AloVoip.???


**URL** : `/CrmObjectUrl`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints
With the following parameters you can send your request:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|Id |String|Yes| شناسه منحصر به فرد CRM Object |
|Type |String |Yes | نوع سی ار ام ابجکت|
|IdentityId |String |Yes |شناسه منحصر به فرد پروفایل مرتبط|

## Request 


```json
{
     "Id": "[]",
     "Type": "[]",
     "IdentityId": "[]",   
}
```

## Success Response
If successful, you will receive back this response:

**Code** : `200 OK`

```json
{

    "Id": "",
    "Url": ""
}

```
With the following parameters:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|Id|? |? | ? |
|Url|? |? | ? |
## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`


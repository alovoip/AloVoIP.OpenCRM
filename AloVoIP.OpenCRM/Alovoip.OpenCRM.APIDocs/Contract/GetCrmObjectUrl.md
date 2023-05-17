# CrmObjectUrl

???Get the details of the invoice creation in AloVoip.???


**URL** : `/CrmObjectUrl`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints


|Name|Type|Mandatory|Description|
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



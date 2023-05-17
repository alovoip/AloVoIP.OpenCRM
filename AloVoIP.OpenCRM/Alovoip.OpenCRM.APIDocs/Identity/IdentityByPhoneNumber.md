# IdentityByPhoneNumber

???Get the details of the invoice creation in AloVoip.??


**URL** : `/IdentityByPhoneNumber`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints

|Name|Type|Mandatory|Description|
|-|-|-|-| 
|PhoneNumber |String|Yes|  شماره موبایل مشتری|

## Request 


```json
{
     "PhoneNumber": "[]"
}
```

## Success Response

**Code** : `200 OK`

```json
{
    "ContinuedNumber": "",
    "Extension": "",
    "PhoneNumber": "",
    "PhoneType": ""
}

```

## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`

` ` 



# IdentityByPhoneNumber

???Get the details of the invoice creation in AloVoip.??


**URL** : `/IdentityByPhoneNumber`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints
With the following parameters you can send your request:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|PhoneNumber |String|Yes|  شماره موبایل مشتری|

## Request 


```json
{
     "PhoneNumber": "[]"
}
```

## Success Response
If successful, you will receive back this response:

**Code** : `200 OK`

```json
{
    "ContinuedNumber": "",
    "Extension": "",
    "PhoneNumber": "",
    "PhoneType": ""
}

```
With the following parameters:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|ContinuedNumber|? |? | ? |
|Extension|? |? | ? |
|PhoneNumber|? |? | ? |
|PhoneType|? |? | ? |
## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`




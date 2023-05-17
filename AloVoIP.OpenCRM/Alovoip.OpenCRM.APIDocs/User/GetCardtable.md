# GetCardtable

????Get the details of the invoice creation in AloVoip.?????


**URL** : `/GetCardtable`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints
With the following parameters you can send your request:

|Parameter|Type|Mandatory|Description|
|-|-|-|-|  
|CrmObjectTypeKey |String|Yes|  کلید زیرنوع آیتم در شخصی سازی |
|IdentityId |String |Yes | شناسه منحصر به فرد پروفایل مرتبط|

## Request 


```json
{
     "CrmObjectTypeKey": "[]",
     "IdentityId": "[]"
}
```

## Success Response
If successful, you will receive back this response:

**Code** : `200 OK`

```json
{
    "TotalItemsCount": "",
    "CardtableItems": ""
}

```
With the following parameters:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|TotalItemsCount|? |? | ? |
|CardtableItems|? |? | ? |
## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`

# GetCardtable

????Get the details of the invoice creation in AloVoip.?????


**URL** : `/GetCardtable`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints

|Name|Type|Mandatory|Description|
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

**Code** : `200 OK`

```json
{
    "TotalItemsCount": "",
    "CardtableItems": ""
}

```

## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`

` ` 



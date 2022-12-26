# GetCardtable

????Get the details of the invoice creation in AloVoip.?????


**URL** : `/GetCardtable`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints

|Name|Type|Mandatory|Description|
|-|-|-|-| 
|CrmObjectTypeKey |String|Yes|  |
|IdentityId |String |Yes | |

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



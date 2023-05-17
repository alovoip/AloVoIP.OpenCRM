# IdentityByCustomerInfo 

Get the details of the invoice creation in AloVoip.


**URL** : `/IdentityByCustomerInfo`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints

|Name|Type|Mandatory|Description|
|-|-|-|-| 
|CustomerNo |String|Yes| شماره مشتری |
|CustomerId |String |Yes | شناسه منحصر به فرد مشتری|

## Request 


```json
{
     "CustomerNo": "[]",
     "CustomerId": "[]",

}
```

## Success Response

**Code** : `200 OK`

```json
{
    "??": ""
}

```

## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`

` ` 



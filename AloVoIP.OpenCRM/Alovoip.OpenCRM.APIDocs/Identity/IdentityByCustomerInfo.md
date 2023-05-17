# IdentityByCustomerInfo 

Get the details of the invoice creation in AloVoip.


**URL** : `/IdentityByCustomerInfo`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints
With the following parameters you can send your request:

|Parameter|Type|Mandatory|Description|
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
If successful, you will receive back this response:

**Code** : `200 OK`

```json
{
    "??": ""
}

```
With the following parameters:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|??|? |? | ? |
## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`

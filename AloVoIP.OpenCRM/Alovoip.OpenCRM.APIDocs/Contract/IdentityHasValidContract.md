# IdentityHasValidContract

????Get the details of the invoice creation in AloVoip.???


**URL** : `/IdentityHasValidContract`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints
With the following parameters you can send your request:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|CustomerRequest | |Yes|  یک درخواست که شامل CustomerNo:شماره مشتری and CustomerId:شناسه منحصر به فرد مشتری است|
|ContractKey |String |Yes |کلید تعریف شده در شخصی‌سازی آیتم قرارداد |

## Request 


```json
{
     "CustomerRequest": "[]",
     "ContractKey": "[]",
     
}
```

## Success Response
If successful, you will receive back this response:

**Code** : `200 OK`

```json
{
    "IsValid": ""
}

```
With the following parameters:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|IsValid|? |? | ? |
## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`

` ` 



# PaymentInfo

?/Get the details of the invoice creation in AloVoip.???


**URL** : `/PaymentInfo`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints
With the following parameters you can send your request:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|CustomerRequest | |Yes|  یک درخواست که شامل CustomerNo:شماره مشتری and CustomerId:شناسه منحصر به فرد مشتری است|
|BillableObjectTypeKey |String |Yes | کلید زیرنوع دریافت در شخصی سازی آیتم|
|BillableObjectNumber |String |Yes |شماره دریافت |
|LookupNumberFieldKey |String |Yes | کلید فیلد اضافه تعریف شده در دریافت برای «جستجو»|
|ValueFieldKey |String |Yes | کلید فیلد مقدار برای جستجو در مقادیر فیلد اضافه بالایی|

## Request 


```json
{
     "CustomerRequest": "[]",
     "BillableObjectTypeKey": "[]",
     "BillableObjectNumber": "[]",
     "LookupNumberFieldKey": "[]",
     "ValueFieldKey": "[]"
}
```

## Success Response
If successful, you will receive back this response:

**Code** : `200 OK`

```json
{
    "IdentityId": "",
    "Amount": ""
}

```
With the following parameters:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|IdentityId|? |? | ? |
|Amount|? |? | ? |
## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`


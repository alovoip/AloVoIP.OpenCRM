# CreateSalesInvoice Event

Get the details of the invoice creation in AloVoip.


**URL** : `/CreateSalesInvoice`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints
With the following parameters you can send your request:

???
            ExtendedProperties = new List<ExtendedPropertiesRequest>();
            ProductDetails = new List<ProductDetailsRequest>();

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|CrmId |String|Yes| شناسه منحصر به فرد فاکتور فروش در CRM |
|CrmObjectTypeCode |String |Yes | کد زیرنوع فاکتور فروش در CRM|
|RefId |String |Yes | شناسه منحصر به فرد منبع (تماس)|
|IdentityId |String |Yes | شناسه منحصر به فرد پروفایل مرتبط|
|Description |String |Yes | توضیحات فاکتور فروش|
|Subject |String |Yes| عنوان فاکتور فروش|
|FinalValue |Decimal |Yes | مبلغ نهایی فاکتور فروش|
|Discount |Decimal |Yes | مبلغ کل تخفیف|
|Vat |Decimal |Yes | مالیات و ارزش افزوده|
|Toll |Decimal |Yes | عوارض|
|AdditionalCosts |Decimal |Yes | مقدار مبلغ اضافی روی فاکتور فروش|
|TotalValue |Decimal |Yes |مبلغ کل فاکتور فروش |
|VatPercent |Decimal |Yes | درصد مالیات و ارزش افزوده|
|TollPercent |Decimal |Yes | درصد مالیات|
|DiscountPercent |Decimal |Yes | درصد تخفیف|
|TotalDiscountPercent |Decimal |Yes |درصد کل تخفیف |
|ExtendedProperties |List |Yes | مشخصات اضافه محصول - Name, Key, Value|
|ProductDetails |List |Yes | فیلد توضیحات محصول|
|InvoiceDate |DateTime |Yes | تاریخ ایجاد فاکتور فروش|
|ExpireDate |DateTime |No |تاریخ انقضا فاکتور فروش |

## Request 


```json
{
     "CrmId": "[]",
     "CrmObjectTypeCode": "[]",
     "RefId": "[]",
     "IdentityId": "[]",
     "Description": "[]",
     "Subject": "[]",
     "FinalValue": "[]",
     "Discount": "[]",
     "Vat": "[]",
     "Toll": "[]",
     "AdditionalCosts": "[]",
     "TotalValue": "[]",
     "VatPercent": "[]",
     "TollPercent": "[]",
     "DiscountPercent": "[]",
     "TotalDiscountPercent": "[]",
     "ExtendedProperties": "[]",
     "ProductDetails": "[]",
     "InvoiceDate": "[]",
     "ExpireDate": "[]",
     
}
```

## Success Response
If successful, you will receive back this response:

**Code** : `200 OK`

```json
{
    "InvoiceId": ""
}

```
With the following parameters:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|InvoiceId|? |? | ? |
## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`

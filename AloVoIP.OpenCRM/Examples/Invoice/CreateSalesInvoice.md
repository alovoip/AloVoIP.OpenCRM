# CreateSalesInvoice Event

Get the details of the invoice creation in AloVoip.


**URL** : `/CreateSalesInvoice`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints

???
            ExtendedProperties = new List<ExtendedPropertiesRequest>();
            ProductDetails = new List<ProductDetailsRequest>();

|Name|Type|Mandatory|Description|
|-|-|-|-| 
|CrmId |String|Yes|  |
|CrmObjectTypeCode |String |Yes | |
|RefId |String |Yes | |
|IdentityId |String |Yes | |
|Description |String |Yes | |
|Subject |String |Yes| |
|FinalValue |Decimal |Yes | |
|Discount |Decimal |Yes | |
|Vat |Decimal |Yes | |
|Toll |Decimal |Yes | |
|AdditionalCosts |Decimal |Yes | |
|TotalValue |Decimal |Yes | |
|VatPercent |Decimal |Yes | |
|TollPercent |Decimal |Yes | |
|DiscountPercent |Decimal |Yes | |
|TotalDiscountPercent |Decimal |Yes | |
|ExtendedProperties |List |Yes | |
|ProductDetails |List |Yes | |
|InvoiceDate |DateTime |Yes | |
|ExpireDate |DateTime |Yes | |

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

**Code** : `200 OK`

```json
{
    "InvoiceId": ""
}

```

## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`

` ` 



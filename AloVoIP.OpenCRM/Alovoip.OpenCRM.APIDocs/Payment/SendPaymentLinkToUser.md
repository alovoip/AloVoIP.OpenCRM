# SendPaymentLinkToUser

???Get the details of the invoice creation in AloVoip.???


**URL** : `/SendPaymentLinkToUser`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints

|Name|Type|Mandatory|Description|
|-|-|-|-| 
|PaymentInfo | |Yes|  مشخصات پرداخت که شامل IdentityId: شناسه منحصر به فرد مشتری  , Amount:  مبلغ پرداختی|
|MobileNumber |String |Yes |شماره موبایل مشتری|
|MoneyAccountUserKey |String |Yes | |کلید حساب مالی کاربر
|ResultMessage |String |Yes | نتیجه ایجاد لینک پرداخت |

## Request 


```json
{
     "PaymentInfo": "[]",
     "MobileNumber": "[]",
     "MoneyAccountUserKey": "[]",
     "ResultMessage": "[]"
}
```

## Success Response

**Code** : `200 OK`

```json
{
    "IsSuccess": "",
    "Message": ""
}

```

## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`

` ` 



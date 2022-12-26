# SendPaymentLinkToUser

???Get the details of the invoice creation in AloVoip.???


**URL** : `/SendPaymentLinkToUser`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints

|Name|Type|Mandatory|Description|
|-|-|-|-| 
|PaymentInfo | |Yes|  |
|MobileNumber |String |Yes | |
|MoneyAccountUserKey |String |Yes | |
|ResultMessage |String |Yes | |

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



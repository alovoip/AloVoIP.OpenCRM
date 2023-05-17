# SubmitVoting

???Get the details of the invoice creation in AloVoip.???


**URL** : `/SubmitVoting`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints

|Name|Type|Mandatory|Description|
|-|-|-|-| 
|VotingResultId| | | شناسه منحصر به فرد نتیجه نظرسنجی|
|CreateDate | | | تاریخ ثبت نظر|
|ModuleCode | | | کد ماژول نظرسنجی|
|ModuleName | | | نام ماژول نظرسنجی|
|VotingCode | | | کد فرم نظرسنجی| 
|QuestionCode | | | کد مرتبط با سوال در سم CRM|
|QuestionIndex | | | ردیف سوال (ترتیب سوال 1و2و3و4و5)|
|PeerCode | | | کد داخلی که نظرسنجی برای آن ثبت شده|
|QueueCode | | | کد صف|
|QueueName | | | نام صف|
|PhoneNumber | | | شماره تماس نظردهنده |
|CallerIdNum | | | شماره تماس گیرنده|
|CallerIdName | | |نام تماس گیرنده | 
|CustomerId | | | شناسه منحصر به فرد مشتری|
|CustomerNo | | | شماره مشتری|
|CallId| | | شناسه منحصر به فرد تماس|
|CallChannelId | | | شناسه منحصر به فرد کانال تماس|
|Input | | | عدد ورودی (نظر)|
|IsValid | | | آیا نظر معتبر است یا نه؟|

## Request 


```json
{
     "CrmId": "[]",
     "CrmObjectTypeCode": "[]",
}
```

## Success Response

**Code** : `200 OK`

```json
{
    "???": ""
}

```

## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`

` ` 



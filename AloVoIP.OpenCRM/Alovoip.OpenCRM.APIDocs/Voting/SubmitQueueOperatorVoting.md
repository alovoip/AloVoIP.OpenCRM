# SubmitQueueOperatorVoting

???Get the details of the invoice creation in AloVoip.???بعد از تماس و نظرسنجی، نظراتش رو میاریم و توی سی ار ام ثبت میکنیم



**URL** : `/SubmitQueueOperatorVoting`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints
With the following parameters you can send your request:

|Parameter|Type|Mandatory|Description|
|-|-|-|-|
|QueueVotingResultId| Long| Yes| شناسه منحصر به فرد نظر ثبت شده|
|CreateDate | | | تاریخ ثبت نظر|
|ModuleCode | | | کد ماژول نظرسنجی|
|ModuleName | | | نام ماژول نظرسنجی|
|VotingCode | | | کد فرم نظرسنجی| 
|QuestionCode | | | کد مرتبط با سوال در سم CRM|
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
If successful, you will receive back this response:

**Code** : `200 OK`

```json
{
    "IntId": ""
}

```
With the following parameters:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|IntId|? |? | ? |
## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`


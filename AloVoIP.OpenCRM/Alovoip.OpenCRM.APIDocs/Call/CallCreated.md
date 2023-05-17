# CallCreated Event

Get the details of the call creation in AloVoip.


**URL** : `/CallCreated`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints
With the following parameters you can send your request:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|TsKey|String|Yes|  کلید منحصر به فرد سیستم تلفنی|
|IsLive |Boolean |Yes | وضعیت زنده بودن تماس|
|SourceCallId |String |Yes | شناسه منحصر به فرد مبدا تماس|
|Number |String |Yes | شماره تماس گیرنده|
|Date |Date |Yes | تاریخ ایجاد تماس|
|CallType | |Yes|نوع تماس - IncComing, Outgoing, Internal |
|CallResult | | Yes| وضعیت تماس -Answered, NotAnswered|
|SourceInitCallChannelId |string |Yes | شناسه منحصر به فرد کانال شروع کننده تماس|
|SourceInitCallChannelPeerName |string |Yes | نام داخلی شروع کننده تماس|
|SourceInitCallChannelPeerType | |Yes | نوع داخلی شروع کننده تماس - Extention, Trunk|

## Request 


```json
{
     "TsKey": "[]",
     "IsLive": "[]",
     "SourceCallId": "[]",
     "Number": "[]",
     "Date": "[]",
     "CallType": "[]",
     "CallResult": "[]",
     "SourceInitCallChannelId": "[]",
     "SourceInitCallChannelPeerName": "[]",
     "SourceInitCallChannelPeerType": "[]"
}
```

## Success Response
If successful, you will receive back this response:

**Code** : `200 OK`

```json
{

    "CallId": "",
    "InitCallChannelId": "",
    "IdentityId": "",
    "IdentityName": ""
}
```
With the following parameters:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|CallId|? |? | ? |
|InitCallChannelId|? |? | ? |
|IdentityId|? |? | ? |
|IdentityName|? |? | ? |
## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`


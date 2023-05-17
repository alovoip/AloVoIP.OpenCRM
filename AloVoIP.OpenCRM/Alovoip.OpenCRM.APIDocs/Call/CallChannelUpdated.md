# CallChannelUpdated Event

Get the details of the call channel updating in AloVoip.


**URL** : `/CallChannelUpdated`

**Method** : `Post`

**Auth required** : `true`

## Data Constraints
With the following parameters you can send your request:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|ChannelId|String|Yes| شناسه محنحصر به فرد کانال تماس |
|IsLive |Boolean |Yes |وضعیت تماس هنوز در حال مکالمه است یا نه  |
|ChannelState |String |Yes |وضعیت کانال تماس -Done, reserved, offHook,Dialing, Ring, Ringing,Up, Busy, DialingOffHook, PreRing, Unkown, HangedUp |
|ChannelResponse |String |Yes | وضعیت پاسخگویی کانال تماس - NotAnswered, Answered, Busy, Tranfered, Failed, Unavailable|
|ConnectDate |Date |Yes | تاریخ اتصال کانال|
|HangupDate | |Yes| تاریخ پایان اتصال|
|RecordedFileName |String |Yes | نام فایل ضبط شده تماس|
|ToChangePeerName |String |Yes | ؟|
|ToChangePeerType | |Yes | ؟|

## Request 


```json
{
     "ChannelId": "[]",
     "IsLive": "[]",
     "ChannelState": "[]",
     "ChannelResponse": "[]",
     "DaConnectDatete": "[]",
     "HangupDate": "[]",
     "CallResult": "[]",
     "RecordedFileName": "[]",
     "ToChangePeerName": "[]",
     "ToChangePeerType": "[]"
}
```

## Success Response
If successful, you will receive back this response:

**Code** : `200 OK`

```json
{

    "CallChannelId": "",
}
```
With the following parameters:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|CallChannelId|? |? | ? |

## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`


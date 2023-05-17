# CallChannelCreated Event

Get the details of the call channel creation in AloVoip.


**URL** : `/CallChannelCreated`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints


|Name|Type|Mandatory|Description|
|-|-|-|-| 
|CallId|String|Yes| شناسه منحصر به فرد تماس |
|IsLive |Boolean |Yes |وضعیت تماس هنوز در حال مکالمه است یا نه |
|PeerName |String |Yes | نام یا کد داخلی|
|PeerType | |Yes | نوع داخلی یا ترانک|
|SourceCallChannelId |String |Yes |کانال مبدا تماس|
|ChannelState | |Yes| وضعیت کانال تماس -Done, reserved, offHook,Dialing, Ring, Ringing,Up, Busy, DialingOffHook, PreRing, Unkown, HangedUp|
|CreateDate |string |Yes |تاریخ ایجاد کانال تماس |

## Request 


```json
{
     "CallId": "[]",
     "IsLive": "[]",
     "PeerName": "[]",
     "PeerType": "[]",
     "SourceCallChannelId": "[]",
     "ChannelState": "[]",
     "CreateDate": "[]"
}
```

## Success Response

**Code** : `200 OK`

```json
{

    "CallChannelId": "",
}
```

## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`

` ` 



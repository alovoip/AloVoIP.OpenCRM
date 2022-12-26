# CallChannelUpdated Event

Get the details of the call channel updating in AloVoip.


**URL** : `/CallChannelUpdated`

**Method** : `Post`

**Auth required** : `true`

## Data Constraints


|Name|Type|Mandatory|Description|
|-|-|-|-| 
|ChannelId|String|Yes|  |
|IsLive |Boolean |Yes | |
|ChannelState |String |Yes | |
|ChannelResponse |String |Yes | |
|ConnectDate |Date |Yes | |
|HangupDate | |Yes| |
|RecordedFileName |String |Yes | |
|ToChangePeerName |String |Yes | |
|ToChangePeerType | |Yes | |

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

**Code** : `200 OK`

```json
{

    "CallChannelId": "",

```

## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`

` ` 



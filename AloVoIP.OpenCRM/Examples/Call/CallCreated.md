# CallCreated Event

Get the details of the call creation in AloVoip.


**URL** : `/CallCreated`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints


|Name|Type|Mandatory|Description|
|-|-|-|-| 
|TsKey|String|Yes|  |
|IsLive |Boolean |Yes | |
|SourceCallId |String |Yes | |
|Number |String |Yes | |
|Date |Date |Yes | |
|CallType | |Yes| |
|SourceInitCallChannelId |string |Yes | |
|SourceInitCallChannelPeerName |string |Yes | |
|SourceInitCallChannelPeerType | |Yes | |

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

**Code** : `200 OK`

```json
{

    "CallId": "",
    "InitCallChannelId": "",
    "IdentityId": "",
    "IdentityName": ""
}
```

## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`

` ` 



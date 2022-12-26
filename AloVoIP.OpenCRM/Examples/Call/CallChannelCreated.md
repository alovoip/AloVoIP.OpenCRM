# CallChannelCreated Event

Get the details of the call channel creation in AloVoip.


**URL** : `/CallChannelCreated`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints


|Name|Type|Mandatory|Description|
|-|-|-|-| 
|CallId|String|Yes|  |
|IsLive |Boolean |Yes | |
|PeerName |String |Yes | |
|PeerType | |Yes | |
|SourceCallChannelId |String |Yes | |
|ChannelState | |Yes| |
|CreateDate |string |Yes | |

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



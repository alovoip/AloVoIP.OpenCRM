# CallUpdated Event

Get the details of the call Updating in AloVoip.

**URL** : `/CallUpdated`

**Method** : `POST`

**Auth required** : `True`


## Data constraints

|Name|Type|Mandatory|Description|
|-|-|-|-| 
|CallId |String|Yes|  |
|IsLive |Boolean |Yes | |
|Number |String |Yes | |
|Date |Date |Yes | |
|CallType | |Yes| |
|CallResult | |Yes | |
|IdentityId |string |Yes | |


## Reques 

```json
{
    "CallId": "[]",
    "IsLive": "[]",
    "Number": "[]" ,
    "Date": "[]",
    "CallType": "[]",
    "CallResult": "[]",
    "IdentityId": "[]"
}
```

## Success Response

**Code** : `200 OK`

```json
{
    "IdentityId": "",
    "IdentityName": ""
}
```

## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`

` ` 



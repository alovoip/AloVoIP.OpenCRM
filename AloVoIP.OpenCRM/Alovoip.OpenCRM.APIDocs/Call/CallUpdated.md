# CallUpdated Event

Get the details of the call Updating in AloVoip.

**URL** : `/CallUpdated`

**Method** : `POST`

**Auth required** : `True`


## Data constraints

|Name|Type|Mandatory|Description|
|-|-|-|-| 
|CallId |String|Yes|  شناسه منحصر به فرد تماس|
|IsLive |Boolean |Yes | وضعیت زنده بودن تماس|
|Number |String |Yes | شماره تماس گیرنده|
|Date |Date |Yes |زمان ایجاد تماس |
|CallType | |Yes| |
|CallResult | |Yes | وضعیت تماس -Answered, NotAnswered|
|IdentityId |string |Yes | شناسه منحصر به فرد تماس گیرنده در CRM|


## Request

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



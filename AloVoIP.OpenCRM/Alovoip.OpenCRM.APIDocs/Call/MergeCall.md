# MergeCall

Get the details of the call merging in AloVoip.
در حالت های ترنسفر و انتقال تماس کاربرد داره و دوتا تماس رو مرج می کنه

**URL** : `/MergeCall`

**Method** : `POST`

**Auth required** : `True`


## Data constraints

|Name|Type|Mandatory|Description|
|-|-|-|-| 
|TsKey |String|Yes|  شناسه منحصر به فرد سیستم تلفنی|
|SourceCallId |Long |Yes | شناسه منحصر به فرد تماس مبدا|
|DestCallId |Long |Yes | شناسه منحصر به فرد تماس مقصد|

## Reques 

```json
{
    "TsKey": "[]",
    "SourceCallId": "[]",
    "DestCallId": "[]" ,
}
```

## Success Response

**Code** : `200 OK`

```json
{
    "Merged": ""
}
```

## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`

` ` 



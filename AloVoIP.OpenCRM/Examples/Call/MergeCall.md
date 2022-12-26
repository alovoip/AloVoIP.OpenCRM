# MergeCall

Get the details of the call merging in AloVoip.

**URL** : `/MergeCall`

**Method** : `POST`

**Auth required** : `True`


## Data constraints

|Name|Type|Mandatory|Description|
|-|-|-|-| 
|TsKey |String|Yes|  |
|SourceCallId |Long |Yes | |
|DestCallId |Long |Yes | |

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



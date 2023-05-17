# BillableObjectTypeProps

???Get the details of the invoice creation in AloVoip.??


**URL** : `/BillableObjectTypeProps`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints
With the following parameters you can send your request:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|BillableObjectTypeKey |String|Yes| کلید زیرنوع دریافت در شخصی سازی آیتم |

## Request 


```json
{
     "BillableObjectTypeKey": "[]",
}
```

## Success Response
If successful, you will receive back this response:

**Code** : `200 OK`

```json
{
    "CRMObjectTypes": ""
}

```
With the following parameters:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|CRMObjectTypes|? |? | ? |

## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`


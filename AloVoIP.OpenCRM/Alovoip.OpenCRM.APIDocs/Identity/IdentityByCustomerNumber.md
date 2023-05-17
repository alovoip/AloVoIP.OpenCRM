# IdentityByCustomerNumber

??Get the details of the invoice creation in AloVoip.??/


**URL** : `/IdentityByCustomerNumber`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints
With the following parameters you can send your request:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|CustomerNumber |String|Yes| شماره مشتری |


## Request 


```json
{
     "CustomerNumber": "[]",
}
```

## Success Response
If successful, you will receive back this response:

**Code** : `200 OK`

```json
{
    "??": ""
}

```
With the following parameters:

|Parameter|Type|Mandatory|Description|
|-|-|-|-| 
|??|? |? | ? |

## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`



# IdentityHasValidContract

????Get the details of the invoice creation in AloVoip.???


**URL** : `/IdentityHasValidContract`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints

|Name|Type|Mandatory|Description|
|-|-|-|-| 
|CustomerRequest | |Yes|  |
|ContractKey |String |Yes | |

## Request 


```json
{
     "CustomerRequest": "[]",
     "ContractKey": "[]",
     
}
```

## Success Response

**Code** : `200 OK`

```json
{
    "IsValid": ""
}

```

## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`

` ` 



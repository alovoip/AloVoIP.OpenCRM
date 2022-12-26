# PaymentInfo

?/Get the details of the invoice creation in AloVoip.???


**URL** : `/PaymentInfo`

**Method** : `POST`

**Auth required** : `true`

## Data Constraints

|Name|Type|Mandatory|Description|
|-|-|-|-| 
|CustomerRequest | |Yes|  |
|BillableObjectTypeKey |String |Yes | |
|BillableObjectNumber |String |Yes | |
|LookupNumberFieldKey |String |Yes | |
|ValueFieldKey |String |Yes | |

## Request 


```json
{
     "CustomerRequest": "[]",
     "BillableObjectTypeKey": "[]",
     "BillableObjectNumber": "[]",
     "LookupNumberFieldKey": "[]",
     "ValueFieldKey": "[]"
}
```

## Success Response

**Code** : `200 OK`

```json
{
    "IdentityId": "",
    "Amount": ""
}

```

## Error Response

**Condition** : 
**Code** : `400 BAD REQUEST`

` ` 



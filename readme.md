
# Solution description

Acrelec.SCO.Core is a client application which communicates to Acrelec.SCO.Server through REST.
Its goal is to inject an order into a POS system.
Before attempting to inject the order, make sure the server is available by perfoming a check availability API.
Below is the API containing the 2 methods that have to be implemented.

## Check server availability

Core -> Server

GET /api-sco/v1/availability

```Response (success)
{
	"CanInjectOrders":true
}
Response (failure)
{
	"CanInjectOrders":false
}
```

## Inject an order

Core -> Server

POST /api-sco/v1/injectorder

```Request
{
	"Order": {
		"OrderItems":[{
			"ItemCode": "100",
			"Qty": 1
		},
		{
			"ItemCode": "200",
			"Qty": 2
		}]
	},
	"Customer": {
		"Firstname": "John",
		"Address": "Bucharest"
	}
}
Response (success)
{
	"OrderNumber": "10"
}
```

Response (failure - Customer details are missing)

HTTP StatusCode=400 Bad Request


# Development request

1. Implement missing code marked with "//todo" in the solution.
   There are 10 distinct points
2. In Acrelec.SCO.Server project write the REST server that is able to answer the 2 API calls described above.
   You can use any system you want
3. Make sure the solution can be compiled
4. Tests should pass


# Developer reports:

- Fixed ```//todo``` issues
- Implemented service/provider logics
- Clean unused references
- Created REST Api endpoints
- Swagger UI - https://i.imgur.com/KRTWtOf.png
- Unit Test - https://i.imgur.com/jH5GBRm.png
- Integration Test - https://i.imgur.com/xCvxMn7.png

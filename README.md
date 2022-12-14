# btc.usd.core

## BTC-USD WEB API Application.

An application which fetching BTC/USD symbol prices from two specific URL Endpoints.

An .NET 6 Framework WEB API Application within Dockerized Image [Linux].
Implemented with Swagger GET API Endpoints. 
The app focused to show the clean architecture templated, unit of work and other design patterns in an isolation of N-Layers. 
Based on seperation of concerns, reusability, dependency injection, scalability and integrity. As along for unit testing.

The application can be run from the core itself or Docker runtime instance.

A Rest API Service with (restSharp dll) had used to send API requests to the end servers in order to store the results in an inapp SQLITE db.
There is an already pushed Database within the App. 

For integrity the deletion of the database schema files will ensure the recreation on runtime from EF as to migrate. 
(database.sqlite, database.sqlite-shm,database.sqlite-wal).

> Based on
```
Clean Architecture 
```

> Main Libraries used 
```
EF Core,
EF Core SQlite,
Serilog,
restSharp,
Automapper,
Autofac, 
Mediator
```

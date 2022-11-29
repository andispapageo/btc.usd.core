# btc.usd.core

BTC-USE WEB API Application.

An application which fetching BTC/USD symbol prices from two specific URL Endpoints.

An .NET 6 Framework WEB API Application within Dockerized Image [Linux].
Implemented with Swagger with GET API Endpoints.The app illustrates  clean architecture, unit of work,  design patterns in an isolaition of N-Layers 
for seperation of concerns, scalability and integrity. As along for unit testing.

A Rest API Service with (restSharp dll) had used to send API requests to the end servers in order to store the results in an inapp SQLITE db.

Libraries
EF Core,
EF Core SQlite,
Serilog,
restSharp,
Automapper,
Autofac

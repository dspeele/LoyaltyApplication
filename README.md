# LoyaltyApplication
Loyalty Application for Button

## Setup
* Download and install SqlServer: https://www.microsoft.com/en-us/sql-server/sql-server-editions-express
* Download and install SMSS: https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms
* Log into localhost db from SMSS and create database Loyalty: https://www.gfi.com/support/products/gfi-mailessentials/KBID003379
* Follow steps under "Create your database" at https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/new-db

## Running the application
* Open the solution in Visual Studio
* Debug -> Start Without Debugging

## Running tests
* Open test file (eg UserCoreTest.cs)
* Right click and choose Run Tests

## Endpoints
* Create user - POST /user
  * Payload: 
  ```
  {
	"email": "danapeele@gmail.com",
	"lastName": "Peele",
	"firstName": "Dana"
  }
  ```
* Retrieve user - GET /user/{id}
* Retrieve all users - GET /user
* Create transfer - POST /transfer
  * Payload:
  ```
  {
	"userId":3,
	"Amount":1
  }
  ```
* Retrieve transfers for user - GET /transfer?userId={id}
* Retrieve all transfers - GET /transfer

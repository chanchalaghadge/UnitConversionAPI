# UnitConversionAPI
Unit conversion Api
# Unit Conversion API

## Overview

A RESTful API built with ASP.NET Core that converts numerical values between units of measurement.

The API currently supports:

* Length: meters, kilometers, centimeters, millimeters, feet, inches and miles.
* Mass: kilograms, grams, milligrams, pounds and ounces.
* Temperature: Celsius, Fahrenheit and Kelvin.

## Technologies

* C#
* ASP.NET Core Web API
* .NET 10
* Dependency Injection
* Swagger / OpenAPI
* xUnit

## Prerequisites

* .NET 10 SDK
* Visual Studio 2022 or a compatible IDE
* Git

## Run locally

1. Clone the repository.

2. Open the solution in Visual Studio or navigate to the API project directory.

3. Restore dependencies:

   ```bash
   dotnet restore
   ```

4. Run the application:

   ```bash
   dotnet run
   ```

5. Open the Swagger URL printed in the console to explore and test the API.

## API endpoints

### Convert units

`POST /api/conversions`

Example request:

```json
{
  "value": 5,
  "fromUnit": "km",
  "toUnit": "m"
}
```

### List supported units

`GET /api/conversions/units`

Returns the supported units and their categories.

## Design decisions

* **Separation of concerns:** Controllers handle HTTP requests, while the conversion service handles business logic.
* **Dependency injection:** The conversion service is registered through an interface.
* **Centralized unit definitions:** Unit metadata and conversion factors are maintained in a single registry.
* **Base-unit conversion:** Values are converted through a base unit for their category, avoiding individual formulas for every unit pair.
* **Temperature offsets:** The conversion model supports both scale factors and offsets.
* **Extensibility:** New units can be added to the registry without introducing new controller endpoints.
* **Testing:** Unit tests cover successful conversions and invalid requests.

## Trade-offs and future improvements

Unit definitions are hardcoded for this assessment. A larger system could use configuration or a database for managed unit definitions, with validation, caching, versioning and additional conversion strategies where necessary.

Further improvements could include integration tests, centralized exception handling, structured logging and CI/CD.

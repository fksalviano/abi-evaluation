# ABI-Evaluation

ABI - Ambev Developer Evaluation Test

.Net 8 API crud sample using Mediator pattern, Commands, Handlers and FluentValiadtions with Handlers PipelineBehavior.

Tests with XUnit, NSubstitute, Bogus Faker and FluentAssertions.

Data access with ORM Entity Framework Core. Using PostgreSQL Database.

### Application Handlers

- **CreateSaleHandler**:
    Handler for the POST /Sale endpoint to create a new sale with items, products and his quantities.

- **DeleteSaleHandler**:
    Handler for the DELETE /Sale endpoint to make a logical delete of the sale by cancelling it.

- **GetSaleHandler**:
    Handler for the GET /Sale/{id} endpoint to get sale by Id.

- **GetSalesHandler**:
    Handler for the GET /Sale endpoint to get the sales list.    


## Tests

- **CreateSaleHandlerTests**:
    Unit Tests for the CreateSaleHandler.

- **DeleteSaleHandlerTests**:
    Unit Tests for the DeleteSaleHandler.

- **GetSaleHandlerTests**:
    Unit Tests for the GetSaleHandler.

- **GetSalesHandlerTests**:
    Unit Tests for the GetSalesHandler.

## Configuration

### Requirements

Need to install the follow:

- Git:
    https://git-scm.com/downloads

- Dotnet Core 9.0 SDK and Runtime:
    https://dotnet.microsoft.com/en-us/download/dotnet/8.0


## Getting Started

#### Clone the repository:

```bash
git clone https://github.com/fksalviano/abi-evaluation.git
```

#### Go to the project directory

```bash
cd abi-evaluation
```

#### Up Docker Compose dependencies

```bash
docker compose up -d
```

#### Build the project

```bash
dotnet build Ambev.DeveloperEvaluation.sln 
```

#### Run the WebApi project

```bash
dotnet run --project src/Ambev.DeveloperEvaluation.WebApi/
```

# Gavel Mobile PO Approver API

This repository contains the backend REST API for the Gavel Mobile Purchase Order (PO) Approval application. It securely handles user authentication, approval workflows, and provides data to the mobile application regarding outstanding and historical purchase orders.

## Architecture

The solution is built using **Clean Architecture** principles and the **CQRS** (Command Query Responsibility Segregation) pattern to ensure maintainability, scalability, and loose coupling.

The repository is divided into the following core projects:

* **`GavelMobilePoApprover.Api` (Presentation Layer)**
    * The entry point of the application.
    * Contains REST API Controllers (`AuthenticationController`, `CountController`, `PurchaseOrderEditableController`, `PurchaseOrderHistoryController`, etc.).
    * Handles HTTP requests/responses, dependency injection setup, global error handling via ProblemDetails, and object mapping configurations.
* **`GavelMobilePoApprover.Application` (Application Layer)**
    * Contains the core business logic and use cases.
    * Implements CQRS using **MediatR** (e.g., `LoginQuery`, `OutstandingCountQuery`).
    * Defines interfaces for infrastructure implementations (e.g., `IJwtTokenGenerator`, `IUserRepository`, `IOutstandingCountRepository`).
    * Includes request validation pipelines using FluentValidation behaviors.
* **`GavelMobilePoApprover.Domain` (Domain Layer)**
    * The core of the system containing enterprise logic and entities.
    * Defines Domain Aggregates such as `User` and `OutstandingCount`.
    * Contains custom domain exceptions and error definitions.
* **`GavelMobilePoApprover.Infrastructure` (Infrastructure Layer)**
    * Implements the interfaces defined in the Application layer.
    * Contains data access logic using **Entity Framework Core** (`GavelMobilePoApproverDbContext`, Repositories, Entity Configurations).
    * Handles external concerns like JWT Token Generation (`JwtTokenGenerator`) and DateTime providers.
* **`GavelMobilePoApprover.Contracts` (Contracts Layer)**
    * Contains the Data Transfer Objects (DTOs) used for API requests and responses (e.g., `LoginRequest`, `OutstandingCountResponse`).
    * Acts as a shared contract definition between the API and the mobile client.

## Technologies Used

* **Framework:** .NET (C#)
* **Architecture:** Clean Architecture, CQRS
* **Libraries:** MediatR, Entity Framework Core, FluentValidation
* **Security:** JWT (JSON Web Tokens) Authentication

## Getting Started

### Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/download)
* SQL Server (or your configured database provider)

### Setup & Configuration

1.  **Clone the repository:**
    ```bash
    git clone <repository-url>
    cd gavelpo-approver-api
    ```

2.  **Configure AppSettings:**
    Update the `appsettings.json` or `appsettings.Development.json` file in the `GavelMobilePoApprover.Api` project with your specific database connection string and JWT secret keys.
    ```json
    "JwtSettings": {
      "Secret": "your-super-secret-key",
      "ExpiryMinutes": 60,
      "Issuer": "gavel-po-api",
      "Audience": "gavel-po-client"
    }
    ```

3.  **Apply Database Migrations:**
    Ensure your database is up to date with the latest EF Core migrations.
    ```bash
    dotnet ef database update --project GavelMobilePoApprover.Infrastructure --startup-project GavelMobilePoApprover.Api
    ```

4.  **Run the API:**
    ```bash
    cd GavelMobilePoApprover.Api
    dotnet run
    ```

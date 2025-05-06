# CandidateHub

A .NET-based candidate management system built using Clean Architecture principles.

## Project Structure

The solution is organized into the following projects:

- **CandidateHub.API**: The presentation layer containing controllers and API endpoints
- **CandidateHub.Application**: The application layer containing business logic and interfaces
- **CandidateHub.Domain**: The domain layer containing entities and domain models
- **CandidateHub.Infrastructure**: The infrastructure layer containing data access and external service implementations

## Technology Stack

- .NET 8
- Entity Framework Core
- SQL Server
- Clean Architecture
- Repository Pattern

## Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server
- Visual Studio 2022 or VS Code

### Installation

1. Clone the repository
```bash
git clone https://github.com/John-Ashraf/Onspec-Task.git
```

2. Navigate to the project directory
```bash
cd CandidateHub
```

3. Restore dependencies
```bash
dotnet restore
```

4. Update the connection string in `appsettings.json`

5. Run the application
```bash
dotnet run --project CandidateHub.API
```

## List of Assumptions

1. **Database**: The system assumes SQL Server as the database provider
2. **Authentication**: Basic authentication is implemented, assuming JWT token-based authentication
3. **Data Validation**: Input validation is handled at the API level
4. **Error Handling**: Global exception handling is implemented through middleware
5. **Logging**: Basic logging is implemented using built-in .NET logging
6. **Environment**: Development and Production environments are supported
7. **Dependencies**: All required NuGet packages are properly referenced

## List of Suggestions for Improvement

1. **Testing**
   - Add unit tests for business logic
   - Implement integration tests for API endpoints
   - Add end-to-end testing

2. **Security**
   - Implement more robust authentication and authorization
   - Add rate limiting
   - Implement API key management
   - Add request validation middleware

3. **Performance**
   - Implement caching mechanism
   - Add database indexing
   - Implement pagination for large datasets
   - Add response compression

4. **Monitoring and Logging**
   - Implement structured logging
   - Add application insights
   - Implement health checks
   - Add performance monitoring

5. **Documentation**
   - Add Swagger/OpenAPI documentation
   - Implement API versioning
   - Add more detailed code documentation

6. **CI/CD**
   - Set up automated build pipeline
   - Implement automated testing
   - Add deployment automation
   - Set up code quality checks

7. **Features**
   - Add file upload functionality
   - Implement email notifications
   - Add reporting features
   - Implement audit logging

## Time Spent

- Project Setup and Architecture: 0.5 hours
- Domain Layer Implementation: 0.5 hours
- Application Layer Implementation: 1 hours
- Infrastructure Layer Implementation: 1 hours
- API Layer Implementation: 1 hours
- Testing and Debugging: 1 hours
- Documentation: 0.5 hour

Total: 5.5 hours

# [EF-Core_Dapper_Tutorial](https://codewithmukesh.com/blog/using-entity-framework-core-and-dapper/)

[Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) and [Dapper](https://dapper-tutorial.net/) Tutorial

## BackEnd

Documentation pages made with [Doxygen](https://www.doxygen.nl/index.html) (with
[Graphviz](https://graphviz.org/download/) dependency to generate the class diagrams)

## Personal notes

### The following files should be at the [Persistence](Back/src/EF-CoreDapperTuto.Persistence) layer:

-   [EF-CoreDapperTuto.Domain/Interfaces/IApplicationDbContext](Back/src/EF-CoreDapperTuto.Domain/Interfaces/IApplicationDbContext.cs)
-   [EF-CoreDapperTuto.Domain/Interfaces/IApplicationReadDbConnection](Back/src/EF-CoreDapperTuto.Domain/Interfaces/IApplicationReadDbConnection.cs)
-   [EF-CoreDapperTuto.Domain/Interfaces/IApplicationWriteDbConnection](Back/src/EF-CoreDapperTuto.Domain/Interfaces/IApplicationWriteDbConnection.cs)

## The following files should be at the Application layer (that doesn't exist in the tutorial):

-   [EF-CoreDapperTuto.Persistence/DTOs/DepartmentDTO](Back/src/EF-CoreDapperTuto.Persistence/DTOs/DepartmentDTO.cs)
-   [EF-CoreDapperTuto.Persistence/DTOs/EmployeeDTO](Back/src/EF-CoreDapperTuto.Persistence/DTOs/EmployeeDTO.cs)

### Omnisharp

Sometimes it drives me nuts... 😜

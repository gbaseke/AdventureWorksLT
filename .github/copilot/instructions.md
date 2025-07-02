# GitHub Copilot Instructions for AdventureWorksLT Project

## Project Overview
This project works with the AdventureWorksLT database, a lightweight version of the Microsoft AdventureWorks sample database. It's designed to demonstrate database operations and business logic for a fictional bicycle manufacturer called Adventure Works Cycles.

## Database Structure
- **SalesLT.Customer**: Customer information
- **SalesLT.Product**: Product catalog information
- **SalesLT.ProductCategory**: Product categories
- **SalesLT.ProductDescription**: Product descriptions
- **SalesLT.ProductModel**: Product model information
- **SalesLT.SalesOrderDetail**: Sales order line items
- **SalesLT.SalesOrderHeader**: Sales order headers
- **SalesLT.Address**: Customer and vendor addresses
# Coding Guidelines

## Indentation

We use tabs, not spaces.

## Naming Conventions

* Use PascalCase for `type` names
* Use PascalCase for `enum` values
* Use camelCase for `function` and `method` names
* Use camelCase for `property` names and `local variables`
* Use whole words in names when possible

## Types

* Do not export `types` or `functions` unless you need to share it across multiple components
* Do not introduce new `types` or `values` to the global namespace

## Comments

* When there are comments for `functions`, `interfaces`, `enums`, and `classes` use JSDoc style comments

## Strings

* Use "double quotes" for strings shown to the user that need to be externalized (localized)
* Use 'single quotes' otherwise
* All strings visible to the user need to be externalized

## Style

* Use arrow functions `=>` over anonymous function expressions
* Only surround arrow function parameters when necessary. For example, `(x) => x + x` is wrong but the following are correct:

```javascript
x => x + x
(x, y) => x + y
<T>(x: T, y: T) => x === y
```

* Always surround loop and conditional bodies with curly braces
* Open curly braces always go on the same line as whatever necessitates them
* Parenthesized constructs should have no surrounding whitespace. A single space follows commas, colons, and semicolons in those constructs. For example:

```javascript
for (let i = 0, n = str.length; i < 10; i++) {
    if (x < 10) {
        foo();
    }
}

function f(x: number, y: string): void { }
```

## Coding Conventions
- Use camelCase for variable names and PascalCase for class/interface names
- Include XML documentation comments for public methods and classes
- Follow SOLID principles for object-oriented design
- Use async/await for asynchronous operations
- Implement proper error handling with try/catch blocks
- Use meaningful variable and function names that describe their purpose

## Common Tasks
When working on this project, I often need help with:
- Writing efficient SQL queries against the AdventureWorksLT database
- Creating data access layers with proper repository patterns
- Building REST API endpoints for the AdventureWorksLT data
- Implementing business logic for sales and product management
- Creating unit tests for the application logic

## Libraries and Technologies
The project may use:
- Entity Framework Core for data access
- ASP.NET Core for web APIs
- SQL Server for the database
- xUnit or NUnit for testing
- Azure for cloud deployments
- typescript for the front-end

## Security Considerations
- Always use parameterized queries to prevent SQL injection
- Implement proper authentication and authorization
- Protect sensitive customer data
- Follow least privilege principle for database access

## Performance Guidelines
- Use pagination for large data sets
- Consider caching strategies for frequently accessed data
- Index database columns that are frequently used in WHERE clauses
- Use asynchronous operations for I/O-bound work

## Additional Notes
When suggesting code, please consider the relationships between the AdventureWorksLT tables and the business rules that might apply to a bicycle sales company.
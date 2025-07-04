# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a full-stack e-commerce application built with ASP.NET Core Web API backend and Angular frontend. It implements a product catalog system using the AdventureWorksLT database schema.

## Architecture

The solution follows Clean Architecture principles with three main layers:

- **API**: ASP.NET Core Web API with controllers and DTOs
- **Core**: Domain entities, interfaces, and business logic
- **Infrastructure**: Data access, Entity Framework context, and repositories

The frontend is an Angular application located in the `/client` directory.

## Commands

### Backend (.NET)
- **Build solution**: `dotnet build` (from root directory)
- **Run API**: `dotnet run --project API` or `dotnet watch --project API`
- **Restore packages**: `dotnet restore`
- **Run tests**: `dotnet test` (if test projects exist)

### Frontend (Angular)
Navigate to `/client` directory first:
- **Install dependencies**: `npm install`
- **Start development server**: `ng serve` or `npm start`
- **Build for production**: `ng build` or `npm run build`
- **Run tests**: `ng test` or `npm test`
- **Watch build**: `ng build --watch --configuration development`

## Key Components

### Backend Architecture
- **Generic Repository Pattern**: `IGenericRepository<T>` with `GenericRepository<T>` implementation
- **Specification Pattern**: `BaseSpecification<T>` for complex queries
- **Entity Framework**: Uses SQL Server with `StoreContext` as the main DbContext
- **AutoMapper**: DTO mapping between entities and API responses
- **Exception Middleware**: Centralized error handling

### Frontend Architecture
- **Angular 20**: Modern Angular application with standalone components
- **Material Design**: Uses Angular Material UI components
- **Tailwind CSS**: Utility-first CSS framework
- **TypeScript**: Strongly typed throughout

## Database
- Uses SQL Server with AdventureWorksLT schema
- Products table in `SalesLT` schema
- Connection string configured in `appsettings.Development.json`

## Development Notes
- API runs on `https://localhost:5001` (or configured port)
- Angular client runs on `http://localhost:4200`
- CORS is configured to allow requests from the Angular client
- API includes OpenAPI/Swagger documentation in development mode
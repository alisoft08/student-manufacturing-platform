# First Student Manufacturing Platform

## Summary
First Student Manufacturing Platform API, built with Microsoft C#, ASP.NET Core, Entity Framework Core, and MySQL persistence. It also illustrates OpenAPI documentation configuration and integration with Swagger UI.

## Features
- RESTful API
- OpenAPI Documentation
- Swagger UI
- ASP.NET Framework
- Entity Framework Core
- Audit Creation and Update Date
- Custom Route Naming Conventions
- Custom Object-Relational Mapping Naming Conventions
- MySQL Database
- Domain-Driven Design

## Bounded Contexts
This version of the First Student Manufacturing Platform is divided into two main bounded contexts: Assets and Operations.

### Assets Context

The Assets context is responsible for managing buses. It includes the following features:

- Bus creation
- Bus querying by ID
- Bus seat management

This context also includes an anti-corruption layer to communicate with the Operations context. The anti-corruption layer manages communication between both contexts and offers the following capabilities to other bounded contexts:

- Fetch bus by ID
- Fetch number of seats by bus ID

### Operations Context

The Operations context is responsible for both student management and assignments between students and buses. Its main features include:

- Student creation and querying
- Management of sibling relationships between students (parentId)
- Creation of assignments between students and buses
- Querying assignments by ID
- Listing all assignments
- Unassigning students from buses
- Validation of assignment rules (e.g., seat availability, student eligibility)
- Integration with the Assets context to verify bus information

This context ensures that each assignment respects business rules and maintains data consistency across the platform. It also provides the necessary student and relationship information to validate assignments.

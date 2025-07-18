# FIRSTstudentManufacturingPlatform Platform

## Summary
FIRSTstudentManufacturingPlatform Platform API,
made with Microsoft C#, ASP.NET Core, Entity Framework Core and MySQL persistence.
It also illustrates open-api documentation configuration and integration with Swagger UI.

## Features
- RESTful API
- OpenAPI Documentation
- Swagger UI
- ASP.NET Framework
- Entity Framework Core
- Audit Creation and Update Date
- Custom Route Naming Conventions
- Custom Object-Relational Mapping Naming Conventions.
- MySQL Database
- Domain-Driven Design

## Bounded Contexts
This version of FIRSTstudentManufacturingPlatform Platform is divided into three bounded contexts: Assets, Operations, and Students.

### Assets Context

The Assets Context is responsible for managing the buses. It includes the following features:

- Bus creation
- Bus querying by ID
- Bus seat management

This context includes also an anti-corruption layer to communicate with the Operations Context.
The anti-corruption layer is responsible
for managing the communication between the Assets Context and the Operations Context.
It offers the following capabilities to other bounded contexts:

- Fetch bus by ID
- Fetch number of seats by bus ID

### Operations Context

The Operations Context is responsible for managing assignments between students and buses.
Its features include:

- Assignment creation
- Assignment validation (siblings assigned to same bus)
- Assignment querying


The Students feature is responsible for managing student information and relationships.
Its features include:

- Student creation and seeding
- Student querying
- Sibling relationship management (parentId)

This context supports assignment validation by providing sibling information to the Operations Context.

namespace FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Queries;

/// <summary>
/// Represents a query to retrieve a bus by its unique identifier.
/// This record contains the bus ID parameter needed to fetch a specific bus entity.
/// </summary>
/// <param name="Id">The unique identifier of the bus to retrieve.</param>
/// <author>Alison Arrieta</author>
public record GetBusByIdQuery(int Id);
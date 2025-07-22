namespace FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Commands;

/// <summary>
/// Represents a command to create a new assignment between a student and a bus.
/// This record contains the necessary identifiers to establish the assignment relationship.
/// </summary>
/// <param name="studentId">The unique identifier of the student to be assigned.</param>
/// <param name="busId">The unique identifier of the bus to be assigned.</param>
/// <author>Alison Arrieta</author>
public record CreateAssignmentCommand(int studentId, int busId);

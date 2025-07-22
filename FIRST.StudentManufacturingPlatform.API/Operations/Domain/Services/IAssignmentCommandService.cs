using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Aggregates;
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Commands;

namespace FIRST.StudentManufacturingPlatform.API.Operations.Domain.Services;

/// <summary>
/// Service interface for handling assignment command operations in the operations context.
/// Provides methods to process assignment-related commands and business logic.
/// </summary>
/// <author>Alison Arrieta</author>
public interface IAssignmentCommandService
{
    /// <summary>
    /// Handles the creation of a new assignment based on the provided command.
    /// </summary>
    /// <param name="command">The create assignment command containing the assignment data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created assignment if successful; otherwise, null.</returns>
    /// <author>Alison Arrieta</author>
    Task<Assignment?> Handle(CreateAssignmentCommand command);
}
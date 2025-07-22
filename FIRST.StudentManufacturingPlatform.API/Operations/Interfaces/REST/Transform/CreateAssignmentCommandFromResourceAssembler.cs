using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Commands;
using FIRST.StudentManufacturingPlatform.API.Operations.Interfaces.REST.Resources;

namespace FIRST.StudentManufacturingPlatform.API.Operations.Interfaces.REST.Transform;

/// <summary>
/// Static assembler class for transforming CreateAssignmentResource objects into CreateAssignmentCommand objects.
/// Provides methods to convert REST API resources to domain commands.
/// </summary>
/// <author>Alison Arrieta</author>
public static class CreateAssignmentCommandFromResourceAssembler
{
    /// <summary>
    /// Transforms a CreateAssignmentResource into a CreateAssignmentCommand for domain processing.
    /// </summary>
    /// <param name="resource">The CreateAssignmentResource containing the assignment data from the API request.</param>
    /// <param name="busId">The unique identifier of the bus to be assigned.</param>
    /// <returns>A CreateAssignmentCommand containing the resource data formatted for domain processing.</returns>
    /// <author>Alison Arrieta</author>
    public static CreateAssignmentCommand ToCommandFromResource(CreateAssignmentResource resource, int busId)
    {
        return new CreateAssignmentCommand(
            resource.StudentId,
            busId
        );
    }
}
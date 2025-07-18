using eb4395u202312031.Manufacturing.Domain.Model.Commands;
using eb4395u202312031.Manufacturing.Interfaces.REST.Resources;

namespace eb4395u202312031.Manufacturing.Interfaces.REST.Transform;

/// <summary>
/// Provides a method to convert a CreateAssignmentResource into a CreateAssignmentCommand.
/// </summary>
/// <remarks>
/// Alison Jimena Arrieta Quispe
/// </remarks>
public static class CreateAssignmentCommandFromResourceAssembler
{
    /// <summary>
    /// Transforms a REST resource into a domain command for creating a Assignment entity.
    /// </summary>
    /// <param name="resource">The input resource received from the API request.</param>
    /// <returns>A CreateAssignmentCommand instance containing the mapped data from the resource.</returns>
    /// <remarks>
    /// Alison Jimena Arrieta Quispe
    /// </remarks>
    public static CreateAssignmentCommand ToCommandFromResource(CreateAssignmentResource resource, int busId)
    {
        return new CreateAssignmentCommand(
            resource.StudentId,
            busId
        );
    }
}
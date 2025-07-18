using eb4395u202312031.Manufacturing.Domain.Model.Aggregates;
using eb4395u202312031.Manufacturing.Interfaces.REST.Resources;

namespace eb4395u202312031.Manufacturing.Interfaces.REST.Transform;

/// <summary>
/// Provides a method to convert a Assignment domain entity into a AssignmentResource for API responses.
/// </summary>
/// <remarks>
/// Alison Jimena Arrieta Quispe
/// </remarks>
public static class AssignmentResourceFromEntityAssembler
{
    /// <summary>
    /// Converts a Assignment entity into its corresponding REST resource representation.
    /// </summary>
    /// <param name="entity">The Assignment entity from the domain model.</param>
    /// <returns>A AssignmentResource object containing the mapped values.</returns>
    /// <remarks>
    /// Alison Jimena Arrieta Quispe
    /// </remarks>
    public static AssignmentResource ToResourceFromEntity(Assignment entity)
    {
        return new AssignmentResource(
            entity.Id,
            entity.StudentId,
            entity.BusId,
            entity.AssignedAt
            );

    }
}
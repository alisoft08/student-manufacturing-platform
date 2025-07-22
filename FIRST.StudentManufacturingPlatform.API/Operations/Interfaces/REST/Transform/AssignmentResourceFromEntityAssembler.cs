using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Aggregates;
using FIRST.StudentManufacturingPlatform.API.Operations.Interfaces.REST.Resources;

namespace FIRST.StudentManufacturingPlatform.API.Operations.Interfaces.REST.Transform;

/// <summary>
/// Static assembler class for transforming Assignment entities into AssignmentResource objects.
/// Provides methods to convert domain entities to REST API resource representations.
/// </summary>
/// <author>Alison Arrieta</author>
public static class AssignmentResourceFromEntityAssembler
{
    /// <summary>
    /// Transforms an Assignment entity into an AssignmentResource for REST API responses.
    /// </summary>
    /// <param name="entity">The Assignment entity to transform.</param>
    /// <returns>An AssignmentResource containing the entity data formatted for API consumption.</returns>
    /// <author>Alison Arrieta</author>
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
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Commands;
using FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.REST.Resources;

namespace FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.REST.Transform;

/// <summary>
/// Static assembler class for transforming CreateBusResource objects into CreateBusCommand objects.
/// Provides methods to convert REST API resources to domain commands.
/// </summary>
/// <author>Alison Arrieta</author>
public static class CreateBusCommandFromResourceAssembler
{
    /// <summary>
    /// Transforms a CreateBusResource into a CreateBusCommand for domain processing.
    /// </summary>
    /// <param name="resource">The <see cref="CreateBusResource"/> containing the bus data from the API request.</param>
    /// <returns>A <see cref="CreateBusCommand"/> containing the resource data formatted for domain processing.</returns>
    /// <author>Alison Arrieta</author>
    public static CreateBusCommand ToCommandFromResource(CreateBusResource resource)
    {
        return new CreateBusCommand(
            resource.vehiclePlate,
            resource.fuelTankType,
            resource.districtId,
            resource.totalSeats);
    }
}
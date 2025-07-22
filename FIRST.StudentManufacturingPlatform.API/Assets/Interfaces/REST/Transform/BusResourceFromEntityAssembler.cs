using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Aggregates;
using FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.REST.Resources;

namespace FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.REST.Transform;

/// <summary>
/// Static assembler class for transforming Bus entities into BusResource objects.
/// Provides methods to convert domain entities to REST API resource representations.
/// </summary>
/// <author>Alison Arrieta</author>
public static class BusResourceFromEntityAssembler
{
    /// <summary>
    /// Transforms a Bus entity into a BusResource for REST API responses.
    /// </summary>
    /// <param name="entity">The <see cref="Bus"/> entity to transform.</param>
    /// <returns>A BusResource containing the entity data formatted for API consumption.</returns>
    /// <author>Alison Arrieta</author>
    public static BusResource ToResourceFromEntity(Bus entity)
    {
        return new BusResource(
            entity.Id,
            entity.VehiclePlate,
            entity.FuelTankType,
            entity.DistrictId,
            entity.TotalSeats);

    }
}
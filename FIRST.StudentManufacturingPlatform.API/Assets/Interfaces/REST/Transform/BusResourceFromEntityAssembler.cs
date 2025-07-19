using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Aggregates;
using FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.REST.Resources;

namespace FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.REST.Transform;


public static class BusResourceFromEntityAssembler
{

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
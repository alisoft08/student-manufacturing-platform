using eb4395u202312031.Assets.Domain.Model.Aggregates;
using eb4395u202312031.Assets.Interfaces.REST.Resources;

namespace eb4395u202312031.Assets.Interfaces.REST.Transform;


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
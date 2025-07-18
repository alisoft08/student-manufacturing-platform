using eb4395u202312031.Assets.Domain.Model.Commands;
using eb4395u202312031.Assets.Interfaces.REST.Resources;

namespace eb4395u202312031.Assets.Interfaces.REST.Transform;

public static class CreateBusCommandFromResourceAssembler
{
  
    public static CreateBusCommand ToCommandFromResource(CreateBusResource resource)
    {
        return new CreateBusCommand(
            resource.vehiclePlate,
            resource.fuelTankType,
            resource.districtId,
            resource.totalSeats);
    }
}
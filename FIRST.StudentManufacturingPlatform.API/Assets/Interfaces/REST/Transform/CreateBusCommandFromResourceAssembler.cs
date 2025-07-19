using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Commands;
using FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.REST.Resources;

namespace FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.REST.Transform;

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
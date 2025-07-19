namespace FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.REST.Resources;


public record CreateBusResource(
    string vehiclePlate,
    string fuelTankType,
    int districtId,
    int totalSeats
    );
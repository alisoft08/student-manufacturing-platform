namespace FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.REST.Resources;


public record BusResource(
    int id,
    string vehiclePlate,
    string fuelTankType,
    int districtId,
    int totalSeats
    );
namespace eb4395u202312031.Assets.Interfaces.REST.Resources;


public record BusResource(
    int id,
    string vehiclePlate,
    string fuelTankType,
    int districtId,
    int totalSeats
    );
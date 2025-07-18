namespace eb4395u202312031.Assets.Interfaces.REST.Resources;


public record CreateBusResource(
    string vehiclePlate,
    string fuelTankType,
    int districtId,
    int totalSeats
    );
namespace FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Commands;

public record CreateBusCommand(string vehiclePLate, string fuelTankType, int districtId, int totalSeats);
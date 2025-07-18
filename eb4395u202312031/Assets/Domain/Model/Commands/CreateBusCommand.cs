namespace eb4395u202312031.Assets.Domain.Model.Commands;

public record CreateBusCommand(string vehiclePLate, string fuelTankType, int districtId, int totalSeats);
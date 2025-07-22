namespace FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Commands;

/// <summary>
/// Represents a command to create a new bus in the student manufacturing platform.
/// This record contains the necessary parameters to establish a new bus entity with vehicle information, fuel specifications, district assignment, and seating capacity.
/// </summary>
/// <param name="vehiclePLate">The vehicle plate number in format 'ABC-1234' (three uppercase letters, hyphen, four digits).</param>
/// <param name="fuelTankType">The fuel tank type identifier. Valid values are 'A', 'B', 'C', or 'D'.</param>
/// <param name="districtId">The district identifier where the bus will operate. Valid values are 1, 2, or 3.</param>
/// <param name="totalSeats">The total number of seats available in the bus. Valid range is between 20 and 40 seats inclusive.</param>
/// <author>Alison Arrieta</author>
public record CreateBusCommand(string vehiclePLate, string fuelTankType, int districtId, int totalSeats);
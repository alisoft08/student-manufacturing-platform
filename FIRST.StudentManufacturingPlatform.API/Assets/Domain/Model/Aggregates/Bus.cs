using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Commands;

namespace FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Aggregates;

/// <summary>
/// Represents a bus entity in the student manufacturing platform.
/// This aggregate manages bus information including vehicle plate, fuel tank type, district assignment, and seating capacity.
/// </summary>
/// <author>Alison Arrieta</author>
public partial class Bus
{
    /// <summary>
    /// Gets the unique identifier for the bus.
    /// </summary>
    /// <value>The bus ID.</value>
    public int Id { get; }

    /// <summary>
    /// Gets or sets the vehicle plate number of the bus.
    /// Must follow the format 'ABC-1234' (three uppercase letters, hyphen, four digits).
    /// </summary>
    /// <value>The vehicle plate in the format 'ABC-1234'.</value>
    public string VehiclePlate { get; set; } 
    
    /// <summary>
    /// Gets or sets the fuel tank type of the bus.
    /// Valid values are 'A', 'B', 'C', or 'D'.
    /// </summary>
    /// <value>The fuel tank type identifier.</value>
    public string FuelTankType { get; set; }
    
    /// <summary>
    /// Gets or sets the district identifier where the bus operates.
    /// Valid values are 1, 2, or 3.
    /// </summary>
    /// <value>The district ID (1-3).</value>
    public int DistrictId { get; set; }
    
    /// <summary>
    /// Gets or sets the total number of seats available in the bus.
    /// Valid range is between 20 and 40 seats inclusive.
    /// </summary>
    /// <value>The total number of seats (20-40).</value>
    public int TotalSeats { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Bus"/> class with default values.
    /// </summary>
    /// <author>Alison Arrieta</author>
    public Bus(){}

    /// <summary>
    /// Initializes a new instance of the <see cref="Bus"/> class with the specified parameters.
    /// Validates all input parameters according to business rules.
    /// </summary>
    /// <param name="vehiclePLate">The vehicle plate number in format 'ABC-1234'.</param>
    /// <param name="fuelTankType">The fuel tank type ('A', 'B', 'C', or 'D').</param>
    /// <param name="districtId">The district identifier (1, 2, or 3).</param>
    /// <param name="totalSeats">The total number of seats (20-40).</param>
    /// <exception cref="ArgumentException">Thrown when <see cref="VehiclePlate"/> format is invalid or <see cref="FuelTankType"/> is not valid.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <see cref="DistrictId"/> or <see cref="TotalSeats"/> are outside valid ranges.</exception>
    /// <author>Alison Arrieta</author>
    public Bus(string vehiclePLate, string fuelTankType, int districtId, int totalSeats)
    {
        if (!System.Text.RegularExpressions.Regex.IsMatch(vehiclePLate, @"^[A-Z]{3}-\d{4}$"))
        {
            throw new ArgumentException("Vehicle plate must be in the format 'ABC-1234'.", nameof(vehiclePLate));
        }
        VehiclePlate = vehiclePLate;
        
        if(fuelTankType != "A" && fuelTankType != "B" && fuelTankType != "C" 
           && fuelTankType != "D")
        {
            throw new ArgumentException("Fuel tank type must be 'A', 'B', 'C' or 'D'.", nameof(fuelTankType));
        }
        FuelTankType = fuelTankType;
        if(districtId < 1 || districtId > 3)
        {
            throw new ArgumentOutOfRangeException(nameof(districtId), 
                "District ID must be 1, 2, or 3.");
        }
        DistrictId = districtId;
        if(totalSeats < 20 || totalSeats > 40)
        {
            throw new ArgumentOutOfRangeException(nameof(totalSeats), 
                "Total seats must be integer between 20 and 40.");
        }
        
        
        
        TotalSeats = totalSeats;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Bus"/> class using a create bus command.
    /// Validates all command parameters according to business rules.
    /// </summary>
    /// <param name="command">The <see cref="CreateBusCommand"/> containing the bus data.</param>
    /// <exception cref="ArgumentException">Thrown when <see cref="VehiclePlate"/> format is invalid or <see cref="FuelTankType"/> is not valid.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <see cref="DistrictId"/> or <see cref="TotalSeats"/> are outside valid ranges.</exception>
    /// <author>Alison Arrieta</author>
    public Bus(CreateBusCommand command) 
        : this(command.vehiclePLate, command.fuelTankType, command.districtId, command.totalSeats)
    {
    }

    
}
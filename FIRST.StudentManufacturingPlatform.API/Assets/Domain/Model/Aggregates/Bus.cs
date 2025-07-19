using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Commands;

namespace FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Aggregates;


public partial class Bus
{
    
    public int Id { get; }

   
    public string VehiclePlate { get; set; } 
    
    public string FuelTankType { get; set; }
    
    public int DistrictId { get; set; }
    
    public int TotalSeats { get; set; }

    
    
    public Bus(){}

    
    
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

 
    public Bus(CreateBusCommand command)
    {
        if (!System.Text.RegularExpressions.Regex.IsMatch(command.vehiclePLate, @"^[A-Z]{3}-\d{4}$"))
        {
            throw new ArgumentException("Vehicle plate must be in the format 'ABC-1234'.", nameof(command.vehiclePLate));
        }
        VehiclePlate = command.vehiclePLate;
        
        if(command.fuelTankType != "A" && command.fuelTankType != "B" && command.fuelTankType != "C" 
           && command.fuelTankType != "D")
        {
            throw new ArgumentException("Fuel tank type must be 'A', 'B', 'C' or 'D'.", nameof(command.fuelTankType));
        }
        
        FuelTankType = command.fuelTankType;
        
        if(command.districtId < 1 || command.districtId > 3)
        {
            throw new ArgumentOutOfRangeException(nameof(command.districtId), 
                "District ID must be 1, 2, or 3.");
        }
        
        DistrictId = command.districtId;
        if(command.totalSeats < 20 || command.totalSeats > 40)
        {
            throw new ArgumentOutOfRangeException(nameof(command.totalSeats), 
                "Total seats must be integer between 20 and 40.");
        }
        TotalSeats = command.totalSeats;
    }

    
}
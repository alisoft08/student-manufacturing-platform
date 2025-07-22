using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Aggregates;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Commands;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Repositories;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Services;
using FIRST.StudentManufacturingPlatform.API.Shared.Domain.Repositories;

namespace FIRST.StudentManufacturingPlatform.API.Assets.Application.Internal.CommandServices;

/// <summary>
/// Implementation of the bus command service for handling bus creation operations.
/// This service manages the business logic for creating buses, including validation of vehicle plate uniqueness
/// and coordination of persistence operations with transaction management.
/// </summary>
/// <author>Alison Arrieta</author>
public class BusCommandService(IBusRepository repository, IUnitOfWork unitOfWork) : IBusCommandService
{
    /// <summary>
    /// Handles the creation of a new bus with comprehensive validation and error handling.
    /// Validates vehicle plate uniqueness and manages the complete bus creation workflow.
    /// </summary>
    /// <param name="command">The <see cref="CreateBusCommand"/> containing bus data including vehicle plate, fuel tank type, district ID, and total seats.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created bus if all validations pass and persistence succeeds; otherwise, null.</returns>
    /// <exception cref="Exception">Thrown when a bus with the same vehicle plate already exists.</exception>
    /// <author>Alison Arrieta</author>
    public async Task<Bus?> Handle(CreateBusCommand command)
    {


        var exists = await repository.ExistsByVehiclePlateAsync(command.vehiclePLate);
        if (exists)
        {
            throw new Exception($"A bus with the vehicle plate {command.vehiclePLate} already exists.");
        }

        var Bus = new Bus(command);

        try
        {
            await repository.AddAsync(Bus);
            await unitOfWork.CompleteAsync();
            return Bus;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
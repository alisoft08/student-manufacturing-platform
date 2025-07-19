using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Aggregates;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Commands;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Repositories;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Services;
using FIRST.StudentManufacturingPlatform.API.Shared.Domain.Repositories;

namespace FIRST.StudentManufacturingPlatform.API.Assets.Application.Internal.CommandServices;


/// <summary>
/// Service responsible for handling bus creation commands and coordinating persistence operations.
/// </summary>
/// <author>
/// Alison Arrieta
/// </author>
public class BusCommandService(IBusRepository repository, IUnitOfWork unitOfWork) : IBusCommandService
{
    /// <inheritdoc />
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
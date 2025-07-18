using eb4395u202312031.API.Shared.Domain.Repositories;
using eb4395u202312031.Assets.Domain.Model.Aggregates;
using eb4395u202312031.Assets.Domain.Model.Commands;
using eb4395u202312031.Assets.Domain.Repositories;
using eb4395u202312031.Assets.Domain.Services;
namespace eb4395u202312031.Assets.Application.Internal.CommandServices;


/// <summary>
/// Service responsible for handling bus creation commands and coordinating persistence operations.
/// </summary>
/// <remarks>
/// Alison Jimena Arrieta Quispe
/// </remarks>
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
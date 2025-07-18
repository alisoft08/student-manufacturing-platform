using eb4395u202312031.API.Shared.Domain.Repositories;
using eb4395u202312031.Assets.Domain.Model.Aggregates;
using eb4395u202312031.Assets.Domain.Model.Commands;
using eb4395u202312031.Assets.Domain.Repositories;
using eb4395u202312031.Assets.Domain.Services;
namespace eb4395u202312031.Assets.Application.Internal.CommandServices;


public class BusCommandService(IBusRepository repository, IUnitOfWork unitOfWork) : IBusCommandService
{
   
    public async Task<Bus?> Handle(CreateBusCommand command)
    {
        /*var minCapacityThreshold = configuration.GetValue<int>("CapacityThresholds:minCapacityThreshold");
        var maxBusionQuantity = configuration.GetValue<int>("CapacityThresholds:maxCapacityThreshold");
        
        
        Bus.SetBusionCapacity(command.maxBusionQuantity, minCapacityThreshold, maxBusionQuantity);
        
        var requiredQuantity = await facade.FetchLatestRequiredQuantity();
        var lastCurrentBusionQuantity = await repository.FindLastCurrentBusionQuantity();
        var sum = requiredQuantity + lastCurrentBusionQuantity;
        Bus.UpdateCurrentBusionQuantity(sum);
        
        if(command.maxBusionQuantity < sum)
        {
            throw new Exception($"The maximum Busion quantity {command.maxBusionQuantity} cannot be less than the required quantity {sum}.");
        }
        */
        
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
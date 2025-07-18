using eb4395u202312031.Assets.Domain.Model.Aggregates;
using eb4395u202312031.Assets.Domain.Model.Queries;
using eb4395u202312031.Assets.Domain.Repositories;
using eb4395u202312031.Assets.Domain.Services;

namespace eb4395u202312031.Assets.Application.Internal.QueryServices;

public class BusQueryService(IBusRepository repository) : IBusQueryService
{
 
    public async Task<IEnumerable<Bus>> Handle(GetAllBusesQuery query)
    {
        return await repository.ListAsync();
    }

    public async Task<Bus?> Handle(GetBusByIdQuery query)
    {
        return await repository.FindBusByIdAsync(query.Id);
        
    }

    


    // public async Task<Bus?> Handle(GetBusByBusNumberQuery query)
    // {
    //     return await repository.FindBusByBusNumberAsync(query.BusNumber);
    // }
}
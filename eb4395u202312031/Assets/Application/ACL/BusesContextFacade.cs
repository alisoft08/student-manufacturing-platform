using eb4395u202312031.Assets.Domain.Model.Queries;
using eb4395u202312031.Assets.Domain.Services;
using eb4395u202312031.Assets.Interfaces.ACL;

namespace eb4395u202312031.Assets.Application.ACL;


public class BusesContextFacade(IBusQueryService BusQueryService) : IBusesContextFacade
{

    /// <inheritdoc />
    public async Task<int> FetchBusByIdAsync(int busId)
    {
        var getBusById = new GetBusByIdQuery(busId);
        var Bus = await BusQueryService.Handle(getBusById);
        return Bus?.Id ?? 0;
    }

    /// <inheritdoc />
    public async Task<int> FetchNumberOfSeatsByBusIdAsync(int busId)
    {
        var getBusById = new GetBusByIdQuery(busId);
        var Bus = await BusQueryService.Handle(getBusById);
        return Bus?.TotalSeats ?? -1;
    }
    
}
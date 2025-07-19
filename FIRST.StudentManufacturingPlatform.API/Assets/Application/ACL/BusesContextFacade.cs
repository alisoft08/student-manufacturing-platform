using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Queries;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Services;
using FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.ACL;

namespace FIRST.StudentManufacturingPlatform.API.Assets.Application.ACL;


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
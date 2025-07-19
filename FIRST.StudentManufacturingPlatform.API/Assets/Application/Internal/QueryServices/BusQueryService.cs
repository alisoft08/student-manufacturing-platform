using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Aggregates;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Queries;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Repositories;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Services;

namespace FIRST.StudentManufacturingPlatform.API.Assets.Application.Internal.QueryServices;

public class BusQueryService(IBusRepository repository) : IBusQueryService
{
 
 

    public async Task<Bus?> Handle(GetBusByIdQuery query)
    {
        return await repository.FindByIdAsync(query.Id);
        
    }
}
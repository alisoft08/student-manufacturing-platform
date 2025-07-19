using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Aggregates;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Queries;

namespace FIRST.StudentManufacturingPlatform.API.Assets.Domain.Services;


public interface IBusQueryService
{
    
    Task<Bus?> Handle(GetBusByIdQuery query);

}
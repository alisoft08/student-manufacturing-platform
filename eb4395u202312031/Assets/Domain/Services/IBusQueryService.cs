using eb4395u202312031.Assets.Domain.Model.Aggregates;
using eb4395u202312031.Assets.Domain.Model.Queries;

namespace eb4395u202312031.Assets.Domain.Services;


public interface IBusQueryService
{
    
    Task<IEnumerable<Bus>> Handle(GetAllBusesQuery query);
    
    
    Task<Bus?> Handle(GetBusByIdQuery query);

}
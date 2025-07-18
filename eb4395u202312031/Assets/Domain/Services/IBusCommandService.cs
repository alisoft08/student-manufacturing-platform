using eb4395u202312031.Assets.Domain.Model.Aggregates;
using eb4395u202312031.Assets.Domain.Model.Commands;

namespace eb4395u202312031.Assets.Domain.Services;


public interface IBusCommandService
{

    Task<Bus?> Handle(CreateBusCommand command);
}
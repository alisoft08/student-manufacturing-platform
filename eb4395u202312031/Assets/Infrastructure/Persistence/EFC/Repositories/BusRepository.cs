using eb4395u202312031.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using eb4395u202312031.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using eb4395u202312031.Assets.Domain.Model.Aggregates;
using eb4395u202312031.Assets.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eb4395u202312031.Assets.Infrastructure.Persistence.EFC.Repositories;


public class BusRepository(AppDbContext context) : BaseRepository<Bus>(context), IBusRepository
{
    
    public async Task<bool> ExistsByVehiclePlateAsync(string vehiclePlate)
    {
        return await Context.Set<Bus>()
            .AnyAsync(b =>
                b.VehiclePlate == vehiclePlate);
    }

    public async Task<Bus?> FindBusByIdAsync(int busId)
    {
        return await Context.Set<Bus>().FirstOrDefaultAsync(sn => sn.Id == busId);
    }

    public async Task<int> FindNumberOfSeatsByBusIdAsync(int busId)
    {
        var bus = await Context.Set<Bus>().FirstOrDefaultAsync(b => b.Id == busId);
        return bus?.TotalSeats ?? 0;
    }

    
}
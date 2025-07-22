using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Aggregates;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Repositories;
using FIRST.StudentManufacturingPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FIRST.StudentManufacturingPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FIRST.StudentManufacturingPlatform.API.Assets.Infrastructure.Persistence.EFC.Repositories;


public class BusRepository(AppDbContext context) : BaseRepository<Bus>(context), IBusRepository
{
    
    /// <inheritdoc />
    public async Task<bool> ExistsByVehiclePlateAsync(string vehiclePlate)
    {
        return await Context.Set<Bus>()
            .AnyAsync(b =>
                b.VehiclePlate == vehiclePlate);
    }
    
}
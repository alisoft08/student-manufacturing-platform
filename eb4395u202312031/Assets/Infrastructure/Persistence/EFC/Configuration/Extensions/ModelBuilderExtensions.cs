using eb4395u202312031.Assets.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace eb4395u202312031.Assets.Infrastructure.Persistence.EFC.Configuration.Extensions;


public static class ModelBuilderExtensions
{
   
    public static void ApplyBusConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Bus>().HasKey(t => t.Id);

        builder.Entity<Bus>()
            .Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Entity<Bus>().Property(t => t.VehiclePlate).IsRequired();
        builder.Entity<Bus>().Property(t => t.FuelTankType).IsRequired();
        builder.Entity<Bus>().Property(t => t.DistrictId).IsRequired();
        builder.Entity<Bus>().Property(t => t.TotalSeats).IsRequired();
        


    }
}
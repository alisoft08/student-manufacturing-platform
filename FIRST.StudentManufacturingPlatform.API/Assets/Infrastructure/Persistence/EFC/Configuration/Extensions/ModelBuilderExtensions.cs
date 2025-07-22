using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace FIRST.StudentManufacturingPlatform.API.Assets.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
/// Extension methods for ModelBuilder to configure entity mappings for the assets context.
/// Contains configuration methods for Bus entities including primary key, required properties, and constraints.
/// </summary>
/// <author>Alison Arrieta</author>
public static class ModelBuilderExtensions
{
    /// <summary>
    /// Applies configuration for the Bus entity including primary key, required properties, and constraints.
    /// </summary>
    /// <param name="builder">The ModelBuilder instance to configure.</param>
    /// <author>Alison Arrieta</author>
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
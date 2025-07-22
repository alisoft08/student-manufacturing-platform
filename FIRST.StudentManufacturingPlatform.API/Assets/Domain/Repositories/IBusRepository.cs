using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Aggregates;
using FIRST.StudentManufacturingPlatform.API.Shared.Domain.Repositories;

namespace FIRST.StudentManufacturingPlatform.API.Assets.Domain.Repositories;

/// <summary>
/// Repository interface for managing bus entities in the assets context.
/// Provides specific operations for bus queries and persistence operations beyond the base repository functionality.
/// </summary>
/// <author>Alison Arrieta</author>
public interface IBusRepository : IBaseRepository<Bus>
{
    /// <summary>
    /// Checks if a bus exists with the specified vehicle plate number.
    /// </summary>
    /// <param name="vehiclePlate">The vehicle plate number to check for existence.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains true if a bus with the specified vehicle plate exists; otherwise, false.</returns>
    /// <author>Alison Arrieta</author>
    Task<bool> ExistsByVehiclePlateAsync(string vehiclePlate);
}
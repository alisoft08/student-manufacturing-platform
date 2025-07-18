using eb4395u202312031.API.Shared.Domain.Repositories;
using eb4395u202312031.Assets.Domain.Model.Aggregates;

namespace eb4395u202312031.Assets.Domain.Repositories;

/// <summary>
/// Repository interface for Bus aggregate, providing methods for bus data access and queries.
/// </summary>
/// <remarks>
/// Alison Jimena Arrieta Quispe
/// </remarks>
public interface IBusRepository : IBaseRepository<Bus>
{
    /// <summary>
    /// Checks if a bus exists by its vehicle plate.
    /// </summary>
    /// <param name="vehiclePlate">The vehicle plate to check.</param>
    /// <returns>True if a bus with the given vehicle plate exists; otherwise, false.</returns>
    /// <remarks>
    /// Alison Jimena Arrieta Quispe
    /// </remarks>
    Task<bool> ExistsByVehiclePlateAsync(string vehiclePlate);

    /// <summary>
    /// Finds a bus by its unique identifier.
    /// </summary>
    /// <param name="busId">The bus ID to search for.</param>
    /// <returns>The bus if found; otherwise, null.</returns>
    /// <remarks>
    /// Alison Jimena Arrieta Quispe
    /// </remarks>
    Task<Bus?> FindBusByIdAsync(int busId);

    
}
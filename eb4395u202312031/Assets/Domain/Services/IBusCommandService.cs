using eb4395u202312031.Assets.Domain.Model.Aggregates;
using eb4395u202312031.Assets.Domain.Model.Commands;

namespace eb4395u202312031.Assets.Domain.Services;

/// <summary>
/// Defines the contract for bus command services, including bus creation logic.
/// </summary>
/// <remarks>
/// Alison Jimena Arrieta Quispe
/// </remarks>
public interface IBusCommandService
{
    /// <summary>
    /// Handles the creation of a new bus based on the provided command.
    /// </summary>
    /// <param name="command">The command containing the bus creation data.</param>
    /// <returns>
    /// The created <see cref="Bus"/> object if successful.
    /// Throws an exception if a bus with the same vehicle plate already exists.
    /// Returns null if an error occurs during persistence.
    /// </returns>
    /// <remarks>
    /// Alison Jimena Arrieta Quispe
    /// </remarks>
    Task<Bus?> Handle(CreateBusCommand command);
}
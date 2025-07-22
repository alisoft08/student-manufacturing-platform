namespace FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.ACL;

/// <summary>
/// Facade interface for accessing bus-related information from the Assets context.
/// Provides methods to fetch bus details and seat information for integration with other bounded contexts.
/// </summary>
/// <author>Alison Arrieta</author>
public interface IBusesContextFacade
{
    /// <summary>
    /// Fetches the bus identifier by its ID.
    /// </summary>
    /// <param name="busId">The unique identifier of the bus.</param>
    /// <returns>
    /// The bus identifier as an integer if the bus is found; otherwise, 0.
    /// </returns>
    /// <author>Alison Arrieta</author>
    Task<int> FetchBusByIdAsync(int busId);

    /// <summary>
    /// Fetches the number of seats for a given bus by its ID.
    /// </summary>
    /// <param name="busId">The unique identifier of the bus.</param>
    /// <returns>
    /// The number of seats available in the bus if the bus is found; otherwise, -1.
    /// </returns>
    /// <author>Alison Arrieta</author>
    Task<int> FetchNumberOfSeatsByBusIdAsync(int busId);
}

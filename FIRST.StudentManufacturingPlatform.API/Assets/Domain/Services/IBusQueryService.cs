using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Aggregates;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Queries;

namespace FIRST.StudentManufacturingPlatform.API.Assets.Domain.Services;

/// <summary>
/// Service interface for handling bus query operations in the assets context.
/// Provides methods to process bus-related queries and data retrieval operations.
/// </summary>
/// <author>Alison Arrieta</author>
public interface IBusQueryService
{
    /// <summary>
    /// Handles the retrieval of a bus by its unique identifier.
    /// </summary>
    /// <param name="query">The <see cref="GetBusByIdQuery"/> containing the bus ID to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the bus if found; otherwise, null.</returns>
    /// <author>Alison Arrieta</author>
    Task<Bus?> Handle(GetBusByIdQuery query);

}
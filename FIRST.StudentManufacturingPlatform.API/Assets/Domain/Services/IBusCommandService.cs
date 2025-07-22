using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Aggregates;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Commands;

namespace FIRST.StudentManufacturingPlatform.API.Assets.Domain.Services;

/// <summary>
/// Service interface for handling bus command operations in the assets context.
/// Provides methods to process bus-related commands and business logic operations.
/// </summary>
/// <author>Alison Arrieta</author>
public interface IBusCommandService
{
    /// <summary>
    /// Handles the creation of a new bus based on the provided command.
    /// </summary>
    /// <param name="command">The <see cref="CreateBusCommand"/> containing the bus data including vehicle plate, fuel tank type, district ID, and total seats.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created bus if successful; otherwise, null.</returns>
    /// <author>Alison Arrieta</author>
    Task<Bus?> Handle(CreateBusCommand command);
}
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Aggregates;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Queries;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Repositories;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Services;

namespace FIRST.StudentManufacturingPlatform.API.Assets.Application.Internal.QueryServices;

/// <summary>
/// Implementation of the bus query service for handling bus retrieval operations.
/// This service manages the business logic for querying buses from the repository,
/// providing data access operations for bus-related queries.
/// </summary>
/// <author>Alison Arrieta</author>
public class BusQueryService(IBusRepository repository) : IBusQueryService
{
    
    /// <inheritdoc />
    public async Task<Bus?> Handle(GetBusByIdQuery query)
    {
        return await repository.FindByIdAsync(query.Id);
        
    }
}
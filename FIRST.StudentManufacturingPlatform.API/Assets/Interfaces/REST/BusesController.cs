using System.Net.Mime;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Queries;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Services;
using FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.REST.Resources;
using FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.REST;

/// <summary>
/// REST API controller for managing bus operations in the student manufacturing platform.
/// Provides endpoints for creating and retrieving bus information including vehicle details, fuel specifications, and seating capacity.
/// </summary>
/// <author>Alison Arrieta</author>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Buses Endpoints.")]
public class BusesController(IBusCommandService BusCommandService, IBusQueryService BusQueryService)
    : ControllerBase
{
    /// <summary>
    /// Creates a new bus with the specified vehicle information and specifications.
    /// </summary>
    /// <param name="resource">The <see cref="CreateBusResource"/> containing the bus data including vehicle plate, fuel tank type, district ID, and total seats.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created bus resource if successful, or a bad request response if creation fails.</returns>
    /// <author>Alison Arrieta</author>
    [HttpPost]
    [SwaggerOperation("Create Bus", "Create a new Bus.", OperationId = "CreateBus")]
    [SwaggerResponse(201, "The Bus was created.", typeof(BusResource))]
    [SwaggerResponse(400, "The Bus was not created.")]
    public async Task<IActionResult> CreateProfile(CreateBusResource resource)
    {
        var createBusCommand = CreateBusCommandFromResourceAssembler.ToCommandFromResource(resource);
        var Bus = await BusCommandService.Handle(createBusCommand);
        if (Bus is null) return BadRequest();
        var BusResource = BusResourceFromEntityAssembler.ToResourceFromEntity(Bus);
        return StatusCode(201, BusResource);    
    }

    /// <summary>
    /// Retrieves a specific bus by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the bus to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the bus resource if found, or a not found response if the bus doesn't exist.</returns>
    /// <author>Alison Arrieta</author>
    [HttpGet("{id}")]
    [SwaggerOperation("Get Bus By Id", "Get a Bus by its ID", OperationId = "GetBusById")]
    [SwaggerResponse(200, "The Bus was found and returned", typeof(BusResource))]
    [SwaggerResponse(404, "The Bus was not found")]
    public async Task<IActionResult> GetBusById(int id)
    {
        var getBusByIdQuery = new GetBusByIdQuery(id);
        var bus = await BusQueryService.Handle(getBusByIdQuery);
        if (bus == null) return NotFound();
        var busResource = BusResourceFromEntityAssembler.ToResourceFromEntity(bus);
        return Ok(busResource);
    }
}

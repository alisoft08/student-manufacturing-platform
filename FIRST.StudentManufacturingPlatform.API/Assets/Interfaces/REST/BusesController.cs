using System.Net.Mime;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Model.Queries;
using FIRST.StudentManufacturingPlatform.API.Assets.Domain.Services;
using FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.REST.Resources;
using FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.REST;

/// <summary>
/// Exposes RESTful endpoints for managing Bus entities in the Assets context.
/// </summary>
/// <remarks>
/// Alison Jimena Arrieta Quispe
/// </remarks>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Buses Endpoints.")]
public class BusesController(IBusCommandService BusCommandService, IBusQueryService BusQueryService)
    : ControllerBase
{
   

    /// <summary>
    /// Creates a new Bus entity based on the provided resource data.
    /// </summary>
    /// <param name="resource">The resource containing the information required to create a Bus.</param>
    /// <returns>
    /// An HTTP 201 response with the created Bus resource if successful; otherwise, 400.
    /// </returns>
    /// <remarks>
    /// Alison Jimena Arrieta Quispe
    /// </remarks>
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
    /// Retrieves a Bus entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the Bus to retrieve.</param>
    /// <returns>An HTTP 200 response with the Bus resource if found; otherwise, 404.</returns>
    /// <remarks>
    /// Alison Jimena Arrieta Quispe
    /// </remarks>
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

using System.Net.Mime;
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Services;
using FIRST.StudentManufacturingPlatform.API.Operations.Interfaces.REST.Resources;
using FIRST.StudentManufacturingPlatform.API.Operations.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FIRST.StudentManufacturingPlatform.API.Operations.Interfaces.REST;

/// <summary>
/// Exposes RESTful endpoints for managing Assignment entities in the Operations context.
/// </summary>
/// <remarks>
/// Alison Jimena Arrieta Quispe
/// </remarks>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Assignments Endpoints.")]
public class AssignmentsController(IAssignmentCommandService AssignmentCommandService)
    : ControllerBase
{
    /// <summary>
    /// Creates a new Assignment entity based on the provided input resource.
    /// </summary>
    /// <param name="resource">The resource containing the data to create the Assignment.</param>
    /// <returns>
    /// A 201 Created response with the created AssignmentResource if successful; otherwise, 400 BadRequest.
    /// </returns>
    /// <remarks>
    /// Alison Jimena Arrieta Quispe
    /// </remarks>
    [HttpPost("/api/v1/buses/{busId}/assignments")]
    [SwaggerOperation("Create Assignment", "Create a new Assignment.", OperationId = "CreateAssignment")]
    [SwaggerResponse(201, "The Assignment was created.", typeof(AssignmentResource))]
    [SwaggerResponse(400, "The Assignment was not created.")]
    public async Task<IActionResult> CreateAssignment(int busId, [FromBody] CreateAssignmentResource resource)
    {
        var createAssignmentCommand = CreateAssignmentCommandFromResourceAssembler.ToCommandFromResource(resource, busId);
        var Assignment = await AssignmentCommandService.Handle(createAssignmentCommand);
        if (Assignment is null) return BadRequest();
        var BusResource = AssignmentResourceFromEntityAssembler.ToResourceFromEntity(Assignment);
        return StatusCode(201, BusResource);    
    }
}
using System.Net.Mime;
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Services;
using FIRST.StudentManufacturingPlatform.API.Operations.Interfaces.REST.Resources;
using FIRST.StudentManufacturingPlatform.API.Operations.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FIRST.StudentManufacturingPlatform.API.Operations.Interfaces.REST;

/// <summary>
/// REST API controller for managing assignment operations in the student manufacturing platform.
/// Provides endpoints for creating and managing assignments between students and buses.
/// </summary>
/// <author>Alison Arrieta</author>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Assignments Endpoints.")]
public class AssignmentsController(IAssignmentCommandService AssignmentCommandService)
    : ControllerBase
{
    /// <summary>
    /// Creates a new assignment between a student and a specific bus.
    /// </summary>
    /// <param name="busId">The unique identifier of the bus to assign the student to.</param>
    /// <param name="resource">The assignment resource containing the student information.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created assignment resource if successful, or a bad request response if creation fails.</returns>
    /// <author>Alison Arrieta</author>
    [HttpPost("/api/v1/buses/{busId}/assignments")]
    [SwaggerOperation("Create Assignment", "Create a new Assignment.", OperationId = "CreateAssignment")]
    [SwaggerResponse(201, "The Assignment was created.", typeof(AssignmentResource))]
    [SwaggerResponse(400, "The Assignment was not created.")]
    public async Task<IActionResult> CreateAssignment([FromRoute] int busId, [FromBody] CreateAssignmentResource resource)
    {
        var createAssignmentCommand = CreateAssignmentCommandFromResourceAssembler.ToCommandFromResource(resource, busId);
        var Assignment = await AssignmentCommandService.Handle(createAssignmentCommand);
        if (Assignment is null) return BadRequest();
        var BusResource = AssignmentResourceFromEntityAssembler.ToResourceFromEntity(Assignment);
        return StatusCode(201, BusResource);    
    }
}
namespace FIRST.StudentManufacturingPlatform.API.Operations.Interfaces.REST.Resources;


public record AssignmentResource(
    int Id,
    int StudentId,
    int BusId,
    DateTime AssignedAt
    );
namespace eb4395u202312031.Manufacturing.Interfaces.REST.Resources;


public record AssignmentResource(
    int Id,
    int StudentId,
    int BusId,
    DateTime AssignedAt
    );
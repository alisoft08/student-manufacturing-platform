using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Aggregates;
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Commands;

namespace FIRST.StudentManufacturingPlatform.API.Operations.Domain.Services;


public interface IAssignmentCommandService
{
    Task<Assignment?> Handle(CreateAssignmentCommand command);
}
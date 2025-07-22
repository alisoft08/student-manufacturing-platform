using FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.ACL;
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Aggregates;
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Commands;
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Repositories;
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Services;
using FIRST.StudentManufacturingPlatform.API.Shared.Domain.Repositories;

namespace FIRST.StudentManufacturingPlatform.API.Operations.Application.Internal.CommandServices;

/// <summary>
/// Implementation of the assignment command service for handling assignment operations.
/// This service manages the business logic for creating assignments between students and buses,
/// including validation of student existence, bus availability, and capacity constraints.
/// </summary>
public class AssignmentCommandService(IAssignmentRepository repository, IUnitOfWork unitOfWork, IBusesContextFacade facade, IStudentRepository studentRepository)
    : IAssignmentCommandService
{
    /// <summary>
    /// Handles the creation of a new assignment with comprehensive validation.
    /// Validates student existence, bus availability, capacity constraints, and sibling assignments.
    /// </summary>
    /// <param name="command">The create assignment command containing student and bus identifiers.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created assignment if all validations pass.</returns>
    /// <exception cref="Exception">Thrown when student doesn't exist, bus doesn't exist, bus capacity is exceeded, assignment already exists, or sibling validation fails.</exception>
    public async Task<Assignment?> Handle(CreateAssignmentCommand command)
    {
        // Validate that the student exists
        var student = await studentRepository.FindByIdAsync(command.studentId);
        
        if (student == null) throw new Exception("$Student with ID {command.studentId} not found.");
        
        // Validate that the bus exists
        var BusId = await facade.FetchBusByIdAsync(command.busId);

        if (BusId == 0) throw new Exception($"Bus with ID {command.busId} not found.");
        
        // Validate that the bus has not reached its maximum assignment capacity
        var busNumberOfSeats = await facade.FetchNumberOfSeatsByBusIdAsync(command.busId);
        
        var AmountByBusId = await repository.CountByBusIdAsync(command.busId);

        if (busNumberOfSeats < AmountByBusId) throw new Exception($"Bus with ID {command.busId} has already reached its maximum assignment capacity of {busNumberOfSeats} seats.");
        
        // Validate that the assignment does not already exist for the student
        if (await repository.ExistsByStudentIdAsync(command.studentId)) throw new Exception($"Assignment with Student ID {command.studentId} already exists.");
        
        // Validate if the parent of the student has another child
        var idParent = student.GetParentId();
        var studentSibling = await studentRepository.FindByParentIdAsync(idParent);
        
        if (studentSibling is not null)
        {
            // If the student has a sibling, check if they are already assigned to a bus
            
            var siblingAssignment = await repository.FindByStudentIdAsync(studentSibling.Id);
            
            if (siblingAssignment is not null)
            {
                // If student sibling assignment exists, check if they are assigned to a different bus

                var siblingBusId = siblingAssignment.GetBusId();
                if (siblingBusId != command.busId)
                {
                    throw new Exception($"Sibling with ID {studentSibling.Id} is already assigned to a different bus with ID {siblingBusId}. Siblings cannot be assigned to different buses.");
                }
            }

        }
        
        var Assignment = new Assignment(command);
        
        await repository.AddAsync(Assignment);
        await unitOfWork.CompleteAsync();

        return Assignment;
    }
}

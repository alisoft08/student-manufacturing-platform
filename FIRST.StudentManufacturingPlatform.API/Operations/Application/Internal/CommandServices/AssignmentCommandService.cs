using FIRST.StudentManufacturingPlatform.API.Assets.Interfaces.ACL;
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Aggregates;
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Commands;
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Repositories;
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Services;
using FIRST.StudentManufacturingPlatform.API.Shared.Domain.Repositories;

namespace FIRST.StudentManufacturingPlatform.API.Operations.Application.Internal.CommandServices;

/// <summary>
/// Handles the creation of Assignment entities, applying business validations and coordinating persistence.
/// </summary>
/// <remarks>
/// Alison Jimena Arrieta Quispe
/// </remarks>
public class AssignmentCommandService(IAssignmentRepository repository, IUnitOfWork unitOfWork, IBusesContextFacade facade, IStudentRepository studentRepository)
    : IAssignmentCommandService
{
    /// <summary>
    /// Processes a command to create a new Assignment. Validates uniqueness and existence of related Bus entity.
    /// </summary>
    /// <param name="command">The command containing data required to create a Assignment.</param>
    /// <returns>
    /// A task representing the asynchronous operation. Returns the created Assignment if successful; otherwise, throws exception.
    /// </returns>
    /// <exception cref="Exception">
    /// Thrown if the Assignment already exists for the given item Bus number, batch ID, and Bill of Materials ID,
    /// or if the related Bus is not found.
    /// </exception>
    /// <remarks>
    /// Alison Jimena Arrieta Quispe
    /// </remarks>
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
        
        // Validate that the parent of the student does not already have a student assigned in another bus          
        var idParent = student.GetParentId();

        var studentSibling = await studentRepository.FindByParentIdAsync(idParent);
        
        // If student sibling exists, check if they are assigned to a different bus
        if (studentSibling != null)
        {
            var siblingAssignment = await repository.FindByStudentIdAsync(studentSibling.Id);
            if (siblingAssignment != null)
            {
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

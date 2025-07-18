using eb4395u202312031.API.Shared.Domain.Repositories;
using eb4395u202312031.Assets.Interfaces.ACL;
using eb4395u202312031.Manufacturing.Domain.Model.Aggregates;
using eb4395u202312031.Manufacturing.Domain.Model.Commands;
using eb4395u202312031.Manufacturing.Domain.Repositories;
using eb4395u202312031.Manufacturing.Domain.Services;

namespace eb4395u202312031.Manufacturing.Application.Internal.CommandServices;

/// <summary>
/// Handles the creation of Assignment entities, applying business validations and coordinating persistence.
/// </summary>
/// <remarks>
/// Alison Jimena Arrieta Quispe
/// </remarks>
public class AssignmentCommandService(IAssignmentRepository repository, IUnitOfWork unitOfWork, IBusesContextFacade facade, IStudentRepository srepository)
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
        

        var student = await srepository.FindStudentByIdAsync(command.studentId);

        if (student == null)
        {
            throw new Exception("$Student with ID {command.studentId} not found.");
        }



        var BusId = await facade.FetchBusByIdAsync(command.busId);

        if (BusId == 0)
        {
            throw new Exception($"Bus with ID {command.busId} not found.");
        }
        
        
        var busNumberOfSeats = await facade.FetchNumberOfSeatsByBusIdAsync(command.busId);
        
        var cantByBusId = await repository.CountByBusIdAsync(command.busId);

        if (busNumberOfSeats < cantByBusId)
        {
            throw new Exception($"Bus with ID {command.busId} has already reached its maximum assignment capacity of {busNumberOfSeats} seats.");
        }
        
        
        
        

        if (await repository.ExistsByStudentIdAsync(command.studentId))
        {
            throw new Exception($"Assignment with Student ID {command.studentId} already exists.");
        }
        
        var idParent = student.GetParentId();
        
        
        if (await srepository.ExistsByParentIdAsync(idParent))
        {
            throw new Exception($"Parent with ID {idParent} already has a student assigned in another bus. Siblings cannot be assigned to different buses.");
        }
        
        
        

        var Assignment = new Assignment(command);
        
        await repository.AddAsync(Assignment);
        await unitOfWork.CompleteAsync();

        return Assignment;
    }
}

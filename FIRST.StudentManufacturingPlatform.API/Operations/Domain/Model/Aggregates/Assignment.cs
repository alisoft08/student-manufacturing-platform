using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Commands;
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Entities;

namespace FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Aggregates;


public partial class Assignment
{
   
    public int Id { get; }


    public int StudentId { get; set; }
    
    public int BusId { get; set; }
    
    public DateTime AssignedAt { get; set; } = DateTime.Now;
    
    public Assignment() { }
    public Assignment(int studentId, int busId)
    {
        StudentId = studentId;
        BusId = busId;
    }

    public Student Student { get; set; } 
    public Assignment(CreateAssignmentCommand command)
    {
        StudentId = command.studentId;
        BusId = command.busId;
    }
    /// <summary>
    /// Gets the bus identifier for the Assignment.
    /// </summary>
    /// <returns>The bus identifier.</returns>
    /// <remarks>
    /// Alison Jimena Arrieta Quispe
    /// </remarks>
    public int GetBusId()
    {
        return BusId;
    }
    
}

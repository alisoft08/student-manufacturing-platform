using System.ComponentModel.DataAnnotations.Schema;
using eb4395u202312031.Manufacturing.Domain.Model.Commands;
using eb4395u202312031.Operations.Domain.Model.Entities;


namespace eb4395u202312031.Manufacturing.Domain.Model.Aggregates;


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


    public Assignment(CreateAssignmentCommand command)
    {
        StudentId = command.studentId;
        BusId = command.busId;
    }
    
}

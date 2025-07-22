using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Commands;
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Entities;
namespace FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Aggregates;

/// <summary>
/// Represents an assignment between a student and a bus in the student manufacturing platform.
/// This aggregate manages the relationship and assignment details.
/// </summary>
/// <author>Alison Arrieta</author>
public partial class Assignment
{
    /// <summary>
    /// Gets the unique identifier for the assignment.
    /// </summary>
    /// <value>The assignment ID.</value>
    public int Id { get; }

    /// <summary>
    /// Gets or sets the student identifier associated with this assignment.
    /// </summary>
    /// <value>The student ID.</value>
    public int StudentId { get; set; }
    
    /// <summary>
    /// Gets or sets the bus identifier associated with this assignment.
    /// </summary>
    /// <value>The bus ID.</value>
    public int BusId { get; set; }
    
    /// <summary>
    /// Gets or sets the date and time when the assignment was created.
    /// </summary>
    /// <value>The assignment creation timestamp. Defaults to current date and time.</value>
    public DateTime AssignedAt { get; set; } = DateTime.Now;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Assignment"/> class with default values.
    /// </summary>
    /// <author>Alison Arrieta</author>
    public Assignment() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Assignment"/> class with the specified student and bus identifiers.
    /// </summary>
    /// <param name="studentId">The student identifier.</param>
    /// <param name="busId">The bus identifier.</param>
    /// <author>Alison Arrieta</author>
    public Assignment(int studentId, int busId)
    {
        StudentId = studentId;
        BusId = busId;
    }


    /// <summary>
    /// Initializes a new instance of the <see cref="Assignment"/> class using a create assignment command.
    /// </summary>
    /// <param name="command">The <see cref="CreateAssignmentCommand"/> containing the assignment data.</param>
    /// <author>Alison Arrieta</author>
    public Assignment(CreateAssignmentCommand command) : this(command.studentId, command.busId){}
  
    /// <summary>
    /// Gets the bus identifier associated with this assignment.
    /// </summary>
    /// <returns>The bus ID.</returns>
    /// <author>Alison Arrieta</author>
    public int GetBusId()
    {
        return BusId;
    }
}

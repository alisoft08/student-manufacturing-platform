namespace FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Entities;

/// <summary>
/// Represents a student entity in the student manufacturing platform.
/// This class contains the basic information and identifiers for a student.
/// </summary>
/// <author>Alison Arrieta</author>
public class Student
{
    /// <summary>
    /// Gets or sets the unique identifier for the student.
    /// </summary>
    /// <value>The student ID.</value>
    public int Id { get; internal set; }

    /// <summary>
    /// Gets or sets the first name of the student.
    /// </summary>
    /// <value>The student's first name.</value>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the student.
    /// </summary>
    /// <value>The student's last name.</value>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the district identifier where the student belongs.
    /// </summary>
    /// <value>The district ID.</value>
    public int DistrictId { get; set; }

    /// <summary>
    /// Gets or sets the parent identifier associated with this student.
    /// </summary>
    /// <value>The parent ID.</value>
    public int ParentId { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Student"/> class with default values.
    /// </summary>
    public Student() { }

    /// <summary>
    /// Gets the parent identifier associated with this student.
    /// </summary>
    /// <returns>The parent ID.</returns>
    public int GetParentId()
    {
        return ParentId;
    }
}
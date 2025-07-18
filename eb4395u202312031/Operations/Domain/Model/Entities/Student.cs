using System;

namespace eb4395u202312031.Operations.Domain.Model.Entities;

/// <summary>
/// Represents a student entity within the domain model.
/// </summary>
/// <remarks>
/// Alison Jimena Arrieta Quispe
/// </remarks>
public class Student
{
    /// <summary>
    /// Gets or sets the unique identifier for the student.
    /// </summary>
    public int Id { get; internal set; }

    /// <summary>
    /// Gets or sets the first name of the student.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the student.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the district identifier associated with the student.
    /// </summary>
    public int DistrictId { get; set; }

    /// <summary>
    /// Gets or sets the parent identifier associated with the student.
    /// </summary>
    public int ParentId { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Student"/> class.
    /// </summary>
    public Student() { }

    /// <summary>
    /// Gets the parent identifier for the student.
    /// </summary>
    /// <returns>The parent identifier.</returns>
    public int GetParentId()
    {
        return ParentId;
    }
}
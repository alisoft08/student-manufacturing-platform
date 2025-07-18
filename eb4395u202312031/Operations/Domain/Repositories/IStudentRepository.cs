using eb4395u202312031.API.Shared.Domain.Repositories;
using eb4395u202312031.Operations.Domain.Model.Entities;

namespace eb4395u202312031.Manufacturing.Domain.Repositories;

/// <summary>
/// Repository interface for managing Student entities.
/// </summary>
/// <remarks>
/// Alison Jimena Arrieta Quispe
/// </remarks>
public interface IStudentRepository : IBaseRepository<Student>
{
    /// <summary>
    /// Finds a student by their unique identifier.
    /// </summary>
    /// <param name="studentId">The unique identifier of the student.</param>
    /// <returns>The student entity if found; otherwise, null.</returns>
    Task<Student?> FindStudentById(int studentId);
    
    /// <summary>
    /// Finds all students who share the same parent identifier.
    /// </summary>
    /// <param name="parentId">The parent identifier to search siblings for.</param>
    /// <returns>A collection of students with the same parent identifier.</returns>
    Task<IEnumerable<Student>> FindSiblingsByParentIdAsync(int parentId);
}
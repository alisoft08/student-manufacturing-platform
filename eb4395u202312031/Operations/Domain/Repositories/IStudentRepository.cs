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
    /// <remarks>
    /// Alison Jimena Arrieta Quispe
    /// </remarks>
    
    Task<Student?> FindByParentIdAsync(int parentId);
}
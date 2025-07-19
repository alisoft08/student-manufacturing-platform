using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Entities;
using FIRST.StudentManufacturingPlatform.API.Shared.Domain.Repositories;

namespace FIRST.StudentManufacturingPlatform.API.Operations.Domain.Repositories;

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
    /// <author>
    /// Alison Jimena Arrieta Quispe
    /// </author>
    
    Task<Student?> FindByParentIdAsync(int parentId);
}
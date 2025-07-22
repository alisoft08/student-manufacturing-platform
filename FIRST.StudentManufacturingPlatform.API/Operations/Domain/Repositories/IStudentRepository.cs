using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Entities;
using FIRST.StudentManufacturingPlatform.API.Shared.Domain.Repositories;

namespace FIRST.StudentManufacturingPlatform.API.Operations.Domain.Repositories;

/// <summary>
/// Repository interface for managing student entities in the operations context.
/// Provides specific operations for student queries and persistence operations.
/// </summary>
/// <author>Alison Arrieta</author>
public interface IStudentRepository : IBaseRepository<Student>
{
    /// <summary>
    /// Finds a student by the specified parent identifier.
    /// </summary>
    /// <param name="parentId">The unique identifier of the parent to find the student for.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the student if found; otherwise, null.</returns>
    /// <author>Alison Arrieta</author>
    Task<Student?> FindByParentIdAsync(int parentId);
}
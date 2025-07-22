using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Aggregates;
using FIRST.StudentManufacturingPlatform.API.Shared.Domain.Repositories;

namespace FIRST.StudentManufacturingPlatform.API.Operations.Domain.Repositories;

/// <summary>
/// Repository interface for managing assignment entities in the operations context.
/// Provides specific operations for assignment queries and persistence operations.
/// </summary>
/// <author>Alison Arrieta</author>
public interface IAssignmentRepository : IBaseRepository<Assignment>
{
    /// <summary>
    /// Checks if an assignment exists for the specified student identifier.
    /// </summary>
    /// <param name="studentId">The unique identifier of the student to check.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains true if an assignment exists for the student; otherwise, false.</returns>
    /// <author>Alison Arrieta</author>
    Task<bool> ExistsByStudentIdAsync(int studentId);

    /// <summary>
    /// Counts the number of assignments associated with the specified bus identifier.
    /// </summary>
    /// <param name="busId">The unique identifier of the bus to count assignments for.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the number of assignments for the specified bus.</returns>
    /// <author>Alison Arrieta</author>
    Task<int> CountByBusIdAsync(int busId);
    
    /// <summary>
    /// Finds an assignment by the specified student identifier.
    /// </summary>
    /// <param name="studentId">The unique identifier of the student to find the assignment for.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the assignment if found; otherwise, null.</returns>
    /// <author>Alison Arrieta</author>
    Task<Assignment?> FindByStudentIdAsync(int studentId);

}
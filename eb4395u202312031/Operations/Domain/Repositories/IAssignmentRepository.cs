using eb4395u202312031.API.Shared.Domain.Repositories;
using eb4395u202312031.Manufacturing.Domain.Model.Aggregates;

namespace eb4395u202312031.Manufacturing.Domain.Repositories;

/// <summary>
/// Repository interface for Assignment aggregate, providing methods for assignment data access and validation.
/// </summary>
/// <remarks>
/// Alison Jimena Arrieta Quispe
/// </remarks>
public interface IAssignmentRepository : IBaseRepository<Assignment>
{
    /// <summary>
    /// Checks if an assignment exists for a given student ID.
    /// </summary>
    /// <param name="studentId">The student ID to check.</param>
    /// <returns>True if an assignment exists for the student; otherwise, false.</returns>
    /// <remarks>
    /// Alison Jimena Arrieta Quispe
    /// </remarks>
    Task<bool> ExistsByStudentIdAsync(int studentId);

    /// <summary>
    /// Counts the number of assignments for a given bus ID.
    /// </summary>
    /// <param name="busId">The bus ID to count assignments for.</param>
    /// <returns>The number of assignments for the bus.</returns>
    /// <remarks>
    /// Alison Jimena Arrieta Quispe
    /// </remarks>
    Task<int> CountByBusIdAsync(int busId);
    
    Task<Assignment?> FindByStudentIdAsync(int studentId);

}
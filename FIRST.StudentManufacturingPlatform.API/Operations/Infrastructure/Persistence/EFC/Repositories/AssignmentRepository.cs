using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Aggregates;
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Repositories;
using FIRST.StudentManufacturingPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FIRST.StudentManufacturingPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FIRST.StudentManufacturingPlatform.API.Operations.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Provides methods for accessing and managing Assignment entities in the database.
/// </summary>
/// <remarks>
/// Alison Jimena Arrieta Quispe
/// </remarks>
public class AssignmentRepository(AppDbContext context)
    : BaseRepository<Assignment>(context), IAssignmentRepository
{

  
    /// <summary>
    /// Checks if an assignment exists for the specified student identifier.
    /// </summary>
    /// <param name="studentId">The unique identifier of the student.</param>
    /// <returns>True if an assignment exists for the student; otherwise, false.</returns>
    public async Task<bool> ExistsByStudentIdAsync(int studentId)
    {
        return await Context.Set<Assignment>()
            .AnyAsync(Assignment =>
                Assignment.StudentId == studentId);
    }

    /// <summary>
    /// Counts the number of assignments for a specific bus identifier.
    /// </summary>
    /// <param name="busId">The unique identifier of the bus.</param>
    /// <returns>The number of assignments for the bus.</returns>
    public async Task<int> CountByBusIdAsync(int busId)
    {
        return await Context.Set<Assignment>()
            .CountAsync(a => a.BusId == busId);
    }

    public async Task<Assignment?> FindByStudentIdAsync(int studentId)
    {
        return await Context.Set<Assignment>()
            .FirstOrDefaultAsync(a => a.StudentId == studentId);
    }
}

using eb4395u202312031.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using eb4395u202312031.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using eb4395u202312031.Manufacturing.Domain.Model.Aggregates;
using eb4395u202312031.Manufacturing.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eb4395u202312031.Manufacturing.Infrastructure.Persistence.EFC.Repositories;

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

}

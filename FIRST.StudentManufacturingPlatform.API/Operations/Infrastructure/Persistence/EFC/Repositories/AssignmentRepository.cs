using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Aggregates;
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Repositories;
using FIRST.StudentManufacturingPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FIRST.StudentManufacturingPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FIRST.StudentManufacturingPlatform.API.Operations.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Provides methods for accessing and managing Assignment entities in the database.
/// </summary>
/// <author>
/// Alison Arrieta
/// </author>
public class AssignmentRepository(AppDbContext context)
    : BaseRepository<Assignment>(context), IAssignmentRepository
{
    
    /// <inheritdoc />
    public async Task<bool> ExistsByStudentIdAsync(int studentId)
    {
        return await Context.Set<Assignment>()
            .AnyAsync(Assignment =>
                Assignment.StudentId == studentId);
    }

   /// <inheritdoc />
    public async Task<int> CountByBusIdAsync(int busId)
    {
        return await Context.Set<Assignment>()
            .CountAsync(a => a.BusId == busId);
    }
   
    /// <inheritdoc />
    public async Task<Assignment?> FindByStudentIdAsync(int studentId)
    {
        return await Context.Set<Assignment>()
            .FirstOrDefaultAsync(a => a.StudentId == studentId);
    }
}

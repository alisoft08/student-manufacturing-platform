using eb4395u202312031.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using eb4395u202312031.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using eb4395u202312031.Manufacturing.Domain.Model.Aggregates;
using eb4395u202312031.Manufacturing.Domain.Repositories;
using eb4395u202312031.Operations.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace eb4395u202312031.Manufacturing.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Provides methods for accessing and managing Student entities in the database.
/// </summary>
/// <remarks>
/// Alison Jimena Arrieta Quispe
/// </remarks>
public class StudentRepository(AppDbContext context) : BaseRepository<Student>(context), IStudentRepository
{

    /// <summary>
    /// Finds a student by their unique identifier.
    /// </summary>
    /// <param name="studentId">The unique identifier of the student.</param>
    /// <returns>The student entity if found; otherwise, null.</returns>
   

    public async Task<Student?> FindStudentByIdAsync(int studentId)
    { 
        return await Context.Set<Student>().FirstOrDefaultAsync(sn => sn.Id == studentId);
    }
    

    public async Task<bool> ExistsByParentIdAsync(int parentId)
    {
        return await Context.Set<Student>()
            .AnyAsync(s =>
                s.ParentId == parentId);
    }
}
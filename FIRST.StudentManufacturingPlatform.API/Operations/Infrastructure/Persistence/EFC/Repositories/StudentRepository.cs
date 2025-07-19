using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Entities;
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Repositories;
using FIRST.StudentManufacturingPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FIRST.StudentManufacturingPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FIRST.StudentManufacturingPlatform.API.Operations.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Provides methods for accessing and managing Student entities in the database.
/// </summary>
/// <remarks>
/// Alison Jimena Arrieta Quispe
/// </remarks>
public class StudentRepository(AppDbContext context) : BaseRepository<Student>(context), IStudentRepository
{
    
    /// <inheritdoc />
    public async Task<Student?> FindByParentIdAsync(int parentId)
    {
        return await Context.Set<Student>().FirstOrDefaultAsync(sn => sn.ParentId == parentId);
    }
}
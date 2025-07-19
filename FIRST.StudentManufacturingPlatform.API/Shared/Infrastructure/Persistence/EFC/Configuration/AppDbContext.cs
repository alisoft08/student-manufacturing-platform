using FIRST.StudentManufacturingPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FIRST.StudentManufacturingPlatform.API.Assets.Infrastructure.Persistence.EFC.Configuration.Extensions;
using FIRST.StudentManufacturingPlatform.API.Operations.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FIRST.StudentManufacturingPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context
/// </summary>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyBusConfiguration();
        builder.ApplyAssignmentConfiguration();
        builder.ApplyStudentConfiguration();
        builder.UseSnakeCaseNamingConvention();

       
    }
}
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Aggregates;
using FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FIRST.StudentManufacturingPlatform.API.Operations.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
/// Extension methods for ModelBuilder to configure entity mappings for the operations context.
/// Contains configuration methods for Assignment and Student entities.
/// </summary>
/// <author>Alison Arrieta</author>
public static class ModelBuilderExtensions
{
    /// <summary>
    /// Applies configuration for the Assignment entity including primary key, required properties, and constraints.
    /// </summary>
    /// <param name="builder">The ModelBuilder instance to configure.</param>
    /// <author>Alison Arrieta</author>
    public static void ApplyAssignmentConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Assignment>().HasKey(t => t.Id);

        builder.Entity<Assignment>()
            .Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder.Entity<Assignment>()
            .Property(a => a.BusId)
            .IsRequired();
        
        builder.Entity<Assignment>()
            .Property(a => a.StudentId)
            .IsRequired();
        
        builder.Entity<Assignment>()
            .Property(a => a.AssignedAt)
            .IsRequired();
        
      
       
    }
    
    /// <summary>
    /// Applies configuration for the Student entity including primary key, required properties, and constraints.
    /// </summary>
    /// <param name="builder">The ModelBuilder instance to configure.</param>
    /// <author>Alison Arrieta</author>
    public static void ApplyStudentConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Student>().HasKey(t => t.Id);

        builder.Entity<Student>()
            .Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Entity<Student>()
            .Property(t => t.FirstName)
            .IsRequired();

        builder.Entity<Student>()
            .Property(t => t.LastName)
            .IsRequired();
        
        builder.Entity<Student>()
            .Property(t => t.DistrictId)
            .IsRequired();
        
        builder.Entity<Student>()
            .Property(t => t.ParentId)
            .IsRequired();
        
        builder.Entity<Student>().HasData(
            new Student { Id = 1, FirstName = "Emma", LastName = "Smith", DistrictId = 1, ParentId = 101 },
            new Student { Id = 2, FirstName = "Liam", LastName = "Smith", DistrictId = 1, ParentId = 101 },
            new Student { Id = 3, FirstName = "Olivia", LastName = "Johnson", DistrictId = 1, ParentId = 102 },
            new Student { Id = 4, FirstName = "Noah", LastName = "Johnson", DistrictId = 1, ParentId = 102 },
            new Student { Id = 5, FirstName = "Ava", LastName = "Wilson", DistrictId = 2, ParentId = 103 },
            new Student { Id = 6, FirstName = "James", LastName = "Wilson", DistrictId = 2, ParentId = 103 },
            new Student { Id = 7, FirstName = "Sophia", LastName = "Anderson", DistrictId = 2, ParentId = 104 },
            new Student { Id = 8, FirstName = "William", LastName = "Anderson", DistrictId = 2, ParentId = 104 },
            new Student { Id = 9, FirstName = "Isabella", LastName = "Jackson", DistrictId = 3, ParentId = 105 },
            new Student { Id = 10, FirstName = "Lucas", LastName = "Jackson", DistrictId = 3, ParentId = 105 }
        );
    }
}
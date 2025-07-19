using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace FIRST.StudentManufacturingPlatform.API.Operations.Domain.Model.Aggregates;

/// <summary>
/// Extends the Assignment aggregate with audit properties for tracking creation and update timestamps.
/// </summary>
/// <remarks>
/// Alison Jimena Arrieta Quispe
/// </remarks>
public partial class Assignment : IEntityWithCreatedUpdatedDate
{
    /// <summary>
    /// Gets or sets the timestamp when the entity was created.
    /// </summary>
    /// <remarks>
    /// Alison Jimena Arrieta Quispe
    /// </remarks>
    [Column("CreatedAt")]
    public DateTimeOffset? CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets the timestamp when the entity was last updated.
    /// </summary>
    /// <remarks>
    /// Alison Jimena Arrieta Quispe
    /// </remarks>
    [Column("UpdatedAt")]
    public DateTimeOffset? UpdatedDate { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace eb4395u202312031.Assets.Domain.Model.Aggregates;

/// <summary>
/// Adds audit trail properties to the Bus aggregate to track creation and update timestamps.
/// </summary>
public partial class Bus : IEntityWithCreatedUpdatedDate
{
    /// <summary>
    /// Gets or sets the date and time when the entity was created.
    /// </summary>
    [Column("CreatedAt")]
    public DateTimeOffset? CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was last updated.
    /// </summary>
    [Column("UpdatedAt")]
    public DateTimeOffset? UpdatedDate { get; set; }
}
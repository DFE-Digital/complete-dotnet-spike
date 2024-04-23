using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.Data
{
    public partial class CompleteContext : DbContext
    {
        public virtual DbSet<Entities.Note> Notes { get; set; }
    }
}

namespace Dfe.Complete.Data.Entities
{
public partial class Note
{
    public Guid Id { get; set; }

    public string Body { get; set; }

    public Guid? ProjectId { get; set; }

    public Guid? UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string TaskIdentifier { get; set; }

    public Guid? SignificantDateHistoryId { get; set; }

    public virtual Project Project { get; set; }

    public virtual User User { get; set; }
}
}
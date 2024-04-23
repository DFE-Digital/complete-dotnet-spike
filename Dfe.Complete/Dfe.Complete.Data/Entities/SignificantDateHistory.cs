using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.SignificantDateHistory> SignificantDateHistories { get; set; }
    }
}

namespace Dfe.Complete.Data.Entities
{
public partial class SignificantDateHistory
{
    public Guid Id { get; set; }

    public DateTime? RevisedDate { get; set; }

    public DateTime? PreviousDate { get; set; }

    public Guid? ProjectId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
}
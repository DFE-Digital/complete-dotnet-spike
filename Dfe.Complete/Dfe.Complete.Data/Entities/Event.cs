using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.Data
{
    public partial class CompleteContext : DbContext
    {
        public virtual DbSet<Entities.Event> Events { get; set; }
    }
}

namespace Dfe.Complete.Data.Entities
{
public partial class Event
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string EventableType { get; set; }

    public Guid? EventableId { get; set; }

    public int? Grouping { get; set; }

    public string Message { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
}
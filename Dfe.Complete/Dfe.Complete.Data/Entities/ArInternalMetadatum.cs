using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.ArInternalMetadatum> ArInternalMetadata { get; set; }
    }
}

namespace Dfe.Complete.Data.Entities
{
public partial class ArInternalMetadatum
{
    public string Key { get; set; }

    public string Value { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
}
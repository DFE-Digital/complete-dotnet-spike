using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.SchemaMigration> SchemaMigrations { get; set; }
    }
}

namespace Dfe.Complete.Data.Entities
{
public partial class SchemaMigration
{
    public string Version { get; set; }
}
}
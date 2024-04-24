using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.Data
{
    public partial class CompleteContext : DbContext
    {
        public virtual DbSet<Entities.LocalAuthority> LocalAuthorities { get; set; }
    }
}

namespace Dfe.Complete.Data.Entities
{
public partial class LocalAuthority
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Code { get; set; }

    public string Address1 { get; set; }

    public string Address2 { get; set; }

    public string Address3 { get; set; }

    public string AddressTown { get; set; }

    public string AddressCounty { get; set; }

    public string AddressPostcode { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
}
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.GiasGroup> GiasGroups { get; set; }
    }
}

namespace Dfe.Complete.Data.Entities
{
public partial class GiasGroup
{
    public Guid Id { get; set; }

    public int? Ukprn { get; set; }

    public int? UniqueGroupIdentifier { get; set; }

    public string GroupIdentifier { get; set; }

    public string OriginalName { get; set; }

    public string CompaniesHouseNumber { get; set; }

    public string AddressStreet { get; set; }

    public string AddressLocality { get; set; }

    public string AddressAdditional { get; set; }

    public string AddressTown { get; set; }

    public string AddressCounty { get; set; }

    public string AddressPostcode { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
}
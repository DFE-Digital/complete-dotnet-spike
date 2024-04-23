using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.Data
{
    public partial class CompleteContext : DbContext
    {
        public virtual DbSet<Entities.GiasEstablishment> GiasEstablishments { get; set; }
    }
}

namespace Dfe.Complete.Data.Entities
{
public partial class GiasEstablishment
{
    public Guid Id { get; set; }

    public int? Urn { get; set; }

    public int? Ukprn { get; set; }

    public string Name { get; set; }

    public string EstablishmentNumber { get; set; }

    public string LocalAuthorityName { get; set; }

    public string LocalAuthorityCode { get; set; }

    public string RegionName { get; set; }

    public string RegionCode { get; set; }

    public string TypeName { get; set; }

    public string TypeCode { get; set; }

    public int? AgeRangeLower { get; set; }

    public int? AgeRangeUpper { get; set; }

    public string PhaseName { get; set; }

    public string PhaseCode { get; set; }

    public string DioceseName { get; set; }

    public string DioceseCode { get; set; }

    public string ParliamentaryConstituencyName { get; set; }

    public string ParliamentaryConstituencyCode { get; set; }

    public string AddressStreet { get; set; }

    public string AddressLocality { get; set; }

    public string AddressAdditional { get; set; }

    public string AddressTown { get; set; }

    public string AddressCounty { get; set; }

    public string AddressPostcode { get; set; }

    public string Url { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
}
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.Data
{
    public partial class CompleteContext : DbContext
    {
        public virtual DbSet<Entities.Contact> Contacts { get; set; }
    }
}

namespace Dfe.Complete.Data.Entities
{
public partial class Contact
{
    public Guid Id { get; set; }

    public Guid? ProjectId { get; set; }

    public string Name { get; set; }

    public string Title { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int Category { get; set; }

    public string OrganisationName { get; set; }

    public string Type { get; set; }

    public Guid? LocalAuthorityId { get; set; }

    public int? EstablishmentUrn { get; set; }

    public virtual Project Project { get; set; }
}
}
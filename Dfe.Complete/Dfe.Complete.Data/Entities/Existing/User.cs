using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.Data
{
    public partial class CompleteContext : DbContext
    {
        public virtual DbSet<Entities.User> Users { get; set; }
    }
}

namespace Dfe.Complete.Data.Entities
{
public partial class User
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool? ManageTeam { get; set; }

    public bool AddNewProject { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string ActiveDirectoryUserId { get; set; }

    public bool? AssignToProject { get; set; }

    public bool? ManageUserAccounts { get; set; }

    public string ActiveDirectoryUserGroupIds { get; set; }

    public string Team { get; set; }

    public DateTime? DeactivatedAt { get; set; }

    public bool? ManageConversionUrns { get; set; }

    public bool? ManageLocalAuthorities { get; set; }

    public DateTime? LatestSession { get; set; }

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual ICollection<Project> ProjectAssignedTos { get; set; } = new List<Project>();

    public virtual ICollection<Project> ProjectCaseworkers { get; set; } = new List<Project>();

    public virtual ICollection<Project> ProjectRegionalDeliveryOfficers { get; set; } = new List<Project>();

    public virtual ICollection<Project> ProjectTeamLeaders { get; set; } = new List<Project>();
}
}
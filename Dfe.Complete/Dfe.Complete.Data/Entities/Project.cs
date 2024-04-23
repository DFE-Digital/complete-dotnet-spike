using System;
using System.Collections.Generic;
using Dfe.Complete.API.Contracts.Project;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.Data
{
    public partial class CompleteContext : DbContext
    {
        public virtual DbSet<Entities.Project> Projects { get; set; }
    }
}

namespace Dfe.Complete.Data.Entities
{
public partial class Project
{
    public Guid Id { get; set; }

    public int Urn { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? TeamLeaderId { get; set; }

    public int? IncomingTrustUkprn { get; set; }

    public Guid? RegionalDeliveryOfficerId { get; set; }

    public Guid? CaseworkerId { get; set; }

    public DateTime? AssignedAt { get; set; }

    public DateTime? AdvisoryBoardDate { get; set; }

    public string AdvisoryBoardConditions { get; set; }

    public string EstablishmentSharepointLink { get; set; }

    public DateTime? CompletedAt { get; set; }

    public string IncomingTrustSharepointLink { get; set; }

    public ProjectType? Type { get; set; }

    public Guid? AssignedToId { get; set; }

    public DateTime? SignificantDate { get; set; }

    public bool? SignificantDateProvisional { get; set; }

    public bool? DirectiveAcademyOrder { get; set; }

    public string Region { get; set; }

    public int? AcademyUrn { get; set; }

    public Guid? TasksDataId { get; set; }

    public string TasksDataType { get; set; }

    public Guid? FundingAgreementContactId { get; set; }

    public int? OutgoingTrustUkprn { get; set; }

    public string Team { get; set; }

    public bool? TwoRequiresImprovement { get; set; }

    public string OutgoingTrustSharepointLink { get; set; }

    public bool? AllConditionsMet { get; set; }

    public Guid? MainContactId { get; set; }

    public Guid? EstablishmentMainContactId { get; set; }

    public Guid? IncomingTrustMainContactId { get; set; }

    public Guid? OutgoingTrustMainContactId { get; set; }

    public string NewTrustReferenceNumber { get; set; }

    public string NewTrustName { get; set; }

    public Guid? ChairOfGovernorsContactId { get; set; }

    public int State { get; set; }

    public virtual User AssignedTo { get; set; }

    public virtual User Caseworker { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual User RegionalDeliveryOfficer { get; set; }

    public virtual User TeamLeader { get; set; }
}
}
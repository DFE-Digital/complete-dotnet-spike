using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.Wfa> Wfa { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Wfa
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string WorksFundingAgreementsWfaId { get; set; }

        public DateTime? WorksFundingAgreementsWorkFundingAgreementIssuedDate { get; set; }

        public string WorksFundingAgreementsWorkFundingAgreementTotalValue { get; set; }
    }
}
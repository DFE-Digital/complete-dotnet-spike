using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.Pdgl> Pdgl { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Pdgl
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string ProjectDeliveryGrantLetterPdglId { get; set; }

        public DateTime? ProjectDeliveryGrantLetterProjectDeliveryGrantLetterIssuedDate { get; set; }

        public string ProjectDeliveryGrantLetterProjectDeliveryGrantLetterTotalValue { get; set; }
    }
}
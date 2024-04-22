using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.Porf> Porf { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Porf
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string PurchaseOrderRequestFormPorfId { get; set; }

        public DateTime? PurchaseOrderRequestFormPurchaseOrderCreatedDate { get; set; }

        public string PurchaseOrderRequestFormPurchaseOrderNumber { get; set; }

        public string PurchaseOrderRequestFormPurchaseOrderRequestFormVendor { get; set; }

        public string PurchaseOrderRequestFormPorfGlCode { get; set; }

        public string PurchaseOrderRequestFormPurchaseOrderRequestFormTotalValueExclVat { get; set; }

        public string PurchaseOrderRequestFormPurchaseOrderRequestFormVat { get; set; }
    }
}
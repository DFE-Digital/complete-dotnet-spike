using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.TechnicalQa> TechnicalQa { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class TechnicalQa
    {
        public string Month { get; set; }

        public int Gifa { get; set; }

        public int TypeOfWork { get; set; }

        public int ContractBudgetValue { get; set; }

        public int ContractingParty { get; set; }

        public int Bim { get; set; }

        public int DeliveryParty { get; set; }

        public int FeasibiltyReportStartDate { get; set; }

        public int FeasibilityReportApproved { get; set; }

        public int ContractProcurementStatus { get; set; }

        public int ProcurementStartActual { get; set; }

        public int ProcurementRoute { get; set; }

        public int Contractor { get; set; }

        public int ContractAwardValue { get; set; }

        public int EnterIntoMainContractActual { get; set; }

        public int FinalContractValue { get; set; }

        public int PcCertificateIssuedActual { get; set; }

        public int ComgdIssued { get; set; }
    }
}
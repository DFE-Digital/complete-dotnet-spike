using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.PropertyQa> PropertyQa { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class PropertyQa
    {
        public string Month { get; set; }

        public int LocatEdDelivery { get; set; }

        public int LocatEdCommissionReference { get; set; }

        public int HeadOfRegion { get; set; }

        public int ProjectDirector { get; set; }

        public int EsfaCapitalProjectManager { get; set; }

        public int EsfaRegionalPropertyLead { get; set; }

        public int EsfaPropertyLead { get; set; }

        public int LocatEdAcquisitionManager { get; set; }

        public int LegalManager { get; set; }

        public int NameOfSite { get; set; }

        public int AddressOfSite { get; set; }

        public int PostcodeOfSite { get; set; }

        public int TenureHighlight { get; set; }

        public int PleaseStateReasonIfMoreThanOneTenureTypeSelected { get; set; }

        public int SiteIdentifiedForecast { get; set; }

        public int SiteIdentifiedActual { get; set; }

        public int DateOfHeadsOfTermsAgreedForecast { get; set; }

        public int DateOfHeadsOfTermsAgreedActual { get; set; }

        public int DateOfExchangeForecast { get; set; }

        public int DateOfExchangeActual { get; set; }

        public int DateOfCompletionForecast { get; set; }
    }
}
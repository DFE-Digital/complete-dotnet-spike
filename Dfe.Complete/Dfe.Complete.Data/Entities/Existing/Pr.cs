using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.Pr> Pr { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Pr
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string PreregistrationReferenceNumber { get; set; }

        public DateTime? PreregistrationDateSubmitted { get; set; }

        public string PreregistrationWhichWaveDoYouIntendToApplyFor { get; set; }

        public string PreregistrationTrustId { get; set; }

        public string PreregistrationTrustName { get; set; }

        public string PreregistrationStaticLinkToTrustPageOnKim { get; set; }

        public string PreregistrationLeadSponsorId { get; set; }

        public string PreregistrationLeadSponsorName { get; set; }

        public string PreregistrationProposedTrustName { get; set; }

        public string PreregistrationIsThisAReApplicationIEAnApplicationThatWasPreviouslyUnsuccessful { get; set; }

        public string PreregistrationTypeOfGroup { get; set; }

        public string PreregistrationTypeOfGroupOther { get; set; }

        public string PreregistrationDoYouAlreadyRunOneOrMoreFreeSchoolsAcademiesOrHaveAnyInThePipeline { get; set; }

        public string PreregistrationHowManyFreeSchoolsAreYouApplyingForInThisWave { get; set; }

        public string PreregistrationNameOfLeadApplicant { get; set; }

        public string PreregistrationTelephoneNumberOfLeadApplicant { get; set; }

        public string PreregistrationEmailOfLeadApplicant { get; set; }

        public string PreregistrationNameOfPersonSubmittingFormIfNotLeadApplicant { get; set; }

        public string PreregistrationTelephoneOfPersonSubmittingFormIfNotLeadApplicant { get; set; }

        public string PreregistrationEmailOfPersonSubmittingFormIfNotLeadApplicant { get; set; }

        public DateTime? PreregistrationDateOfLastContactWithApplicant { get; set; }

        public string PreregistrationContactNotes { get; set; }
    }
}
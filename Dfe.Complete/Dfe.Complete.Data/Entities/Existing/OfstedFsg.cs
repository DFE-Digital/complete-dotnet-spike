using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.OfstedFsg> OfstedFsg { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class OfstedFsg : IAuditable
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string EducationalEstablishmentUrn { get; set; }

        public string ProjectUrn { get; set; }

        public string EducationalEstablishmentSchoolName { get; set; }

        public string EducationalEstablishmentLaestab { get; set; }

        public string EducationalEstablishmentLocalAuthority { get; set; }

        public string LocalAuthority { get; set; }

        public string EducationalEstablishmentRegion { get; set; }

        public string EducationalEstablishmentRscRegion { get; set; }

        public string EducationalEstablishmentConstituency { get; set; }

        public string EducationalEstablishmentStatus { get; set; }

        public string EducationalEstablishmentSchoolPhase { get; set; }

        public string Phase { get; set; }

        public string EducationalEstablishmentSchoolType { get; set; }

        public DateTime? EducationalEstablishmentOpenDate { get; set; }

        public DateTime? EducationalEstablishmentDateClosed { get; set; }

        public string EducationalEstablishmentAddressPostcode { get; set; }

        public string EducationalEstablishmentDistrict { get; set; }

        public DateTime? OfstedDataOfstedSection5InspectionDate { get; set; }

        public DateTime? OfstedDataOfstedSection5InspectionDateL { get; set; }

        public string OfstedDataOfstedSection5OverallEffectiveness { get; set; }

        public string OfstedDataOfstedSection5OverallEffectivenessL { get; set; }

        public string OfstedDataOfstedSection5CategoryOfConcern { get; set; }

        public string OfstedDataOfstedSection5CategoryOfConcernL { get; set; }

        public DateTime? OfstedDataOfstedSection5DateInCategory4 { get; set; }

        public DateTime? OfstedDataOfstedSection5DateInCategory4L { get; set; }

        public DateTime? OfstedDataOfstedSection5DateOutOfCategory4 { get; set; }

        public DateTime? OfstedDataOfstedSection5DateOutOfCategory4L { get; set; }

        public DateTime? OfstedDataModerationDate { get; set; }

        public DateTime? OfstedDataModerationDateL { get; set; }

        public string OfstedDataNumberOfMonthsInCategory4 { get; set; }

        public string OfstedDataNumberOfMonthsInCategory4L { get; set; }

        public string OfstedDataOfstedSection5SixthFormProvision { get; set; }

        public string OfstedDataOfstedSection5OutcomesForChildrenAndLearners { get; set; }

        public string OfstedDataOfstedSection5QualityOfTeachingLearningAndAssessment { get; set; }

        public string OfstedDataOfstedSection5PersonalDevelopmentBehaviourAndWelfare { get; set; }

        public string OfstedDataOfstedSection5EffectivenessLeadershipAndManagement { get; set; }

        public DateTime? OfstedDataPreviousOfstedSection5InspectionDate { get; set; }

        public DateTime? OfstedDataPreviousOfstedSection5InspectionDateL { get; set; }

        public string OfstedDataPreviousOfstedSection5OverallEffectiveness { get; set; }

        public string OfstedDataPreviousOfstedSection5OverallEffectivenessL { get; set; }

        public DateTime? OfstedDataOfstedSection8InspectionDate { get; set; }

        public string OfstedDataOfstedSection8Judgement { get; set; }
    }
}
using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Common;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.Milestones> Milestones { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Milestones : IAuditable
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string FsgPreOpeningMilestonesViewCostPlan1 { get; set; }

        public string FsgPreOpeningMilestonesViewCostPlan2 { get; set; }

        public string FsgPreOpeningMilestonesDetailsOfFundingArrangementAgreedBetweenLaAndSponsor { get; set; }

        public DateTime? FsgPreOpeningMilestonesKickOffMeetingHeldActualDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesSiteKickOffMeetingHeldActualDate { get; set; }

        public string FsgPreOpeningMilestonesHaveYouCompletedAndSavedYourRiskAppraisalForm { get; set; }

        public string FsgPreOpeningMilestonesLinkToRiskAppraisalForm { get; set; }

        public string FsgPreOpeningMilestonesIsThisProjectRatedHighOrLowRiskForEducation { get; set; }

        public string FsgPreOpeningMilestonesIsThisProjectRatedHighOrLowRiskForGovernance { get; set; }

        public string FsgPreOpeningMilestonesIsThisProjectRatedHighOrLowRiskForFinance { get; set; }

        public DateTime? FsgPreOpeningMilestonesSapBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesSapForecastDate { get; set; }
                
        public DateTime? FsgPreOpeningMilestonesSapActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi54CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi105LinkToSavedDocument { get; set; }

        public DateTime? FsgPreOpeningMilestonesMaaBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesMaaForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesMaaActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi56CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi107LinkToSavedDocument { get; set; }

        public DateTime? FsgPreOpeningMilestonesMfadBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesMfadForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesMfadActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi58CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi109LinkToSavedDocument { get; set; }

        public DateTime? FsgPreOpeningMilestonesDgpBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesDgpForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesDgpActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi60CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi111LinkToSavedDocument { get; set; }

        public DateTime? FsgPreOpeningMilestonesCoGappBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesCoGappForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesCoGappActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi62CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi113LinkToSavedDocument { get; set; }

        public DateTime? FsgPreOpeningMilestonesPdappBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesPdappForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesPdappActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi64CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi115LinkToSavedDocument { get; set; }

        public DateTime? FsgPreOpeningMilestonesS9lBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesS9lForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesS9lActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi66CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi117LinkToSavedDocument { get; set; }

        public DateTime? FsgPreOpeningMilestonesEdBrBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesEdBrForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesEdBrActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi68CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi119LinkToSavedDocument { get; set; }

        public string FsgPreOpeningMilestonesAppEvApplicable { get; set; }

        public string FsgPreOpeningMilestonesAppEvReasonNotApplicable { get; set; }

        public DateTime? FsgPreOpeningMilestonesAppEvBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesAppEvForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesAppEvActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi70CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi121LinkToSavedDocument { get; set; }

        public string FsgPreOpeningMilestonesBefpApplicable { get; set; }

        public string FsgPreOpeningMilestonesBefpReasonNotApplicable { get; set; }

        public DateTime? FsgPreOpeningMilestonesBefpBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesBefpForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesBefpActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi72CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi123LinkToSavedDocument { get; set; }

        public DateTime? FsgPreOpeningMilestonesFgpaBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesFgpaForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesFgpaActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi74CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi125LinkToSavedDocument { get; set; }

        public string FsgPreOpeningMilestonesPfacmMilestoneApplicable { get; set; }

        public string FsgPreOpeningMilestonesPfacmReasonNotApplicable { get; set; }

        public DateTime? FsgPreOpeningMilestonesPfacmBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesPfacmForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesPfacmActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi76CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi127LinkToSavedDocument { get; set; }

        public DateTime? FsgPreOpeningMilestonesSccBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesSccForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesSccActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi78CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi129LinkToSavedDocument { get; set; }

        public DateTime? FsgPreOpeningMilestonesScrBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesScrForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesScrActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi80CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi131LinkToSavedDocument { get; set; }

        public DateTime? FsgPreOpeningMilestonesDbsiBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesDbsiForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesDbsiActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi81CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi133LinkToSavedDocument { get; set; }

        public DateTime? FsgPreOpeningMilestonesIaeaBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesIaeaForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesIaeaActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi83CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi135LinkToSavedDocument { get; set; }

        public DateTime? FsgPreOpeningMilestonesEapolBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesEapolForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesEapolActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi85CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi137LinkToSavedDocument { get; set; }

        public DateTime? FsgPreOpeningMilestonesFsrdBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesFsrdForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesFsrdActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi87CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi139LinkToSavedDocument { get; set; }

        public DateTime? FsgPreOpeningMilestonesFaBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesFaForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesFaActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi89CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi141LinkToSavedDocument { get; set; }

        public string FsgPreOpeningMilestonesEaoMilestoneApplicable { get; set; }

        public string FsgPreOpeningMilestonesEaoReasonNotApplicable { get; set; }

        public DateTime? FsgPreOpeningMilestonesEaoBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesEaoForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesEaoActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi91CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi143LinkToSavedDocument { get; set; }

        public DateTime? FsgPreOpeningMilestonesFcpBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesFcpForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesFcpActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi93CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi145LinkToSavedDocument { get; set; }

        public DateTime? FsgPreOpeningMilestonesOprBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesOprForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesOprActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesOutcomeOfInspectionAsAdvisedByOfsted { get; set; }

        public string FsgPreOpeningMilestonesInspectionConditionsMet { get; set; }

        public string FsgPreOpeningMilestonesMi95CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi147LinkToSavedDocument { get; set; }

        public DateTime? FsgPreOpeningMilestonesRomBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesRomForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesRomActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesOutcomeOfRom { get; set; }

        public string FsgPreOpeningMilestonesRomConditionsMet { get; set; }

        public string FsgPreOpeningMilestonesMi97CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi149LinkToSavedDocument { get; set; }

        public string FsgPreOpeningMilestonesRomReasonNotApplicable { get; set; }

        public DateTime? FsgPreOpeningMilestonesFpaBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesFpaForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesFpaActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi99CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi151LinkToSavedDocument { get; set; }

        public DateTime? FsgPreOpeningMilestonesDbscBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesDbscForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesDbscActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi101CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi153LinkToSavedDocument { get; set; }

        public DateTime? FsgPreOpeningMilestonesGiasBaselineDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesGiasForecastDate { get; set; }

        public DateTime? FsgPreOpeningMilestonesGiasActualDateOfCompletion { get; set; }

        public string FsgPreOpeningMilestonesMi103CommentsOnDecisionToApproveIfApplicable { get; set; }

        public string FsgPreOpeningMilestonesMi155LinkToSavedDocument { get; set; }
    }
}
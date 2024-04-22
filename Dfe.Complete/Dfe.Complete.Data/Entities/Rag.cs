using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Rag
    {
        public string RagRatingsGovernanceAndSuitabilityRagSummary { get; set; }
        public string RagRatingsEducationRagSummary { get; set; }
        public string RagRatingsRiskAppraisalFormSharepointLink { get; set; }
        public Guid RevisionMarker { get; set; }

    }
}

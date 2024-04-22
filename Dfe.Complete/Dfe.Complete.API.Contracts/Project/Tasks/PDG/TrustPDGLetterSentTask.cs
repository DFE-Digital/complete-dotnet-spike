using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks.PDG
{
    public class TrustPDGLetterSentTask
    {
        public DateTime? TrustSignedPDGLetterDate { get; set; }
        public bool? PDGLetterSavedInWorkspaces { get; set; }
    }
}

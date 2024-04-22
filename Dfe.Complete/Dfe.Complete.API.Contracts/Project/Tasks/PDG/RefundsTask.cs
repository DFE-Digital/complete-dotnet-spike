using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks.PDG
{
    public class RefundsTask
    {
        public DateTime? LatestRefundDate { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}

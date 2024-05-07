using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Contracts.Project.Transfer.Tasks
{
    public class GetTransferProjectByTaskSummaryResponse
    {
        public TaskSummaryResponse HandoverWithDeliveryOfficer { get; set; } = new();
    }
}

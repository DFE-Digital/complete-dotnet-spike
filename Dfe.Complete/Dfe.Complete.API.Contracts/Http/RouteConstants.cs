using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Contracts.Http
{
    public class RouteConstants
    {
        public const string ProjectList = "api/v1/client/projects/list";

        // Transfer
        public const string TransferProject = "api/v1/client/transfer-projects";
        public const string TransferProjectTask = TransferProject + "/{0}/tasks";
        public const string TransferProjectTaskSummary = TransferProjectTask + "/summary";
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dfe.Complete.API.Contracts.Project.Tasks;

namespace Dfe.Complete.API.Contracts.Project.Conversion.Tasks
{
    public class GetConversionProjectByTaskSummaryResponse
    {
        public TaskSummaryResponse HandoverWithDeliveryOfficer { get; set; } = new();
    }
}

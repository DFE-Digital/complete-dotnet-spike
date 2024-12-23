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
        public ProjectDetails ProjectDetails { get; set; }
        public TaskSummaryResponse HandoverWithDeliveryOfficer { get; set; } = new();

        public TaskSummaryResponse StakeholderKickoff { get; set; } = new();
        public TaskSummaryResponse LandQuestionnaire { get; set; } = new();
        public TaskSummaryResponse LandRegistry { get; set; } = new();
        public TaskSummaryResponse SupplementalFundingAgreement { get; set; } = new();
    }
}

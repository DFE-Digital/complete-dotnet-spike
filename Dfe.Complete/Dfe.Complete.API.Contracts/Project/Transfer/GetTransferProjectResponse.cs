﻿namespace Dfe.Complete.API.Contracts.Project.Transfer
{
    public record GetTransferProjectResponse
    {
        public ProjectDetails ProjectDetails { get; set; }

        public ReasonForTheTransfer ReasonForTheTransfer { get; set; }

        public AdvisoryBoardDetails AdvisoryBoardDetails { get; set; }

        public SchoolDetails SchoolDetails { get; set; }

        public TrustDetails IncomingTrustDetails { get; set; }

        public TrustDetails OutgoingTrustDetails { get; set; }
    }

    public record ReasonForTheTransfer
    {
        public bool? IsDueTo2RI { get; set; }

        public bool? IsDueToOfstedRating { get; set; }

        public bool? IsDueToIssues { get; set; }
    }
}

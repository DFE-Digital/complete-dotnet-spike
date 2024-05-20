namespace Dfe.Complete.API.Contracts.Project.Transfer
{
    public record ReasonForTheTransfer
    {
        public bool? IsDueTo2RI { get; set; }

        public bool? IsDueToOfstedRating { get; set; }

        public bool? IsDueToIssues { get; set; }
    }
}

namespace Dfe.Complete.API.Contracts.Project.Transfer
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

    public record class AdvisoryBoardDetails
    {
        public DateTime? Date { get; set; }

        public string Conditions { get; set; }
    }

    public record SchoolDetails
    {
        public string Name { get; set; }

        public string Urn { get; set; }

        public string Type { get; set; }

        public string LowerAge { get; set; }

        public string UpperAge { get; set; }

        public string AgeRange
        {
            get 
            {
                if (string.IsNullOrEmpty(LowerAge) || string.IsNullOrEmpty(UpperAge))
                {
                    return string.Empty;
                }

                return $"{LowerAge} to {UpperAge}";
            }
        }

        public string Phase { get; set; }

        public Address Address { get; set; } = new();

        public string Diocese { get; set; }

        public string SharePointLink { get; set; }
    }

    public record TrustDetails
    {
        public string Name { get; set; }

        public string UkPrn { get; set; }

        public string GroupId { get; set; }

        public string CompaniesHouseNumber { get; set; }

        public Address Address { get; set; } = new();

        public string SharePointLink { get; set; }
    }

    public record Address
    {
        public string Street { get; set; }
        public string Locality { get; set; }
        public string Additional { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }

        public string[] ToArray()
        {
            var lines = new string[] { Street, Locality, Additional, Town, County, Postcode };

            var result = lines.Where(line => !string.IsNullOrEmpty(line)).ToArray();

            return result;
        }
    }
}

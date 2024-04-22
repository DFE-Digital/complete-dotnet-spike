namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.PupilNumbers
{
    public record GetPupilNumbersResponse
    {
        public string SchoolName { get; set; }
        public CapacityWhenFullResponse CapacityWhenFull { get; set; } = new();
        public RecruitmentAndViabilityResponse RecruitmentAndViability { get; set; } = new();
        public Pre16PublishedAdmissionNumberResponse Pre16PublishedAdmissionNumber { get; set; } = new();
        public Post16PublishedAdmissionNumberResponse Post16PublishedAdmissionNumber { get; set; } = new();
        public Pre16CapacityBuildup Pre16CapacityBuildup { get; set; } = new();
        public Post16CapacityBuildup Post16CapacityBuildup { get; set; } = new();
    }

    public record CapacityWhenFullResponse : CapacityWhenFull
    {
        public int Total { get; set; }
    }

    public record CapacityWhenFull
    {
        public int Nursery { get; set; }
        public int ReceptionToYear6 { get; set; }
        public int Year7ToYear11 { get; set; }
        public int Year12ToYear14 { get; set; }
        public int SpecialEducationNeeds { get; set; }
        public int AlternativeProvision { get; set; }
    }

    public record RecruitmentAndViabilityResponse
    {
        public RecruitmentAndViabilityEntryWithPercentage ReceptionToYear6 { get; set; } = new();
        public RecruitmentAndViabilityEntryWithPercentage Year7ToYear11 { get; set; } = new();
        public RecruitmentAndViabilityEntryWithPercentage Year12ToYear14 { get; set; } = new();
        public RecruitmentAndViabilityEntry Total { get; set; } = new();
    }

    public record RecruitmentAndViability
    {
        public RecruitmentAndViabilityEntry ReceptionToYear6 { get; set; } = new();
        public RecruitmentAndViabilityEntry Year7ToYear11 { get; set; } = new();
        public RecruitmentAndViabilityEntry Year12ToYear14 { get; set; } = new();
    }

    public record RecruitmentAndViabilityEntry
    {
        public int MinimumViableNumber { get; set; }
        public int ApplicationsReceived { get; set; }
    }

    public record RecruitmentAndViabilityEntryWithPercentage : RecruitmentAndViabilityEntry
    {
        public decimal PercentageComparedToMinimumViable { get; set; }
        public decimal PercentageComparedToPublishedAdmissionNumber { get; set; }
    }

    public record Pre16PublishedAdmissionNumberResponse : Pre16PublishedAdmissionNumber
    {
        public int Total { get; set; }
    }

    public record Pre16PublishedAdmissionNumber
    {
        public int Reception { get; set; }
        public int Year7 { get; set; }
        public int Year10 { get; set; }
        public int OtherPre16 { get; set; }
    }

    public record Post16PublishedAdmissionNumberResponse : Post16PublishedAdmissionNumber
    {
        public int Total { get; set; }
    }

    public record Post16PublishedAdmissionNumber
    {
        public int Year12 { get; set; }
        public int OtherPost16 { get; set; }
    }

    public record Pre16CapacityBuildup
    {
        public CapacityBuildupEntry Nursery { get; set; } = new();
        public CapacityBuildupEntry Reception { get; set; } = new();
        public CapacityBuildupEntry Year1 { get; set; } = new();
        public CapacityBuildupEntry Year2 { get; set; } = new();
        public CapacityBuildupEntry Year3 { get; set; } = new();
        public CapacityBuildupEntry Year4 { get; set; } = new();
        public CapacityBuildupEntry Year5 { get; set; } = new();
        public CapacityBuildupEntry Year6 { get; set; } = new();
        public CapacityBuildupEntry Year7 { get; set; } = new();
        public CapacityBuildupEntry Year8 { get; set; } = new();
        public CapacityBuildupEntry Year9 { get; set; } = new();
        public CapacityBuildupEntry Year10 { get; set; } = new();
        public CapacityBuildupEntry Year11 { get; set; } = new();
        public CapacityBuildupEntry Total { get; set; } = new();
    }

    public record Post16CapacityBuildup
    {
        public CapacityBuildupEntry Year12 { get; set; } = new();
        public CapacityBuildupEntry Year13 { get; set; } = new();
        public CapacityBuildupEntry Year14 { get; set; } = new();
        public CapacityBuildupEntry Total { get; set; } = new();
    }

    public record CapacityBuildupEntry
    {
        public int CurrentCapacity { get; set; }
        public int FirstYear { get; set; }
        public int SecondYear { get; set; }
        public int ThirdYear { get; set; }
        public int FourthYear { get; set; }
        public int FifthYear { get; set; }
        public int SixthYear { get; set;}
        public int SeventhYear { get; set; }
    }
}

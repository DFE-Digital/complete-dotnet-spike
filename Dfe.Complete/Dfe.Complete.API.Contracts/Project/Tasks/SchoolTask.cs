using System.ComponentModel;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks
{
    public record SchoolTask
    {
        public string CurrentFreeSchoolName { get; set; }
        public SchoolType SchoolType { get; set; }
        public SchoolPhase SchoolPhase { get; set; }
        public string AgeRange { get; set; }
        public ClassType.Nursery Nursery { get; set; }
        public ClassType.SixthForm SixthForm { get; set; }
        public ClassType.AlternativeProvision AlternativeProvision { get; set; }
        public ClassType.SpecialEducationNeeds SpecialEducationNeeds { get; set; }
        public Gender Gender { get; set; }
        public string FormsOfEntry { get; set; }
        public FaithStatus FaithStatus { get; set; }
        public FaithType FaithType { get; set; }
        public string OtherFaithType { get; set; }
        public bool MarkedAsComplete { get; set; }
    }
    
    public enum SchoolPhase
    {
        [Description("NotSet")]
        NotSet,
        [Description("Primary")]
        Primary,
        [Description("Secondary")]
        Secondary,
        [Description("16 to 19")]
        SixteenToNineteen, 
        [Description("All-through")]
        AllThrough, 
    }

    public enum FaithType
    {
        [Description("NotSet")]
        NotSet,
        [Description("Church of England")]
        ChurchOfEngland,
        [Description("Christian")]
        Christian,
        [Description("Greek Orthodox")]
        GreekOrthodox,
        [Description("Hindu")]
        Hindu,
        [Description("Jewish")]
        Jewish,
        [Description("Methodist")]
        Methodist,
        [Description("Muslim")]
        Muslim,
        [Description("Roman Catholic")]
        RomanCatholic,
        [Description("Sikh")]
        Sikh,
        [Description("Other")]
        Other
    }

    public enum FaithStatus
    {
        NotSet,
        None,
        Designation,
        Ethos,
    }

    public enum Gender
    {
        NotSet,
        [Description("Boys only")]
        BoysOnly,
        [Description("Girls only")]
        GirlsOnly,
        [Description("Mixed")]
        Mixed
    }
}

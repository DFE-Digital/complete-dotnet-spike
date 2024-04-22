namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Contacts;

    public record ContactsTask
    {
        public string ChairOfGovernorsName { get; set; }
        
        public string ChairOfGovernorsEmail { get; set; }
        
        public string SchoolChairOfGovernorsName { get; set; }
        
        public string SchoolChairOfGovernorsEmail { get; set; }
    }


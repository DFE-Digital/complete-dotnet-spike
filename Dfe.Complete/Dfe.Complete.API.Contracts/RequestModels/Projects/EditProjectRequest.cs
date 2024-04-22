using System.ComponentModel.DataAnnotations;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.RequestModels.Projects
{
    public class EditProjectRequest
    {
        [Required]
        public string ProjectId { get; set; }
        [Required]
        public string SchoolName { get; set; }
        [Required]
        public string ApplicationNumber { get; set; }
        [Required]
        public string ApplicationWave { get; set; }
        [Required]
        public string CreatedBy { get; set; }
    }
}

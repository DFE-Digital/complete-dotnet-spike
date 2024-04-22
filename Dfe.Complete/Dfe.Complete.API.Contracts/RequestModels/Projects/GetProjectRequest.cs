using System.ComponentModel.DataAnnotations;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.RequestModels.Projects
{
    public class GetProjectRequest
    {
        [Required]
        public string ProjectId { get; set; }
    }
}

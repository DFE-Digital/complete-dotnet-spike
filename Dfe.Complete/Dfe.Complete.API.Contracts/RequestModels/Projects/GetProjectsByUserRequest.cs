using System.ComponentModel.DataAnnotations;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.RequestModels.Projects
{
    public class GetProjectsByUserRequest
    {
        [Required]
        public string User { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels.Project
{
    public class ProjectResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
		[JsonPropertyName("projectId")]
		public string ProjectId { get; set; }
        [JsonPropertyName("schoolName")]
        public string SchoolName { get; set; }
        [JsonPropertyName("applicationNumber")]
        public string ApplicationNumber { get; set; }
		[JsonPropertyName("applicationWave")]
		public string ApplicationWave { get; set; }
		[JsonPropertyName("createdAt")]
		public DateTime CreatedAt { get; set; }
		[JsonPropertyName("updatedAt")]
		public DateTime? UpdatedAt { get; set; }
		[JsonPropertyName("createdBy")]
		public string CreatedBy { get; set; }

    }
}

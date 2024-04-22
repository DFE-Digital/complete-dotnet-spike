using System;
using System.ComponentModel.DataAnnotations;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project
{
    public record CreateProjectResponse
    {
        public List<ProjectResponseDetails> Projects { get; set; } = new();
    }

    public enum ProjectCreateState
    {
        New = 1,
        Exists = 2
    }

    public class ProjectResponseDetails
    {
        public string ProjectId { get; set; }

        public ProjectCreateState ProjectCreateState { get; set; }
    }
}


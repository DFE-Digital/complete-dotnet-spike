using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.ApplicationsEvidence
{
    public record ApplicationsEvidenceTaskSummaryBuilderParameters
    {
        public SchoolType SchoolType { get; set; }
        public TaskSummaryResponse TaskSummary { get; set; }
    }

    public class ApplicationsEvidenceTaskSummaryBuilder
    {
        public TaskSummaryResponse Build(ApplicationsEvidenceTaskSummaryBuilderParameters parameters)
        {
            var taskSummary = parameters.TaskSummary;
            var schoolType = parameters.SchoolType;

            if (schoolType is SchoolType.AlternativeProvision or SchoolType.Special)
            {
                taskSummary.IsHidden = true;
            }

            return taskSummary;
        }
    }
}

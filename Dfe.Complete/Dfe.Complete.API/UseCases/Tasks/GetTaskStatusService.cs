using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Tasks;

public interface IGetTaskStatusService
{
    Task<ProjectTaskStatus> Execute(string projectId, string taskName);
}

public class GetTaskStatusService : IGetTaskStatusService
{
    private readonly MfspContext _context;

    public GetTaskStatusService (MfspContext context)
    {
        _context = context;
    }

    public async Task<ProjectTaskStatus> Execute(string projectId, string taskName)
    {
        var dbKpi = await _context.Kpi.FirstOrDefaultAsync(x => x.ProjectStatusProjectId == projectId);
        var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Rid == dbKpi.Rid && x.TaskName == Enum.Parse<TaskName>(taskName));
        var mappedStatus = (task?.Status ?? Status.InProgress).Map();
        
        return mappedStatus;
    }
}


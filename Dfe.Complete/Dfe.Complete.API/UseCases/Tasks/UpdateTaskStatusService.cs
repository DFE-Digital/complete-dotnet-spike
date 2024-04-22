using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Tasks;

public interface IUpdateTaskStatusService
{
    Task Execute(string projectId, string taskName, ProjectTaskStatus updatedProjectTaskStatus);
}

public class UpdateTaskStatusService : IUpdateTaskStatusService
{
    private readonly MfspContext _context;

    public UpdateTaskStatusService(MfspContext context)
    {
        _context = context;
    }

    public async Task Execute(string projectId, string taskName, ProjectTaskStatus updatedProjectTaskStatus)
    {
        var dbKpi = await _context.Kpi.FirstOrDefaultAsync(x => x.ProjectStatusProjectId == projectId);
        
        //taskName might need mapping to TaskName enum if contains multiple words from frontend
        var task = await _context.Tasks.FirstOrDefaultAsync(e => e.Rid == dbKpi.Rid && e.TaskName == Enum.Parse<TaskName>(taskName));

        var parsedStatus = updatedProjectTaskStatus.Map();

        if (task == null)
        {
            task = new Data.Entities.Existing.Tasks() { Rid = dbKpi.Rid, TaskName = Enum.Parse<TaskName>(taskName), Status = parsedStatus };
            _context.Add(task);
        }
        else if (task.Status == parsedStatus)
        {
            return;
        }
        
        task.Status = parsedStatus;

        await _context.SaveChangesAsync();
    }
}
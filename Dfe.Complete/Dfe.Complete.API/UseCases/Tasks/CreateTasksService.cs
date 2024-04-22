using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Extensions;
using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Tasks;


public interface ICreateTasksService
{
    Task Execute(string projectId);
}

public class CreateTasksService : ICreateTasksService
{
    private readonly MfspContext _context; 
    
    public CreateTasksService(MfspContext context)
    {
        _context = context;
    }

    public async Task Execute(string projectId)
    {
        var kpi = await _context.Kpi.FirstOrDefaultAsync(x => x.ProjectStatusProjectId == projectId);
        _context.Tasks.AddRange(ProjectTaskBuilder.BuildTasks(kpi.Rid));
        await _context.SaveChangesAsync();
    }
}
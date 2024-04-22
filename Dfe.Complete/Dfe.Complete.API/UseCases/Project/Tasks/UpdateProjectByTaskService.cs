using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Exceptions;
using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks
{
    public interface IUpdateProjectByTaskService
    {
        public Task Execute(string projectId, UpdateProjectByTaskRequest request);
    }

    public class UpdateProjectByTaskService : IUpdateProjectByTaskService
    {
        private readonly MfspContext _context;
        private readonly IEnumerable<IUpdateTaskService> _updateTaskServices;

        public UpdateProjectByTaskService(
            MfspContext context,
            IEnumerable<IUpdateTaskService> updateTaskServices)
        {
            _context = context;
            _updateTaskServices = updateTaskServices;
        }

        public async Task Execute(string projectId, UpdateProjectByTaskRequest request)
        {
            var dbKpi = await _context.Kpi.FirstOrDefaultAsync(p => p.ProjectStatusProjectId == projectId);

            if (dbKpi == null)
            {
                throw new NotFoundException($"Project {projectId} not found");
            }

            var updateParameters = new UpdateTaskServiceParameters()
            {
                Kpi = dbKpi,
                ProjectId = projectId,
                Request = request
            };

            foreach (var updateTaskService in _updateTaskServices)
            {
                await updateTaskService.Update(updateParameters);
            }

            await UpdateTaskStatus(dbKpi.Rid, Status.InProgress, request);

            await _context.SaveChangesAsync();
        }

        private async Task UpdateTaskStatus(string taskRid, Status updatedStatus, UpdateProjectByTaskRequest updateProjectByTaskRequest)
        {
            var taskNameToUpdate = Enum.Parse<TaskName>(updateProjectByTaskRequest.TaskToUpdate);

            var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Rid == taskRid && x.TaskName == taskNameToUpdate);
            if (task is null)
                return;

            task.Status = updatedStatus;
        }
    }
}
using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Exceptions;
using Dfe.Complete.Data;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project
{
    public static class ProjectExtensions
    {
        public static async Task<TransferProject> GetTransferProjectById(this CompleteContext context, Guid projectId)
        {
            var result = await (from project in context.Projects
                                join taskData in context.TransferTasksData on project.TasksDataId equals taskData.Id into joinedTaskData
                                from taskData in joinedTaskData.DefaultIfEmpty()
                                where project.Id == projectId && project.Type == ProjectType.Transfer
                                select new TransferProject
                                {
                                    Project = project,
                                    TaskData = taskData
                                }).FirstOrDefaultAsync();

            if (result == null)
            {
                throw new NotFoundException($"Project with id {projectId} not found");
            }

            if (result.TaskData == null)
            {
                throw new NotFoundException($"Project with id {projectId} does not have any transfer tasks data");
            }

            return result;
        }

        public static IQueryable<Data.Entities.Project> GetConversionProjects(this CompleteContext context, Guid projectId)
        {
            var result = context.Projects.Where(p => p.Id == projectId && p.Type == ProjectType.Conversion);

            return result;
        }
    }
}

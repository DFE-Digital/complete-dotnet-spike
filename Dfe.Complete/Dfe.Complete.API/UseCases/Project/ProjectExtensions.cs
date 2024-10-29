using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Exceptions;
using Dfe.Complete.Data;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project
{
    public static class ProjectExtensions
    {
        public static IQueryable<TransferProject> GetTransferProjects(this CompleteContext context, IQueryable<Data.Entities.Project> projects)
        {     
            var result = (from project in projects
                          join taskData in context.TransferTasksData on project.TasksDataId equals taskData.Id into joinedTaskData
                          from taskData in joinedTaskData.DefaultIfEmpty()
                          where project.Type == ProjectType.Transfer
                          select new TransferProject
                          {
                              Project = project,
                              TaskData = taskData
                          });

            return result;
        }

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

        public static async Task<ConversionProject> GetConversionProjectById(this CompleteContext context, Guid projectId)
        {
            var result = await (from project in context.Projects
                                join taskData in context.ConversionTasksData on project.TasksDataId equals taskData.Id into joinedTaskData
                                from taskData in joinedTaskData.DefaultIfEmpty()
                                where project.Id == projectId && project.Type == ProjectType.Conversion
                                select new ConversionProject
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
                throw new NotFoundException($"Project with id {projectId} does not have any conversion tasks data");
            }

            return result;
        }

        public static async Task<ConversionProject> GetConversionProjectByUrn(this CompleteContext context, int urn)
        {
            var result = (from project in context.Projects
                          join taskData in context.ConversionTasksData on project.TasksDataId equals taskData.Id into joinedTaskData
                          from taskData in joinedTaskData.DefaultIfEmpty()
                          where project.Urn == urn && project.Type == ProjectType.Conversion
                          select new ConversionProject
                          {
                              Project = project,
                              TaskData = taskData
                          }
                          ).FirstOrDefault();

            return result;
        }

        public static async Task<Data.Entities.Project> GetProjectById(this CompleteContext context, Guid projectId)
        {
            var project = await context.Projects.FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null)
            {
                throw new NotFoundException($"Project with id {projectId} not found");
            }

            return project;
        }

        public static async Task<Note> GetProjectNoteById(this CompleteContext context, Guid projectId, Guid noteId)
        {
            var note = await context.Notes.Include(n => n.User).FirstOrDefaultAsync(n => n.ProjectId == projectId && n.Id == noteId);

            if (note == null)
            {
                throw new NotFoundException($"Project with id {projectId}, note with id {noteId} not found");
            }

            return note;
        }
    }
}

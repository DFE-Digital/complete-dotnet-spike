﻿using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.API.Exceptions;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks.HandoverWithDeliveryOfficer;
using Dfe.Complete.Data;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project.Conversion.Tasks
{
    public interface IGetConversionProjectByTaskSummaryService
    {
        Task<GetConversionProjectByTaskSummaryResponse> Execute(Guid projectId);
    }

    public class GetConversionProjectByTaskSummaryService : IGetConversionProjectByTaskSummaryService
    {
        private readonly CompleteContext _context;

        public GetConversionProjectByTaskSummaryService(CompleteContext context)
        {
            _context = context;
        }

        public async Task<GetConversionProjectByTaskSummaryResponse> Execute(Guid projectId)
        {
            var queryResult = await _context.GetConversionProjects(projectId).FirstOrDefaultAsync();

            if (queryResult == null)
            {
                throw new NotFoundException($"Project with id {projectId} not found");
            }

            var conversionTasks = await _context.ConversionTasksData
                .Where(t => t.Id == queryResult.Project.TasksDataId)
                .FirstOrDefaultAsync();

            if (conversionTasks == null)
            {
                conversionTasks = new ConversionTasksData();
            }

            var handoverWithDeliveryOfficer = HandoverWithDeliveryOfficerTaskBuilder.Execute(conversionTasks);

            var result = new GetConversionProjectByTaskSummaryResponse
            {
                HandoverWithDeliveryOfficer = new TaskSummaryResponse()
                {
                    Status = ProjectTaskStatusBuilder.Build(handoverWithDeliveryOfficer),
                }
            };

            return result;
        }
    }
}

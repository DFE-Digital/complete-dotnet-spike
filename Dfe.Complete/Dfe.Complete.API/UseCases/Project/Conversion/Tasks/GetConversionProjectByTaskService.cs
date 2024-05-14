﻿using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.Exceptions;
using Dfe.Complete.API.UseCases.Academies;
using Dfe.Complete.API.UseCases.Project.Conversion.Tasks.StakeholderKickoff;
using Dfe.Complete.API.UseCases.Project.Tasks.HandoverWithDeliveryOfficer;
using Dfe.Complete.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project.Conversion.Tasks
{
    public interface IGetConversionProjectByTaskService
    {
        public Task<GetConversionProjectByTaskResponse> Execute(Guid projectId, ConversionProjectTaskName taskName);
    }

    public class GetConversionProjectByTaskService : IGetConversionProjectByTaskService
    {
        private readonly CompleteContext _context;
        private readonly ISetProjectSchoolNameService _setProjectSchoolNameService;

        public GetConversionProjectByTaskService(
            CompleteContext context,
            ISetProjectSchoolNameService setProjectSchoolNameService)
        {
            _context = context;
            _setProjectSchoolNameService = setProjectSchoolNameService;
        }

        public async Task<GetConversionProjectByTaskResponse> Execute(Guid projectId, ConversionProjectTaskName taskName)
        {
            var project = await _context.GetConversionProjects(projectId).FirstOrDefaultAsync();

            if (project == null)
            {
                throw new NotFoundException($"Project with id {projectId} not found");
            }

            var conversionTaskData = await _context.ConversionTasksData.FirstOrDefaultAsync(t => t.Id == project.TasksDataId);

            if (conversionTaskData == null)
            {
                conversionTaskData = new Data.Entities.ConversionTasksData();
            }

            GetConversionProjectByTaskResponse response = new GetConversionProjectByTaskResponse()
            {
                Urn = project.Urn
            };

            await _setProjectSchoolNameService.Execute(response);

            switch (taskName)
            {
                case ConversionProjectTaskName.HandoverWithDeliveryOfficer:
                    response.HandoverWithDeliveryOfficer = HandoverWithDeliveryOfficerTaskBuilder.Execute(conversionTaskData);
                    break;

                case ConversionProjectTaskName.StakeholderKickoff:
                    response.StakeholderKickoff = ConversionStakeholderKickoffTaskBuilder.Execute(conversionTaskData);
                    break;

                default:
                    throw new ArgumentException($"Unknown project conversion task name {taskName}");
            }

            return response;
        }
    }
}

﻿using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.API.Exceptions;
using Dfe.Complete.API.UseCases.Project.Tasks.HandoverWithDeliveryOfficer;
using Dfe.Complete.API.UseCases.Project.Tasks.StakeholderKickoff;
using Dfe.Complete.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.API.UseCases.Project.Transfer.Tasks
{
    public interface IUpdateTransferProjectByTaskService
    {
        public Task Execute(Guid projectId, UpdateTransferProjectByTaskRequest request);
    }

    public class UpdateTransferProjectByTaskService : IUpdateTransferProjectByTaskService
    {
        private readonly CompleteContext _context;

        public UpdateTransferProjectByTaskService(
            CompleteContext context)
        {
            _context = context;
        }

        public async Task Execute(Guid projectId, UpdateTransferProjectByTaskRequest request)
        {
            var queryResult = await _context.GetTransferProjectById(projectId);
            var project = queryResult.Project;
            var transferTaskData = queryResult.TaskData;

            if (request.HandoverWithDeliveryOfficer != null)
                UpdateHandoverWithDeliveryOfficerTaskBuilder.Execute(request.HandoverWithDeliveryOfficer, transferTaskData);

            if (request.StakeholderKickoff != null)
                UpdateStakeholderKickoffTaskBuilder.Execute(request.StakeholderKickoff, transferTaskData);

            await _context.SaveChangesAsync();
        }
    }
}

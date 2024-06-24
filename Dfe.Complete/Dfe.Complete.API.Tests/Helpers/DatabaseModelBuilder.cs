using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.Data;
using Dfe.Complete.Data.Entities;
using System;

namespace Dfe.Complete.API.Tests.Helpers
{
    public static class DatabaseModelBuilder
    {
        public static readonly Fixture _fixture = new();

        static DatabaseModelBuilder()
        {
            _fixture.Customize(new OmitNestedPropertiesCustomization());
        }

        public static Data.Entities.Project BuildProject()
        {
            var result = new Data.Entities.Project()
            {
                Id = Guid.NewGuid(),
                Urn = 1001,
                SignificantDate = _fixture.Create<DateTime>(),
                Type = ProjectType.Conversion,
            };

            return result;
        }

        public static Data.Entities.Project BuildInProgressProject(User user)
        {
            var result = BuildProject();
            result.State = ProjectState.Active;
            result.AssignedTo = user;

            return result;
        }

        public static Data.Entities.Project BuildCompletedProject()
        {
            var result = BuildProject();
            result.AssignedTo = null;
            result.State = ProjectState.Completed;

            return result;
        }

        public static TransferProject BuildTransferProject()
        {
            var project = BuildProject();
            project.Type = ProjectType.Transfer;
            project.TasksDataType = TaskType.Transfer;
            project.CompletedAt = null;
            project.State = ProjectState.Active;

            var taskData = _fixture.Create<TransferTasksData>();

            var result = new TransferProject() { Project = project, TaskData = taskData };

            return result;
        }
    }
}

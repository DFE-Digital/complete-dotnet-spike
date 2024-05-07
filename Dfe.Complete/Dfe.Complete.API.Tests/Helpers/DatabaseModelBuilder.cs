using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.Data.Entities;
using System;

namespace Dfe.Complete.API.Tests.Helpers
{
    public static class DatabaseModelBuilder
    {
        public static Fixture _fixture = new();

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
    }
}

using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.Data.Entities;
using System;

namespace Dfe.Complete.API.Tests.Helpers
{
    public static class DatabaseModelBuilder
    {
        public static Project BuildProject()
        {
            var result = new Project()
            {
                Id = Guid.NewGuid(),
                Urn = 1001,
                SignificantDate = DateTime.Now,
                Type = ProjectType.Conversion,
            };

            return result;
        }

        public static Project BuildInProgressProject(User user)
        {
            var result = BuildProject();
            result.State = ProjectState.Active;
            result.AssignedTo = user;

            return result;
        }

        public static Project BuildCompletedProject()
        {
            var result = BuildProject();
            result.AssignedTo = null;
            result.State = ProjectState.Completed;

            return result;
        }
    }
}

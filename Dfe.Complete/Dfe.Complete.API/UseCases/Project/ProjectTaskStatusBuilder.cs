using Dfe.Complete.API.Contracts.Project;
using System.Reflection;

namespace Dfe.Complete.API.UseCases.Project
{
    public static class ProjectTaskStatusBuilder
    {
        public static ProjectTaskStatus Build(TaskBase task)
        {
            if (task.NotApplicable == true)
            {
                return ProjectTaskStatus.NotApplicable;
            }

            var properties = task.GetType().GetProperties().Where(p => p.Name != "NotApplicable").ToList();

            var numberOfSetProperties = properties.Count(p => HasValue(p, task));

            if (numberOfSetProperties == properties.Count())
            {
                return ProjectTaskStatus.Completed;
            }

            if (numberOfSetProperties > 0)
            {
                return ProjectTaskStatus.InProgress;
            }

            return ProjectTaskStatus.NotStarted;
        }

        private static bool HasValue(PropertyInfo property, TaskBase task)
        {
            if (property.PropertyType == typeof(bool?))
            {
                bool? value = (bool?)property.GetValue(task);
                return value.HasValue && value.Value;
            }

            return false;
        }
    }
}

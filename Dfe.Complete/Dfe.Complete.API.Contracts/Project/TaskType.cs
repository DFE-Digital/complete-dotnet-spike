namespace Dfe.Complete.API.Contracts.Project
{
    public enum TaskType
    {
        Conversion = 1,
        Transfer = 2
    }

    public static class TaskTypeExtensions
    {
        private const string ConversionProjectType = "Conversion::TasksData";
        private const string TransferProjectType = "Transfer::TasksData";

        public static string ToTaskTypeString(this TaskType? taskType)
        {
            // We haven't controlled this since it came from the Ruby code, but it defines one of only 2 types of task data
            // If we get something that I haven't seen supported we should throw an exception, to make sure we do not corrupt the data
            return taskType switch
            {
                TaskType.Conversion => ConversionProjectType,
                TaskType.Transfer => TransferProjectType,
                _ => throw new ArgumentNullException($"Unknown taskType type '{taskType}'")
            };
        }

        public static TaskType ToTaskType(string taskType)
        {
            return taskType switch
            {
                ConversionProjectType => TaskType.Conversion,
                TransferProjectType => TaskType.Transfer,
                _ => throw new ArgumentException($"Unknown task type '{taskType}'"),
            };
        }
    }
}

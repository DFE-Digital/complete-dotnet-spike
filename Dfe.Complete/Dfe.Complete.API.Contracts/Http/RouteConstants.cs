namespace Dfe.Complete.API.Contracts.Http
{
    public class RouteConstants
    {
        public const string ProjectList = "api/v1/client/projects/list";

        // Project
        public const string ProjectNote = "api/v1/client/projects/{0}/notes";
        public const string ProjectNoteById = ProjectNote + "/{1}";

        // Transfer
        public const string CreateTransferProject = "api/v1/transfer-projects";
        public const string TransferProject = "api/v1/client/transfer-projects";
        public const string TransferProjectById = TransferProject + "/{0}";
        public const string TransferProjectTask = TransferProject + "/{0}/tasks";
        public const string TransferProjectTaskSummary = TransferProjectTask + "/summary";

        // Conversion
        public const string CreateConversionProject = "api/v1/conversion-projects";
        public const string ConversionProject = "api/v1/client/conversion-projects";
        public const string ConversionProjectById = ConversionProject + "/{0}";
        public const string ConversionProjectTask = ConversionProject + "/{0}/tasks";
        public const string ConversionProjectTaskSummary = ConversionProjectTask + "/summary";
    }
}

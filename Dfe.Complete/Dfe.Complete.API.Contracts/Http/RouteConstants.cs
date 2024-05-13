namespace Dfe.Complete.API.Contracts.Http
{
    public class RouteConstants
    {
        public const string ProjectList = "api/v1/client/projects/list";

        // Transfer
        public const string CreateTransferProject = "api/v1/transfer-projects";
        public const string TransferProject = "api/v1/client/transfer-projects";
        public const string TransferProjectTask = TransferProject + "/{0}/tasks";
        public const string TransferProjectTaskSummary = TransferProjectTask + "/summary";

        // Conversion
        public const string ConversionProject = "api/v1/client/conversion-projects";
        public const string ConversionProjectTask = ConversionProject + "/{0}/tasks";
        public const string ConversionProjectTaskSummary = ConversionProjectTask + "/summary";
    }
}

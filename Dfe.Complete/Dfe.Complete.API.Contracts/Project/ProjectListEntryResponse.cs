namespace Dfe.Complete.API.Contracts.Project
{
    public record ProjectListEntryResponse : ProjectBaseResponse
    {
        public Guid Id { get; set; }
        public DateTime? ConversionOrTransferDate { get; set; }
        public ProjectType? ProjectType { get; set; }
        public bool IsFormAMatProject { get; set; }
        public string AssignedTo { get; set; }
    }
}

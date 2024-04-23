namespace Dfe.Complete.API.Contracts.Project
{
    public record ProjectListEntryResponse
    {
        public Guid Id { get; set; }
        public string SchoolOrAcademy { get; set; }
        public int Urn { get; set; }
        public DateTime? ConversionOrTransferDate { get; set; }
        public ProjectType? ProjectType { get; set; }
        public bool IsFormAMatProject { get; set; }
        public string AssignedTo { get; set; }
    }
}

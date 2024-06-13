namespace Dfe.Complete.API.Contracts.Project.Notes
{
    public record CreateProjectNoteRequest
    {
        public string Text { get; set; }
        public string Email { get; set; }
    }
}

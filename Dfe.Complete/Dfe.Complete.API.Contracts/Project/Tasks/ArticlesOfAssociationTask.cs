namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks
{
    public record ArticlesOfAssociationTask
    {
        public bool? CheckedSubmittedArticlesMatch { get; set; }
        public bool? ChairHaveSubmittedConfirmation { get; set; }
        public bool? ArrangementsMatchGovernancePlans { get; set; }
        public DateTime? ForecastDate { get; set; }
        public DateTime? ActualDate { get; set; }
        public string CommentsOnDecision { get; set; }
        public string SharepointLink { get; set; }
    }
}

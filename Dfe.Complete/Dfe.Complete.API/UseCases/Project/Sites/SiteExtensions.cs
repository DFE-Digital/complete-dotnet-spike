using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Sites
{
    public static class SiteExtensions
    {
        public static bool IsPermanentSite(this Property property)
        {
            return property.Tos == "Main";
        }

        public static bool IsTemporarySite(this Property property)
        {
            return property.Tos == "Temporary" || property.Tos == "Other";
        }
    }
}

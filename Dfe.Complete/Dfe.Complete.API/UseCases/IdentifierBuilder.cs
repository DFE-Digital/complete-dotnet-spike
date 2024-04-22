namespace Dfe.ManageFreeSchoolProjects.API.UseCases
{
    public static class IdentifierBuilder
    {
        public static string BuildRid()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 11);
        }
    }
}

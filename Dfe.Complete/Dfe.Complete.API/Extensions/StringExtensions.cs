namespace Dfe.ManageFreeSchoolProjects.API.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt(this string value)
        {
            var succeeded = int.TryParse(value, out var result);

            return succeeded ? result : 0;
        }

        public static decimal ToDecimal(this string value)
        {
            var succeeded = decimal.TryParse(value, out var result);

            return succeeded ? result : 0;
        }
    }
}

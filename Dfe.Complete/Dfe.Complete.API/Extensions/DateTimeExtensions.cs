using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dfe.ManageFreeSchoolProjects.API.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToUkDateString(this DateTime? date)
        {
            return date.HasValue ? date.Value.ToString("dd/MM/yyyy") : string.Empty;
        } 

    }
}

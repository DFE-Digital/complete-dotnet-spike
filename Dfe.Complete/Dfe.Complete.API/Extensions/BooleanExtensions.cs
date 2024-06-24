namespace Dfe.Complete.API.Extensions
{
    public static class BooleanExtensions
    {
        public static string ToYesNoString(this bool value) => value ? "Yes" : "No";
        public static string ToYesNoString(this bool? value)
        {
            if (value.HasValue) return value.Value ? "Yes" : "No";

            return "";
        }
    }
}

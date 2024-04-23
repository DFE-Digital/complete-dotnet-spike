using System.Globalization;

namespace Dfe.Complete.Extensions
{
	public static class DecimalExtensions
	{
		public static string ToMoneyString(this decimal value, bool includePoundSign = false)
		{
			return string.Format(CultureInfo.CreateSpecificCulture("en-GB"), includePoundSign ? "{0:C2}" : "{0:F2}", value);
		}
		public static string ToMoneyString(this decimal? value, bool includePoundSign = false)
		{
			if(!value.HasValue)
			{
				return "";
			}
			return string.Format(CultureInfo.CreateSpecificCulture("en-GB"), includePoundSign ? "{0:C2}" : "{0:F2}", value);
		}

		public static string ToPercentage(this decimal value)
		{
			return string.Format("{0:G0}%", value);
		}

		public static string ToPercentageWith2Dp(this decimal value)
		{
            return string.Format("{0:0.00}%", value);
        }

		public static string ToSafeString(this decimal? value)
		{
			if (!value.HasValue)
			{
				return "";
			}
			return value.Value.ToString("G0");
		}
	}
}

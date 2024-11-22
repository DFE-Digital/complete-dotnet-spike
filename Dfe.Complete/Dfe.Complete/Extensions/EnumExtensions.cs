using System;
using System.ComponentModel;
using System.Reflection;

namespace Dfe.Complete.Extensions
{
	public static class EnumExtensions
	{
		public static string ToDescription<T>(this T source)
		{
			if (source == null) return string.Empty;

			FieldInfo fi = source.GetType().GetField(source.ToString());

			var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
				typeof(DescriptionAttribute), false);

			return attributes.Length > 0
				? attributes[0].Description
				: source.ToString();
		}

		public static string ToIntString(this Enum value)
		{
			if (value == null) return string.Empty;

			return value.ToString("D");
		}

		public static T? ToEnum<T>(this string value) where T : struct
        {
			if (value == null) return null;

            return (T)Enum.Parse(typeof(T), value);
		}

	}
}

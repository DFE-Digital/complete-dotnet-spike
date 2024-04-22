using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace Dfe.ManageFreeSchoolProjects.API.Extensions
{
	public static class EnumExtensions
	{
		public static string GetDescription<T>(this T? e) where T : IConvertible
		{
			if (e == null)
			{
				return null;
			}

			if (e is Enum)
			{
				Type type = e.GetType();

				foreach (int val in System.Enum.GetValues(type))
				{
					if (val == e.ToInt32(CultureInfo.InvariantCulture))
					{
						var memInfo = type.GetMember(type.GetEnumName(val));
						var descriptionAttribute = memInfo[0]
							.GetCustomAttributes(typeof(DescriptionAttribute), false)
							.FirstOrDefault() as DescriptionAttribute;

						if (descriptionAttribute != null)
						{
							return descriptionAttribute.Description;
						}
					}
				}
			}

			return null;
		}

		public static string ToDescription<T>(this T source)
		{
			if (source == null) return string.Empty;

			var fi = source.GetType().GetField(source.ToString());

			var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
				typeof(DescriptionAttribute), false);

			return attributes.Length > 0
				? attributes[0].Description
				: source.ToString();
		}
	}
}


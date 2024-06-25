using Dfe.Complete.API.Contracts.Project.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Helpers
{
    internal class CsvHelper
    {
        public static List<string> GetLines(string csv)
        {
            return csv.Split(Environment.NewLine).Where(l => l != string.Empty).ToList();
        }

        public static List<string> GetHeaders(string csv)
        {
            var lines = GetLines(csv);
            return lines.First().Split(",").ToList();
        }

        public static bool IsValidCsv(string csv)
        {
            var headers = GetHeaders(csv);
            var expectedColumns = headers.Count;
            return headers.All(h => !string.IsNullOrWhiteSpace(h)) && GetLines(csv).Skip(1).All(l => l.Split(",").Length == expectedColumns);
        }

        public static T ToObject<T>(string[] values) where T : new()
        {
            var entry = new T();

            var properties = entry.GetType().GetProperties();

            if (values.Length != properties.Length)
            {
                throw new ArgumentException("Number of values does not match number of properties");
            }

            for (var i = 0; i < values.Length; i++)
            {
                var value = values[i];
                var property = properties[i];

                property.SetValue(entry, value);
            }

            return entry;
        }
    }
}

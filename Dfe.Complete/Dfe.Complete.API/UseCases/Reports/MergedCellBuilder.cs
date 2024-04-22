using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using System.Text;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Reports
{
    public static class MergedCellBuilder
    {
        public static List<MergeCell> Build(int columnNumber, Dictionary<string, List<ProjectHeaderRow>> grouping)
        {
            var result = new List<MergeCell>();
            var currentColumn = 1;

            foreach (var kvp in grouping)
            {
                var numberOfEntries = kvp.Value.Count;
                var startColumn = currentColumn;
                var endColumn = currentColumn + numberOfEntries - 1;

                var mergedCell = new MergeCell()
                {
                    Reference = new StringValue($"{GetColumnName((uint)startColumn)}{columnNumber}:{GetColumnName((uint)endColumn)}{columnNumber}")
                };

                result.Add(mergedCell);

                // Merge cells
                currentColumn += numberOfEntries;
            }

            return result;
        }

        private static string GetColumnName(uint columnNumber)
        {
            uint dividend = columnNumber;
            var columnName = new StringBuilder();
            uint modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName.Insert(0, Convert.ToChar(65 + modulo));
                dividend = ((dividend - modulo) / 26);
            }

            return columnName.ToString();
        }
    }
}

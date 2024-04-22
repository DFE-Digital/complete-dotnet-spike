using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Dfe.ManageFreeSchoolProjects.Services.Project
{
    public interface IProjectTableReader 
    {
        public ProjectTable Read(MemoryStream stream, string contentType);
    }

    public class ProjectTableReader : IProjectTableReader
    {
        public ProjectTable Read(MemoryStream stream, string contentType)
        {
            using var reader = CreateReader(stream, contentType);

            var dataSet = reader.AsDataSet(BuildConfiguration());

            var table = dataSet.Tables[0];

            ProjectTable projectTable = ReadProjectTable(table);

            return projectTable;
        }

        private static IExcelDataReader CreateReader(MemoryStream stream, string contentType)
        {
            if (contentType == "text/csv")
            {
                return ExcelReaderFactory.CreateCsvReader(stream);
            }

            return ExcelReaderFactory.CreateReader(stream);
        }

        private static ExcelDataSetConfiguration BuildConfiguration()
        {
            return new ExcelDataSetConfiguration()
            {
                UseColumnDataType = false,
                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                {
                    // Possibly could allow the user to tell us this information in the form
                    UseHeaderRow = true,
                },
            };
        }

        private static ProjectTable ReadProjectTable(DataTable table)
        {
            ProjectTable projectTable = new ProjectTable();
            var idx = 2;

            foreach (DataRow row in table.Rows)
            {
                var projectRow = new ProjectRow()
                {
                    RowNumber = idx,
                    ProjectTitle = ParseColumn(row.ItemArray[0]),
                    ProjectId = ParseColumn(row.ItemArray[1]),
                    TrustName = ParseColumn(row.ItemArray[2]),
                    Region = ParseColumn(row.ItemArray[3]),
                    LocalAuthority = ParseColumn(row.ItemArray[4]),
                    RealisticOpeningDate = DateTime.Parse(ParseColumn(row.ItemArray[5]), new CultureInfo("en-GB")),
                    Status = ParseColumn(row.ItemArray[6]),
                    SourceData = row.ItemArray.Take(7).Select(value => ParseColumn(value)).ToList()
                };

                projectTable.Rows.Add(projectRow);

                idx++;
            }

            return projectTable;
        }

        private static string ParseColumn(object column)
        {
            return column != DBNull.Value ? column.ToString() : null;
        }

    }

    public record ProjectTable
    {
        public List<ProjectRow> Rows { get; set; } = new();
    }

    public record ProjectRow
    {
        public int RowNumber { get; set; }
        public string ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public string TrustName { get; set; }
        public string Region { get; set; }
        public string LocalAuthority { get; set; }
        public DateTime? RealisticOpeningDate { get; set; }
        public string Status { get; set; }
        public List<string> SourceData { get; set; }
    }
}

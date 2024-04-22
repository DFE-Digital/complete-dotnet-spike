using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Dfe.ManageFreeSchoolProjects.Services.Project
{
    public interface ICreateBulkProjectValidator
    {
        public List<ProjectRowError> Validate(ProjectTable projectTable);
    }

    public class CreateBulkProjectValidator : ICreateBulkProjectValidator
    {
        public CreateBulkProjectValidator() 
        {
        }

        public List<ProjectRowError> Validate(ProjectTable projectTable)
        {
            List<ProjectRowError> result = new List<ProjectRowError>();
            var validator = new ProjectRowValidator();

            projectTable.Rows.ForEach(row =>
            {
                var errors = validator.Validate(row).Errors.Select(e => e.ErrorMessage).ToList();

                if (!errors.Any()) 
                {
                    return;
                }

                var rowError = new ProjectRowError()
                {
                    RowNumber = row.RowNumber,
                    Errors = errors,
                    SourceData = row.SourceData
                };

                result.Add(rowError);
            });

            return result;
        }

        private sealed class ProjectRowValidator : AbstractValidator<ProjectRow>
        {
            public ProjectRowValidator()
            {
                RuleFor(table => table.ProjectTitle).NotEmpty().MaximumLength(80);
                RuleFor(table => table.ProjectId).NotEmpty();
                RuleFor(table => table.TrustName).NotEmpty();
                RuleFor(table => table.Region).NotEmpty();
                RuleFor(table => table.LocalAuthority).NotEmpty();
                RuleFor(table => table.RealisticOpeningDate).NotEmpty();
                RuleFor(table => table.Status).NotEmpty();
            }
        }
    }

    public class ProjectRowError
    {
        public int RowNumber { get; set; }
        public List<string> Errors { get; set; }
        public List<string> SourceData { get; set; }
    }
}

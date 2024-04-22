using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.PupilNumbers
{
    /// <summary>
    /// Validation attribute for number fields on pupil numbers
    /// Due to the sheer number of fields this is a wrapper to reduce duplication
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false)]
    public class ValidNumberForPupilNumbersAttribute : ValidNumberAttribute
    {
        public ValidNumberForPupilNumbersAttribute(): base(0, 9999)
        {
        }
    }
}

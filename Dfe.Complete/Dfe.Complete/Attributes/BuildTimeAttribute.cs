using System;

namespace Dfe.ManageFreeSchoolProjects.Attributes
{
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    public sealed class BuildTimeAttribute : Attribute
    {
        public string BuildTime { get; }

        public BuildTimeAttribute(string buildDateTime)
        {
            BuildTime = buildDateTime;
        }
    }
}

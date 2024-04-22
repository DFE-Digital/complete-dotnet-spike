using System;

namespace Dfe.ManageFreeSchoolProjects.Attributes
{
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    public sealed class CustomBuildMessageAttribute : Attribute
    {
        public string CustomBuildMessage { get; }

        public CustomBuildMessageAttribute(string customBuildMessage)
        {
            CustomBuildMessage = customBuildMessage;
        }
    }
}

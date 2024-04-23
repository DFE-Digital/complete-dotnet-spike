using System;

namespace Dfe.Complete.Attributes
{
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    public sealed class BuildGuidAttribute : Attribute
    {
        public string BuildGuid { get; }

        public BuildGuidAttribute(string buildGuid)
        {
            BuildGuid = buildGuid;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Contracts.Project
{
    /// <summary>
    /// Used to filter the results of a project list query by status.
    /// We cannot use the ProjectState because in progress does not exist, it is a calulated state.
    /// Adding in progress to this would be confusing.
    /// Perhaps later we should have a state of in progress, but we are working against an existing application.
    /// This does not map to the project state enum its just used for a query parameter to tell us the status requested
    /// </summary>
    public enum ProjectStatusQueryParameter
    {
        InProgress = 1,
        Completed = 2
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Contracts.Project.Tasks
{
    public interface INotApplicableTask
    {
        public bool? NotApplicable { get; set; }
    }
}

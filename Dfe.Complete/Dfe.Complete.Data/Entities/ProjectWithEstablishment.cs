using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Complete.Data.Entities
{
    public class ProjectWithEstablishment
    {
        public Project Project { get; set; }

        public GiasEstablishment Establishment { get; set; }
    }
}

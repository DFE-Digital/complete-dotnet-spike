using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Property
    {
        public string TownOrCity { get; set; }

        public DateTime? DatePlanningPermissionObtained { get; set; }
    }
}

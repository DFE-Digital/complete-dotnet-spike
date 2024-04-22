using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Kpi
    {
        public int? UserId { get; set; }

        public User? User { get; set; }

        public string SchoolDetailsAlternativeProvision { get; set; }

        public string SchoolDetailsSpecialEducationNeeds { get; set; }
    }
}

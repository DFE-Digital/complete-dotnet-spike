using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Contracts.Project
{
    public record ProjectBaseResponse
    {
        public string SchoolName { get; set; }
        public int Urn { get; set; }
    }
}

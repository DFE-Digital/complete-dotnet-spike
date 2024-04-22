using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Constituency
{
    public record GetSearchConstituencyResponse
    {
        public List<SearchConstituencyResponse> Constituencies { get; set; }
    }

    public record SearchConstituencyResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string MPName { get; set; }
        public string Party { get; set; }
    }
}

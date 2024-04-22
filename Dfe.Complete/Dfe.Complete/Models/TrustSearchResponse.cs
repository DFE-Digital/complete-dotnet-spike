using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using System.Collections.Generic;

namespace Dfe.ManageFreeSchoolProjects.Models
{
    public class TrustSearchResponse
    {
        public TrustSearchResponse()
        {
            Data = new List<SearchTrustByRefResponse>();
        }

        public IList<SearchTrustByRefResponse> Data { get; set; }
        public string Nonce { get; set; }
    }
}
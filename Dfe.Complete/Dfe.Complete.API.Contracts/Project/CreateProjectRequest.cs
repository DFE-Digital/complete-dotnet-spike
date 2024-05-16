using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Contracts.Project
{
    public record CreateProjectRequest
    {
        public string Urn { get; set; }
        public DateTime? Date { get; set; }
        public string EstablishmentSharePointLink { get; set; }
        public string IncomingTrustUkprn { get; set; }
        public string IncomingTrustSharePointLink { get; set; }
        public bool? IsDateProvisional { get; set; }
        public Region? Region { get; set; }
        public bool? IsIsDueTo2RI { get; set; }
        public DateTime? AdvisoryBoardDate { get; set; }
        public string AdvisoryBoardConditions { get; set; }
    }
}

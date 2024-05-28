using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Contracts.Project.Notes
{
    public class GetProjectNoteListResponse
    {
        public ProjectDetails ProjectDetails { get; set; }
        public List<GetProjectNoteResponse> Notes { get; set; }
    }
}

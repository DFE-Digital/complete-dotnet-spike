using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.PupilNumbers
{
    public class UpdatePupilNumbersRequest
    {
        public CapacityWhenFull CapacityWhenFull { get; set; }
        public RecruitmentAndViability RecruitmentAndViability { get; set; }
        public Pre16PublishedAdmissionNumber Pre16PublishedAdmissionNumber { get; set; }
        public Post16PublishedAdmissionNumber Post16PublishedAdmissionNumber { get; set; }
        public Pre16CapacityBuildup Pre16CapacityBuildup { get; set; }
        public Post16CapacityBuildup Post16CapacityBuildup { get; set; }
    }
}

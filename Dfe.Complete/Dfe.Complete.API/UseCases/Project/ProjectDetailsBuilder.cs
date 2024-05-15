using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Extensions;
using Dfe.Complete.API.UseCases.Academies;

namespace Dfe.Complete.API.UseCases.Project
{
    public static class ProjectDetailsBuilder
    {
        public static ProjectDetails Execute(Data.Entities.Project project, GetEstablishmentAndTrustResponse establishmentAndTrust)
        {
            var result = new ProjectDetails()
            {
                Urn = project.Urn.ToString(),
                Date = project.SignificantDate,
                IsDateProvisional = project.SignificantDateProvisional,
                IncomingTrustUkprn = project.IncomingTrustUkprn?.ToString(),
                OutgoingTrustUkprn = project.OutgoingTrustUkprn?.ToString(),
                Region = project.Region.ToDescription(),
                ProjectType = project.Type,
                IncomingTrustName = establishmentAndTrust.IncomingTrust?.Name,
                OutgoingTrustName = establishmentAndTrust.OutgoingTrust?.Name,
                LocalAuthority = establishmentAndTrust.Establishment?.LocalAuthorityName,
                Name = establishmentAndTrust.Establishment?.Name,
            };

            return result;
        }
    }
}

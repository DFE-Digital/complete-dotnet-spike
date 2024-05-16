using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.UseCases.Academies;

namespace Dfe.Complete.API.UseCases.Project
{
    public static class SchoolDetailsBuilder
    {
        public static SchoolDetails Execute(GetEstablishmentResponse establishmentResponse, string sharepointLink)
        {
            if (establishmentResponse == null)
            {
                return new();
            }

            var result = new SchoolDetails()
            {
                Name = establishmentResponse.Name,
                Urn = establishmentResponse.Urn,
                Type = establishmentResponse.EstablishmentType.Name,
                Phase = establishmentResponse.PhaseOfEducation.Name,
                LowerAge = establishmentResponse.StatutoryLowAge,
                UpperAge = establishmentResponse.StatutoryHighAge,
                Address = new()
                {
                    Street = establishmentResponse.Address.Street,
                    Locality = establishmentResponse.Address.Locality,
                    Additional = establishmentResponse.Address.Additional,
                    Town = establishmentResponse.Address.Town,
                    County = establishmentResponse.Address.County,
                    Postcode = establishmentResponse.Address.Postcode
                },
                Diocese = establishmentResponse.Diocese.Name,
                SharePointLink = sharepointLink
            };

            return result;
        }
    }
}

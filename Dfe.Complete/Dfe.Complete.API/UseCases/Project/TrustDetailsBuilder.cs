using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.UseCases.Academies;

namespace Dfe.Complete.API.UseCases.Project
{
    public static class TrustDetailsBuilder
    {
        public static TrustDetails Execute(GetTrustResponse trustResponse, string sharepointLink)
        {
            if (trustResponse == null)
            {
                return new();
            }

            var result = new TrustDetails()
            {
                Name = trustResponse.Name,
                UkPrn = trustResponse.Ukprn,
                GroupId = trustResponse.ReferenceNumber,
                CompaniesHouseNumber = trustResponse.CompaniesHouseNumber,
                SharePointLink = sharepointLink,
                Address = new()
                {
                    Street = trustResponse.Address.Street,
                    Locality = trustResponse.Address.Locality,
                    Additional = trustResponse.Address.Additional,
                    Town = trustResponse.Address.Town,
                    County = trustResponse.Address.County,
                    Postcode = trustResponse.Address.Postcode
                }
            };

            return result;
        }
    }
}

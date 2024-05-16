namespace Dfe.Complete.Constants
{
    public class ExternalSiteConstants
    {
        public const string Gias = "https://get-information-schools.service.gov.uk";
        public const string GiasEstablishment = Gias + "/Establishments/Establishment/Details/{0}";
        public const string GiasTrust = Gias + "/Groups/Search?GroupSearchModel.Text={0}";

        public const string CompaniesHouse = "https://find-and-update.company-information.service.gov.uk";
        public const string CompaniesHouseByCompany = CompaniesHouse + "/company/{0}";
    }
}

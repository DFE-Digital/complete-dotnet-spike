using Dfe.ManageFreeSchoolProjects.API.Contracts.Constituency;
using System.Text.Json;
using System.Linq;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Constituency
{
    public interface ISearchConstituencyService
    {
        Task<GetSearchConstituencyResponse> Execute(string searchTerm);
    }
    public class SearchConstituencyService : ISearchConstituencyService
    {
        private readonly IHttpClientFactory _clientFactory;

        public SearchConstituencyService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<GetSearchConstituencyResponse> Execute(string searchTerm)
        {
            var httpClient = _clientFactory.CreateClient();
            var response = await httpClient.GetAsync(
                $"https://members-api.parliament.uk/api/Location/Constituency/Search?searchText={searchTerm}&skip=0&take=10");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ParlimentaryApiResponse>(content);

            return new GetSearchConstituencyResponse
            {
                Constituencies =
                result.items.Select(x => new SearchConstituencyResponse() 
                { 
                    Name = x.value.name, 
                    Id = x.value.id.ToString(), 
                    MPName = x.value.currentRepresentation.member.value.nameFullTitle,
                    Party = x.value.currentRepresentation.member.value.latestParty.name
                }).ToList()
            };
        }
    }

    public class CurrentRepresentation
    {
        public Member member { get; set; }
        public Representation representation { get; set; }
    }

    public class Item
    {
        public Value value { get; set; }
        public List<Link> links { get; set; }
    }

    public class LatestHouseMembership
    {
        public string membershipFrom { get; set; }
        public int membershipFromId { get; set; }
        public int house { get; set; }
        public DateTime membershipStartDate { get; set; }
        public object membershipEndDate { get; set; }
        public object membershipEndReason { get; set; }
        public object membershipEndReasonNotes { get; set; }
        public object membershipEndReasonId { get; set; }
        public MembershipStatus membershipStatus { get; set; }
    }

    public class LatestParty
    {
        public int id { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string backgroundColour { get; set; }
        public string foregroundColour { get; set; }
        public bool isLordsMainParty { get; set; }
        public bool isLordsSpiritualParty { get; set; }
        public int governmentType { get; set; }
        public bool isIndependentParty { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
        public string method { get; set; }
    }

    public class Member
    {
        public Value value { get; set; }
        public List<Link> links { get; set; }
    }

    public class MembershipStatus
    {
        public bool statusIsActive { get; set; }
        public string statusDescription { get; set; }
        public object statusNotes { get; set; }
        public int statusId { get; set; }
        public int status { get; set; }
        public DateTime statusStartDate { get; set; }
    }

    public class Representation
    {
        public string membershipFrom { get; set; }
        public int membershipFromId { get; set; }
        public int house { get; set; }
        public DateTime membershipStartDate { get; set; }
        public object membershipEndDate { get; set; }
        public object membershipEndReason { get; set; }
        public object membershipEndReasonNotes { get; set; }
        public object membershipEndReasonId { get; set; }
        public object membershipStatus { get; set; }
    }

    public class ParlimentaryApiResponse
    {
        public List<Item> items { get; set; }
        public int totalResults { get; set; }
        public string resultContext { get; set; }
        public int skip { get; set; }
        public int take { get; set; }
        public List<Link> links { get; set; }
    }

    public class Value
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public object endDate { get; set; }
        public CurrentRepresentation currentRepresentation { get; set; }
        public string nameListAs { get; set; }
        public string nameDisplayAs { get; set; }
        public string nameFullTitle { get; set; }
        public string nameAddressAs { get; set; }
        public LatestParty latestParty { get; set; }
        public string gender { get; set; }
        public LatestHouseMembership latestHouseMembership { get; set; }
        public string thumbnailUrl { get; set; }
    }


}

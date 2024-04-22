using Dfe.ManageFreeSchoolProjects.API.Contracts.Constituency;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using System.Net;
using System.Net.Http.Json;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration
{

    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ConstituencyApiTest: ApiTestsBase
    {
        public ConstituencyApiTest(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {

        }

        [Fact]
        public async void When_Search_Term_Empty_Or_Null_Returns_Status400_With_ErrorMsg()
        {
            var result = await _client.GetAsync("/api/v1/client/constituency/search");
            var responseMessage = await result.Content.ReadAsStringAsync();

            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            responseMessage.Should().Be("SearchTerm is required.");
        }

        /*
         * This test calls the parlimentary api and thus is not in normal runs.
         * It also has data that may change over time so be aware when attempting to 
         * run.
         */
        [Fact(Skip = "Calls external API so not in testing suite.")]
        public async void When_Correctly_Searched_Returns_Status_200_With_Data()
        {
            var getProjectByTaskResponse = await _client.GetAsync($"/api/v1/client/constituency/search?searchTerm=SW1P");
            getProjectByTaskResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = await getProjectByTaskResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<GetSearchConstituencyResponse>>();

            result.Data.Constituencies.Count.Should().Be(3);
            result.Data.Constituencies[0].Name.Should().Be("Battersea");
            result.Data.Constituencies[0].MPName.Should().Be("Marsha De Cordova MP");
            result.Data.Constituencies[0].Id.Should().Be("3310");

            result.Data.Constituencies[1].Name.Should().Be("Cities of London and Westminster");
            result.Data.Constituencies[1].MPName.Should().Be("Nickie Aiken MP");
            result.Data.Constituencies[1].Id.Should().Be("3415");

            result.Data.Constituencies[2].Name.Should().Be("Hammersmith");
            result.Data.Constituencies[2].MPName.Should().Be("Andy Slaughter MP");
            result.Data.Constituencies[2].Id.Should().Be("3512");
        }
    }
}

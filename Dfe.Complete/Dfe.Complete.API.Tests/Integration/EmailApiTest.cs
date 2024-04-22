using System;
using System.Net;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration;

[Collection(ApiTestCollection.ApiTestCollectionName)]
public class EmailApiTest : ApiTestsBase
{
    public EmailApiTest(ApiTestFixture apiTestFixture) : base(apiTestFixture)
    {
    }

    [Fact]
    public async Task When_Email_Empty_Or_Null_Returns_Status400_With_ErrorMsg()
    {
        var request = new EmailNotifyRequest { Email = string.Empty, ProjectUrl = "https://test.com" };

        var result = await _client.PostAsync("/api/v1/email", request.ConvertToJson());
        var responseMessage = await result.Content.ReadAsStringAsync();

        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        responseMessage.Should().Contain("Email is required.");
    }

    [Theory]
    [InlineData("@invalidemail.com")]
    [InlineData("invalid@")]
    public async Task When_Email_Is_Invalid_Returns_Status400_With_ErrorMsg(string email)
    {
        var request = new EmailNotifyRequest { Email = email, ProjectUrl = "http://test.com" };

        var result = await _client.PostAsync($"/api/v1/email", request.ConvertToJson());
        var responseMessage = await result.Content.ReadAsStringAsync();

        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        responseMessage.Should().Be("Email is not valid.");
    }
    
    [Fact]
    public async Task When_ProjectUrl_Empty_Or_Null_Returns_Status400_With_ErrorMsg()
    {
        var request = new EmailNotifyRequest { Email = "test@test.com", ProjectUrl = string.Empty };

        var result = await _client.PostAsync("/api/v1/email", request.ConvertToJson());
        var responseMessage = await result.Content.ReadAsStringAsync();

        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        responseMessage.Should().Contain("Project Url is required.");
    }
    
}
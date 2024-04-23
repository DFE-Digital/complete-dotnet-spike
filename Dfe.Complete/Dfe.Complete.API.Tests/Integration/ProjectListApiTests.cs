using Dfe.Complete.API.Contracts.Common;
using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Integration
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ProjectListApiTests : ApiTestsBase
    {
        public ProjectListApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task GetProjectList_InProgress_Returns_200()
        {
            using var context = _testFixture.GetContext();

            var dbProject = new Project() 
            { 
                Id = Guid.NewGuid(),
                Urn = 123456,
                SignificantDate = DateTime.Now,
                Type = ProjectType.Conversion.ToProjectTypeString()
            };

            context.Projects.Add(dbProject);

            await context.SaveChangesAsync();

            var response = await _client.GetAsync("api/v1/client/projects/list");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadFromJsonAsync<ApiResponseV2<ProjectListEntryResponse>>();

            var projects = content.Data;

            var existingProject = projects.FirstOrDefault(p => p.Id == dbProject.Id);
            existingProject.Should().NotBeNull();

            existingProject.Urn.Should().Be(dbProject.Urn);
            existingProject.ConversionOrTransferDate.Value.Date.Should().Be(dbProject.SignificantDate.Value.Date);
            existingProject.ProjectType.Should().Be(ProjectType.Conversion);
        }
    }
}

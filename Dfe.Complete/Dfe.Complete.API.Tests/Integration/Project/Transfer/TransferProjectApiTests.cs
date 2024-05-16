﻿using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.API.Contracts.Project.Transfer;
using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.API.Tests.Helpers;
using System;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Integration.Project.Transfer
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class TransferProjectApiTests : ApiTestsBase
    {
        public TransferProjectApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Post_Returns_200()
        {
            var createProjectRequest = _autoFixture.Create<CreateTransferProjectRequest>();
            createProjectRequest.Region = Region.NorthWest;
            createProjectRequest.Urn = "1001";
            createProjectRequest.IncomingTrustUkprn = "10000001";
            createProjectRequest.OutgoingTrustUkprn = "10000002";

            var response = await _client.PostAsync(RouteConstants.CreateTransferProject, createProjectRequest.ConvertToJson());
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var createProjectResponse = await response.Content.ReadFromJsonAsync<CreateTransferProjectResponse>();

            createProjectResponse.Id.Should().NotBeEmpty();

            var getProjectResponse = await _client.GetAsync($"{string.Format(RouteConstants.TransferProjectById, createProjectResponse.Id)}");
            getProjectResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var project = await getProjectResponse.Content.ReadFromJsonAsync<GetTransferProjectResponse>();

            // Project details
            project.ProjectDetails.Urn.Should().Be(createProjectRequest.Urn);
            project.ProjectDetails.Date.Value.Date.Should().Be(createProjectRequest.Date.Value.Date);
            project.ProjectDetails.IsDateProvisional.Should().Be(createProjectRequest.IsDateProvisional);
            project.ProjectDetails.IncomingTrustUkprn.Should().Be(createProjectRequest.IncomingTrustUkprn);
            project.ProjectDetails.IncomingTrustName.Should().Be("Trust 1");
            project.ProjectDetails.OutgoingTrustUkprn.Should().Be(createProjectRequest.OutgoingTrustUkprn);
            project.ProjectDetails.OutgoingTrustName.Should().Be("Trust 2");
            project.ProjectDetails.Region.Should().Be("North West");
            project.ProjectDetails.ProjectType.Should().Be(ProjectType.Transfer);
            project.ProjectDetails.LocalAuthority.Should().Be("Local authority 1");
            project.ProjectDetails.Name.Should().Be("Establishment 1");

            // Reason for the transfer
            project.ReasonForTheTransfer.IsDueTo2RI.Should().Be(createProjectRequest.IsIsDueTo2RI);
            project.ReasonForTheTransfer.IsDueToOfstedRating.Should().Be(createProjectRequest.IsDueToOfstedRating);
            project.ReasonForTheTransfer.IsDueToIssues.Should().Be(createProjectRequest.IsDueToIssues);

            // Advisory board details
            project.AdvisoryBoardDetails.Date.Value.Date.Should().Be(createProjectRequest.AdvisoryBoardDate.Value.Date);
            project.AdvisoryBoardDetails.Conditions.Should().Be(createProjectRequest.AdvisoryBoardConditions);

            // Incoming trust details
            project.IncomingTrustDetails.Name.Should().Be("Trust 1");
            project.IncomingTrustDetails.UkPrn.Should().Be(createProjectRequest.IncomingTrustUkprn);
            project.IncomingTrustDetails.GroupId.Should().Be("TR0001");
            project.IncomingTrustDetails.CompaniesHouseNumber.Should().Be("00001");
            project.IncomingTrustDetails.Address.Street.Should().Be("Trust 1 Street");
            project.IncomingTrustDetails.Address.Locality.Should().Be("Trust 1 Locality");
            project.IncomingTrustDetails.Address.Additional.Should().Be("Trust 1 Additional");
            project.IncomingTrustDetails.Address.Town.Should().Be("Trust 1 Town");
            project.IncomingTrustDetails.Address.County.Should().Be("Trust 1 County");
            project.IncomingTrustDetails.Address.Postcode.Should().Be("Trust 1 Postcode");
            project.IncomingTrustDetails.SharePointLink.Should().Be(createProjectRequest.IncomingTrustSharePointLink);

            // Outgoing trust details
            project.OutgoingTrustDetails.Name.Should().Be("Trust 2");
            project.OutgoingTrustDetails.UkPrn.Should().Be(createProjectRequest.OutgoingTrustUkprn);
            project.OutgoingTrustDetails.GroupId.Should().Be("TR0002");
            project.OutgoingTrustDetails.CompaniesHouseNumber.Should().Be("00002");
            project.OutgoingTrustDetails.Address.Street.Should().Be("Trust 2 Street");
            project.OutgoingTrustDetails.Address.Locality.Should().Be("Trust 2 Locality");
            project.OutgoingTrustDetails.Address.Additional.Should().Be("Trust 2 Additional");
            project.OutgoingTrustDetails.Address.Town.Should().Be("Trust 2 Town");
            project.OutgoingTrustDetails.Address.County.Should().Be("Trust 2 County");
            project.OutgoingTrustDetails.Address.Postcode.Should().Be("Trust 2 Postcode");
            project.OutgoingTrustDetails.SharePointLink.Should().Be(createProjectRequest.OutgoingTrustSharePointLink);

            // School details
            project.SchoolDetails.Name.Should().Be("Establishment 1");
            project.SchoolDetails.Urn.Should().Be(createProjectRequest.Urn);
            project.SchoolDetails.Type.Should().Be("Voluntary aided school");
            project.SchoolDetails.LowerAge.Should().Be("3");
            project.SchoolDetails.UpperAge.Should().Be("16");
            project.SchoolDetails.AgeRange.Should().Be("3 to 16");
            project.SchoolDetails.Phase.Should().Be("Primary");
            project.SchoolDetails.Address.Street.Should().Be("Establishment 1 Street");
            project.SchoolDetails.Address.Locality.Should().Be("Establishment 1 Locality");
            project.SchoolDetails.Address.Additional.Should().Be("Establishment 1 Additional");
            project.SchoolDetails.Address.Town.Should().Be("Establishment 1 Town");
            project.SchoolDetails.Address.County.Should().Be("Establishment 1 County");
            project.SchoolDetails.Address.Postcode.Should().Be("Establishment 1 Postcode");
            project.SchoolDetails.Diocese.Should().Be("St Pauls");
            project.SchoolDetails.SharePointLink.Should().Be(createProjectRequest.EstablishmentSharePointLink);

            var testContext = _testFixture.GetContext();

            var dbProject = testContext.Projects.FirstOrDefault(p => p.Id == createProjectResponse.Id);
            dbProject.TasksDataType.Should().Be(TaskType.Transfer);
            dbProject.Type.Should().Be(ProjectType.Transfer);
            dbProject.SignificantDate.Value.Date.Should().Be(createProjectRequest.Date.Value.Date);
            dbProject.SignificantDateProvisional.Should().Be(createProjectRequest.IsDateProvisional);
        }

        [Fact]
        public async Task Get_ProjectDoesNotExist_Returns_404()
        {
            var projectId = Guid.NewGuid();

            var response = await _client.GetAsync(string.Format(RouteConstants.TransferProjectById, projectId));
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().Contain($"Project with id {projectId} not found");
        }

        [Fact]
        public async Task Get_ProjectDoesNotHaveTaskData_Returns_404()
        {
            var project = DatabaseModelBuilder.BuildProject();
            project.Type = ProjectType.Transfer;

            var context = _testFixture.GetContext();
            context.Projects.Add(project);
            context.SaveChanges();

            var response = await _client.GetAsync(string.Format(RouteConstants.TransferProjectById, project.Id));
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().Contain($"Project with id {project.Id} does not have any transfer tasks data");
        }
    }
}

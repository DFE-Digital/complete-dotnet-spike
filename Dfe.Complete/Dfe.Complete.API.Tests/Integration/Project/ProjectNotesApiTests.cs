using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Notes;
using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.API.Tests.Helpers;
using System;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Integration.Project
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ProjectNotesApiTests : ApiTestsBase
    {
        public ProjectNotesApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task CreateProjectNote_Returns_200()
        {
            var createdProject = await _client.CreateTransferProject();
            var projectId = createdProject.Id;
            
            var createNoteRequest = new CreateProjectNoteRequest
            {
                Note = _autoFixture.Create<string>(),
                Email = _testFixture.DefaultUser.Email
            };

            var createResponse = await _client.PostAsync(string.Format(RouteConstants.ProjectNote, projectId), createNoteRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var createdNote = await createResponse.Content.ReadFromJsonAsync<CreateProjectNoteResponse>();

            var getResponse = await _client.GetAsync(string.Format(RouteConstants.ProjectNoteById, projectId, createdNote.Id));
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var projectNote = await getResponse.Content.ReadFromJsonAsync<GetProjectNoteResponse>();

            projectNote.Note.Should().Be(createNoteRequest.Note);
            projectNote.CreatedBy.Should().Be("Automation User");
        }

        [Fact]
        public async Task UpdateProjectNote_Returns_200()
        {
            var createdProject = await _client.CreateTransferProject();
            var projectId = createdProject.Id;

            var createNoteRequest = new CreateProjectNoteRequest
            {
                Note = _autoFixture.Create<string>(),
                Email = _testFixture.DefaultUser.Email
            };

            var createResponse = await _client.PostAsync(string.Format(RouteConstants.ProjectNote, projectId), createNoteRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var createdNote = await createResponse.Content.ReadFromJsonAsync<CreateProjectNoteResponse>();
            var noteId = createdNote.Id;

            var updateNoteRequest = new UpdateProjectNoteRequest
            {
                Note = _autoFixture.Create<string>()
            };

            var updateResponse = await _client.PatchAsync(string.Format(RouteConstants.ProjectNoteById, projectId, noteId), updateNoteRequest.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync(string.Format(RouteConstants.ProjectNoteById, projectId, createdNote.Id));
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var projectNote = await getResponse.Content.ReadFromJsonAsync<GetProjectNoteResponse>();
            projectNote.Note.Should().Be(updateNoteRequest.Note);
        }

        [Fact]
        public async Task DeleteProjectNote_Returns_200()
        {
            var createdProject = await _client.CreateTransferProject();
            var projectId = createdProject.Id;

            var createNoteRequest = new CreateProjectNoteRequest
            {
                Note = _autoFixture.Create<string>(),
                Email = _testFixture.DefaultUser.Email
            };

            var createResponse = await _client.PostAsync(string.Format(RouteConstants.ProjectNote, projectId), createNoteRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var createdNote = await createResponse.Content.ReadFromJsonAsync<CreateProjectNoteResponse>();

            var deleteResponse = await _client.DeleteAsync(string.Format(RouteConstants.ProjectNoteById, projectId, createdNote.Id));
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync(string.Format(RouteConstants.ProjectNoteById, projectId, createdNote.Id));
            getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var content = await getResponse.Content.ReadAsStringAsync();
            content.Should().Contain($"Project with id {projectId}, note with id {createdNote.Id} not found");
        }

        [Fact]
        public async Task GetProjectNoteList_Returns_200()
        {
            var createdProject = await _client.CreateTransferProject();
            var projectId = createdProject.Id;

            var createdFirstNote = await CreateProjectNote(projectId);
            var createdSecondNote = await CreateProjectNote(projectId);

            var getResponse = await _client.GetAsync(string.Format(RouteConstants.ProjectNote, projectId));
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var projectNotes = await getResponse.Content.ReadFromJsonAsync<GetProjectNoteListResponse>();

            projectNotes.ProjectDetails.ProjectType.Should().Be(ProjectType.Transfer);

            projectNotes.Notes.Count.Should().Be(2);

            var firstNote = projectNotes.Notes.FirstOrDefault(n => n.Id == createdFirstNote.Id);
            var secondNote = projectNotes.Notes.FirstOrDefault(n => n.Id == createdSecondNote.Id);

            firstNote.Should().Be(createdFirstNote);
            secondNote.Should().Be(createdSecondNote);
        }

        [Fact]
        public async Task GetProjectNoteList_NoNotes_Returns_Empty_200()
        {
            var createdProject = await _client.CreateTransferProject();
            var projectId = createdProject.Id;

            var getResponse = await _client.GetAsync(string.Format(RouteConstants.ProjectNote, projectId));
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var projectNotes = await getResponse.Content.ReadFromJsonAsync<GetProjectNoteListResponse>();

            projectNotes.Notes.Count.Should().Be(0);
        }

        [Fact]
        public async Task CreateProjectNote_ProjectNotFound_Returns_404()
        {
            var projectId = Guid.NewGuid();
            var createNoteRequest = new CreateProjectNoteRequest
            {
                Note = _autoFixture.Create<string>()
            };

            var createResponse = await _client.PostAsync(string.Format(RouteConstants.ProjectNote, projectId), createNoteRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var content = await createResponse.Content.ReadAsStringAsync();
            content.Should().Contain($"Project with id {projectId} not found");
        }

        [Fact]
        public async Task CreateProjectNote_UserNotFound_Returns_422()
        {
            var createdProject = await _client.CreateTransferProject();
            var projectId = createdProject.Id;

            var createNoteRequest = new CreateProjectNoteRequest
            {
                Note = _autoFixture.Create<string>(),
                Email = _autoFixture.Create<string>()
            };

            var createResponse = await _client.PostAsync(string.Format(RouteConstants.ProjectNote, projectId), createNoteRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.UnprocessableContent);

            var content = await createResponse.Content.ReadAsStringAsync();
            content.Should().Contain($"User with email not found");
        }

        [Fact]
        public async Task GetProjectNote_NoteNotFound_Returns_404()
        {
            var createdProject = await _client.CreateTransferProject();
            var projectId = createdProject.Id;
            var noteId = Guid.NewGuid();

            var getResponse = await _client.GetAsync(string.Format(RouteConstants.ProjectNoteById, projectId, noteId));
            getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var content = await getResponse.Content.ReadAsStringAsync();
            content.Should().Contain($"Project with id {projectId}, note with id {noteId} not found");
        }

        [Fact]
        public async Task UpdateProjectNote_NoteNotFound_Returns_404()
        {
            var createdProject = await _client.CreateTransferProject();
            var projectId = createdProject.Id;
            var noteId = Guid.NewGuid();

            var updateNoteRequest = new UpdateProjectNoteRequest
            {
                Note = _autoFixture.Create<string>()
            };

            var updateResponse = await _client.PatchAsync(string.Format(RouteConstants.ProjectNoteById, projectId, noteId), updateNoteRequest.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var content = await updateResponse.Content.ReadAsStringAsync();
            content.Should().Contain($"Project with id {projectId}, note with id {noteId} not found");
        }

        [Fact]
        public async Task DeleteProjectNote_NoteNotFound_Returns_404()
        {
            var createdProject = await _client.CreateTransferProject();
            var projectId = createdProject.Id;
            var noteId = Guid.NewGuid();

            var deleteResponse = await _client.DeleteAsync(string.Format(RouteConstants.ProjectNoteById, projectId, noteId));
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var content = await deleteResponse.Content.ReadAsStringAsync();
            content.Should().Contain($"Project with id {projectId}, note with id {noteId} not found");
        }

        [Fact]
        public async Task GetProjectList_ProjectNotFound_Returns_404()
        {
            var projectId = Guid.NewGuid();

            var getResponse = await _client.GetAsync(string.Format(RouteConstants.ProjectNote, projectId));
            getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var content = await getResponse.Content.ReadAsStringAsync();
            content.Should().Contain($"Project with id {projectId} not found");
        }

        private async Task<GetProjectNoteResponse> CreateProjectNote(Guid projectId)
        {
            var createNoteRequest = new CreateProjectNoteRequest
            {
                Note = _autoFixture.Create<string>(),
                Email = _testFixture.DefaultUser.Email
            };

            var createResponse = await _client.PostAsync(string.Format(RouteConstants.ProjectNote, projectId), createNoteRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var createdNote = await createResponse.Content.ReadFromJsonAsync<CreateProjectNoteResponse>();

            var getResponse = await _client.GetAsync(string.Format(RouteConstants.ProjectNoteById, projectId, createdNote.Id));
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = await getResponse.Content.ReadFromJsonAsync<GetProjectNoteResponse>();

            return result;
        }
    }
}

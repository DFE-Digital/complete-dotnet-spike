using Azure.Core;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.PupilNumbers;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class PupilNumbersApiTests : ApiTestsBase
    {
        public PupilNumbersApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task When_PupilNumbers_CapacityWhenFull_Returns_200()
        {
            var project = await CreateProject();
            var projectId = project.ProjectStatusProjectId;

            var updatePupilNumbersRequest = new UpdatePupilNumbersRequest()
            {
                CapacityWhenFull = new()
                {
                    Nursery = 10,
                    ReceptionToYear6 = 20,
                    Year7ToYear11 = 30,
                    Year12ToYear14 = 40,
                    SpecialEducationNeeds = 50,
                    AlternativeProvision = 60
                }
            };
            var content = await UpdatePupilNumbers(projectId, updatePupilNumbersRequest);

            var actualPupilNumbers = content.Data;

            // CapacityWhenFull
            actualPupilNumbers.CapacityWhenFull.Nursery.Should().Be(updatePupilNumbersRequest.CapacityWhenFull.Nursery);
            actualPupilNumbers.CapacityWhenFull.ReceptionToYear6.Should().Be(updatePupilNumbersRequest.CapacityWhenFull.ReceptionToYear6);
            actualPupilNumbers.CapacityWhenFull.Year7ToYear11.Should().Be(updatePupilNumbersRequest.CapacityWhenFull.Year7ToYear11);
            actualPupilNumbers.CapacityWhenFull.Year12ToYear14.Should().Be(updatePupilNumbersRequest.CapacityWhenFull.Year12ToYear14);
            actualPupilNumbers.CapacityWhenFull.SpecialEducationNeeds.Should().Be(updatePupilNumbersRequest.CapacityWhenFull.SpecialEducationNeeds);
            actualPupilNumbers.CapacityWhenFull.AlternativeProvision.Should().Be(updatePupilNumbersRequest.CapacityWhenFull.AlternativeProvision);
            actualPupilNumbers.SchoolName.Should().Be(project.ProjectStatusCurrentFreeSchoolName);

            actualPupilNumbers.CapacityWhenFull.Total.Should().Be(210);
        }

        [Fact]
        public async void When_PupilNumbers_Pre16PublishedAdmissionsNumber_Returns_200()
        {
            var project = await CreateProject();
            var projectId = project.ProjectStatusProjectId;

            var updatePupilNumbersRequest = new UpdatePupilNumbersRequest()
            {
                Pre16PublishedAdmissionNumber = new()
                {
                    Reception = 10,
                    Year7 = 20,
                    Year10 = 30,
                    OtherPre16 = 40
                }
            };

            var content = await UpdatePupilNumbers(projectId, updatePupilNumbersRequest);

            var actualPupilNumbers = content.Data;

            actualPupilNumbers.Pre16PublishedAdmissionNumber.Reception.Should().Be(updatePupilNumbersRequest.Pre16PublishedAdmissionNumber.Reception);
            actualPupilNumbers.Pre16PublishedAdmissionNumber.Year7.Should().Be(updatePupilNumbersRequest.Pre16PublishedAdmissionNumber.Year7);
            actualPupilNumbers.Pre16PublishedAdmissionNumber.Year10.Should().Be(updatePupilNumbersRequest.Pre16PublishedAdmissionNumber.Year10);
            actualPupilNumbers.Pre16PublishedAdmissionNumber.OtherPre16.Should().Be(updatePupilNumbersRequest.Pre16PublishedAdmissionNumber.OtherPre16);

            actualPupilNumbers.Pre16PublishedAdmissionNumber.Total.Should().Be(100);
        }

        [Fact]
        public async void When_PupilNumbers_Post16PublishedAdmissionsNumber_Returns_200()
        {
            var project = await CreateProject();
            var projectId = project.ProjectStatusProjectId;

            var updatePupilNumbersRequest = new UpdatePupilNumbersRequest()
            {
                Post16PublishedAdmissionNumber = new()
                {
                    Year12 = 10,
                    OtherPost16 = 20
                }
            };

            var content = await UpdatePupilNumbers(projectId, updatePupilNumbersRequest);

            var actualPupilNumbers = content.Data;

            actualPupilNumbers.Post16PublishedAdmissionNumber.Year12.Should().Be(updatePupilNumbersRequest.Post16PublishedAdmissionNumber.Year12);
            actualPupilNumbers.Post16PublishedAdmissionNumber.OtherPost16.Should().Be(updatePupilNumbersRequest.Post16PublishedAdmissionNumber.OtherPost16);

            actualPupilNumbers.Post16PublishedAdmissionNumber.Total.Should().Be(30);
        }

        [Fact]
        public async void When_PupilNumbers_Pre16CapacityBuildup_Returns_200()
        {
            var project = await CreateProject();
            var projectId = project.ProjectStatusProjectId;

            var updatePupilNumbersRequest = new UpdatePupilNumbersRequest()
            {
                Pre16CapacityBuildup = new()
                {
                    Nursery = new()
                    {
                        CurrentCapacity = 11,
                        FirstYear = 21,
                        SecondYear = 31,
                        ThirdYear = 41,
                        FourthYear = 51,
                        FifthYear = 61,
                        SixthYear = 71,
                        SeventhYear = 81
                    },
                    Reception = new()
                    {
                        CurrentCapacity = 12,
                        FirstYear = 22,
                        SecondYear = 32,
                        ThirdYear = 42,
                        FourthYear = 52,
                        FifthYear = 62,
                        SixthYear = 72,
                        SeventhYear = 82
                    },
                    Year1 = new()
                    {
                        CurrentCapacity = 13,
                        FirstYear = 23,
                        SecondYear = 33,
                        ThirdYear = 43,
                        FourthYear = 53,
                        FifthYear = 63,
                        SixthYear = 73,
                        SeventhYear = 83
                    },
                    Year2 = new()
                    {
                        CurrentCapacity = 14,
                        FirstYear = 24,
                        SecondYear = 34,
                        ThirdYear = 44,
                        FourthYear = 54,
                        FifthYear = 64,
                        SixthYear = 74,
                        SeventhYear = 84
                    },
                    Year3 = new()
                    {
                        CurrentCapacity = 15,
                        FirstYear = 25,
                        SecondYear = 35,
                        ThirdYear = 45,
                        FourthYear = 55,
                        FifthYear = 65,
                        SixthYear = 75,
                        SeventhYear = 85
                    },
                    Year4 = new()
                    {
                        CurrentCapacity = 16,
                        FirstYear = 26,
                        SecondYear = 36,
                        ThirdYear = 46,
                        FourthYear = 56,
                        FifthYear = 66,
                        SixthYear = 76,
                        SeventhYear = 86
                    },
                    Year5 = new()
                    {
                        CurrentCapacity = 17,
                        FirstYear = 27,
                        SecondYear = 37,
                        ThirdYear = 47,
                        FourthYear = 57,
                        FifthYear = 67,
                        SixthYear = 77,
                        SeventhYear = 87
                    },
                    Year6 = new()
                    {
                        CurrentCapacity = 18,
                        FirstYear = 28,
                        SecondYear = 38,
                        ThirdYear = 48,
                        FourthYear = 58,
                        FifthYear = 68,
                        SixthYear = 78,
                        SeventhYear = 88
                    },
                    Year7 = new() 
                    {
                        CurrentCapacity = 19,
                        FirstYear = 29,
                        SecondYear = 39,
                        ThirdYear = 49,
                        FourthYear = 59,
                        FifthYear = 69,
                        SixthYear = 79,
                        SeventhYear = 89
                    },
                    Year8 = new()
                    {
                        CurrentCapacity = 20,
                        FirstYear = 30,
                        SecondYear = 40,
                        ThirdYear = 50,
                        FourthYear = 60,
                        FifthYear = 70,
                        SixthYear = 80,
                        SeventhYear = 90
                    },
                    Year9 = new()
                    {
                        CurrentCapacity = 21,
                        FirstYear = 31,
                        SecondYear = 41,
                        ThirdYear = 51,
                        FourthYear = 61,
                        FifthYear = 71,
                        SixthYear = 81,
                        SeventhYear = 91
                    },
                    Year10 = new()
                    {
                        CurrentCapacity = 22,
                        FirstYear = 32,
                        SecondYear = 42,
                        ThirdYear = 52,
                        FourthYear = 62,
                        FifthYear = 72,
                        SixthYear = 82,
                        SeventhYear = 92
                    },
                    Year11 = new()
                    {
                        CurrentCapacity = 23,
                        FirstYear = 33,
                        SecondYear = 43,
                        ThirdYear = 53,
                        FourthYear = 63,
                        FifthYear = 73,
                        SixthYear = 83,
                        SeventhYear = 93
                    }
                }
            };

            var content = await UpdatePupilNumbers(projectId, updatePupilNumbersRequest);

            var actualPupilNumbers = content.Data;

            actualPupilNumbers.Pre16CapacityBuildup.Nursery.Should().BeEquivalentTo(updatePupilNumbersRequest.Pre16CapacityBuildup.Nursery);
            actualPupilNumbers.Pre16CapacityBuildup.Reception.Should().BeEquivalentTo(updatePupilNumbersRequest.Pre16CapacityBuildup.Reception);
            actualPupilNumbers.Pre16CapacityBuildup.Year1.Should().BeEquivalentTo(updatePupilNumbersRequest.Pre16CapacityBuildup.Year1);
            actualPupilNumbers.Pre16CapacityBuildup.Year2.Should().BeEquivalentTo(updatePupilNumbersRequest.Pre16CapacityBuildup.Year2);
            actualPupilNumbers.Pre16CapacityBuildup.Year3.Should().BeEquivalentTo(updatePupilNumbersRequest.Pre16CapacityBuildup.Year3);
            actualPupilNumbers.Pre16CapacityBuildup.Year4.Should().BeEquivalentTo(updatePupilNumbersRequest.Pre16CapacityBuildup.Year4);
            actualPupilNumbers.Pre16CapacityBuildup.Year5.Should().BeEquivalentTo(updatePupilNumbersRequest.Pre16CapacityBuildup.Year5);
            actualPupilNumbers.Pre16CapacityBuildup.Year6.Should().BeEquivalentTo(updatePupilNumbersRequest.Pre16CapacityBuildup.Year6);
            actualPupilNumbers.Pre16CapacityBuildup.Year7.Should().BeEquivalentTo(updatePupilNumbersRequest.Pre16CapacityBuildup.Year7);
            actualPupilNumbers.Pre16CapacityBuildup.Year8.Should().BeEquivalentTo(updatePupilNumbersRequest.Pre16CapacityBuildup.Year8);
            actualPupilNumbers.Pre16CapacityBuildup.Year9.Should().BeEquivalentTo(updatePupilNumbersRequest.Pre16CapacityBuildup.Year9);
            actualPupilNumbers.Pre16CapacityBuildup.Year10.Should().BeEquivalentTo(updatePupilNumbersRequest.Pre16CapacityBuildup.Year10);
            actualPupilNumbers.Pre16CapacityBuildup.Year11.Should().BeEquivalentTo(updatePupilNumbersRequest.Pre16CapacityBuildup.Year11);

            actualPupilNumbers.Pre16CapacityBuildup.Total.CurrentCapacity.Should().Be(221);
            actualPupilNumbers.Pre16CapacityBuildup.Total.FirstYear.Should().Be(351);
            actualPupilNumbers.Pre16CapacityBuildup.Total.SecondYear.Should().Be(481);
            actualPupilNumbers.Pre16CapacityBuildup.Total.ThirdYear.Should().Be(611);
            actualPupilNumbers.Pre16CapacityBuildup.Total.FourthYear.Should().Be(741);
            actualPupilNumbers.Pre16CapacityBuildup.Total.FifthYear.Should().Be(871);
            actualPupilNumbers.Pre16CapacityBuildup.Total.SixthYear.Should().Be(1001);
            actualPupilNumbers.Pre16CapacityBuildup.Total.SeventhYear.Should().Be(1131);
        }

        [Fact]
        public async void When_PupilNumbers_Post16CapacityBuildup_Returns_200()
        {
            var project = await CreateProject();
            var projectId = project.ProjectStatusProjectId;

            var updatePupilNumbersRequest = new UpdatePupilNumbersRequest()
            {
                Post16CapacityBuildup = new()
                {
                    Year12 = new()
                    {
                        CurrentCapacity = 10,
                        FirstYear = 20,
                        SecondYear = 30,
                        ThirdYear = 40,
                        FourthYear = 50,
                        FifthYear = 60,
                        SixthYear = 70,
                        SeventhYear = 80
                    },
                    Year13 = new()
                    {
                        CurrentCapacity = 11,
                        FirstYear = 21,
                        SecondYear = 31,
                        ThirdYear = 41,
                        FourthYear = 51,
                        FifthYear = 61,
                        SixthYear = 71,
                        SeventhYear = 81
                    },
                    Year14 = new()
                    {
                        CurrentCapacity = 12,
                        FirstYear = 22,
                        SecondYear = 32,
                        ThirdYear = 42,
                        FourthYear = 52,
                        FifthYear = 62,
                        SixthYear = 72,
                        SeventhYear = 82
                    }
                }
            };

            var content = await UpdatePupilNumbers(projectId, updatePupilNumbersRequest);

            var actualPupilNumbers = content.Data;

            actualPupilNumbers.Post16CapacityBuildup.Year12.Should().BeEquivalentTo(updatePupilNumbersRequest.Post16CapacityBuildup.Year12);
            actualPupilNumbers.Post16CapacityBuildup.Year13.Should().BeEquivalentTo(updatePupilNumbersRequest.Post16CapacityBuildup.Year13);
            actualPupilNumbers.Post16CapacityBuildup.Year14.Should().BeEquivalentTo(updatePupilNumbersRequest.Post16CapacityBuildup.Year14);

            actualPupilNumbers.Post16CapacityBuildup.Total.CurrentCapacity.Should().Be(33);
            actualPupilNumbers.Post16CapacityBuildup.Total.FirstYear.Should().Be(63);
            actualPupilNumbers.Post16CapacityBuildup.Total.SecondYear.Should().Be(93);
            actualPupilNumbers.Post16CapacityBuildup.Total.ThirdYear.Should().Be(123);
            actualPupilNumbers.Post16CapacityBuildup.Total.FourthYear.Should().Be(153);
            actualPupilNumbers.Post16CapacityBuildup.Total.FifthYear.Should().Be(183);
            actualPupilNumbers.Post16CapacityBuildup.Total.SixthYear.Should().Be(213);
            actualPupilNumbers.Post16CapacityBuildup.Total.SeventhYear.Should().Be(243);
        }

        [Fact]
        public async void When_PupilNumbers_RecruitmentAndViability_Returns_200()
        {
            var project = await CreateProject();
            var projectId = project.ProjectStatusProjectId;

            var updateRecruitmentAndViabilityRequest = new UpdatePupilNumbersRequest()
            {
                RecruitmentAndViability = new RecruitmentAndViability()
                {
                    ReceptionToYear6 = new RecruitmentAndViabilityEntry()
                    {
                        MinimumViableNumber = 10,
                        ApplicationsReceived = 5
                    },
                    Year7ToYear11 = new RecruitmentAndViabilityEntry()
                    {
                        MinimumViableNumber = 3,
                        ApplicationsReceived = 10
                    },
                    Year12ToYear14 = new RecruitmentAndViabilityEntry()
                    {
                        MinimumViableNumber = 15,
                        ApplicationsReceived = 19
                    }
                }
            };

            var content = await UpdatePupilNumbers(projectId, updateRecruitmentAndViabilityRequest);

            var actualPupilNumbers = content.Data;

            actualPupilNumbers.RecruitmentAndViability.ReceptionToYear6.Should().BeEquivalentTo(updateRecruitmentAndViabilityRequest.RecruitmentAndViability.ReceptionToYear6);
            actualPupilNumbers.RecruitmentAndViability.ReceptionToYear6.PercentageComparedToMinimumViable.Should().Be(50);
            actualPupilNumbers.RecruitmentAndViability.ReceptionToYear6.PercentageComparedToPublishedAdmissionNumber.Should().Be(0);

            actualPupilNumbers.RecruitmentAndViability.Year7ToYear11.Should().BeEquivalentTo(updateRecruitmentAndViabilityRequest.RecruitmentAndViability.Year7ToYear11);
            actualPupilNumbers.RecruitmentAndViability.Year7ToYear11.PercentageComparedToMinimumViable.Should().Be(333.33m);
            actualPupilNumbers.RecruitmentAndViability.Year7ToYear11.PercentageComparedToPublishedAdmissionNumber.Should().Be(0);

            actualPupilNumbers.RecruitmentAndViability.Year12ToYear14.Should().BeEquivalentTo(updateRecruitmentAndViabilityRequest.RecruitmentAndViability.Year12ToYear14);
            actualPupilNumbers.RecruitmentAndViability.Year12ToYear14.PercentageComparedToMinimumViable.Should().Be(126.67m);
            actualPupilNumbers.RecruitmentAndViability.Year12ToYear14.PercentageComparedToPublishedAdmissionNumber.Should().Be(0);

            actualPupilNumbers.RecruitmentAndViability.Total.MinimumViableNumber.Should().Be(28);
            actualPupilNumbers.RecruitmentAndViability.Total.ApplicationsReceived.Should().Be(34);

            var updatePanRequest = new UpdatePupilNumbersRequest()
            {
                Pre16PublishedAdmissionNumber = new()
                {
                    Reception = 16,
                    Year7 = 20,
                    Year10 = 30,
                    OtherPre16 = 40
                },
                Post16PublishedAdmissionNumber = new()
                {
                    Year12 = 10,
                    OtherPost16 = 20
                },
            };

            content = await UpdatePupilNumbers(projectId, updatePanRequest);

            actualPupilNumbers = content.Data;

            actualPupilNumbers.RecruitmentAndViability.ReceptionToYear6.PercentageComparedToPublishedAdmissionNumber.Should().Be(31.25m);
            actualPupilNumbers.RecruitmentAndViability.Year7ToYear11.PercentageComparedToPublishedAdmissionNumber.Should().Be(11.11m);
            actualPupilNumbers.RecruitmentAndViability.Year12ToYear14.PercentageComparedToPublishedAdmissionNumber.Should().Be(63.33m);
        }

        [Fact]
        public async void When_PupilNumbers_NoProjectExists_Returns_404()
        {
            var updatePupilNumbersRequest = _autoFixture.Create<UpdatePupilNumbersRequest>();

            var updatePupilNumbersResponse = await _client.PatchAsync($"/api/v1/client/projects/NotExist/pupil-numbers", updatePupilNumbersRequest.ConvertToJson());
            updatePupilNumbersResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var getPupilNumbersResponse = await _client.GetAsync($"/api/v1/client/projects/NotExist/pupil-numbers");
            getPupilNumbersResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Making sure if we receive blank the API does not break
        /// </summary>
        [Fact]
        public async void When_UpdateWithEmpty_Returns_200()
        {
            var project = await CreateProject();
            var projectId = project.ProjectStatusProjectId;

            var updatePupilNumbersRequest = new UpdatePupilNumbersRequest()
            {
                CapacityWhenFull = new(),
                Pre16PublishedAdmissionNumber = new(),
                Post16PublishedAdmissionNumber = new(),
                RecruitmentAndViability = new(),
                Pre16CapacityBuildup = new(),
                Post16CapacityBuildup = new()
            };

            // CapacityWhenFull
            var updatePupilNumbersResponse = await _client.PatchAsync($"/api/v1/client/projects/{projectId}/pupil-numbers", updatePupilNumbersRequest.ConvertToJson());
            updatePupilNumbersResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        /// <summary>
        /// PO entry does not exist, should return a 200
        /// This can happen in cases we migrate from KIM
        /// </summary>
        [Fact]
        public async void When_PupilNumbers_GetWithNoPupilNumbers_Returns_200()
        {
            var project = await CreateProject();
            var projectId = project.ProjectStatusProjectId;

            var getPupilNumbersResponse = await _client.GetAsync($"/api/v1/client/projects/{projectId}/pupil-numbers");
            getPupilNumbersResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await getPupilNumbersResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<GetPupilNumbersResponse>>();

            var actualPupilNumbers = content.Data;
            actualPupilNumbers.CapacityWhenFull.Should().NotBeNull();
            actualPupilNumbers.Pre16PublishedAdmissionNumber.Should().NotBeNull();
            actualPupilNumbers.Post16PublishedAdmissionNumber.Should().NotBeNull();
            actualPupilNumbers.RecruitmentAndViability.Should().NotBeNull();
            actualPupilNumbers.Pre16CapacityBuildup.Should().NotBeNull();
            actualPupilNumbers.Post16CapacityBuildup.Should().NotBeNull();
        }

        private async Task<Kpi> CreateProject()
        {
            var project = DatabaseModelBuilder.BuildProject();

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            return project;
        }

        private async Task<ApiSingleResponseV2<GetPupilNumbersResponse>> UpdatePupilNumbers(string projectId, UpdatePupilNumbersRequest updatePupilNumbersRequest)
        {
            var updatePupilNumbersResponse = await _client.PatchAsync($"/api/v1/client/projects/{projectId}/pupil-numbers", updatePupilNumbersRequest.ConvertToJson());
            updatePupilNumbersResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getPupilNumbersResponse = await _client.GetAsync($"/api/v1/client/projects/{projectId}/pupil-numbers");
            getPupilNumbersResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await getPupilNumbersResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<GetPupilNumbersResponse>>();
            return content;
        }
    }
}

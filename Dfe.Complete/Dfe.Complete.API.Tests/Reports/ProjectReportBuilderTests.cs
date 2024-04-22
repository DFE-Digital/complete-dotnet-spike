using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Reports;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Reports
{
    public class ProjectReportBuilderTests
    {
        [Fact]
        public void Build_ReturnsProjectReport()
        {
            // Arrange
            var sourceData = BuildSourceData();

            // Act
            var result = ProjectReportBuilder.Build(sourceData);

            var taskHeaders = result.Headers.Select(h => h.TaskName).ToList();
            var sectionHeaders = result.Headers.Select(h => h.Section).ToList();
            var columnHeaders = result.Headers.Select(h => h.ColumnName).ToList();

			taskHeaders.Should().Contain("Reference data");
			taskHeaders.Should().Contain("Dates");
            taskHeaders.Should().Contain("School");
            taskHeaders.Should().Contain("Trust");
            taskHeaders.Should().Contain("Region and local authority");
            taskHeaders.Should().Contain("Constituency");
            taskHeaders.Should().Contain("Risk appraisal meeting");
            taskHeaders.Should().Contain("Kick-off meeting");
            taskHeaders.Should().Contain("Model funding agreement");
            taskHeaders.Should().Contain("Funding agreement health check");
            taskHeaders.Should().Contain("Articles of association");
            taskHeaders.Should().Contain("Draft governance plan");
            taskHeaders.Should().Contain("Finance plan");
            taskHeaders.Should().Contain("Final finance plan");
            taskHeaders.Should().Contain("Gias");
            taskHeaders.Should().Contain("Education brief");
            taskHeaders.Should().Contain("Impact assessment");
            taskHeaders.Should().Contain("Equalities assessment");
            taskHeaders.Should().Contain("Statutory consultation");
            taskHeaders.Should().Contain("Accepted offers evidence");

            sectionHeaders.Should().Contain("About the project");
            sectionHeaders.Should().Contain("Setting-up");
            sectionHeaders.Should().Contain("Pre-opening");
            sectionHeaders.Should().Contain("Sign-off preparation");
            sectionHeaders.Should().Contain("Getting ready to open");

            result.Projects.Count.Should().Be(1);

            var project = result.Projects.First();

            AssertEntry(nameof(ProjectReferenceData.ProjectId), "123", project, columnHeaders);
            AssertEntry(nameof(DatesTask.DateOfEntryIntoPreopening), "01/01/2021", project, columnHeaders);
            AssertEntry(nameof(DatesTask.ProvisionalOpeningDateAgreedWithTrust), "EMPTY", project, columnHeaders);
            AssertEntry(nameof(SchoolTask.Gender), "Boys only", project, columnHeaders);
            AssertEntry(nameof(SchoolTask.FaithType), "EMPTY", project, columnHeaders);
            AssertEntry(nameof(TrustTask.TrustName), "Test school", project, columnHeaders);
            AssertEntry(nameof(RegionAndLocalAuthorityTask.LocalAuthorityCode), "123", project, columnHeaders);
            AssertEntry(nameof(ConstituencyTask.Name), "Sheffield", project, columnHeaders);
            AssertEntry(nameof(RiskAppraisalMeetingTask.InitialRiskAppraisalMeetingCompleted), "No", project, columnHeaders);
            AssertEntry(nameof(KickOffMeetingTask.FundingArrangementAgreed), "Yes", project, columnHeaders);
            AssertEntry(nameof(ArticlesOfAssociationTask.ChairHaveSubmittedConfirmation), "No", project, columnHeaders);
            AssertEntry(nameof(FinancePlanTask.RpaCoverType), "Cover", project, columnHeaders);
            AssertEntry(nameof(FinalFinancePlanTask.Grade6SignedOffFinalPlanDate), "01/01/2023", project, columnHeaders);
            AssertEntry(nameof(DraftGovernancePlanTask.PlanFedBackToTrust), "No", project, columnHeaders);
			AssertEntry(nameof(ModelFundingAgreementTask.SharedFAWithTheTrust), "Yes", project, columnHeaders);
            AssertEntry(nameof(FundingAgreementHealthCheckTask.DraftedFundingAgreementHealthCheck), "Yes", project, columnHeaders);
            AssertEntry(nameof(GiasTask.CheckedTrustInformation), "Yes", project, columnHeaders);
            AssertEntry(nameof(EducationBriefTask.EducationPlanInEducationBrief), "Yes", project, columnHeaders);
            AssertEntry(nameof(AdmissionsArrangementsTask.TrustConfirmedAdmissionsArrangementsTemplate), "Yes", project, columnHeaders);
            AssertEntry(nameof(ImpactAssessmentTask.ImpactAssessment), "Yes", project, columnHeaders);
            AssertEntry(nameof(EqualitiesAssessmentTask.CompletedEqualitiesProcessRecord), "Yes", project, columnHeaders);
            AssertEntry(nameof(EvidenceOfAcceptedOffersTask.EvidenceOfAcceptedOffers), "Yes" , project, columnHeaders);
            AssertEntry(nameof(OfstedInspectionTask.InspectionBlockDecided), "Yes" , project, columnHeaders);
            AssertEntry(nameof(ApplicationsEvidenceTask.ConfirmedPupilNumbers), "Yes" , project, columnHeaders);
        }

        private static List<ProjectReportSourceData> BuildSourceData()
        {
            var result = new List<ProjectReportSourceData>()
            {
                new ProjectReportSourceData()
                {
                    ProjectReferenceData = new ProjectReferenceData()
                    {
                        ProjectId = "123",
                    },
                    TaskInformation = new GetProjectByTaskResponse()
                    {
                        Dates = new DatesTask()
                        {
                            DateOfEntryIntoPreopening = new DateTime(2021, 1, 1),
                        },
                        School = new SchoolTask()
                        {
                            Gender = Gender.BoysOnly,
                            FaithType = FaithType.NotSet
                        },
                        Trust = new TrustTask()
                        {
                            TrustName = "Test school"
                        },
                        RegionAndLocalAuthority = new RegionAndLocalAuthorityTask()
                        {
                            LocalAuthorityCode = "123",
                        },
                        Constituency = new ConstituencyTask()
                        {
                            Name = "Sheffield",
                        },
                        RiskAppraisalMeeting = new RiskAppraisalMeetingTask()
                        {
                            InitialRiskAppraisalMeetingCompleted = false,
                        },
                        KickOffMeeting = new KickOffMeetingTask()
                        {
                            FundingArrangementAgreed = true,
                        },
                        ArticlesOfAssociation = new ArticlesOfAssociationTask()
                        {
                            ChairHaveSubmittedConfirmation = false,
                        },
                        FinancePlan = new FinancePlanTask()
                        {
                            RpaCoverType = "Cover",
                        },
                        DraftGovernancePlan = new DraftGovernancePlanTask()
                        {
							PlanFedBackToTrust = false,
						},
                        ModelFundingAgreement = new ModelFundingAgreementTask()
                        {
							SharedFAWithTheTrust = true
						},
                        FundingAgreementHealthCheck = new FundingAgreementHealthCheckTask()
                        {
                            DraftedFundingAgreementHealthCheck = true
                        },
                        Gias = new GiasTask()
                        {
                            CheckedTrustInformation = true
                        },
                        EducationBrief = new EducationBriefTask()
                        {
                            EducationPlanInEducationBrief = true
                        },
                        AdmissionsArrangements = new AdmissionsArrangementsTask()
                        {
                            TrustConfirmedAdmissionsArrangementsTemplate = true
                        },
                        ImpactAssessment = new ImpactAssessmentTask()
                        {
                            ImpactAssessment = true
                        },
                        EqualitiesAssessment = new EqualitiesAssessmentTask()
                        {
                            CompletedEqualitiesProcessRecord = true
                        },
                        StatutoryConsultation = new StatutoryConsultationTask()
                        {
                            ExpectedDateForReceivingFindingsFromTrust = new DateTime(2024, 1, 1),
                        },
                        EvidenceOfAcceptedOffers = new EvidenceOfAcceptedOffersTask()
                        {
                            EvidenceOfAcceptedOffers = true,
                        },
                        OfstedInspection = new OfstedInspectionTask()
                        {
                            InspectionBlockDecided = true,
                        },
                        ApplicationsEvidence = new ApplicationsEvidenceTask()
                        {
                            ConfirmedPupilNumbers = true,
                        },
                        FinalFinancePlan = new FinalFinancePlanTask()
                        {
                            Grade6SignedOffFinalPlanDate = new DateTime(2023, 1, 1),
                        },

                    }
                }
            };

            return result;
        }

        private static void AssertEntry(
            string propertyName, 
            string expectedValue,
            ProjectDataRow project,
            List<string> columnHeaders)
        {
            columnHeaders.Should().Contain(propertyName);
            var columnIndex = columnHeaders.IndexOf(propertyName);
            project.Values[columnIndex].Value.Should().Be(expectedValue);
        }
    }
}

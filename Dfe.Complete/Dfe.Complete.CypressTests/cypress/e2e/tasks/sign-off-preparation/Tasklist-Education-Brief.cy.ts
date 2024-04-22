import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import summaryPage from "cypress/pages/task-summary-base";
import taskListPage from "cypress/pages/taskListPage";
import educationBriefEditPage from "../../../pages/tasks/sign-off-preparation/edit-education-brief.cy";
import riskPage from "cypress/pages/risk/projectRiskSummaryPage"

describe("Testing education brief", () => {

    let project: ProjectDetailsRequest;

    beforeEach(() => {
        cy.login();

        project = RequestBuilder.createProjectDetails();

        projectApi
            .post({
                projects: [project],
            })
            .then(() => {
                cy.visit(`/projects/${project.projectId}/tasks`);
            });
    });

    it("Should successfully set education brief task", () => {

        cy.log("education brief");
        taskListPage.isTaskStatusIsNotStarted("EducationBrief")
            .selectEducationBriefFromList();
        
        cy.log("Confirm empty education brief");
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Education brief")
            .inOrder()
            .summaryShows("Education plan is in the education brief").IsEmpty().HasChangeLink()
            .summaryShows("Education policies are in the education brief").IsEmpty().HasChangeLink()
            .summaryShows("Pupil assessment and tracking history are in place").IsEmpty().HasChangeLink()
            .summaryShows("Saved documents in Workplaces folder").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete();


        cy.executeAccessibilityTests();
        cy.log("Go back to task list");
        summaryPage.clickBack();

        cy.log("Confirm not started and open education brief");
        taskListPage.isTaskStatusIsNotStarted("EducationBrief")
            .selectEducationBriefFromList()

        cy.log("Check confirm puts project in In Progress");
        summaryPage.clickConfirmAndContinue();

        taskListPage.isTaskStatusInProgress("EducationBrief")
            .selectEducationBriefFromList()

        cy.log("Check education brief page");

        summaryPage.clickChange();

        cy.executeAccessibilityTests

        educationBriefEditPage
            .checkEducationPlanInBrief()
            .checkEducationPoliciesInBrief()
            .checkAssessmentAndTrackingHistoryInPlace()
            .checkCopySavedToWorkspaces()
            .clickContinue()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Education brief")
            .inOrder()
            .summaryShows("Education plan is in the education brief").HasValue("Yes").HasChangeLink()
            .summaryShows("Education policies are in the education brief").HasValue("Yes").HasChangeLink()
            .summaryShows("Pupil assessment and tracking history are in place").HasValue("Yes").HasChangeLink()
            .summaryShows("Saved documents in Workplaces folder").HasValue("Yes").HasChangeLink()
            .isNotMarkedAsComplete();

        cy.log("uncheck education brief page");

        summaryPage.clickChange();

        cy.executeAccessibilityTests

        educationBriefEditPage
            .uncheckEducationPlanInBrief()
            .uncheckEducationPoliciesInBrief()
            .uncheckAssessmentAndTrackingHistoryInPlace()
            .uncheckCopySavedToWorkspaces()
            .clickContinue()
            .MarkAsComplete()
            .clickConfirmAndContinue()

        taskListPage
            .selectEducationBriefFromList()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Education brief")
            .inOrder()
            .summaryShows("Education plan is in the education brief").IsEmpty().HasChangeLink()
            .summaryShows("Education policies are in the education brief").IsEmpty().HasChangeLink()
            .summaryShows("Pupil assessment and tracking history are in place").IsEmpty().HasChangeLink()
            .summaryShows("Saved documents in Workplaces folder").IsEmpty().HasChangeLink()
            .isMarkedAsComplete()

        cy.log("click on risk link");
        
        summaryPage
            .clickChangeRiskRating()

        riskPage
            .hasSchoolName(project.schoolName)
            .hasTitle("Current risk ratings")
            .hasOverallRiskRating(["Empty"])
    })
})
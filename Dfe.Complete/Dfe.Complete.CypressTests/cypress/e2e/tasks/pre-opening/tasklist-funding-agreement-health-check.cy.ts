import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import summaryPage from "cypress/pages/task-summary-base";
import taskListPage from "cypress/pages/taskListPage";
import fundingAgreementHealthCheckEditPage from "../../../pages/tasks/pre-opening/edit-funding-agreement-health-check.cy";

describe("Testing Funding agreement health check Task", () => {

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

    it("Should successfully set funding agreement health check task", () => {

        cy.log("Select funding agreement heakth check");
        taskListPage.isTaskStatusIsNotStarted("FundingAgreementHealthCheck")
            .selectFundingAgreementHealthCheckFromTaskList();

        cy.log("Confirm empty funding agreement health check");

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Funding agreement health check")
            .inOrder()
            .summaryShows("Drafted a funding agreement (FA) health check").IsEmpty().HasChangeLink()
            .summaryShows("Regional Director has signed-off the FA health check (if applicable)").IsEmpty().HasChangeLink()
            .summaryShows("Minister has signed-off the FA health check (if applicable)").IsEmpty().HasChangeLink()
            .summaryShows("Saved the health check in Workplaces folder").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete();


        cy.executeAccessibilityTests();
        cy.log("Go back to task list");
        summaryPage.clickBack();

        cy.log("Confirm not started and open funding agreement health check");
        taskListPage.isTaskStatusIsNotStarted("FundingAgreementHealthCheck")
            .selectFundingAgreementHealthCheckFromTaskList();

        cy.log("Check confirm puts project in In Progress");
        summaryPage.clickConfirmAndContinue();

        taskListPage.isTaskStatusInProgress("FundingAgreementHealthCheck")
            .selectFundingAgreementHealthCheckFromTaskList();

        cy.log("Check search page");

        summaryPage.clickChange();

        cy.executeAccessibilityTests({ "aria-allowed-attr": { enabled: false } });

        cy.log("Fill in funding arrangement health check")

        fundingAgreementHealthCheckEditPage
            .checkDraftedFAHealthCheck()
            .checkMinisterSignedOffFAHealthCheck()
            .clickContinue()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Funding agreement health check")
            .inOrder()
            .summaryShows("Drafted a funding agreement (FA) health check").HasValue("Yes").HasChangeLink()
            .summaryShows("Regional Director has signed-off the FA health check (if applicable)").HasValue("No").HasChangeLink()
            .summaryShows("Minister has signed-off the FA health check (if applicable)").HasValue("Yes").HasChangeLink()
            .summaryShows("Saved the health check in Workplaces folder").HasValue("No").HasChangeLink()
            .isNotMarkedAsComplete();

        cy.log("Edit funding agreement health check")
       
        summaryPage.clickChange();
        fundingAgreementHealthCheckEditPage
            .uncheckMinisterSignedOffFAHealthCheck()
            .checkRegionalDirectorSignedOffFAHealthCheck()
            .checkSavedFAHealthCheckInWorkplacesFolder()
            .clickContinue()
            

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Funding agreement health check")
            .inOrder()
            .summaryShows("Drafted a funding agreement (FA) health check").HasValue("Yes").HasChangeLink()
            .summaryShows("Regional Director has signed-off the FA health check (if applicable)").HasValue("Yes").HasChangeLink()
            .summaryShows("Minister has signed-off the FA health check (if applicable)").HasValue("No").HasChangeLink()
            .summaryShows("Saved the health check in Workplaces folder").HasValue("Yes").HasChangeLink()
            .isNotMarkedAsComplete()
            .MarkAsComplete()
            .clickConfirmAndContinue()

        taskListPage
            .selectFundingAgreementHealthCheckFromTaskList()
        
        summaryPage.isMarkedAsComplete()
    })
    
    
    
})
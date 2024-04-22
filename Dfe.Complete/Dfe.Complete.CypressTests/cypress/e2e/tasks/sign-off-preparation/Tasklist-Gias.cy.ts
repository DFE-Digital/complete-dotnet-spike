import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import summaryPage from "cypress/pages/task-summary-base";
import taskListPage from "cypress/pages/taskListPage";
import giasEditPage from "../../../pages/tasks/sign-off-preparation/edit-gias.cy";

describe("Testing gias", () => {

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

    it("Should successfully set gias task", () => {

        cy.log("Select gias");
        taskListPage.isTaskStatusIsNotStarted("Gias")
            .selectGiasFromTaskList();

        cy.log("Confirm empty gias");

        cy.log("Confirm empty gias");
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Set up the school on GIAS (Get information about schools)")
            .inOrder()
            .summaryShows("Check the information on trusts' completed GIAS application form is correct").IsEmpty().HasChangeLink()
            .summaryShows("Send the application form to the Ofstedpre-reg.FreeSchools@education.gov.uk mailbox").IsEmpty().HasChangeLink()
            .summaryShows("Save a copy of the application form in Workplaces").IsEmpty().HasChangeLink()
            .summaryShows("Send the trust their URN and DfE establishment number").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete();


        cy.executeAccessibilityTests();
        cy.log("Go back to task list");
        summaryPage.clickBack();

        cy.log("Confirm not started and open gias");
        taskListPage.isTaskStatusIsNotStarted("Gias")
            .selectGiasFromTaskList();

        cy.log("Check confirm puts project in In Progress");
        summaryPage.clickConfirmAndContinue();

        taskListPage.isTaskStatusInProgress("Gias")
            .selectGiasFromTaskList()

        cy.log("Check gias page");

        summaryPage.clickChange();

        cy.executeAccessibilityTests
        
        giasEditPage
            .checkCheckTrustInformation()
            .checkApplicationFormSent()
            .checkCopySavedToWorkspaces()
            .checkSentTrustURN()
            .clickContinue()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Set up the school on GIAS (Get information about schools)")
            .inOrder()
            .summaryShows("Check the information on trusts' completed GIAS application form is correct").HasValue("Yes").HasChangeLink()
            .summaryShows("Send the application form to the Ofstedpre-reg.FreeSchools@education.gov.uk mailbox").HasValue("Yes").HasChangeLink()
            .summaryShows("Save a copy of the application form in Workplaces").HasValue("Yes").HasChangeLink()
            .summaryShows("Send the trust their URN and DfE establishment number").HasValue("Yes").HasChangeLink()
            .isNotMarkedAsComplete();

        cy.log("uncheck gias page");

        summaryPage.clickChange();

        cy.executeAccessibilityTests

        giasEditPage
            .unCheckCheckTrustInformation()
            .unCheckApplicationFormSent()
            .unCheckSentTrustURN()
            .unCheckCopySavedToWorkspaces()
            .clickContinue()
            .MarkAsComplete()
            .clickConfirmAndContinue()

        taskListPage
            .selectGiasFromTaskList()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Set up the school on GIAS (Get information about schools)")
            .inOrder()
            .summaryShows("Check the information on trusts' completed GIAS application form is correct").HasValue("No").HasChangeLink()
            .summaryShows("Send the application form to the Ofstedpre-reg.FreeSchools@education.gov.uk mailbox").HasValue("No").HasChangeLink()
            .summaryShows("Save a copy of the application form in Workplaces").HasValue("No").HasChangeLink()
            .summaryShows("Send the trust their URN and DfE establishment number").HasValue("No").HasChangeLink()
            .isMarkedAsComplete()

    })
})
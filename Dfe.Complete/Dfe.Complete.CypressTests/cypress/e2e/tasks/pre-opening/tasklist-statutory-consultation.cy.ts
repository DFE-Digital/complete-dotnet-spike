import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import summaryPage from "cypress/pages/task-summary-base";
import taskListPage from "cypress/pages/taskListPage";
import statutoryConsultationtEditPage from "../../../pages/tasks/pre-opening/edit-statutory-consultation.cy";
import validationComponent from "cypress/pages/validationComponent";

describe("Testing statutory consultation", () => {

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

    it("Should successfully set statutory consultation task", () => {

        cy.log("Select statutory consultation");
        taskListPage.isTaskStatusIsNotStarted("StatutoryConsultation")
            .selectStatutoryConsultationFromTaskList();

        cy.log("Go back to task list");
        summaryPage.clickBack();

        taskListPage.selectStatutoryConsultationFromTaskList();

        cy.log("Confirm empty statutory consultation");
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Statutory consultation")
            .inOrder()
            .summaryShows("Expected date for receiving findings from trust").IsEmpty().HasChangeLink()
            .summaryShows("Received consultation findings from trust").IsEmpty().HasChangeLink()
            .summaryShows("Date received").IsEmpty().HasChangeLink()
            .summaryShows("Consultation fulfils the trust's section 10 statutory duty").IsEmpty().HasChangeLink()
            .summaryShows("Comments").IsEmpty().HasChangeLink()
            .summaryShows("Saved findings in Workplaces folder").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete();

        cy.executeAccessibilityTests();

        summaryPage.clickChange();

        cy.log("Check all the fields are optional");
        statutoryConsultationtEditPage
            .titleIs("Edit Statutory consultation")
            .schoolNameIs(project.schoolName)
            .clickContinue();

        cy.log("Go back to task list");
        summaryPage.clickBack();

        cy.log("Check confirm puts project in In Progress");
        taskListPage.isTaskStatusInProgress("StatutoryConsultation")
            .selectStatutoryConsultationFromTaskList()


        cy.log("Add new values");
        summaryPage.clickChange();

        cy.log("Testing validation");
        statutoryConsultationtEditPage
            .withExpectedDateForReceivingFindingsFromTrust("2", "", "")
            .checkReceivedConsultationFindingsFromTrust()
            .withDateReceived("4", "", "")
            .withCommentsExceedingMaxLength()
            .clickContinue();

        validationComponent
            .hasValidationError("Date received must include a month and year")
            .hasValidationError("Expected date for receiving findings from trust must include a month and year")
            .hasValidationError("The comments must be 999 characters or less");

        cy.executeAccessibilityTests({ "aria-allowed-attr": { enabled: false } });

        statutoryConsultationtEditPage
            .schoolNameIs(project.schoolName)

        statutoryConsultationtEditPage
            .withExpectedDateForReceivingFindingsFromTrust("2", "3", "2020")
            .withDateReceived("4", "3", "2020")
            .checkConsultationFulfilsTrustSection10StatutoryDuty()
            .withComments("This is a comment")
            .checkSavedFindingsInWorkplacesFolder()
            .clickContinue();

        cy.log("Confirm new values for statutory consultation");
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Statutory consultation")
            .inOrder()
            .summaryShows("Expected date for receiving findings from trust").HasValue("2 March 2020")
            .summaryShows("Received consultation findings from trust").HasValue("Yes")
            .summaryShows("Date received").HasValue("4 March 2020")
            .summaryShows("Consultation fulfils the trust's section 10 statutory duty").HasValue("Yes")
            .summaryShows("Comments").HasValue("This is a comment")
            .summaryShows("Saved findings in Workplaces folder").HasValue("Yes")
            .isNotMarkedAsComplete();

        cy.log("Edit values");
        summaryPage.clickChange();

        statutoryConsultationtEditPage
            .withDateReceived("3", "3", "2020")
            .withComments("This is a new comment")
            .clickContinue();

        cy.log("Confirm edited values for statutory consultation");
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Statutory consultation")
            .inOrder()
            .summaryShows("Expected date for receiving findings from trust").HasValue("2 March 2020")
            .summaryShows("Received consultation findings from trust").HasValue("Yes")
            .summaryShows("Date received").HasValue("3 March 2020")
            .summaryShows("Consultation fulfils the trust's section 10 statutory duty").HasValue("Yes")
            .summaryShows("Comments").HasValue("This is a new comment")
            .summaryShows("Saved findings in Workplaces folder").HasValue("Yes")
            .isNotMarkedAsComplete();

        summaryPage
            .MarkAsComplete()
            .clickConfirmAndContinue();

        taskListPage.isTaskStatusIsCompleted("StatutoryConsultation");
    });
})
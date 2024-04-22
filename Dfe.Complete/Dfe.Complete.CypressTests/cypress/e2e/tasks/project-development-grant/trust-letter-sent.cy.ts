import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import summaryPage from "cypress/pages/task-summary-base";
import taskListPage from "cypress/pages/taskListPage";
import pdgDashboard from "cypress/pages/tasks/project-development-grant/dashboard";
import trustLetter from "cypress/pages/tasks/project-development-grant/edit-trust-letter";

describe("Trust Letter Sent Task", () => {
    let project: ProjectDetailsRequest;

    beforeEach(() => {
        cy.login();

        project = RequestBuilder.createProjectDetails();

        projectApi
            .post({
                projects: [project],
            })
            .then(() => {
                cy.visit(`/projects/${project.projectId}/tasks/`);
            });
    });
    it("Should successfully set trust letter", () => {

        cy.log("Select Project development grant (PDG)");
        taskListPage.isTaskStatusIsNotStarted("PDG")
            .selectPDGFromTaskList();

        cy.log("Confirm empty dashboard");
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Project development grant (PDG)")
            .inOrder()
            .skip(6)
            .summaryShows("Date when DfE signed PDG letter sent from the trust").IsEmpty()
            .summaryShows("Saved the signed trust letter in Workplaces folder").IsEmpty()
            .isNotMarkedAsComplete();

        pdgDashboard.selectChangeTrustLetter();

        cy.executeAccessibilityTests();

        cy.log("All fields are optional");
        trustLetter
            .titleIs("Edit Trust letter")
            .schoolNameIs(project.schoolName)
            .clickContinue();

        cy.log("Confirm empty dashboard");
        summaryPage
            .inOrder()
            .skip(6)
            .summaryShows("Date when DfE signed PDG letter sent from the trust").IsEmpty()
            .summaryShows("Saved the signed trust letter in Workplaces folder").IsEmpty()
            .isNotMarkedAsComplete();

        pdgDashboard.selectChangeTrustLetter();

        cy.log("Check DG letter sent from the trust validation");
        trustLetter
            .withTrustLetterDate("a", "12", "2025")
            .clickContinue()
            .errorForPaymentDueDate().showsError("Enter a date in the correct format")

        cy.executeAccessibilityTests();

        cy.log('Confirm all set')

        trustLetter
            .withTrustLetterDate("1", "2", "2021")
            .checkSavedInWorkplaces()
            .clickContinue()

        summaryPage
            .inOrder()
            .skip(6)
            .summaryShows("Date when DfE signed PDG letter sent from the trust").HasValue("1 February 2021")
            .summaryShows("Saved the signed trust letter in Workplaces folder").HasValue("Yes")

        summaryPage.MarkAsComplete()
            .clickConfirmAndContinue();

        taskListPage.isTaskStatusIsCompleted("PDG");

    });

});

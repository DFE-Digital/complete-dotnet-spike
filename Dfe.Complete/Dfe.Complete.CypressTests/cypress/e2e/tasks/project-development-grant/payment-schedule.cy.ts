import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import summaryPage from "cypress/pages/task-summary-base";
import taskListPage from "cypress/pages/taskListPage";
import pdgDashboard from "cypress/pages/tasks/project-development-grant/dashboard";
import paymentSchedule from "cypress/pages/tasks/project-development-grant/edit-payment-schedule";

describe("Payment Schedule Task", () => {
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
    it("Should successfully set payment schedule", () => {

        cy.log("Select Project development grant (PDG)");
        taskListPage.isTaskStatusIsNotStarted("PDG")
            .selectPDGFromTaskList();

        cy.log("Confirm empty dashboard");
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Project development grant (PDG)")
            .inOrder()
            .summaryShows("Amount").IsEmpty()
            .summaryShows("Actual payment date").IsEmpty()
            .summaryShows("Payment due date").IsEmpty()
            .summaryShows("Payment due amount").IsEmpty()
            .summaryShows("Actual payment date").IsEmpty()
            .summaryShows("Actual Payment amount").IsEmpty()
            .isNotMarkedAsComplete();

        cy.executeAccessibilityTests();
        cy.log("Go back to task list");
        summaryPage.clickBack();

        cy.log("Confirm not started and open project development grant (PDG)");
        taskListPage.isTaskStatusIsNotStarted("PDG")
            .selectPDGFromTaskList();

        cy.log("Check confirm puts project in In Progress");
        summaryPage.clickConfirmAndContinue();

        taskListPage.isTaskStatusInProgress("PDG")
            .selectPDGFromTaskList();

        pdgDashboard.selectChangePaymentSchedule();

        cy.executeAccessibilityTests();

        cy.log("All fields are optional");
        paymentSchedule
            .titleIs("Edit Payment schedule")
            .schoolNameIs(project.schoolName)
            .clickContinue();

        cy.log("Confirm empty dashboard");
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Project development grant (PDG)")
            .inOrder()
            .summaryShows("Amount").IsEmpty()
            .summaryShows("Actual payment date").IsEmpty()
            .summaryShows("Payment due date").IsEmpty()
            .summaryShows("Payment due amount").IsEmpty()
            .summaryShows("Actual payment date").IsEmpty()
            .summaryShows("Actual Payment amount").IsEmpty()
            .isNotMarkedAsComplete();

        pdgDashboard.selectChangePaymentSchedule();

        cy.log("Check Payment Due Date validation");
        paymentSchedule
            .titleIs("Edit Payment schedule")
            .schoolNameIs(project.schoolName)
            .withPaymentDueDate("a", "12", "2025")
            .clickContinue()
            .errorForPaymentDueDate().showsError("Enter a date in the correct format")

        cy.executeAccessibilityTests();

        cy.log("Check Payment Actual Date");
        paymentSchedule
            .schoolNameIs(project.schoolName)
            .withPaymentActualDate("a", "12", "2025")
            .clickContinue()
            .errorForPaymentActualDate().showsError("Enter a date in the correct format")

        cy.executeAccessibilityTests();

        cy.log("Check Payment Due Amount");
        paymentSchedule
            .schoolNameIs(project.schoolName)
            .withPaymentDueAmount("a")
            .clickContinue()
            .errorForPaymentDueAmount().showsError("Amount of 1st payment due must be a number")
            .withPaymentDueAmount("-1")
            .clickContinue()
            .errorForPaymentDueAmount().showsError("Amount of 1st payment due must be between 0 and 25000")
            .withPaymentDueAmount("250.256")
            .clickContinue()
            .errorForPaymentDueAmount().showsError("Amount of 1st payment due must be two decimal places")
            .withPaymentDueAmount("250000")
            .clickContinue()
            .errorForPaymentDueAmount().showsError("Amount of 1st payment due must be between 0 and 25000")

        cy.executeAccessibilityTests();

        cy.log("Check Payment Actual Amount");
        paymentSchedule
            .schoolNameIs(project.schoolName)
            .withPaymentActualAmount("a")
            .clickContinue()
            .errorForPaymentActualAmount().showsError("What is the payment amount? must be a number")
            .withPaymentActualAmount("-1")
            .clickContinue()
            .errorForPaymentActualAmount().showsError("What is the payment amount? must be between 0 and 25000")
            .withPaymentActualAmount("250.256")
            .clickContinue()
            .errorForPaymentActualAmount().showsError("What is the payment amount? must be two decimal places")
            .withPaymentActualAmount("250000")
            .clickContinue()
            .errorForPaymentActualAmount().showsError("What is the payment amount? must be between 0 and 25000")

        cy.executeAccessibilityTests();

        cy.log('Confirm all set')

        paymentSchedule
            .schoolNameIs(project.schoolName)
            .withPaymentDueDate("1", "2", "2021")
            .withPaymentActualDate("1", "2", "2021")
            .withPaymentDueAmount("100.25")
            .withPaymentActualAmount("200.36")
            .clickContinue()

        summaryPage
            .inOrder()
            .summaryShows("Amount").HasValue("£200.36")
            .summaryShows("Actual payment date").HasValue("1 February 2021")
            .summaryShows("Payment due date").HasValue("1 February 2021")
            .summaryShows("Payment due amount").HasValue("£100.25")
            .summaryShows("Actual payment date").HasValue("1 February 2021")
            .summaryShows("Actual Payment amount").HasValue("£200.36")

        summaryPage.MarkAsComplete()
            .clickConfirmAndContinue();

        taskListPage.isTaskStatusIsCompleted("PDG");

    });

});

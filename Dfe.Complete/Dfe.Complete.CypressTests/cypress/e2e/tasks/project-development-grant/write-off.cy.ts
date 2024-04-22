import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import summaryPage from "cypress/pages/task-summary-base";
import taskListPage from "cypress/pages/taskListPage";
import pdgDashboard from "cypress/pages/tasks/project-development-grant/dashboard";
import writeOff from "cypress/pages/tasks/project-development-grant/edit-write-off";

describe("Write off Task", () => {
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
    it("Should successfully set Write off", () => {

        cy.log("Select Project development grant (PDG)");
        taskListPage.isTaskStatusIsNotStarted("PDG")
            .selectPDGFromTaskList();

        cy.log("Confirm empty dashboard");
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Project development grant (PDG)")
            .inOrder()
            .skip(11)
            .summaryShows("Write-off reason").IsEmpty()
            .summaryShows("Write-off amount").IsEmpty()
            .isNotMarkedAsComplete();

        cy.executeAccessibilityTests();

        pdgDashboard.selectChangeWriteOff();

        cy.executeAccessibilityTests();

        cy.log("All fields are optional");
        writeOff
            .titleIs("Edit Write-off")
            .schoolNameIs(project.schoolName)
            .clickContinue();

        cy.log("Confirm empty dashboard");
        summaryPage
            .inOrder()
            .skip(11)
            .summaryShows("Write-off reason").IsEmpty()
            .summaryShows("Write-off amount").IsEmpty()
            .isNotMarkedAsComplete();

        pdgDashboard.selectChangeWriteOff();
        
        cy.log("Check Write off date validation");
        writeOff
            .schoolNameIs(project.schoolName)
            .withWriteOffDate("a", "12", "2025")
            .clickContinue()
            .errorForWriteOffDate().showsError("Enter a date in the correct format")
            
        cy.executeAccessibilityTests();

        cy.log("Check Approval Date validation");
        writeOff
            .schoolNameIs(project.schoolName)
            .withApprovalDate("a", "12", "2025")
            .clickContinue()
            .errorForApprovalDate().showsError("Enter a date in the correct format")

        cy.executeAccessibilityTests();

        cy.log("Check Write off amount validation");
        writeOff
            .schoolNameIs(project.schoolName)
            .withWriteOffAmount("299.045")
            .clickContinue()
            .errorForWriteOffAmount().showsError("Write-off amount must be two decimal places")

        cy.executeAccessibilityTests();
        
        cy.log("Check Write off amount validation");
        writeOff
            .schoolNameIs(project.schoolName)
            .withWriteOffReason("NotValid{")
            .clickContinue()
            .errorForWriteOffReason().showsError("Write-off reason must not include special characters other than , ( ) '")

        cy.executeAccessibilityTests();

        cy.log("Check Write off amount validation");
        writeOff
            .schoolNameIs(project.schoolName)
            .withFinanceBusinessPartnerApproval("NotValid{")
            .clickContinue()
            .errorForFinanceBusinessPartnerApproval().showsError("Finance business partner approval received from must not include special characters other than , ( ) '")

        cy.executeAccessibilityTests();

        cy.log('Confirm all set')
        writeOff
            .schoolNameIs(project.schoolName)
            .withWriteOffDate("4", "12", "2025")
            .withApprovalDate("5", "12", "2025")
            .withWriteOffAmount("299.04")
            .withWriteOffReason("Reason")
            .withFinanceBusinessPartnerApproval("Sam Smigel")
            .clickContinue()

        summaryPage.MarkAsComplete()
            .clickConfirmAndContinue();

        taskListPage.isTaskStatusIsCompleted("PDG");

    });

});

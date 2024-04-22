import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import { Logger } from "cypress/common/logger";
import trustDetailsPage from "cypress/pages/trustDetailsPage";
import trustSummaryPage from "cypress/pages/trustSummaryPage";
import projectOverviewPage from "cypress/pages/projectOverviewPage";
import taskListPage from "cypress/pages/taskListPage";
import confirmTrustPage from "cypress/pages/confirmTrustPage";

describe("Testing project overview", () => {
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

    it("Should successfully set Tasklist-trust information", () => {
        const validTrustId = "TR03446";

        Logger.log("Clicking on Task list tab");
        projectOverviewPage.selectTaskListTab();

        cy.executeAccessibilityTests();

        Logger.log("Selecting Trust link from Tasklist");
        taskListPage.selectTrustFromTaskList();

        cy.executeAccessibilityTests();

        Logger.log("Checking Trust Summary page elements present");
        trustSummaryPage.verifyTrustSummaryElementsVisible();

        Logger.log("Selecting first Change link from first 'TRN' line");
        trustSummaryPage.selectChangeTRNToGoToTrustDetails();

        cy.executeAccessibilityTests();


        Logger.log("Attempting to save 'Search for a trust by TRN' with no values");
        trustDetailsPage.selectSaveAndContinue()
        
        cy.executeAccessibilityTests();

        Logger.log("Check we get the correct validation messages coming back when no data entered");
        trustDetailsPage.verifyValidationMessagesWhenNoDataSet();

        Logger.log("Attempting to save 'Search for a trust by TRN' with an invalid string e.g. 'POTATO'");
        trustDetailsPage.enterInvalidTRNStringInTRNPage();

        trustDetailsPage.selectSaveAndContinue();

        cy.executeAccessibilityTests();

        trustDetailsPage.verifyValidationMessagesWhenInvalidTRNFormatEntered();

        Logger.log("Attempting to save 'Search for a trust by TRN' with an invalid string with spaces e.g. 'P O T A T O'");
        trustDetailsPage.enterInvalidTRNStringWithSpacesInTRNPage();

        trustDetailsPage.selectSaveAndContinue();

        cy.executeAccessibilityTests();

        trustDetailsPage.verifyValidationMessagesWhenTRNTooLongEntered();

        Logger.log("Attempting to save 'Search for a trust by TRN' with an invalid numerical string e.g. '1234567'");
        trustDetailsPage.enterInvalidTRNNumbersStringInTRNPage();

        trustDetailsPage.selectSaveAndContinue();

        cy.executeAccessibilityTests();

        trustDetailsPage.verifyValidationMessagesWhenInvalidTRNFormatEntered();

        Logger.log("Attempting to save 'Search for a trust by TRN' with a TRN that doesn't exist");
        trustDetailsPage.enterNonExistentTrustIdInTRNPage();

        trustDetailsPage.selectSaveAndContinue();

        cy.executeAccessibilityTests();

        trustDetailsPage.verifyValidationMessagesWhenNonExistentTRNEntered();



        Logger.log("Attempting to save 'Search for a trust by TRN' with SQL injection attempt");
        trustDetailsPage.enterSQLInjectionAttemptInTRNPage();

        trustDetailsPage.selectSaveAndContinue();

        cy.executeAccessibilityTests();

        trustDetailsPage.verifyValidationMessagesWhenTRNTooLongEntered();



        Logger.log("Attempting to save 'Search for a trust by TRN' with Cross-site Scripting Attack");
        trustDetailsPage.enterCrossSiteScriptingAttemptInTRNPage();

        trustDetailsPage.selectSaveAndContinue();

        cy.executeAccessibilityTests();

        trustDetailsPage.verifyValidationMessagesWhenTRNTooLongEntered();



        Logger.log("Attempting to save 'Search for a trust by TRN' with valid Trust ID that exists");
        trustDetailsPage.enterValidTrustId(validTrustId);

        trustDetailsPage.selectSaveAndContinue();

        cy.executeAccessibilityTests();

        confirmTrustPage.verifyConfirmTrustElementsVisible(project.schoolName, validTrustId);

        confirmTrustPage.selectNo();

        confirmTrustPage.selectSaveAndContinue();

        cy.executeAccessibilityTests();

        trustDetailsPage.enterValidTrustId(validTrustId);

        trustDetailsPage.selectSaveAndContinue();

        cy.executeAccessibilityTests();

        confirmTrustPage.verifyConfirmTrustElementsVisible(project.schoolName, validTrustId);

        confirmTrustPage.selectYes();

        confirmTrustPage.selectSaveAndContinue();

        cy.executeAccessibilityTests();

        trustSummaryPage.verifyTrustSummaryCompleteElementsVisible(validTrustId);

        trustSummaryPage.selectMarkItemAsComplete();

        trustSummaryPage.selectConfirmAndContinue();

        cy.executeAccessibilityTests();

        taskListPage.isTaskStatusIsCompleted("Trust");

        
        taskListPage.selectAboutTheProjectTab();

        cy.executeAccessibilityTests();

        projectOverviewPage.hasTrustId("TR03446");
        projectOverviewPage.hasTrustName("King's Group Academies");
        projectOverviewPage.hasTrustType("MAT (multi-academy trust)");

    });
});

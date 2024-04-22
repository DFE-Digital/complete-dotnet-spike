import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import { Logger } from "cypress/common/logger";
import summaryPage from "cypress/pages/task-summary-base";
import taskListPage from "cypress/pages/taskListPage";
import editFinancePlanPage from "cypress/pages/tasks/pre-opening/editFinancePlanPage";
import validationComponent from "cypress/pages/validationComponent";

describe("Testing finance plan task", () => {
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

    it("Should be able to set a finance plan", () => {

        // Need these labels in a constant because we check exists and not exists
        // Ensures both checks will be consistent
        const rpaStartDateLabel = "RPA start date";
        const rpaCoverTypeLabel = "Type of RPA cover";

        Logger.log("Select finance plan");
        taskListPage.isTaskStatusIsNotStarted("FinancePlan")
            .selectFinancePlanFromTaskList();

        Logger.log("Go back to task list");
        summaryPage.clickBack();

        taskListPage.selectFinancePlanFromTaskList();

        Logger.log("Confirm empty finance plan");
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Finance plan")
            .inOrder()
            .summaryShows("Finance plan agreed").IsEmpty().HasChangeLink()
            .summaryShows("Date agreed").IsEmpty().HasChangeLink()
            .summaryShows("Plan saved in Workplaces folder").IsEmpty().HasChangeLink()
            .summaryShows("Local authority agreed to underwrite pupil numbers").IsEmpty().HasChangeLink()
            .summaryShows("Comments").IsEmpty().HasChangeLink()
            .summaryShows("Trust will opt-in to RPA (risk protection arrangement)").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete();

        cy.executeAccessibilityTests();

        summaryPage.clickChange();

        Logger.log("Check all the fields are optional");
        editFinancePlanPage
            .titleIs("Edit finance plan")
            .schoolNameIs(project.schoolName)
            .clickContinue();

        Logger.log("Add new values");
        summaryPage.clickChange();

        Logger.log("Testing validation");
        editFinancePlanPage
            .withTrustWillOptInToRpa("Yes")
            .withDateAgreed("33", "", "")
            .withRpaStartDate("44", "", "")
            .withCoverTypeExceedingMaxLength()
            .withCommentsExceedingMaxLength()
            .clickContinue();

        validationComponent
            .hasValidationError("Date agreed must include a month and year")
            .hasValidationError("RPA start date must include a month and year")
            .hasValidationError("The comments must be 999 characters or less")
            .hasLinkedValidationError("The type of rpa cover must be 100 characters or less");

        // The conditional radio buttons break "aria-allowed-attr"
        // This is a gov component so we can't fix it, for now just disable the check
        cy.executeAccessibilityTests({ "aria-allowed-attr": { enabled: false } });

        editFinancePlanPage
            .schoolNameIs(project.schoolName)
            .checkFinancePlanAgreed()
            .withDateAgreed("10", "08", "2024")
            .checkPlanSavedInWorkplacesFolder()
            .withLocalAuthorityAgreedToUnderwritePupilNumbers("Yes")
            .withComments("Some comments")
            .withTrustWillOptInToRpa("Yes")
            .withRpaStartDate("12", "09", "2025")
            .withRpaCoverType("Comprehensive")
            .clickContinue();

        summaryPage
            .inOrder()
            .summaryShows("Finance plan agreed").HasValue("Yes")
            .summaryShows("Date agreed").HasValue("10 August 2024")
            .summaryShows("Plan saved in Workplaces folder").HasValue("Yes")
            .summaryShows("Local authority agreed to underwrite pupil numbers").HasValue("Yes")
            .summaryShows("Comments").HasValue("Some comments")
            .summaryShows("Trust will opt-in to RPA (risk protection arrangement)").HasValue("Yes")
            .summaryShows(rpaStartDateLabel).HasValue("12 September 2025")
            .summaryShows(rpaCoverTypeLabel).HasValue("Comprehensive");

        Logger.log("Should be able to edit the existing values");
        summaryPage.clickChange();

        editFinancePlanPage
            .checkFinancePlanAgreed()
            .withDateAgreed("12", "05", "2027")
            .checkPlanSavedInWorkplacesFolder()
            .withLocalAuthorityAgreedToUnderwritePupilNumbers("NotApplicable")
            .withComments("This is my new comments")
            .withTrustWillOptInToRpa("Yes")
            .withRpaStartDate("13", "06", "2026")
            .withRpaCoverType("Standard")
            .clickContinue();

        summaryPage
            .inOrder()
            .summaryShows("Finance plan agreed").HasValue("No")
            .summaryShows("Date agreed").HasValue("12 May 2027")
            .summaryShows("Plan saved in Workplaces folder").HasValue("No")
            .summaryShows("Local authority agreed to underwrite pupil numbers").HasValue("Not applicable")
            .summaryShows("Comments").HasValue("This is my new comments")
            .summaryShows("Trust will opt-in to RPA (risk protection arrangement)").HasValue("Yes")
            .summaryShows(rpaStartDateLabel).HasValue("13 June 2026")
            .summaryShows(rpaCoverTypeLabel).HasValue("Standard");

        Logger.log("Should not validate the RPA fields if no is selected");
        summaryPage.clickChange();

        editFinancePlanPage
            .withTrustWillOptInToRpa("Yes")
            .withRpaStartDate("12", "", "")
            .withCoverTypeExceedingMaxLength()
            .withTrustWillOptInToRpa("No")
            .clickContinue();

        Logger.log("Should not show the RPA fields if no is selected and the optional fields should not be displayed")
        summaryPage
            .startFromRow(5)
            .summaryShows("Trust will opt-in to RPA (risk protection arrangement)").HasValue("No")
            .summaryDoesNotShow(rpaStartDateLabel)
            .summaryDoesNotShow(rpaCoverTypeLabel);

        Logger.log("Should clear the RPA fields as no was selected");
        summaryPage.clickChange();

        editFinancePlanPage
            .withTrustWillOptInToRpa("Yes")
            .hasCoverType("")
            .hasRpaStartDate("", "", "")
            .clickContinue();

        Logger.log("Should update the task status");
        summaryPage.clickConfirmAndContinue();

        taskListPage.isTaskStatusInProgress("FinancePlan").selectFinancePlanFromTaskList();

        summaryPage
            .MarkAsComplete()
            .clickConfirmAndContinue();

        taskListPage.isTaskStatusIsCompleted("FinancePlan");
    });
});
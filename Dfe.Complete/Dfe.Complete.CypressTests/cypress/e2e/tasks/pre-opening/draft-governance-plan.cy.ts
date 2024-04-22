import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import projectRiskApi from "cypress/api/projectRiskApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import { Logger } from "cypress/common/logger";
import projectRiskSummaryComponent from "cypress/pages/risk/projectRiskSummaryComponent";
import summaryPage from "cypress/pages/task-summary-base";
import taskListPage from "cypress/pages/taskListPage";
import editDraftGovernancePlanPage from "cypress/pages/tasks/pre-opening/editDraftGovernancePlanPage";
import validationComponent from "cypress/pages/validationComponent";
import { toDisplayDate } from "cypress/support/formatDate";

describe("Testing draft governance plan task", () => {
    let project: ProjectDetailsRequest;
    let now: string;

    beforeEach(() => {
        cy.login();

        now = toDisplayDate(new Date());

        project = RequestBuilder.createProjectDetails();
        const projectRisk = RequestBuilder.CreateProjectRiskRequest();

        projectApi
            .post({
                projects: [project],
            })
            .then(() => {
                projectRiskApi.post(project.projectId, projectRisk);
            });
    });

    it("Should be able to set a draft governance plan", () => {

        cy.visit(`/projects/${project.projectId}/tasks`);

        Logger.log("Select draft governance plan");
        taskListPage.isTaskStatusIsNotStarted("DraftGovernancePlan")
            .selectDraftGovernancePlanFromTaskList();

        Logger.log("Go back to task list");
        summaryPage.clickBack();

        taskListPage.selectDraftGovernancePlanFromTaskList();

        Logger.log("Confirm empty draft governance plan");
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Draft governance plan")
            .inOrder()
            .summaryShows("Received draft governance plan from trust").IsEmpty().HasChangeLink()
            .summaryShows("Assessed plan using assessment template").IsEmpty().HasChangeLink()
            .summaryShows("Shared plan and assessment with external expert").IsEmpty().HasChangeLink()
            .summaryShows("Shared plan and assessment with ESFA (Education and Skills Funding Agency)").IsEmpty().HasChangeLink()
            .summaryShows("Fed back to trust on plan").IsEmpty().HasChangeLink()
            .summaryShows("Saved documents in Workplaces folder").IsEmpty().HasChangeLink()
            .summaryShows("Comments").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete();

        cy.executeAccessibilityTests();

        Logger.log("Check that the risk rating is displayed");
        projectRiskSummaryComponent
            .hasProjectRiskDate(now)
            .hasProjectRiskRating(["Green"])
            .hasProjectRiskSummary("This is my risk summary");

        summaryPage.clickChange();

        Logger.log("Check all the fields are optional");
        editDraftGovernancePlanPage
            .titleIs("Edit Draft governance plan")
            .schoolNameIs(project.schoolName)
            .clickContinue();

        summaryPage.clickChange();

        Logger.log("Testing validation");
        editDraftGovernancePlanPage
            .checkPlanReceivedFromTrust()
            .withDatePlanReceived("44", "", "")
            .withCommentsExceedingMaxLength()
            .clickContinue();

        validationComponent
            .hasValidationError("Date received must include a month and year")
            .hasValidationError("The comments must be 999 characters or less");

        // The conditional checkboxes break "aria-allowed-attr"
        // This is a gov component so we can't fix it, for now just disable the check
        cy.executeAccessibilityTests({ "aria-allowed-attr": { enabled: false } });

        Logger.log("Add new values");
        editDraftGovernancePlanPage
            .schoolNameIs(project.schoolName)
            .withDatePlanReceived("25", "08", "2025")
            .checkPlanAssessedUsingTemplate()
            .checkPlanAndAssessmentSharedWithExpert()
            .checkPlanAndAssessmentSharedWithEsfa()
            .checkFedBackToTrustOnPlan()
            .checkDocumentsSavedInWorkplacesFolder()
            .withComments("This is my comments")
            .clickContinue();

        summaryPage
            .inOrder()
            .summaryShows("Received draft governance plan from trust").HasValue("Yes")
            .summaryShows("Date received").HasValue("25 August 2025")
            .summaryShows("Assessed plan using assessment template").HasValue("Yes")
            .summaryShows("Shared plan and assessment with external expert").HasValue("Yes")
            .summaryShows("Shared plan and assessment with ESFA (Education and Skills Funding Agency)").HasValue("Yes")
            .summaryShows("Fed back to trust on plan").HasValue("Yes")
            .summaryShows("Saved documents in Workplaces folder").HasValue("Yes")
            .summaryShows("Comments").HasValue("This is my comments")

        Logger.log("Should clear the date if Received draft governance plan from trust is unchecked");
        summaryPage.clickChange();

        editDraftGovernancePlanPage
            .withDatePlanReceived("01", "", "")
            .checkPlanReceivedFromTrust()
            .clickContinue();

        summaryPage.clickChange();

        editDraftGovernancePlanPage
            .checkPlanReceivedFromTrust()
            .clickContinue();

        summaryPage
            .inOrder()
            .summaryShows("Received draft governance plan from trust").HasValue("Yes")
            .summaryShows("Date received").IsEmpty();

        Logger.log("Should be able to update the date received");
        summaryPage.clickChange();

        editDraftGovernancePlanPage
            .withDatePlanReceived("01", "01", "2026")
            .clickContinue();

        summaryPage
            .inOrder()
            .summaryShows("Received draft governance plan from trust").HasValue("Yes")
            .summaryShows("Date received").HasValue("1 January 2026")

        Logger.log("Should be able to update values");
        summaryPage.clickChange();

        editDraftGovernancePlanPage
            .checkPlanReceivedFromTrust()
            .checkPlanAssessedUsingTemplate()
            .checkPlanAndAssessmentSharedWithExpert()
            .checkPlanAndAssessmentSharedWithEsfa()
            .checkFedBackToTrustOnPlan()
            .checkDocumentsSavedInWorkplacesFolder()
            .withComments("This is my updated comments that I have written")
            .clickContinue();

        summaryPage
            .inOrder()
            .summaryShows("Received draft governance plan from trust").IsEmpty()
            .summaryShows("Assessed plan using assessment template").IsEmpty()
            .summaryShows("Shared plan and assessment with external expert").IsEmpty()
            .summaryShows("Shared plan and assessment with ESFA (Education and Skills Funding Agency)").IsEmpty()
            .summaryShows("Fed back to trust on plan").IsEmpty()
            .summaryShows("Saved documents in Workplaces folder").IsEmpty()
            .summaryShows("Comments").HasValue("This is my updated comments that I have written");

        Logger.log("Should update the task status");
        summaryPage.clickConfirmAndContinue();

        taskListPage.isTaskStatusInProgress("DraftGovernancePlan");

        taskListPage.selectDraftGovernancePlanFromTaskList();

        summaryPage
            .MarkAsComplete()
            .clickConfirmAndContinue();

        taskListPage.isTaskStatusIsCompleted("DraftGovernancePlan");
    });
});
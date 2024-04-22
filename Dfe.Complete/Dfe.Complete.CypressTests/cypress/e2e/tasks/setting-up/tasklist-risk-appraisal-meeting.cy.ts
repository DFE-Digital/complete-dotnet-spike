import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import { Logger } from "cypress/common/logger";
import dataGenerator from "cypress/fixtures/dataGenerator";
import riskAppraisalMeetingEditPage from "cypress/pages/risk-appraisal-meeting-page";
import summaryPage from "cypress/pages/task-summary-base";
import taskListPage from "cypress/pages/taskListPage";

describe("Testing Risk appraisal meeting Task", () => {
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

    it("Should successfully set Tasklist-school information", () => {
        
        const RiskAppraisalMeeting = "RiskAppraisalMeeting"

        Logger.log("Select Risk appraisal meeting");
        taskListPage.isTaskStatusIsNotStarted(RiskAppraisalMeeting)
            .selectRiskAppraisalMeetingFromTaskList();

        Logger.log("Confirm empty Risk appraisal meeting");
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Risk appraisal meeting")
            .inOrder()
            .summaryShows("Initial risk appraisal meeting completed").IsEmpty().HasChangeLink()
            .summaryShows("Forecast date").IsEmpty().HasChangeLink()
            .summaryShows("Actual date").IsEmpty().HasChangeLink()
            .summaryShows("Comments on decision to approve (if applicable)").IsEmpty().HasChangeLink()
            .summaryShows("Reason not applicable").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete();
        
        cy.executeAccessibilityTests();
        Logger.log("Go back to task list");
        summaryPage.clickBack();

        Logger.log("Confirm not started and open Risk appraisal meeting");
        taskListPage.isTaskStatusIsNotStarted(RiskAppraisalMeeting)
            .selectRiskAppraisalMeetingFromTaskList();

        Logger.log("Check confirm puts project in In Progress");
        summaryPage.clickConfirmAndContinue();

        taskListPage.isTaskStatusInProgress(RiskAppraisalMeeting)
            .selectRiskAppraisalMeetingFromTaskList();

        Logger.log("Go to edit page");

        summaryPage.clickChange();
    
        cy.executeAccessibilityTests();

        Logger.log("Check all fields optional");
        riskAppraisalMeetingEditPage
            .schoolNameIs(project.schoolName)
            .titleIs("Edit risk appraisal meeting")
            .clickContinue();

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Risk appraisal meeting")
            .inOrder()
            .summaryShows("Initial risk appraisal meeting completed").IsEmpty().HasChangeLink()
            .summaryShows("Forecast date").IsEmpty().HasChangeLink()
            .summaryShows("Actual date").IsEmpty().HasChangeLink()
            .summaryShows("Comments on decision to approve (if applicable)").IsEmpty().HasChangeLink()
            .summaryShows("Reason not applicable").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete();

        summaryPage.clickChange();

        Logger.log("Invalid data causes error");

        riskAppraisalMeetingEditPage
        .withInitialRiskAppraisalMeetingCompleted("Yes")
            .withComments(dataGenerator.generateAlphaNumeric(101))
            .clickContinue()
            .errorForComments().showsError("The comments must be 100 characters or less")
            .withComments("' OR 1=1")
            .clickContinue()
            .errorForComments().showsError("Comments must not include special characters other than , ( ) '")
            .withComments("A comment")
            .withReason(dataGenerator.generateAlphaNumeric(101))
            .clickContinue()
            .errorForReason().showsError("The reason must be 100 characters or less")
            .withReason(("' OR 1=1"))
            .clickContinue()
            .errorForReason().showsError("Reason must not include special characters other than , ( ) '")
            .withReason("A Reason")
            .withForecastDate("PO", "5", "2025")
            .clickContinue()
            .errorForForecastDate().showsError("Enter a date in the correct format")
            .withForecastDate("20", "5", "2025")
            .withActualDate("PO", "5", "2025")
            .clickContinue()
            .errorForActualDate().showsError("Enter a date in the correct format")
            .withActualDate("21", "6", "2024");
        
        cy.executeAccessibilityTests();
        Logger.log("Valid fields save");

        riskAppraisalMeetingEditPage
            .withInitialRiskAppraisalMeetingCompleted("Yes")
            .clickContinue();

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Risk appraisal meeting")
            .inOrder()
            .summaryShows("Initial risk appraisal meeting completed").HasValue("Yes")
            .summaryShows("Forecast date").HasValue("20 May 2025")
            .summaryShows("Actual date").HasValue("21 June 2024")
            .summaryShows("Comments on decision to approve (if applicable)").HasValue("A comment")
            .summaryShows("Reason not applicable").HasValue("A Reason")
            .isNotMarkedAsComplete();

        Logger.log("Mark as complete");

        summaryPage
            .MarkAsComplete()
            .clickConfirmAndContinue();

        taskListPage.isTaskStatusIsCompleted(RiskAppraisalMeeting)
    }); 
});
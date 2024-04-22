import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import { Logger } from "cypress/common/logger";
import summaryPage from "cypress/pages/task-summary-base";
import taskListPage from "cypress/pages/taskListPage";
import admissionsArrangementsEditPage from "../../../pages/tasks/pre-opening/edit-admissions-arrangements.cy";

describe("Testing the admissions arragements task", () => {

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

    it("Should be able to set admissions arrangements", () => {
        Logger.log("Select admissions arrangements");
        taskListPage.isTaskStatusIsNotStarted("AdmissionsArrangements")
            .selectAdmissionsArrangementsFromTaskList();

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Admissions arrangements")
            .inOrder()
            .summaryShows("The trust has confirmed that they have developed their admissions arrangements using the recommended template").IsEmpty().HasChangeLink()
            .summaryShows("The trust has confirmed that the admissions arrangements comply with the appropriate admissions policies").IsEmpty().HasChangeLink()
            .summaryShows("Admissions arrangements confirmed date").IsEmpty().HasChangeLink()
            .summaryShows("Saved the confirmation email in Workplaces folder").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete();

        Logger.log("Go back to task list");
        summaryPage.clickBack();

        taskListPage.selectAdmissionsArrangementsFromTaskList();
        summaryPage.clickChange();

        Logger.log("Edit Admissions Arrangements");

        cy.executeAccessibilityTests();

        cy.executeAccessibilityTests

        admissionsArrangementsEditPage
            .checkTrustConfirmedAdmissionsArrangementsTemplate()
            .checkTrustConfirmedAdmissionsArrangementsPolicies()
            .withConfirmedDate("21","1","2049")
            .checkSavedToWorkplaces()
            .clickContinue()
        
        Logger.log("Should update the task status");

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Admissions arrangements")
            .inOrder()
            .summaryShows("The trust has confirmed that they have developed their admissions arrangements using the recommended template").HasValue("Yes").HasChangeLink()
            .summaryShows("The trust has confirmed that the admissions arrangements comply with the appropriate admissions policies").HasValue("Yes").HasChangeLink()
            .summaryShows("Admissions arrangements confirmed date").HasValue("21 January 2049").HasChangeLink()
            .summaryShows("Saved the confirmation email in Workplaces folder").HasValue("Yes").HasChangeLink()
            .isNotMarkedAsComplete()
            .clickConfirmAndContinue()

        taskListPage.isTaskStatusInProgress("AdmissionsArrangements");

        taskListPage.selectAdmissionsArrangementsFromTaskList();
        summaryPage.clickChange();
        
        admissionsArrangementsEditPage
            .withConfirmedDate("aq","12","2010")
            .clickContinue()
            .errorForConfirmedDate().showsError("Enter a date in the correct format")
            .withConfirmedDate("21","12","1999")
            .clickContinue()
            .errorForConfirmedDate().showsError("Year must be between 2000 and 2050")
            .withConfirmedDate("21","12","2051")
            .clickContinue()
            .errorForConfirmedDate().showsError("Year must be between 2000 and 2050")
            .withConfirmedDate("21","4","2050")
            .uncheckTrustConfirmedAdmissionsArrangementsTemplate()
            .uncheckTrustConfirmedAdmissionsArrangementsPolicies()
            .uncheckSavedToWorkplaces()
            .clickContinue()
        
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Admissions arrangements")
            .inOrder()
            .summaryShows("The trust has confirmed that they have developed their admissions arrangements using the recommended template").HasValue(["Empty"]).HasChangeLink()
            .summaryShows("The trust has confirmed that the admissions arrangements comply with the appropriate admissions policies").HasValue(["Empty"]).HasChangeLink()
            .summaryShows("Admissions arrangements confirmed date").HasValue("21 April 2050").HasChangeLink()
            .summaryShows("Saved the confirmation email in Workplaces folder").HasValue(["Empty"]).HasChangeLink()
            .MarkAsComplete()
            .clickConfirmAndContinue();

        taskListPage.isTaskStatusIsCompleted("AdmissionsArrangements");
    });
});
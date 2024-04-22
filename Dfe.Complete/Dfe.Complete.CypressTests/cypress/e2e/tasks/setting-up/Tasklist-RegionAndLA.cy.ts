import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import { Logger } from "cypress/common/logger";
import taskListPage from "cypress/pages/taskListPage";
import regionDetailsPage from "cypress/pages/regionDetailsPage";
import validationComponent from "cypress/pages/validationComponent";
import summaryPage from "cypress/pages/task-summary-base";

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

    it("Should successfully set Tasklist-Region And LA information", () => {

        Logger.log("Select region and local authority task");
        taskListPage
            .isTaskStatusIsNotStarted("RegionAndLocalAuthority")
            .selectRegionAndLAFromTaskList();

        Logger.log("Go back to task list");
        summaryPage.clickBack();

        taskListPage.selectRegionAndLAFromTaskList();

        Logger.log("Region and local authority should be empty")
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Region and local authority")
            .inOrder()
            .summaryShows("Region").IsEmpty().HasChangeLink()
            .summaryShows("Local authority").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete();

        cy.executeAccessibilityTests();

        summaryPage.clickChange();

        Logger.log("Configuring region and local authority task")
        regionDetailsPage
            .hasSchoolName(project.schoolName)
            .selectContinue();

        validationComponent.hasValidationError("Select the region of the free school");

        cy.executeAccessibilityTests();

        regionDetailsPage
            .hasSchoolName(project.schoolName)
            .withRegion("South West")
            .selectContinue();

        regionDetailsPage
            .hasSchoolName(project.schoolName)
            .selectContinue();

        validationComponent.hasValidationError("Select the local authority of the free school");

        cy.executeAccessibilityTests();

        regionDetailsPage
            .hasSchoolName(project.schoolName)
            .withLocalAuthority("Gloucestershire")
            .selectContinue();

        Logger.log("Region and local authority should be set")
        summaryPage
            .inOrder()
            .summaryShows("Region").HasValue("South West")
            .summaryShows("Local authority").HasValue("Gloucestershire");

        Logger.log("Edit the region and local authority");
        summaryPage.clickChange();

        regionDetailsPage
            .withRegion("North West")
            .selectContinue();

        regionDetailsPage
            .withLocalAuthority("Liverpool")
            .selectContinue();

        Logger.log("Region and local authority should be set")
        summaryPage
            .inOrder()
            .summaryShows("Region").HasValue("North West")
            .summaryShows("Local authority").HasValue("Liverpool");

        Logger.log("Should update the task status");
        summaryPage.clickConfirmAndContinue();

        taskListPage.isTaskStatusInProgress("RegionAndLocalAuthority");

        taskListPage.selectRegionAndLAFromTaskList();

        summaryPage
            .MarkAsComplete()
            .clickConfirmAndContinue();

        taskListPage.isTaskStatusIsCompleted("RegionAndLocalAuthority");
    });
});

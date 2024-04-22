import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import { Logger } from "cypress/common/logger";
import summaryPage from "cypress/pages/task-summary-base";
import taskListPage from "cypress/pages/taskListPage";
import impactAssessmentEditPage from "../../../pages/tasks/Getting-ready-to-open/edit-impact-assessment-cy";

describe("Testing the impact assessment task", () => {

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

    it("Should be able to set impact assessment", () => {
        Logger.log("Select impact assessment");
        taskListPage.isTaskStatusIsNotStarted("ImpactAssessment")
            .selectImpactAssessmentFromTaskList();

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Impact assessment")
            .inOrder()
            .summaryShows("Conducted the impact assessment using the Assess the Impact of Opening a New Free School tool").IsEmpty().HasChangeLink()
            .summaryShows("Saved the signed-off impact assessment in Workplaces folder").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete();

        Logger.log("Go back to task list");
        summaryPage.clickBack();

        taskListPage.selectImpactAssessmentFromTaskList();
        summaryPage.clickChange();

        Logger.log("Impact assessment can save null values");
        
        impactAssessmentEditPage
        .clickContinue()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Impact assessment")
            .inOrder()
            .summaryShows("Conducted the impact assessment using the Assess the Impact of Opening a New Free School tool").IsEmpty().HasChangeLink()
            .summaryShows("Saved the signed-off impact assessment in Workplaces folder").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete()
            .clickChange();

        cy.executeAccessibilityTests();

        Logger.log("Impact assessment can be edited");
        
        impactAssessmentEditPage
            .checkImpactAssessmentDone()
            .checkSavedToWorkplaces()
            .clickContinue()

        Logger.log("Should update the task status");

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Impact assessment")
            .inOrder()
            .summaryShows("Conducted the impact assessment using the Assess the Impact of Opening a New Free School tool").HasValue("Yes").HasChangeLink()
            .summaryShows("Saved the signed-off impact assessment in Workplaces folder").HasValue("Yes").HasChangeLink()
            .isNotMarkedAsComplete()
            .clickConfirmAndContinue()

        taskListPage.isTaskStatusInProgress("ImpactAssessment");

        taskListPage.selectImpactAssessmentFromTaskList();
        summaryPage.clickChange();

        impactAssessmentEditPage
            .uncheckImpactAssessmentDone()
            .uncheckSavedToWorkplaces()
            .clickContinue()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Impact assessment")
            .inOrder()
            .summaryShows("Conducted the impact assessment using the Assess the Impact of Opening a New Free School tool").IsEmpty().HasChangeLink()
            .summaryShows("Saved the signed-off impact assessment in Workplaces folder").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete()
            .MarkAsComplete()
            .clickConfirmAndContinue()
        
        taskListPage.isTaskStatusIsCompleted("ImpactAssessment");
    });
});
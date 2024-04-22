import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import summaryPage from "cypress/pages/task-summary-base";
import taskListPage from "cypress/pages/taskListPage";
import equalitiesAssessmentEditPage from "../../../pages/tasks/pre-opening/edit-equalities-assessment.cy";

describe("Testing equalities assessment", () => {

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

    it("Should successfully set equalities assessment task", () => {

        cy.log("Select equalities assessment");
        taskListPage.isTaskStatusIsNotStarted("EqualitiesAssessment")
            .selectEqualitiesAssessmentFromTaskList();

        cy.log("Go back to task list");
        summaryPage.clickBack();

        taskListPage.selectEqualitiesAssessmentFromTaskList();

        cy.log("Confirm empty equalities assessment");
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Equalities assessment")
            .inOrder()
            .summaryShows("Completed the equalities process record (EPR)").IsEmpty().HasChangeLink()
            .summaryShows("Saved the EPR in Workplaces folder").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete();

        cy.executeAccessibilityTests();

        summaryPage.clickChange();

        cy.log("Check all the fields are optional");
        equalitiesAssessmentEditPage
            .titleIs("Edit Equalities assessment")
            .schoolNameIs(project.schoolName)
            .clickContinue();

        cy.log("Go back to task list");
        summaryPage.clickBack();

        cy.log("Check confirm puts project in In Progress");
        taskListPage.isTaskStatusInProgress("EqualitiesAssessment")
            .selectEqualitiesAssessmentFromTaskList()


        cy.log("Add new values");
        summaryPage.clickChange();

        cy.executeAccessibilityTests();

        equalitiesAssessmentEditPage
            .schoolNameIs(project.schoolName)

        equalitiesAssessmentEditPage
            .checkCompletedEqualitiesProcessRecord()
            .clickContinue();

        cy.log("Confirm new values for equalities assessment");
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Equalities assessment")
            .inOrder()
            .summaryShows("Completed the equalities process record (EPR)").HasValue("Yes")
            .summaryShows("Saved the EPR in Workplaces folder").IsEmpty()
            .isNotMarkedAsComplete();

        cy.log("Edit values");
        summaryPage.clickChange();

        equalitiesAssessmentEditPage
            .checkSavedEPRInWorkplacesFolder()
            .clickContinue();

        cy.log("Confirm edited values for equalities assessment");
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Equalities assessment")
            .inOrder()
            .summaryShows("Completed the equalities process record (EPR)").HasValue("Yes")
            .summaryShows("Saved the EPR in Workplaces folder").HasValue("Yes")
            .isNotMarkedAsComplete();

        summaryPage
            .MarkAsComplete()
            .clickConfirmAndContinue();

        taskListPage.isTaskStatusIsCompleted("EqualitiesAssessment");
    });
})
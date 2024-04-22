import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import { Logger } from "cypress/common/logger";
import summaryPage from "cypress/pages/task-summary-base";
import taskListPage from "cypress/pages/taskListPage";
import acceptedOffersEvidenceEditPage from "../../../pages/tasks/Getting-ready-to-open/edit-accepted-offers-evidence-cy";

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

    it("Should be able to set accepted offers evidence", () => {
        Logger.log("Select Accepted offers evidence");
        taskListPage.isTaskStatusIsNotStarted("EvidenceOfAcceptedOffers")
            .selectAcceptedOffersEvidenceFromTaskList();

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Accepted offers evidence")
            .inOrder()
            .summaryShows("Seen evidence of accepted offers").IsEmpty().HasChangeLink()
            .summaryShows("Comments").IsEmpty().HasChangeLink()
            .summaryShows("Saved email from the trust in Workplaces folder confirming accepted offers").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete();

        Logger.log("Go back to task list");
        summaryPage.clickBack();

        taskListPage.selectAcceptedOffersEvidenceFromTaskList();
        summaryPage.clickChange();

        Logger.log("Accepted offers evidence can save null values");

        acceptedOffersEvidenceEditPage
        .clickContinue()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Accepted offers evidence")
            .inOrder()
            .summaryShows("Seen evidence of accepted offers").IsEmpty().HasChangeLink()
            .summaryShows("Comments").IsEmpty().HasChangeLink()
            .summaryShows("Saved email from the trust in Workplaces folder confirming accepted offers").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete()
            .clickChange();

        cy.executeAccessibilityTests();

        Logger.log("accepted offers evidence can be edited");

        acceptedOffersEvidenceEditPage
            .withComments("!")
            .clickContinue()
            .errorForComments().showsError("Comments must not include special characters other than , ( ) '")
            .withComments("Valid text")
            .checkSeenAcceptedOffersEvidence()
            .checkSavedToWorkplaces()
            .clickContinue()
        

        Logger.log("Should update the task status");

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Accepted offers evidence")
            .inOrder()
            .summaryShows("Seen evidence of accepted offers").HasValue("Yes").HasChangeLink()
            .summaryShows("Comments").HasValue("Valid text").HasChangeLink()
            .summaryShows("Saved email from the trust in Workplaces folder confirming accepted offers").HasValue("Yes").HasChangeLink()
            .isNotMarkedAsComplete()
            .clickConfirmAndContinue()

        taskListPage.isTaskStatusInProgress("EvidenceOfAcceptedOffers");

        taskListPage.selectAcceptedOffersEvidenceFromTaskList();
        summaryPage.clickChange();

        Logger.log("Should be able to clear all values");

        acceptedOffersEvidenceEditPage
            .uncheckSeenAcceptedOffersEvidence()
            .uncheckSavedToWorkplaces()
            .clearComments()
            .clickContinue()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Accepted offers evidence")
            .inOrder()
            .summaryShows("Seen evidence of accepted offers").IsEmpty().HasChangeLink()
            .summaryShows("Comments").IsEmpty().HasChangeLink()
            .summaryShows("Saved email from the trust in Workplaces folder confirming accepted offers").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete()
            .MarkAsComplete()
            .clickConfirmAndContinue()
        
        taskListPage.isTaskStatusIsCompleted("EvidenceOfAcceptedOffers");
    });
});
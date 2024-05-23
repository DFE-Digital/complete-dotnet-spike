import { ProjectBuilder } from "cypress/api/projectBuilder";
import transferProjectApi from "cypress/api/transferProjectApi";
import { Logger } from "cypress/common/logger";
import summaryPage from "cypress/pages/projects/summaryPage";
import taskListPage, { TransferTaskNames } from "cypress/pages/projects/taskListPage";
import editExternalStakholderKickoffPage from "cypress/pages/projects/transfer/tasks/editExternalStakholderKickoffPage";

describe("Transfer external stakeholder kickoff task", () => {
    let projectId: string;

    beforeEach(() => {
        cy.login();

        transferProjectApi
            .createProject(ProjectBuilder.createTransferProjectRequest())
            .then(response => {
                projectId = response.id;
                cy.visit(`/transfer-projects/${projectId}/tasks`);
            });
    });

    it("Should be able to configure the external stakeholder kickoff task", () => {
        Logger.log("Task has status not started");
        taskListPage
            .withTask(TransferTaskNames.ExternalStakeholderKickoff)
            .then(task => {
                task
                    .hasStatusNotStarted()
                    .select();
            });

        cy.executeAccessibilityTests();

        summaryPage
            .titleIs("External stakeholder kick-off")
            .inOrder()
            .summaryShows("Send introductory emails").HasValue("Empty").HasChangeLink()
            .summaryShows("Send invites to the kick-off meeting or call").HasValue("Empty").HasChangeLink()
            .summaryShows("Host the kick-off meeting or call").HasValue("Empty").HasChangeLink();

        summaryPage.clickChange();

        Logger.log("Configuring the task puts it into completed");
        editExternalStakholderKickoffPage
            .selectSendIntroEmails()
            .selectSendInvites()
            .selectHostKickoffMeeting()
            .save();

        summaryPage
            .inOrder()
            .summaryShows("Send introductory emails").HasValue("Yes").HasChangeLink()
            .summaryShows("Send invites to the kick-off meeting or call").HasValue("Yes").HasChangeLink()
            .summaryShows("Host the kick-off meeting or call").HasValue("Yes").HasChangeLink();

        summaryPage.clickBack();

        taskListPage
            .withTask(TransferTaskNames.ExternalStakeholderKickoff)
            .then(task => {
                task
                    .hasStatusCompleted()
                    .select();
            });
    });
});
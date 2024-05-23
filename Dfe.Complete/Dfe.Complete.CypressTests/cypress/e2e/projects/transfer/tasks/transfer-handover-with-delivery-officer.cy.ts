import transferProjectApi from "cypress/api/transferProjectApi";
import { Logger } from "cypress/common/logger";
import editHandoverWithDeliveryOfficerPage from "cypress/pages/projects/tasks/editHandoverWithDeliveryOfficerPage";
import projectSummarySection from "cypress/pages/projects/projectSummarySection";
import taskListPage, { TransferTaskNames } from "cypress/pages/projects/taskListPage";
import summaryPage from "cypress/pages/projects/summaryPage";
import { ProjectBuilder } from "cypress/api/projectBuilder";

describe("Transfer handover with delivery officer task", () => {

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

    it("Should be able to configure the handover with delivery officer task", () => {
        cy.executeAccessibilityTests();

        projectSummarySection
            .hasUrn("142277 ")
            .hasTransferBadge()
            .hasSchoolName("Newcastle Academy")
            .hasTransferDate("1 March 2026");

        Logger.log("Task has status not started");
        taskListPage
            .withTask(TransferTaskNames.HandoverWithRegionalDeliveryOfficer)
            .then(task => {
                task
                    .hasStatusNotStarted()
                    .select();
            });

        cy.executeAccessibilityTests();

        summaryPage
            .titleIs("Handover with regional delivery officer")
            .inOrder()
            .summaryShows("Not applicable").HasValue("Empty").HasChangeLink()
            .summaryShows("Review the project information and carry out research").HasValue("Empty").HasChangeLink()
            .summaryShows("Make notes and write questions to ask the regional delivery officer").HasValue("Empty").HasChangeLink()
            .summaryShows("Attend handover meeting with regional delivery officer").HasValue("Empty").HasChangeLink();

        summaryPage.clickChange();

        Logger.log("Configuring the task puts it into in progress");
        editHandoverWithDeliveryOfficerPage
            .selectReviewProjectInformation()
            .selectMakeNotes()
            .save();

        summaryPage
            .inOrder()
            .summaryShows("Not applicable").HasValue("Empty")
            .summaryShows("Review the project information and carry out research").HasValue("Yes")
            .summaryShows("Make notes and write questions to ask the regional delivery officer").HasValue("Yes")
            .summaryShows("Attend handover meeting with regional delivery officer").HasValue("Empty");

        summaryPage.clickBack();

        taskListPage
            .withTask(TransferTaskNames.HandoverWithRegionalDeliveryOfficer)
            .then(task => {
                task
                    .hasStatusInProgress()
                    .select();
            });

        Logger.log("Finishing the task puts it into completed");

        summaryPage.clickChange();

        editHandoverWithDeliveryOfficerPage
            .selectAttendHandoverMeeting()
            .save();

        summaryPage
            .inOrder()
            .summaryShows("Not applicable").HasValue("Empty")
            .summaryShows("Review the project information and carry out research").HasValue("Yes")
            .summaryShows("Make notes and write questions to ask the regional delivery officer").HasValue("Yes")
            .summaryShows("Attend handover meeting with regional delivery officer").HasValue("Yes");

        summaryPage.clickBack();

        taskListPage
            .withTask(TransferTaskNames.HandoverWithRegionalDeliveryOfficer)
            .then(task => {
                task
                    .hasStatusCompleted()
                    .select();
            });

        Logger.log("Selecting not applicable puts it into not applicable");

        summaryPage.clickChange();

        editHandoverWithDeliveryOfficerPage
            .selectNotApplicable()
            .save();

        summaryPage
            .inOrder()
            .summaryShows("Not applicable").HasValue("Yes")
            .summaryShows("Review the project information and carry out research").HasValue("Yes")
            .summaryShows("Make notes and write questions to ask the regional delivery officer").HasValue("Yes")
            .summaryShows("Attend handover meeting with regional delivery officer").HasValue("Yes");

        summaryPage.clickBack();

        taskListPage
            .withTask(TransferTaskNames.HandoverWithRegionalDeliveryOfficer)
            .then(task => {
                task
                    .hasStatusNotApplicable();
            });
    });
});
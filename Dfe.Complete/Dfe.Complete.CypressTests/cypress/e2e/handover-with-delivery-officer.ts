import transferProjectApi from "cypress/api/transferProjectApi";
import { Logger } from "cypress/common/logger";
import summaryPage from "cypress/pages/projects/SummaryPage";
import editHandoverWithDeliveryOfficerPage from "cypress/pages/projects/transfer/tasks/editHandoverWithDeliveryOfficerPage";
import transferProjectSummarySection from "cypress/pages/projects/transfer/transferProjectSummarySection";
import transferTaskListPage, { TransferTaskNames } from "cypress/pages/projects/transfer/transferTaskListPage";

describe("POC for automation", () => {

    let projectId: string;

    beforeEach(() => {
        cy.login();

        transferProjectApi
            .createTransferProject({})
            .then(response => {
                projectId = response.id;
            });
    });

    it("Should be able to move around the complete service", () => {

        cy.visit(`/projects/${projectId}/transfer/tasks`);

        cy.executeAccessibilityTests();

        transferProjectSummarySection
            .hasAcademyUrn("116564")
            .hasTransferBadge()
            .hasSchoolName("Southlands School")
            .hasTransferDate("1 June 2025");

        Logger.log("Task has status not started");
        transferTaskListPage
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

        transferTaskListPage
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

        transferTaskListPage
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

        transferTaskListPage
            .withTask(TransferTaskNames.HandoverWithRegionalDeliveryOfficer)
            .then(task => {
                task
                    .hasStatusNotApplicable();
            });
    });
});
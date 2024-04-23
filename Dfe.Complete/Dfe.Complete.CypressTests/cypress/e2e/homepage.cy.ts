import { Logger } from "cypress/common/logger";
import handoverWithRegionalDeliveryOfficerPage from "cypress/pages/transfer/task-list/handoverWithRegionalDeliveryOfficerPage";
import transferProjectSummarySection from "cypress/pages/transfer/transferProjectSummarySection";
import transferTaskListPage, { TransferTaskNames } from "cypress/pages/transfer/transferTaskListPage";

describe("POC for automation", () => {
    it("Should be able to move around the complete service", () => {

        cy.login();

        cy.visit("/projects/51FA403B-B3F3-4580-919B-207B842B9BE3/tasks");

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

        Logger.log("Configuring the task puts it into in progress");
        handoverWithRegionalDeliveryOfficerPage
            .selectReviewProjectInformation()
            .save();

        transferTaskListPage
            .withTask(TransferTaskNames.HandoverWithRegionalDeliveryOfficer)
            .then(task => {
                task
                    .hasStatusInProgress()
                    .select();
            });

        Logger.log("Finishing the task puts it into completed");

        handoverWithRegionalDeliveryOfficerPage
            .selectMakeNotes()
            .selectAttendHandoverMeeting()
            .save();

        transferTaskListPage
            .withTask(TransferTaskNames.HandoverWithRegionalDeliveryOfficer)
            .then(task => {
                task
                    .hasStatusCompleted()
                    .select();
            });

        Logger.log("Selecting not applicable puts it into not applicable");

        handoverWithRegionalDeliveryOfficerPage
            .selectNotApplicable()
            .save();

        transferTaskListPage
            .withTask(TransferTaskNames.HandoverWithRegionalDeliveryOfficer)
            .then(task => {
                task
                    .hasStatusNotApplicable();
            });
    });
});
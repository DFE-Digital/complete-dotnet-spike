import { TaskPageBase } from "cypress/pages/taskPageBase";

class HandoverWithRegionalDeliveryOfficerPage extends TaskPageBase {
    public selectReviewProjectInformation(): this {
        cy.getById("transfer_task_handover_task_form_review").click();

        return this;
    }

    public selectMakeNotes(): this {
        cy.getById("transfer_task_handover_task_form_notes").click();

        return this;
    }

    public selectAttendHandoverMeeting(): this {
        cy.getById("transfer_task_handover_task_form_meeting").click();

        return this;
    }
}

const handoverWithRegionalDeliveryOfficerPage = new HandoverWithRegionalDeliveryOfficerPage();

export default handoverWithRegionalDeliveryOfficerPage;
import { TaskPageBase } from "cypress/pages/taskPageBase";

class EditHandoverWithDeliveryOfficerPage extends TaskPageBase {
    public selectReviewProjectInformation(): this {
        cy.containsById("task_handover_task_form_review").click();

        return this;
    }

    public selectMakeNotes(): this {
        cy.containsById("task_handover_task_form_notes").click();

        return this;
    }

    public selectAttendHandoverMeeting(): this {
        cy.containsById("task_handover_task_form_meeting").click();

        return this;
    }
}

const editHandoverWithDeliveryOfficerPage = new EditHandoverWithDeliveryOfficerPage();

export default editHandoverWithDeliveryOfficerPage;
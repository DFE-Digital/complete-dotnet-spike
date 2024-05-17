import { TaskPageBase } from "cypress/pages/taskPageBase";

class EditExternalStakeholderKickoffPage extends TaskPageBase {
    public selectSendIntroEmails(): this {
        cy.containsById("transfer_task_stakeholder_kick_off_task_form_introductory_emails").click();

        return this;
    }

    public selectSendInvites(): this {
        cy.containsById("transfer_task_stakeholder_kick_off_task_form_setup_meeting").click();

        return this;
    }

    public selectHostKickoffMeeting(): this {
        cy.containsById("transfer_task_stakeholder_kick_off_task_form_meeting").click();

        return this;
    }
}

const editExternalStakholderKickoffPage = new EditExternalStakeholderKickoffPage();

export default editExternalStakholderKickoffPage;
class TaskListPage {
    public withTask(task: string): Cypress.Chainable<TaskSummary> {
        return cy.contains("a", task).parents("li.app-task-list__item")
            .then(el => {
                const element = el as JQuery<Element>;
                return new TaskSummary(element);
            });
    }
}

class TaskSummary {

    constructor(private element: JQuery<Element>) {

    }

    public select() {
        cy.wrap(this.element).find("a").click();

        return this;
    }

    public hasStatusNotStarted(): this {
        this.hasStatus("Not started");

        return this;
    }

    public hasStatusInProgress(): this {
        this.hasStatus("In progress");

        return this;
    }

    public hasStatusCompleted(): this {
        this.hasStatus("Completed");

        return this;
    }

    public hasStatusNotApplicable(): this {
        this.hasStatus("Not applicable");

        return this;
    }

    private hasStatus(status: string) {
        cy.wrap(this.element).find("strong").contains(status);

        return this;
    }
}

export const ConversionTaskNames = {
    HandoverWithRegionalDeliveryOfficer: "Handover with regional delivery officer"
}

export const TransferTaskNames = {
    HandoverWithRegionalDeliveryOfficer: "Handover with regional delivery officer",
    ExternalStakeholderKickoff: "External stakeholder kick-off"
}

const taskListPage = new TaskListPage();

export default taskListPage;
export class TaskPageBase {
    public selectNotApplicable(): this {
        cy.contains("Not applicable").click();

        return this;
    }

    public save(): this {
        cy.contains("button", "Save and return").click();

        return this;
    }
}
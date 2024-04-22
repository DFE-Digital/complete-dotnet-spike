class PupilNumbersSummaryComponent {

    public hasCapacity(value: string): this {
        cy.getByTestId("capacity").should("contain.text", value);

        return this;
    }

    public hasPre16PublishedAdmissionNumber(value: string): this {
        cy.getByTestId("pre16-published-admission-number").should("contain.text", value);

        return this;
    }

    public hasPost16PublishedAdmissionNumber(value: string): this {
        cy.getByTestId("post16-published-admission-number").should("contain.text", value);

        return this;
    }

    public hasMinimumViableNumber(value: string): this {
        cy.getByTestId("minimum-viable-number").should("contain.text", value);

        return this;
    }

    public hasApplicationsReceived(value: string): this {
        cy.getByTestId("applications-received").should("contain.text", value);

        return this;
    }

    public viewDetails(): this {
        cy.getByTestId("change-pupil-numbers").click();

        return this;
    }
}

const pupilNumbersSummaryComponent = new PupilNumbersSummaryComponent();

export default pupilNumbersSummaryComponent;
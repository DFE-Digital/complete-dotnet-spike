class EditCapacityWhenFullPage {

    public hasSchoolName(value: string) {
        cy.getByTestId("school-name").should("contain.text", value);

        return this;
    }

    public withNurseryCapacity(value: string) {
        cy.getById("nursery").clear().type(value);

        return this;
    }

    public withReceptionToYear6Capacity(value: string): this {
        cy.getById("reception-to-year6").clear().type(value);

        return this;
    }

    public withYear7ToYear11Capacity(value: string): this {
        cy.getById("year7-to-year11").clear().type(value);

        return this;
    }

    public withYear12ToYear14Capacity(value: string): this {
        cy.getById("year12-to-year14").clear().type(value);

        return this;
    }

    public withSpecialEducationalNeedsCapacity(value: string): this {
        cy.getById("special-education-needs").clear().type(value);

        return this;
    }

    public withAlternativeProvisionCapacity(value: string): this {
        cy.getById("alternative-provision").clear().type(value);

        return this;
    }

    public saveAndContinue(): this {
        cy.getByTestId("save-and-continue").click();

        return this;
    }
}

const editCapacityWhenFullPage = new EditCapacityWhenFullPage();

export default editCapacityWhenFullPage;
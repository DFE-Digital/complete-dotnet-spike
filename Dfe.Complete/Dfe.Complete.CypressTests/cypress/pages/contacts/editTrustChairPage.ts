
class EditTrustChairPage {

    withTrustChairName(value: string): this {
        cy.getByTestId("edit-trust-chair-name").clear().type(value)
        return this;
    }

    withNullTrustChairName(): this {
        cy.getByTestId("edit-trust-chair-name").clear()
        return this;
    }

    withTrustChairEmail(value: string): this {
        cy.getByTestId("edit-trust-chair-email").clear().type(value)
        return this;
    }

    withNullTrustChairEmail(): this {
        cy.getByTestId("edit-trust-chair-email").clear()
        return this;
    }

    errorForTrustChairName(error: string): this {
        cy.getById('trust-chair-name-error').contains(error)
        return this
    }

    errorForTrustChairEmail(error: string): this {
        cy.getById('trust-chair-email-error').contains(error)
        return this
    }

    public hasTitle(value: string): this {
        cy.getByTestId(`edit-trust-chair-title`).should("contain.text", value);

        return this;
    }

    public hasSchoolName(value: string): this {

        cy.getByTestId(`school-name`).should("contain.text", value);

        return this;
    }

    clickContinue() : this {
        cy.getByTestId("continue").click();
        return this;
    }
}

const editTrustChairPage = new EditTrustChairPage();

export default editTrustChairPage;
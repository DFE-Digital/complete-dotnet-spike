
class EditSchoolChairPage {

    withSchoolChairName(value: string): this {
        cy.getByTestId("edit-school-chair-name").clear().type(value)
        return this;
    }

    withNullSchoolChairName(): this {
        cy.getByTestId("edit-school-chair-name").clear()
        return this;
    }

    withSchoolChairEmail(value: string): this {
        cy.getByTestId("edit-school-chair-email").clear().type(value)
        return this;
    }

    withNullSchoolChairEmail(): this {
        cy.getByTestId("edit-school-chair-email").clear()
        return this;
    }

    errorForSchoolChairName(error: string): this {
        cy.getById('school-chair-name-error').contains(error)
        return this
    }
    errorForSchoolChairEmail(error: string): this {
        cy.getById('school-chair-email-error').contains(error)
        return this
    }

    public hasTitle(value: string): this {
        cy.getByTestId(`edit-school-chair-title`).should("contain.text", value);

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

const editSchoolChairPage = new EditSchoolChairPage();

export default editSchoolChairPage;
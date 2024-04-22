class CreateProjectCheckYourAnswersPage {
    public hasSchoolType(value: string): this {
        cy.getByTestId("school-type").should("contain.text", value);

        return this;
    }

    public changeSchoolType(): this {
        cy.getByTestId("change-school-type").click();

        return this;
    }
}

const createProjectCheckYourAnswersPage = new CreateProjectCheckYourAnswersPage();

export default createProjectCheckYourAnswersPage;
class EqualitiesAssessmentEditPage {

    titleIs(title: string): this {
        cy.getByTestId("title").should("contains.text", title)
        return this;
    }

    schoolNameIs(school: string) {
        cy.getByTestId("school-name").should("contains.text", school);
        return this;
    }

    public clickContinue(): this {
        cy.getByTestId("continue").click();
        return this;
    }

    public checkCompletedEqualitiesProcessRecord(): this {
        cy.getByTestId("completed-the-equalities-process-record").click();
        return this;
    }

    public checkSavedEPRInWorkplacesFolder(): this {
        cy.getByTestId("saved-epr-in-workplaces-folder").click();
        return this;
    }
}

const equalitiesAssessmentEditPage = new EqualitiesAssessmentEditPage();
export default equalitiesAssessmentEditPage;
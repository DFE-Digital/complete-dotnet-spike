class EditDraftGovernancePlanPage {
    public titleIs(title: string): this {
        cy.getByTestId("title").should("contains.text", title)
        return this;
    }

    public schoolNameIs(school: string) {
        cy.getByTestId("school-name").should("contains.text", school);
        return this;
    }

    public clickContinue(): this {
        cy.getByTestId("continue").click();
        return this;
    }

    public checkPlanReceivedFromTrust(): this {
        cy.getById("plan-received-from-trust").click();
        return this;
    }

    public withDatePlanReceived(day: string, month: string, year: string): this {
        cy.enterDate("date-plan-received", day, month, year);

        return this;
    }

    public checkPlanAssessedUsingTemplate(): this {
        cy.getById("plan-assessed-using-template").click();
        return this;
    }

    public checkPlanAndAssessmentSharedWithExpert(): this {
        cy.getById("plan-and-assessment-shared-with-expert").click();
        return this;
    }

    public checkPlanAndAssessmentSharedWithEsfa(): this {
        cy.getById("plan-and-assessment-shared-with-esfa").click();
        return this;
    }

    public checkFedBackToTrustOnPlan(): this {
        cy.getById("plan-fed-back-to-trust").click();
        return this;
    }

    public checkDocumentsSavedInWorkplacesFolder(): this {
        cy.getById("saved-documents-in-workplaces-folder").click();
        return this;
    }

    public withComments(value: string): this {
        cy.getById("comments").typeFast(value);

        return this;
    }

    public withCommentsExceedingMaxLength(): this {
        cy.getById("comments").clear().invoke("text", "a".repeat(1000));

        return this;
    }
}

const editDraftGovernancePlanPage = new EditDraftGovernancePlanPage();

export default editDraftGovernancePlanPage;
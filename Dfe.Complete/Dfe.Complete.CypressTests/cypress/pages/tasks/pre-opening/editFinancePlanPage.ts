class EditFinancePlanPage {
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

    public checkFinancePlanAgreed(): this {
        cy.getById("finance-plan-agreed").click();
        return this;
    }

    public withDateAgreed(day: string, month: string, year: string): this {

        cy.enterDate("date-agreed", day, month, year);

        return this;
    }

    public checkPlanSavedInWorkplacesFolder(): this {
        cy.getById("plan-saved-in-workplaces-folder").click();
        return this;
    }

    public withLocalAuthorityAgreedToUnderwritePupilNumbers(value: string): this {
        cy.getByTestId(`local-authority-agreed-${value}`).click();
        return this;
    }

    public withComments(value: string): this {
        cy.getByTestId("comments").typeFast(value);
        return this;
    }

    public withCommentsExceedingMaxLength(): this {
        cy.getByTestId("comments").clear().invoke("val", "a".repeat(1000));
        return this;
    }

    public withTrustWillOptInToRpa(value: string): this {
        cy.getById(`trust-opt-into-rpa-${value}`).click();
        return this;
    }

    public withRpaStartDate(day: string, month: string, year: string): this {
        cy.enterDate("rpa-start-date", day, month, year);
        return this;
    }

    public hasRpaStartDate(day: string, month: string, year: string): this {
        cy.getById("rpa-start-date-day").should("have.value", day);
        cy.getById("rpa-start-date-month").should("have.value", month);
        cy.getById("rpa-start-date-year").should("have.value", year);

        return this;
    }

    public withRpaCoverType(value: string): this {
        cy.getByTestId(`rpa-cover-type`).typeFast(value);
        return this;
    }

    public withCoverTypeExceedingMaxLength(): this {
        cy.getByTestId("rpa-cover-type").clear().invoke("val", "a".repeat(101));
        return this;
    }

    public hasCoverType(value: string): this {
        cy.getByTestId("rpa-cover-type").should("have.value", value);
        return this;
    }
}

const editFinancePlanPage = new EditFinancePlanPage();

export default editFinancePlanPage;
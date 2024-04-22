class ProjectRiskSummaryPage {

    public hasSchoolName(value: string): this {

        cy.getByTestId(`school-name`).should("contain.text", value);

        return this;
    }

    public hasTitle(value: string): this {
        cy.getByTestId(`risk-date`).should("contain.text", value);

        return this;
    }

    public hasOverallRiskRating(values: string[]): this {

        this.checkRagRating(`overall-risk-rating`, values);

        return this;
    }

    public hasOverallRiskSummary(value: string): this {
        cy.getByTestId(`overall-risk-summary`).should(`contain.text`, value);

        return this;
    }

    public hasNoOverallRiskSummary(): this {
        cy.getByTestId(`overall-risk-summary`).should('not.exist');

        return this;
    }

    public changeOverallRisk(): this {
        cy.getByTestId("change-overall-risk").click();

        return this;
    }

    public hasGovernanceAndSuitabilityRiskRating(values: string[]): this {
        this.checkRagRating(`governance-and-suitability-risk-rating`, values);

        return this;
    }

    public hasGovernanceAndSuitabilityRiskSummary(value: string): this {
        cy.getByTestId(`governance-and-suitability-risk-summary`).should(`contain.text`, value);

        return this;
    }

    public changeGovernanceAndSuitabilityRisk(): this {
        cy.getByTestId("change-governance-and-suitability-risk").click();

        return this;
    }

    public hasEducationRiskRating(values: string[]): this {

        this.checkRagRating(`education-risk-rating`, values);

        return this;
    }

    public hasEducationRiskSummary(value: string): this {

        cy.getByTestId(`education-risk-summary`).should(`contain.text`, value);

        return this;
    }

    public changeEducationRisk(): this {
        cy.getByTestId("change-education-risk").click();

        return this;
    }

    public hasFinanceRiskRating(values: string[]): this {

        this.checkRagRating(`finance-risk-rating`, values);

        return this;
    }

    public hasFinanceRiskSummary(value: string): this {

        cy.getByTestId(`finance-risk-summary`).should(`contain.text`, value);

        return this;
    }

    public changeFinanceRisk(): this {
        cy.getByTestId("change-finance-risk").click();

        return this;
    }

    public hasRiskAppraisalFormSharePointLink(value: string): this {

        const selector = `risk-appraisal-form-sharepoint-link`;

        if (value == "Empty")
        {
            cy.getByTestId(selector).should("contain.text", value);
            return this;
        }

        cy.getByTestId(selector).find("a").should(`have.attr`, `href`, value);

        return this;
    }

    public changeRiskAppraisalFormSharePointLink(): this {
        cy.getByTestId("change-risk-appraisal-form-sharepoint-link").click();

        return this;
    }

    public addRiskEntry(): this {
        this.getAddRiskEntry().click();

        return this;
    }

    public cannotAddRiskEntry(): this {
        this.getAddRiskEntry().should("not.exist");

        return this;
    }

    public createRiskEntry(): this {
        cy.getByTestId("create-risk-entry").click();

        return this;
    }

    public markRiskAsReviewed(): this {
        cy.getByTestId("risk-reviewed").check();

        return this;
    }

    public goToRiskSummary(): this {
        cy.getByTestId("link-risk-summary").click();

        return this;
    }

    public goToProjectOverview(): this {
        cy.getByTestId("link-project-overview").click();

        return this;
    }

    private checkRagRating(selector: string, values: string[]): void {
        cy.assertChildList(selector, values);
    }

    private getAddRiskEntry() {
        return cy.getByTestId("add-risk-entry");
    }
}

const projectRiskSummaryPage = new ProjectRiskSummaryPage();

export default projectRiskSummaryPage;
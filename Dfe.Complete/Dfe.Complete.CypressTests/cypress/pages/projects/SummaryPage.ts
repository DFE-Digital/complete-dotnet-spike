class SummaryPage {
    private summaryCounter = -1;

    public inOrder(): this {
        this.summaryCounter = -1
        console.log(this.summaryCounter);
        return this;
    }

    public skip(amount: number): this {
        this.summaryCounter += amount;
        return this;
    }

    public startFromRow(row: number): this {
        this.summaryCounter = row - 1;
        return this;
    }

    public titleIs(title: string): this {
        cy.getByTestId("title").should("contains.text", title)
        return this;
    }

    public schoolNameIs(school: string): this {
        cy.getByTestId("school-name").should("contains.text", school);
        return this;
    }

    public summaryShows(key: string): this {
        this.summaryCounter++;
        cy.get(".govuk-summary-list__key").eq(this.summaryCounter).should("contains.text", key);
        return this;
    }

    public summaryDoesNotShow(key: string): this {
        cy.get(".govuk-summary-list__key").each($el => {
            cy.wrap($el).should("not.contains.text", key);
        });

        return this;
    }

    public IsEmpty(): this {
        cy.get(".govuk-summary-list__value").eq(this.summaryCounter).should("contains.text", "Empty");
        return this;
    }

    public HasValue(value): this {
        cy.get(".govuk-summary-list__value").eq(this.summaryCounter).should("contains.text", value);
        return this;
    }

    public hasLink(value: string): this {
        cy.get(".govuk-summary-list__value").eq(this.summaryCounter).find("a").should("have.attr", "href", value);
        return this;
    }

    public HasChangeLink(): this {
        cy.get(".govuk-summary-list__row").eq(this.summaryCounter).contains("Change");
        return this;
    }

    public HasNoChangeLink(): this {
        cy.get(".govuk-summary-list__row").eq(this.summaryCounter).contains("Change").should('not.exist');
        return this;
    }

    public clickBack() {
        cy.get(".govuk-back-link").click();
    }

    public clickConfirmAndContinue() {
        cy.getByTestId("confirm").click();
    }

    public clickChange(): this {
        cy.contains("Change").click();
        return this;
    }

    public clickChangeById(string): this {
        cy.getById(string).click();
        return this;
    }

    public clickChangeFor(name: string): this {
        cy.get(".govuk-summary-list__key").contains(name).parent().contains("Change").click();
        return this;
    }

    public clickChangeRiskRating() {
        cy.getByTestId("change-project-risk").click();
    }
}

const summaryPage = new SummaryPage();
export default summaryPage;

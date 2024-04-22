class DatesDetailsPage {

    public titleIs(title: string): this {
        cy.getByTestId("title").should("contains.text", title)
        return this;
    }

    public schoolNameIs(school: string) {
        cy.getByTestId("school-name").should("contains.text", school);
        return this;
    }

    public clickContinue(): this {
        cy.getByClass("govuk-button").click();
        return this;
    }

    public withEntryIntoPreOpening(day: string, month: string, year: string): this {
        cy.enterDate("entry-into-pre-opening", day, month, year);
        return this;
    }

    public withProvisionalOpeningDateAgreedWithTrust(day: string, month: string, year: string): this {
        cy.enterDate("provisional-opening-date-agreed-with-trust", day, month, year);
        return this;
    }
}

const datesDetailsPage = new DatesDetailsPage();

export default datesDetailsPage;
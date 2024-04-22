import validationComponent from "./validationComponent";

class ConstituencySearchPage {
    public schoolNameIs(school: string): this {
        cy.getByTestId("school-name").should("contains.text", school);
        return this;
    }

    public titleIs(title: string): this {
        cy.getByTestId("title").should("contains.text", title)
        return this;
    }

    public searchLabelIs(hint: string): this {
        cy.get(`[for="search-constituency"]`).should("contains.text", hint);
        return this;
    }

    public errorMessage(error: string): this {
        validationComponent.hasValidationError(error);
        return this;
    }

    public errorHint(error: string): this {
        cy.get("#search-constituency-error").should("contains.text", error);
        return this;
    }

    public enterSearch(searchTerm: string): this {
        cy.get("#search-constituency").typeFast(searchTerm);
        return this;
    }

    public clickBack(): this {
        cy.get(".govuk-back-link").click();
        return this;
    }

    public clickContinue(): this {
        cy.getByTestId("continue").click();
        return this;
    }
}

const constituencySearchPage = new ConstituencySearchPage();
export default constituencySearchPage;

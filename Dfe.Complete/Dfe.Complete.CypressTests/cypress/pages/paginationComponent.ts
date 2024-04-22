export class PaginationComponent {
    constructor(private prefix: string = "") {}

    public next(): this {
        cy.getByTestId(`${this.prefix}next-page`).click();

        return this;
    }

    public previous(): this {
        cy.getByTestId(`${this.prefix}previous-page`).click();

        return this;
    }

    public goToPage(pageNumber: string) {
        cy.getByTestId(`${this.prefix}page-${pageNumber}`).click();

        return this;
    }

    public isCurrentPage(pageNumber: string): this {
        // Used to check that we have navigated to the next page with ajax
        cy.getByTestId(`${this.prefix}page-${pageNumber}`)
            .parent()
            .should("have.class", "govuk-pagination__item--current");

        return this;
    }
}

const paginationComponent = new PaginationComponent();

export default paginationComponent;

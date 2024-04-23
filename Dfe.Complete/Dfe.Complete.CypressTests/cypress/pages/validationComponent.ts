class ValidationComponent {
    public hasValidationError(message: string): this {
        cy.get(".govuk-error-summary").should("contain.text", message);
        return this;
    }

    public hasLinkedValidationError(message: string): this {
        cy.get(".govuk-error-summary").contains(message).parent()
            .find("a")
            .invoke('attr', "href")
            .then((href: string | undefined) => {
                cy.get(href as string).should('exist');
                cy.get(href as string + "-error").should("contain.text", message);
            });

        return this;
    }
}

const validationComponent = new ValidationComponent();
export default validationComponent;

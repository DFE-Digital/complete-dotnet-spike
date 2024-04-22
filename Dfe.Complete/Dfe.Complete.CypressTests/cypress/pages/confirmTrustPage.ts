class ConfirmTrustPage {
    public verifyConfirmTrustElementsVisible(schoolName: string, validTrustId: string): this {
        cy.getByClass("govuk-back-link").contains("Back");
        cy.getByClass("govuk-heading-xl").getByClass("govuk-caption-l").contains(schoolName);
        cy.getByClass("govuk-heading-xl").contains("Confirm the trust");

        cy.getByClass("govuk-summary-list__key").eq(0).contains("Trust ID:");
        cy.getByClass("govuk-summary-list__value").eq(0).contains(validTrustId);

        cy.getByClass("govuk-summary-list__key").eq(1).contains("Trust name:");
        cy.getByClass("govuk-summary-list__value").eq(1).contains("King's Group Academies");

        cy.getByClass("govuk-summary-list__key").eq(2).contains("Trust type:");
        cy.getByClass("govuk-summary-list__value").eq(2).contains("MAT (multi-academy trust)");

        cy.getByClass("govuk-heading-s").contains("Is this the correct trust?");

        cy.getByTestId("true").should("not.be.selected");
        cy.getByTestId("false").should("not.be.selected");

        cy.getByClass("govuk-button").should("be.visible").contains("Save and continue");

        return this;
    }

    public selectYes(): this {
        cy.getByTestId("true").click();

        return this;
    }

    public selectNo(): this {
        cy.getByTestId("false").click();

        return this;
    }

    public selectSaveAndContinue(): this {
        cy.getByClass("govuk-button").click();

        return this;
    }
}

const confirmTrustPage = new ConfirmTrustPage();

export default confirmTrustPage;
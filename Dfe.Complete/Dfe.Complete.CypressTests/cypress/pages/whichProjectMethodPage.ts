

class WhichProjectMethodPage {
    public checkElementsVisible(): this {
        cy.getByClass("govuk-back-link").contains("Back");

        cy.getByClass("govuk-fieldset__heading").contains("Which method do you want to use?");

        cy.getByTestId("Individual").should('not.be.checked');
        cy.getByLabelFor("method-1").contains("Creating an individual project");

        cy.getByTestId("Bulk").should('not.be.checked');
        cy.getByLabelFor("method-2").contains("Bulk upload");

        cy.getByTestId("continue").should("be.visible").contains("Continue");

        return this;
    }

    public selectIndividualProject(): this {
        cy.getByTestId("Individual").click();
        cy.getByTestId("Individual").should("be.checked");
        cy.getByTestId("Bulk").should("not.be.checked");

        return this;
    }

    public selectBulkUploadProject(): this {
        cy.getByTestId("Bulk").click();
        cy.getByTestId("Bulk").should("be.checked");
        cy.getByTestId("Individual").should("not.be.checked");

        return this;
    }

    public selectContinue(): this {
        cy.getByTestId("continue").click();

        return this;
    }

    public verifyValidationMessage(): this {
        cy.getById("method-error-link").contains("The method field is required");
        cy.getById("method-error").contains("The method field is required");

        return this;
    }

  

}

const whichProjectMethodPage = new WhichProjectMethodPage();

export default whichProjectMethodPage;
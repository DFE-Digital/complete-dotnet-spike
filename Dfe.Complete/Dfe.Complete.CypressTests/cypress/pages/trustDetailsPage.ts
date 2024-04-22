const invalidTRNString = "POTATO";
const invalidTRNStringWithSpaces = "P O T A T O";
const invalidTRNNumbersString = "1234567";
const nonExistentTrustId = "TR09999";

const SQLInjectionAttempt = "' OR 1=1";
const crossSiteScriptingAttempt = "<script>window.alert('Hello World!')</script>";

class TrustDetailsPage {
    
    
    public selectSaveAndContinue(): this {
        cy.getByClass("govuk-button").click();
        return this;
    }

    public verifyValidationMessagesWhenNoDataSet(): this {
        cy.getById("trn-error").should("be.visible").contains("Enter the TRN");

        return this;
    }

    public enterInvalidTRNStringInTRNPage(): this {
        cy.getById("trn").click();
        cy.getById("trn").typeFast(invalidTRNString);

        return this;

    }

    public enterInvalidTRNStringWithSpacesInTRNPage(): this {
        cy.getById("trn").click();
        cy.getById("trn").typeFast(invalidTRNStringWithSpaces);

        return this;

    }

    public enterInvalidTRNNumbersStringInTRNPage(): this {
        cy.getById("trn").click();
        cy.getById("trn").typeFast(invalidTRNNumbersString);

        return this;

    }

    public enterNonExistentTrustIdInTRNPage(): this {
        cy.getById("trn").click();
        cy.getById("trn").typeFast(nonExistentTrustId);

        return this;

    }

    public enterSQLInjectionAttemptInTRNPage(): this {
        cy.getById("trn").click();
        cy.getById("trn").typeFast(SQLInjectionAttempt);

        return this;

    }

    public enterCrossSiteScriptingAttemptInTRNPage(): this {
        cy.getById("trn").click();
        cy.getById("trn").typeFast(crossSiteScriptingAttempt);

        return this;

    }

    public enterValidTrustId(validTrustId: string): this {
        cy.getById("trn").click();
        cy.getById("trn").typeFast(validTrustId);

        return this;
    }


    public verifyValidationMessagesWhenInvalidTRNFormatEntered(): this {
        cy.getById("trn-error").should("be.visible").contains("The TRN must be in the format TRXXXXX");

        return this;
    }

    public verifyValidationMessagesWhenTRNTooLongEntered(): this {
        cy.getById("trn-error").should("be.visible").contains("The TRN (trust reference number) must be 7 characters or less");

        return this;
    }

    public verifyValidationMessagesWhenNonExistentTRNEntered(): this {
        cy.getById("trn-error").should("be.visible").contains("Trust ID not found");

        return this;
    }


   
}

const trustDetailsPage = new TrustDetailsPage();

export default trustDetailsPage;
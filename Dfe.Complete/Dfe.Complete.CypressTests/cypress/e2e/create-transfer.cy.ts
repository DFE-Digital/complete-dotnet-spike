import homePage from "cypress/pages/homePage";
import addTransferPage from "cypress/pages/transfer/addTransferPage";
import validationComponent from "cypress/pages/validationComponent";

describe("Testing creating a transfer in complete", () => {

    beforeEach(() => {
        cy.login();
    });

    it("Should be able to create a transfer", () => {
        homePage
            .addTransfer();

        addTransferPage
            .continue();

        validationComponent
            .hasValidationError("Enter a school URN")
            .hasValidationError("Enter a UKPRN");
    });
});
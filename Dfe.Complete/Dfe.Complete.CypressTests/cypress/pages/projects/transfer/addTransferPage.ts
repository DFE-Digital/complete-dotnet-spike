class AddTransferPage {
    public continue(): this {
        cy.contains("button", "Continue").click();

        return this;
    }
}

const addTransferPage = new AddTransferPage();

export default addTransferPage;
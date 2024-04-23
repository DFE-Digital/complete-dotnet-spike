class HomePage {
    public addTransfer(): this {
        cy.contains("a", "Add a transfer").click();

        return this;

    }
}

const homePage = new HomePage();

export default homePage;
class EditTransferProject {
    public withOutgoingTrustUkprn(value: string): this {
        cy.containsById("outgoing-trust-ukprn").typeFast(value);

        return this;
    }

    public withIncomingTrustUkprn(value: string): this {
        cy.containsById("incoming-trust-ukprn").typeFast(value);

        return this;
    }

    public withAdvisoryBoardDate(day: string, month: string, year: string): this {
        cy.enterDate("date-of-advisory-board", day, month, year);

        return this;
    }

    public withAdvisoryBoardConditions(value: string): this {
        cy.containsById("advisory-board-conditions").typeFast(value);

        return this;
    }

    public withSchoolSharePointLink(value: string): this {
        cy.containsById("establishment-sharepoint-link").typeFast(value);

        return this;
    }

    public withIncomingTrustSharePointLink(value: string): this {
        cy.containsById("incoming-trust-sharepoint-link").typeFast(value);

        return this;
    }

    public withOutgoingTrustSharePointLink(value: string): this {
        cy.containsById("outgoing-trust-sharepoint-link").typeFast(value);

        return this;
    }

    public withIsDueTo2Ir(value: string): this {

        this.selectYesNo("two-requires-improvement", value);

        return this;
    }

    public withIsDueToInadequateOfstedRating(value: string): this {

        this.selectYesNo("inadequate-ofsted", value);

        return this;
    }

    public withIsDueToIssues(value: string): this {

        this.selectYesNo("financial-safeguarding-governance-issues", value);

        return this;
    }

    public save() {
        cy.contains("Continue").click();
    }

    private selectYesNo(id: string, value: string): this {
        if (value === "Yes") {
            cy.containsById(`${id}-true-field`).click();
        }
        else {
            cy.containsById(`${id}-field`).click();
        }

        return this;
    }
}

const editTransferProject = new EditTransferProject();

export default editTransferProject;
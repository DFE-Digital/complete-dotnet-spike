class BeforeInspectionEditPage {

    checkProcessDetailsProvided(): this {
        cy.getById("process-details-provided").check()
        return this
    }
    checkInspectionBlockDecided(): this {
        cy.getById("inspection-block-decided").check()
        return this
    }

    checkOfstedAndTrustLiaisonDetailsConfirmed(): this {
        cy.getById("ofsted-and-trust-liaison-details-confirmed").check()
        return this
    }

    checkBlockAndContentDetailsToOpenersSpreadsheet(): this {
        cy.getById("block-and-content-details-to-openers-spreadsheet").check()
        return this
    }

    uncheckProcessDetailsProvided(): this {
        cy.getById("process-details-provided").uncheck()
        return this
    }
    uncheckInspectionBlockDecided(): this {
        cy.getById("inspection-block-decided").uncheck()
        return this
    }

    uncheckOfstedAndTrustLiaisonDetailsConfirmed(): this {
        cy.getById("ofsted-and-trust-liaison-details-confirmed").uncheck()
        return this
    }

    uncheckBlockAndContentDetailsToOpenersSpreadsheet(): this {
        cy.getById("block-and-content-details-to-openers-spreadsheet").uncheck()
        return this
    }
    
    clickContinue() : this {
        cy.getByTestId("continue").click();
        return this;
    }
    
}

const beforeInspectionEditPage = new BeforeInspectionEditPage();
export default beforeInspectionEditPage;

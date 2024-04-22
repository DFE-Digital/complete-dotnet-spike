class FundingAgreementHealthCheckPage {

    checkDraftedFAHealthCheck(): this {
        cy.getById("drafted-fa-health-check").check()
        return this
    }

    uncheckDraftedFAHealthCheck(): this {
        cy.getById("drafted-fa-health-check").uncheck()
        return this
    }

    checkRegionalDirectorSignedOffFAHealthCheck(): this {
        cy.getById("regional-director-signed-off-fa-health-check").check()
        return this
    }

    uncheckRegionalDirectorSignedOffFAHealtCheck(): this {
        cy.getById("regional-director-signed-off-fa-health-check").uncheck()
        return this
    }

    checkMinisterSignedOffFAHealthCheck(): this {
        cy.getById("minister-signed-off-fa-health-check").check()
        return this
    }

    uncheckMinisterSignedOffFAHealthCheck(): this {
        cy.getById("minister-signed-off-fa-health-check").uncheck()
        return this
    }

    checkSavedFAHealthCheckInWorkplacesFolder(): this {
        cy.getById("saved-fa-health-check-in-workplaces-folder").check()
        return this
    }

    uncheckSavedFAHealthCheckInWorkplacesFolder(): this {
        cy.getById("saved-fa-health-check-in-workplaces-folder").uncheck()
        return this
    }
    
    clickContinue() : this {
        cy.getByTestId("continue").click();
        return this;
    }

}


const fundingAgreementHealthCheckEditPage = new FundingAgreementHealthCheckPage();
export default fundingAgreementHealthCheckEditPage;

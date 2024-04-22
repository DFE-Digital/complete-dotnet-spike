class AcceptedOffersEvidenceEditPage {
    private errorTracking = "";
    
    
    checkSeenAcceptedOffersEvidence(): this {
        cy.getById("seen-accepted-offers-evidence").check()
        return this
    }

    checkSavedToWorkplaces(): this {
        cy.getById("saved-to-workplaces").check()
        return this
    }

    uncheckSeenAcceptedOffersEvidence(): this {
        cy.getById("seen-accepted-offers-evidence").uncheck()
        return this
    }
    
    uncheckSavedToWorkplaces(): this {
        cy.getById("saved-to-workplaces").uncheck()
        return this
    }

    withComments(comment: string): this {
        cy.getById("comments").typeFast(comment)
        return this;
    }

    clearComments(): this {
        cy.getById("comments").clear()
        return this;
    }
    clickContinue() : this {
        cy.getByTestId("continue").click();
        return this;
    }

    errorForComments(): this {
        this.errorTracking = "comments";
        return this;
    }

    showsError(error: string) {
        cy.get(`#${this.errorTracking}-error-link`)
            .should("contain.text", error);

        cy.get(`#${this.errorTracking}-error-link`)
            .invoke('attr', 'href')
            .then((href) => {
                cy.get(href as string).should("exist");
            });

        cy.get(`#${this.errorTracking}-error`)
            .should("contain.text", error);
        return this;
    }

}

const acceptedOffersEvidenceEditPage = new AcceptedOffersEvidenceEditPage();
export default acceptedOffersEvidenceEditPage;

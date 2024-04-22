class ModelFundingAgreementEditPage {
    private errorTracking = "";
    private summaryCounter = -1;
    private setDate(key: string, day: string, month: string, year: string) {
        cy.get('#' + `${key}-day`).typeFast(day);
        cy.get('#' + `${key}-month`).typeFast(month);
        cy.get('#' + `${key}-year`).typeFast(year);
    }

   

    withAgreedDate(day: string, month: string, year: string): this {
        const key = "date-trust-agrees-with-model-fa";
        this.setDate(key, day, month, year);
        return this
    }

    checkAgreesWithModelFa(): this {
        cy.getById("trust-agrees-with-model-fa-Yes").check()
        return this
    }
    
    

    uncheckAgreesWithModelFa(): this {
        cy.getById("trust-agrees-with-model-fa-No").check()
        return this
    }

    checkTailoredAModelFundingAgreement(): this {
        cy.getById("tailored-model-funding-agreement").check()
        return this
    }

    uncheckTailoredAModelFundingAgreement(): this {
        cy.getById("tailored-model-funding-agreement").uncheck()
        return this
    }

    checkSharedFAWithTrust(): this {
        cy.getById("shared-fa-with-the-trust").check()
        return this
    }

    uncheckSharedFAWithTrust(): this {
        cy.getById("shared-fa-with-the-trust").uncheck()
        return this
    }

    checkDraftedFAHealthcheck(): this {
        cy.getById("drafted-fa-health-check").check()
        return this
    }

    uncheckDraftedFAHealthcheck(): this {
        cy.getById("drafted-fa-health-check").uncheck()
        return this
    }

    checkSavedFADocumentsInWorkplacesFolder(): this {
        cy.getById("saved-fa-documents-in-workplaces-folder").check()
        return this
    }

    uncheckSavedFADocumentsInWorkplacesFolder(): this {
        cy.getById("saved-fa-documents-in-workplaces-folder").uncheck()
        return this
    }

    withComments(comment: string): this {
        cy.getById("comments").typeFast(comment)
        return this;
    }

    public HasValue(value): this {
        cy.get(".govuk-summary-list__value").eq(this.summaryCounter).should("contains.text", value);
        return this;
    }
    
    

    errorForAgreedDate(): this {
        this.errorTracking = "date-trust-agrees-with-model-fa";
        return this;
    }

    errorForComments(): this {
        this.errorTracking = "comments";
        return this;
    }
    
    showsError(error: string)
    {
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
    clickContinue() : this {
        cy.getByTestId("continue").click();
        return this;
    }

}


const modelFundingAgreementEditPage = new ModelFundingAgreementEditPage();
export default modelFundingAgreementEditPage;

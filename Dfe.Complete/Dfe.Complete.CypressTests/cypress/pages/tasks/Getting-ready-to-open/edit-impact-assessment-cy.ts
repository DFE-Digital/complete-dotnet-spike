class ImpactAssessmentEditPage {
  
    
    
    checkImpactAssessmentDone(): this {
        cy.getById("impact-assessment-done").check()
        return this
    }

    checkSavedToWorkplaces(): this {
        cy.getById("saved-to-workplaces").check()
        return this
    }

    uncheckImpactAssessmentDone(): this {
        cy.getById("impact-assessment-done").uncheck()
        return this
    }

    uncheckSavedToWorkplaces(): this {
        cy.getById("saved-to-workplaces").uncheck()
        return this
    }
    clickContinue() : this {
        cy.getByTestId("continue").click();
        return this;
    }

}

const impactAssessmentEditPage = new ImpactAssessmentEditPage();
export default impactAssessmentEditPage;

class AfterInspectionEditPage {

    checkSharedOutcomeWithTrust(): this {
        cy.getById("shared-outcome-with-trust").check()
        return this
    }
    checkInspectionConditionsMet(): this {
        cy.getById("inspection-conditions-met").check()
        return this
    }

    checkProposedToOpenOnGias(): this {
        cy.getById("proposed-to-open-on-gias").check()
        return this
    }
    checkSavedToWorkplaces(): this {
        cy.getById("saved-to-workplaces").check()
        return this
    }

    uncheckSharedOutcomeWithTrust(): this {
        cy.getById("shared-outcome-with-trust").uncheck()
        return this
    }
    uncheckInspectionConditionsMet(): this {
        cy.getById("inspection-conditions-met").uncheck()
        return this
    }

    uncheckProposedToOpenOnGias(): this {
        cy.getById("proposed-to-open-on-gias").uncheck()
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

const afterInspectionEditPage = new AfterInspectionEditPage();
export default afterInspectionEditPage;

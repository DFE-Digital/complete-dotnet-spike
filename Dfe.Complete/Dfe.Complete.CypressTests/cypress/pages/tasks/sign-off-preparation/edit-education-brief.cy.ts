class EducationBriefEditPage {
    
    titleIs(title: string): this {
        cy.getByTestId("title").should("contains.text", title)
        return this;
    }

    schoolNameIs(school: string) {
        cy.getByTestId("school-name").should("contains.text", school);
        return this;
    }

   


    checkEducationPlanInBrief(): this {
        cy.getById("education-plan-in-brief").check()
        return this
    }

    checkEducationPoliciesInBrief(): this {
        cy.getById("education-policies-in-brief").check()
        return this
    }

    checkAssessmentAndTrackingHistoryInPlace(): this {
        cy.getById("pupil-assessment-and-tracking-history").check()
        return this
    }
    
    checkCopySavedToWorkspaces(): this {
        cy.getById("saved-in-workplaces").check()
        return this
    }
    
    uncheckEducationPlanInBrief(): this {
        cy.getById("education-plan-in-brief").uncheck()
        return this
    }

    uncheckEducationPoliciesInBrief(): this {
        cy.getById("education-policies-in-brief").uncheck()
        return this
    }

    uncheckAssessmentAndTrackingHistoryInPlace(): this {
        cy.getById("pupil-assessment-and-tracking-history").uncheck()
        return this
    }

    uncheckCopySavedToWorkspaces(): this {
        cy.getById("saved-in-workplaces").uncheck()
        return this
    }

    public MarkAsComplete() {
        cy.getById("mark-as-completed").click();
        return this;
    }

    public clickConfirmAndContinue() {
        cy.getByTestId("confirm").click();
    }
    
    clickContinue(): this {
        cy.getByTestId("continue").click();
        return this;
    }
    
}

const educationBriefEditPage = new EducationBriefEditPage();
export default educationBriefEditPage;

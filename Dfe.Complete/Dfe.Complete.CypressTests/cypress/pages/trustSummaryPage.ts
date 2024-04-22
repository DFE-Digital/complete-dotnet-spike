import summaryPage from "./task-summary-base";

class TrustSummaryPage {

    public verifyTrustSummaryElementsVisible(): this {
        cy.getByClass("govuk-back-link").contains("Back");
        cy.getByClass("govuk-heading-xl").contains("Trust");

        summaryPage.inOrder()
            .summaryShows("TRN (trust reference number)").HasValue('TR00111').HasChangeLink()
            .summaryShows("Trust name").HasValue('Aurora Academies Trust').HasNoChangeLink()
            .summaryShows("Trust type").HasValue('MAT (multi-academy trust)').HasNoChangeLink();

        cy.getById("mark-as-completed").should("not.be.checked");
        cy.contains("Mark this section as complete, you can still make changes later");

        cy.getByClass("govuk-button").should("be.visible").contains("Confirm and continue");

        return this;
    }

    public verifyTrustSummaryCompleteElementsVisible(validTrustId: string): this {
        cy.getByClass("govuk-back-link").contains("Back");
        cy.getByClass("govuk-heading-xl").contains("Trust");

        summaryPage.inOrder()
            .summaryShows("TRN (trust reference number)").HasValue(validTrustId).HasChangeLink()
            .summaryShows("Trust name").HasValue("King's Group Academies").HasNoChangeLink()
            .summaryShows("Trust type").HasValue("MAT").HasNoChangeLink();

        cy.getById("mark-as-completed").should("not.be.checked");
        cy.contains("Mark this section as complete, you can still make changes later");

        cy.getByClass("govuk-button").should("be.visible").contains("Confirm and continue");

        return this;
    }



    public selectChangeTRNToGoToTrustDetails(): this {
        cy.contains("Change").click();

        return this;
    }

    public selectMarkItemAsComplete(): this {
        cy.getById("mark-as-completed").click();
        return this;
    }

    public selectConfirmAndContinue(): this {
        cy.contains("Confirm and continue").click();
        return this;
    }
}

const trustSummaryPage = new TrustSummaryPage();

export default trustSummaryPage;
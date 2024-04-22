class SchoolSummaryPage {

    public verifySchoolSummaryElementsVisible(schoolName: string): this {
        cy.getByClass("govuk-back-link").contains("Back");
        cy.getByClass("govuk-caption-l").contains(schoolName);
        cy.getByClass("govuk-heading-xl").contains("School");

        cy.getByClass("govuk-summary-list__key").eq(0).contains("Current free school name");
        cy.getByClass("govuk-summary-list__value").eq(0).contains(schoolName);
        cy.getByClass("govuk-link").eq(2).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(1).contains("School type");
        cy.getByClass("govuk-summary-list__value").eq(1).contains("Empty");
        cy.getByClass("govuk-link").eq(3).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(2).contains("School phase");
        cy.getByClass("govuk-summary-list__value").eq(2).contains("Empty");
        cy.getByClass("govuk-link").eq(4).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(3).contains("Age range");
        cy.getByClass("govuk-summary-list__value").eq(3).contains("Empty");
        cy.getByClass("govuk-link").eq(5).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(4).contains("Gender");
        cy.getByClass("govuk-summary-list__value").eq(4).contains("Empty");
        cy.getByClass("govuk-link").eq(6).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(5).contains("Nursery");
        cy.getByClass("govuk-summary-list__value").eq(5).contains("Empty");
        cy.getByClass("govuk-link").eq(7).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(6).contains("Sixth form");
        cy.getByClass("govuk-summary-list__value").eq(6).contains("Empty");
        cy.getByClass("govuk-link").eq(8).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(7).contains("Faith status");
        cy.getByClass("govuk-summary-list__value").eq(7).contains("Empty");
        cy.getByClass("govuk-link").eq(9).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(8).contains("Faith type");
        cy.getByClass("govuk-summary-list__value").eq(8).contains("Empty");
        cy.getByClass("govuk-link").eq(10).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(9).contains("Other faith type");
        cy.getByClass("govuk-summary-list__value").eq(9).contains("Empty");
        cy.getByClass("govuk-link").eq(11).contains("Change");

        cy.getById("mark-as-complete").should("not.be.checked");
        cy.contains("Mark this section as complete, you can still make changes later");

        cy.getByClass("govuk-button").should("be.visible").contains("Confirm and continue");
        
        return this;
    }

    public verifySchoolSummaryValidSpecialCharsElementsVisible(schoolWithAllValidSpecialChars :string): this {
        cy.getByClass("govuk-back-link").contains("Back");
        cy.getByClass("govuk-caption-l").contains("St Dunstan's Abbey, (Plymouth)");
        cy.getByClass("govuk-heading-xl").contains("School");

        
        cy.getByClass("govuk-summary-list__key").eq(0).contains("Current free school name");
        cy.getByClass("govuk-summary-list__value").eq(0).contains(schoolWithAllValidSpecialChars);
        cy.getByClass("govuk-link").eq(2).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(1).contains("School type");
        cy.getByClass("govuk-summary-list__value").eq(1).contains("Mainstream");
        cy.getByClass("govuk-link").eq(3).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(2).contains("School phase");
        cy.getByClass("govuk-summary-list__value").eq(2).contains("Secondary");
        cy.getByClass("govuk-link").eq(4).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(3).contains("Age range");
        cy.getByClass("govuk-summary-list__value").eq(3).contains("11-16");
        cy.getByClass("govuk-link").eq(5).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(4).contains("Gender");
        cy.getByClass("govuk-summary-list__value").eq(4).contains("Mixed");
        cy.getByClass("govuk-link").eq(6).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(5).contains("Nursery");
        cy.getByClass("govuk-summary-list__value").eq(5).contains("No");
        cy.getByClass("govuk-link").eq(7).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(6).contains("Sixth form");
        cy.getByClass("govuk-summary-list__value").eq(6).contains("Yes");
        cy.getByClass("govuk-link").eq(8).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(7).contains("Faith status");
        cy.getByClass("govuk-summary-list__value").eq(7).contains("Ethos");
        cy.getByClass("govuk-link").eq(9).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(8).contains("Faith type");
        cy.getByClass("govuk-summary-list__value").eq(8).contains("Greek Orthodox");
        cy.getByClass("govuk-link").eq(10).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(9).contains("Other faith type");
        cy.getByClass("govuk-summary-list__value").eq(9).contains("Empty");
        cy.getByClass("govuk-link").eq(11).contains("Change");

        cy.getById("mark-as-complete").should("not.be.checked");
        cy.contains("Mark this section as complete, you can still make changes later");

        cy.getByClass("govuk-button").should("be.visible").contains("Confirm and continue");
        
        return this;
    }

    public verifySchoolSummaryCompleteElementsVisible(schoolName: string): this {
        cy.getByClass("govuk-back-link").contains("Back");
        cy.getByClass("govuk-caption-l").contains(schoolName);
        cy.getByClass("govuk-heading-xl").contains("School");
        

        cy.getByClass("govuk-summary-list__key").eq(0).contains("Current free school name");
        cy.getByClass("govuk-summary-list__value").eq(0).contains(schoolName);
        cy.getByClass("govuk-link").eq(2).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(1).contains("School type");
        cy.getByClass("govuk-summary-list__value").eq(1).contains("Mainstream");
        cy.getByClass("govuk-link").eq(3).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(2).contains("School phase");
        cy.getByClass("govuk-summary-list__value").eq(2).contains("Secondary");
        cy.getByClass("govuk-link").eq(4).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(3).contains("Age range");
        cy.getByClass("govuk-summary-list__value").eq(3).contains("11-16");
        cy.getByClass("govuk-link").eq(5).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(4).contains("Gender");
        cy.getByClass("govuk-summary-list__value").eq(4).contains("Mixed");
        cy.getByClass("govuk-link").eq(6).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(5).contains("Nursery");
        cy.getByClass("govuk-summary-list__value").eq(5).contains("No");
        cy.getByClass("govuk-link").eq(7).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(6).contains("Sixth form");
        cy.getByClass("govuk-summary-list__value").eq(6).contains("Yes");
        cy.getByClass("govuk-link").eq(8).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(7).contains("Faith status");
        cy.getByClass("govuk-summary-list__value").eq(7).contains("Ethos");
        cy.getByClass("govuk-link").eq(9).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(8).contains("Faith type");
        cy.getByClass("govuk-summary-list__value").eq(8).contains("Other");
        cy.getByClass("govuk-link").eq(10).contains("Change");

        cy.getByClass("govuk-summary-list__key").eq(9).contains("Other faith type");
        cy.getByClass("govuk-summary-list__value").eq(9).contains("Jane");
        cy.getByClass("govuk-link").eq(11).contains("Change");

        cy.getById("mark-as-complete").should("not.be.checked");
        cy.contains("Mark this section as complete, you can still make changes later");

        cy.getByClass("govuk-button").should("be.visible").contains("Confirm and continue");
        
        return this;
    }



    public selectChangeCurrrentFreeSchoolNameToGoToSchoolDetails(): this {
        cy.contains("Change").eq(0).click();

        return this;
    }

    public selectMarkItemAsComplete(): this {
        cy.getById("mark-as-complete").click();
        return this;
    }

    public selectConfirmAndContinue(): this {
        cy.contains("Confirm and continue").click();
    }
}

const schoolSummaryPage = new SchoolSummaryPage();

export default schoolSummaryPage;
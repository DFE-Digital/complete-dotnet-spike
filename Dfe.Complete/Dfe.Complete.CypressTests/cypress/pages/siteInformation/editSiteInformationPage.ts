export class EditSiteInformationPage {
    public withAddressLine1(value: string): this {
        cy.getById("address-line1").clear().type(value);
        return this;
    }

    public withAddressLine2(value: string): this {
        cy.getById("address-line2").clear().type(value);
        return this;
    }

    public withTownOrCity(value: string): this {
        cy.getById("town-or-city").clear().type(value);
        return this;
    }

    public withPostcode(value: string): this {
        cy.getById("postcode").clear().type(value);
        return this;
    }

    public withStartDateOfSiteOccupation(day: string, month: string, year: string): this {
        cy.enterDate("start-date-of-site-occupation", day, month, year);
        return this;
    }

    public withDatePlanningPermissionObtained(day: string, month: string, year: string): this {
        cy.enterDate("date-planning-permission-obtained", day, month, year);
        return this;
    }

    public hasSchoolName(value: string): this {
        cy.getByTestId("school-name").should("contain.text", value);
        return this;
    }

    public withFieldsExceedingMaxLength(): this {
        cy.getById("address-line1").clear().invoke("val", "a".repeat(101));
        cy.getById("address-line2").clear().invoke("val", "a".repeat(301));
        cy.getById("town-or-city").clear().invoke("val", "a".repeat(101));
        cy.getById("postcode").clear().invoke("val", "a".repeat(11));

        return this;
    }

    public saveAndContinue(): this {
        cy.getByTestId("continue").click();
        return this;
    }
}

const editSiteInformationPage = new EditSiteInformationPage();

export default editSiteInformationPage;
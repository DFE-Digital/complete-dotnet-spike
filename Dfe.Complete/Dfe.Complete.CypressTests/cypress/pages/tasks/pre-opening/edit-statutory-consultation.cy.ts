class StatutoryConsultationEditPage {

    titleIs(title: string): this {
        cy.getByTestId("title").should("contains.text", title)
        return this;
    }

    schoolNameIs(school: string) {
        cy.getByTestId("school-name").should("contains.text", school);
        return this;
    }

    public clickContinue(): this {
        cy.getByTestId("continue").click();
        return this;
    }

    withExpectedDateForReceivingFindingsFromTrust(day: string, month: string, year: string): this {
        const key = "expected-date-for-receiving-findings-from-trust";
        cy.enterDate(key, day, month, year);
        return this
    }

    public checkReceivedConsultationFindingsFromTrust(): this {
        cy.getByTestId("received-consultation-findings-from-trust").click();
        return this;
    }

    withDateReceived(day: string, month: string, year: string): this {
        const key = "date-received";
        cy.enterDate(key, day, month, year);
        return this
    }

    public checkConsultationFulfilsTrustSection10StatutoryDuty(): this {
        cy.getByTestId("consultation-fulfils-trust-section-10-statutory-duty").click();
        return this;
    }

    public withComments(value: string): this {
        cy.getByTestId("comments").typeFast(value);
        return this;
    }

    public withCommentsExceedingMaxLength(): this {
        cy.getByTestId("comments").clear().invoke("val", "a".repeat(1000));
        return this;
    }

    public checkSavedFindingsInWorkplacesFolder(): this {
        cy.getByTestId("saved-findings-in-workplaces-folder").click();
        return this;
    }
}

const statutoryConsultationEditPage = new StatutoryConsultationEditPage();
export default statutoryConsultationEditPage;
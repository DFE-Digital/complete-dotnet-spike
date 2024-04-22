class ViewRecruitmentAndViabilityPage {
    public hasReceptionToYear6(
        minimumViableNumber: string,
        applicationsReceived: string,
        percentageComparedToMvn: string,
        percentageComparedToPan: string) {

        this.hasRow("reception-to-year6", minimumViableNumber, applicationsReceived, percentageComparedToMvn, percentageComparedToPan);

        return this;
    }

    public hasYear7ToYear11(
        minimumViableNumber: string,
        applicationsReceived: string,
        percentageComparedToMvn: string,
        percentageComparedToPan: string) {

        this.hasRow("year7-to-year11", minimumViableNumber, applicationsReceived, percentageComparedToMvn, percentageComparedToPan);

        return this;
    }

    public hasYear12ToYear14(
        minimumViableNumber: string,
        applicationsReceived: string,
        percentageComparedToMvn: string,
        percentageComparedToPan: string) {

        this.hasRow("year12-to-year14", minimumViableNumber, applicationsReceived, percentageComparedToMvn, percentageComparedToPan);

        return this;
    }

    public hasTotal(
        minimumViableNumber: string,
        applicationsReceived: string,
    ) {
        cy.getByTestId(`total-mvn`).should("contain.text", minimumViableNumber);
        cy.getByTestId(`total-applications-received`).should("contain.text", applicationsReceived);
    }

    public hasRow(
        idPrefix: string,
        minimumViableNumber: string,
        applicationsReceived: string,
        percentageComparedToMvn: string,
        percentageComparedToPan: string) {
        cy.getByTestId(`${idPrefix}-mvn`).should("contain.text", minimumViableNumber);
        cy.getByTestId(`${idPrefix}-applications-received`).should("contain.text", applicationsReceived);
        cy.getByTestId(`${idPrefix}-mvn-ratio`).should("contain.text", percentageComparedToMvn);
        cy.getByTestId(`${idPrefix}-pan-ratio`).should("contain.text", percentageComparedToPan);

        return this;


    }
}

const viewRecruitmentAndViabilityPage = new ViewRecruitmentAndViabilityPage();

export default viewRecruitmentAndViabilityPage;
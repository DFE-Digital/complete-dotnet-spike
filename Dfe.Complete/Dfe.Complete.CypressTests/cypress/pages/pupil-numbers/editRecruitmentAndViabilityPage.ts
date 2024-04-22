class EditRecruitmentAndViabilityPage {

    public withReceptionToYear6(
        minimumViableNumber: string,
        applicationsReceived: string) {

        this.withRow("reception-to-year6", minimumViableNumber, applicationsReceived)

        return this;
    }

    public withYear7ToYear11(
        minimumViableNumber: string,
        applicationsReceived: string) {

        this.withRow("year7-to-year11", minimumViableNumber, applicationsReceived)

        return this;
    }

    public withYear12ToYear14(
        minimumViableNumber: string,
        applicationsReceived: string) {

        this.withRow("year12-to-year14", minimumViableNumber, applicationsReceived)

        return this;
    }

    public saveAndContinue() {
        cy.getByTestId("save-and-continue").click();

        return this;
    }

    private withRow(
        idPrefix: string,
        minimumViableNumber: string,
        applicationsReceived: string) {

        cy.getByTestId(`${idPrefix}-mvn`).clear().type(minimumViableNumber);
        cy.getByTestId(`${idPrefix}-applications-received`).clear().type(applicationsReceived);
    }
}

const editRecruitmentAndViabilityPage = new EditRecruitmentAndViabilityPage();

export default editRecruitmentAndViabilityPage;
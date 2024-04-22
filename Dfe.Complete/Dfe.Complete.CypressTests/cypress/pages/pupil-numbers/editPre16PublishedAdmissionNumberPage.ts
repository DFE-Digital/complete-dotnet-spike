class EditPre16PublishedAdmissionNumberPage {
    public withReception(value: string) {
        cy.getById("reception").clear().type(value);

        return this;
    }

    public withYear7(value: string) {
        cy.getById("year7").clear().type(value);

        return this;
    }

    public withYear10(value: string) {
        cy.getById("year10").clear().type(value);

        return this;
    }

    public withOtherPre16(value: string) {
        cy.getById("other-pre16").clear().type(value);

        return this;
    }

    public saveAndContinue() {
        cy.getByTestId("save-and-continue").click();

        return this;
    }
}

const editPre16PublishedAdmissionNumberPage = new EditPre16PublishedAdmissionNumberPage();

export default editPre16PublishedAdmissionNumberPage;
class EditPost16PublishedAdmissionNumberPage {
    public withYear12(value: string) {
        cy.getById("year12").clear().type(value);

        return this;
    }

    public withOtherPost16(value: string) {
        cy.getById("other-post16").clear().type(value);

        return this;
    }

    public saveAndContinue() {
        cy.getByTestId("save-and-continue").click();

        return this;
    }
}

const editPost16PublishedAdmissionNumberPage = new EditPost16PublishedAdmissionNumberPage();

export default editPost16PublishedAdmissionNumberPage;
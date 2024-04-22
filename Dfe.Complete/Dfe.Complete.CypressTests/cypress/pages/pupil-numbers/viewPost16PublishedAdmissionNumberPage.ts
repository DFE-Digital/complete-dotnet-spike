class ViewPost16PublishedAdmissionNumberPage {
    public hasYear12(value: string) {
        cy.getByTestId("year12-pan").should("contain.text", value);

        return this;
    }

    public hasOtherPost16(value: string) {
        cy.getByTestId("other-post16-pan").should("contain.text", value);

        return this;
    }

    public hasTotal(value: string) {
        cy.getByTestId("total-post16-pan").should("contain.text", value);

        return this;
    }
}

const viewPost16PublishedAdmissionNumberPage = new ViewPost16PublishedAdmissionNumberPage();

export default viewPost16PublishedAdmissionNumberPage;
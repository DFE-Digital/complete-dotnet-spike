class ViewPre16PublishedAdmissionNumber {
    public hasReception(value: string) {
        cy.getByTestId("reception-pan").should("contain.text", value);

        return this;
    }

    public hasYear7(value: string) {
        cy.getByTestId("year7-pan").should("contain.text", value);

        return this;
    }

    public hasYear10(value: string) {
        cy.getByTestId("year10-pan").should("contain.text", value);

        return this;

    }

    public hasOtherPre16(value: string) {
        cy.getByTestId("other-pre16-pan").should("contain.text", value);

        return this;
    }

    public hasTotal(value: string) {
        cy.getByTestId("total-pre16-pan").should("contain.text", value);

        return this;
    }
}

const viewPre16PublishedAdmissionNumber = new ViewPre16PublishedAdmissionNumber();

export default viewPre16PublishedAdmissionNumber;
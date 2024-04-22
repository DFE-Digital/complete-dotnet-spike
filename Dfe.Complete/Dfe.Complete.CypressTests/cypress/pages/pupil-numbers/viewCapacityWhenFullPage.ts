class ViewCapacityWhenFullPage {
    public hasNursery(value: string): this {
        cy.getByTestId("nursery-capacity").should("contain.text", value);

        return this;
    }

    public hasReceptionToYear6(value: string): this {
        cy.getByTestId("reception-to-year6-capacity").should("contain.text", value);

        return this;
    }

    public hasYear7ToYear11(value: string): this {
        cy.getByTestId("year7-to-year11-capacity").should("contain.text", value);

        return this;
    }

    public hasYear12ToYear14(value: string): this {
        cy.getByTestId("year12-to-year14-capacity").should("contain.text", value);

        return this;
    }

    public hasSpecialEducationalNeeds(value: string): this {
        cy.getByTestId("special-educational-needs-capacity").should("contain.text", value);

        return this;
    }

    public hasAlternativeProvision(value: string): this {
        cy.getByTestId("alternative-provision-capacity").should("contain.text", value);

        return this;
    }

    public hasTotal(value: string): this {
        cy.getByTestId("total-capacity").should("contain.text", value);

        return this;
    }
}

const viewCapacityWhenFullPage = new ViewCapacityWhenFullPage();

export default viewCapacityWhenFullPage;
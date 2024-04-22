class editStopPayments {
    private errorTracking = "";

    public titleIs(title: string): this {
        cy.getByTestId("title").should("contains.text", title)
        return this;
    }

    public schoolNameIs(school: string): this {
        cy.getByTestId("school-name").should("contains.text", school);
        return this;
    }

    public paymentStoppedDateIsVisible(): this {
        cy.getById("payment-stopped-date").should('be.visible');
        return this;
    }
    
    public paymentStoppedDateIsNotVisible(): this {
        cy.getById("payment-stopped-date").should('be.not.visible');
        return this;
    }

    public withPaymentStopped(value: string): this {
        cy.getById(`payment-stopped-${value}`).click();
        return this;
    }

    public withPaymentStoppedDate(day: string, month: string, year: string): this {
        const key = "payment-stopped-date";
        this.setDate(key, day, month, year);
        return this
    }

    
    public paymentStoppedDateIsBlank(): this {
        const key = "payment-stopped-date";
        cy.get('#' + `${key}-day`).should('be.empty');
        cy.get('#' + `${key}-month`).should('be.empty');
        cy.get('#' + `${key}-year`).should('be.empty');
        return this
    }

    private setDate(key: string, day: string, month: string, year: string) {
        cy.get('#' + `${key}-day`).typeFast(day);
        cy.get('#' + `${key}-month`).typeFast(month);
        cy.get('#' + `${key}-year`).typeFast(year);
    }
    
    errorForPaymentStoppedDate(): this {
        this.errorTracking = "payment-stopped-date";
        return this;
    }
   
    showsError(error: string)
    {
        cy.get(`#${this.errorTracking}-error-link`)
            .should("contain.text", error);

        cy.get(`#${this.errorTracking}-error-link`)
            .invoke('attr', 'href')
            .then((href) => {
                cy.get(href as string).should("exist");
            });

        cy.get(`#${this.errorTracking}-error`)
            .should("contain.text", error);
        return this;
    }

    public clickContinue() : this {
        cy.getByTestId("continue").click();
        return this;
    }
}

const stopPayments = new editStopPayments();
export default stopPayments;

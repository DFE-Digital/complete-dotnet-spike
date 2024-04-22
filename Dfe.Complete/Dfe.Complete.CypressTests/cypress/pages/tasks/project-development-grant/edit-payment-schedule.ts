class editPaymentSchedule {
    private errorTracking = "";

    public titleIs(title: string): this {
        cy.getByTestId("title").should("contains.text", title)
        return this;
    }

    public schoolNameIs(school: string): this {
        cy.getByTestId("school-name").should("contains.text", school);
        return this;
    }

    public withPaymentDueDate(day: string, month: string, year: string): this {
        const key = "payment-due-date";
        this.setDate(key, day, month, year);
        return this
    }

    public withPaymentActualDate(day: string, month: string, year: string): this {
        const key = "actual-payment-date";
        this.setDate(key, day, month, year);
        return this
    }
    
    public withPaymentDueAmount(comment: string): this {
        cy.getById("payment-due-amount").typeFast(comment)
        return this;
    }

    public withPaymentActualAmount(comment: string): this {
        cy.getById("payment-actual-amount").typeFast(comment)
        return this;
    }

    private setDate(key: string, day: string, month: string, year: string) {
        cy.get('#' + `${key}-day`).typeFast(day);
        cy.get('#' + `${key}-month`).typeFast(month);
        cy.get('#' + `${key}-year`).typeFast(year);
    }
    
    // public HasValue(value): this {
    //     cy.get(".govuk-summary-list__value").eq(this.summaryCounter).should("contains.text", value);
    //     return this;
    // }

    errorForPaymentDueDate(): this {
        this.errorTracking = "payment-due-date";
        return this;
    }
    
    errorForPaymentActualDate(): this {
        this.errorTracking = "actual-payment-date";
        return this;
    }

    errorForPaymentDueAmount(): this {
        this.errorTracking = "payment-due-amount";
        return this;
    }

    errorForPaymentActualAmount(): this {
        this.errorTracking = "payment-actual-amount";
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

const paymentSchedule = new editPaymentSchedule();
export default paymentSchedule;

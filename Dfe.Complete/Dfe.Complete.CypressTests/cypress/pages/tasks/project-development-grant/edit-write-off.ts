class editWriteOff {
    private errorTracking = "";

    public titleIs(title: string): this {
        cy.getByTestId("title").should("contains.text", title)
        return this;
    }

    public schoolNameIs(school: string): this {
        cy.getByTestId("school-name").should("contains.text", school);
        return this;
    }
        
    public withWriteOffReason(comment: string): this {
        cy.getById("write-off-reason").typeFast(comment)
        return this;
    }

    public withWriteOffAmount(comment: string): this {
        cy.getById("write-off-amount").typeFast(comment)
        return this;
    }

    public withWriteOffDate(day: string, month: string, year: string): this {
        const key = "write-off-date";
        this.setDate(key, day, month, year);
        return this
    }
    
    public withFinanceBusinessPartnerApproval(comment: string): this {
        cy.getById("finance-partner").typeFast(comment)
        return this;
    }

    public withApprovalDate(day: string, month: string, year: string): this {
        const key = "approval-date";
        this.setDate(key, day, month, year);
        return this
    }
    
    private setDate(key: string, day: string, month: string, year: string) {
        cy.get('#' + `${key}-day`).typeFast(day);
        cy.get('#' + `${key}-month`).typeFast(month);
        cy.get('#' + `${key}-year`).typeFast(year);
    }

    public errorForWriteOffReason(): this {
        this.errorTracking = "write-off-reason"
        return this;
    }

    public errorForWriteOffAmount(): this {
        this.errorTracking = "write-off-amount"
        return this;
    }

    public errorForWriteOffDate(): this {
        this.errorTracking =  "write-off-date";
        return this
    }
    
    public errorForFinanceBusinessPartnerApproval(): this {
        this.errorTracking = "finance-partner"
        return this;
    }

    public errorForApprovalDate(): this {
        this.errorTracking = "approval-date";
        return this
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

const writeOff = new editWriteOff();
export default writeOff;

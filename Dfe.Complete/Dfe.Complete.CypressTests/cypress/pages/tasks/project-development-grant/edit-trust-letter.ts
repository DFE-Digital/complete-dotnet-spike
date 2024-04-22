class editTrustLetter {
    private errorTracking = "";

    public titleIs(title: string): this {
        cy.getByTestId("title").should("contains.text", title)
        return this;
    }

    public schoolNameIs(school: string): this {
        cy.getByTestId("school-name").should("contains.text", school);
        return this;
    }

    public withTrustLetterDate(day: string, month: string, year: string): this {
        const key = "trust-letter-date";
        this.setDate(key, day, month, year);
        return this
    }

    public checkSavedInWorkplaces(): this {
        cy.getById("saved-letter-in-workplaces-folder").click();
        return this;
    }

    private setDate(key: string, day: string, month: string, year: string) {
        cy.get('#' + `${key}-day`).typeFast(day);
        cy.get('#' + `${key}-month`).typeFast(month);
        cy.get('#' + `${key}-year`).typeFast(year);
    }
    
    errorForPaymentDueDate(): this {
        this.errorTracking = "trust-letter-date";
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


const trustLetter = new editTrustLetter();
export default trustLetter;

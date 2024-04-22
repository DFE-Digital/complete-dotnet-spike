class RiskAppraisalMeetingEditPage {
    private errorTracking = "";
    
    titleIs(title: string): this {
        cy.getByTestId("title").should("contains.text", title)
        return this;
    }

    schoolNameIs(school: string) {
        cy.getByTestId("school-name").should("contains.text", school);
        return this;
    }

    withInitialRiskAppraisalMeetingCompleted(setting: "Yes" | "No"): this {
        const control = "Initial risk appraisal meeting completed";
        cy.contains(control)
        .parent()
        .contains(setting)
            .invoke('attr', 'for')
            .then((id) => {
            cy.get('#' + id).click();
        });
        return this;
    }
    
    private setDate(key: string, day: string, month: string, year: string) {
        cy.get('#' + `${key}-day`).typeFast(day);
        cy.get('#' + `${key}-month`).typeFast(month);
        cy.get('#' + `${key}-year`).typeFast(year);
    }

    withForecastDate(day: string, month: string, year: string): this {
        const key = "forecast-date";
        this.setDate(key, day, month, year);
        return this
    }

    withActualDate(day: string, month: string, year: string): this {
        const key = "actual-date";
        this.setDate(key, day, month, year);
        return this
    }

    withComments(comment: string): this {
        cy.getByTestId("comments-on-decision").typeFast(comment)
        return this;
    }

    withReason(reason: string): this {
        cy.getByTestId("reason-not-applicable").typeFast(reason)
        return this;
    }

    errorForComments(): this
    {
        this.errorTracking = "comments-on-decision";
        return this;       
    }

    errorForReason(): this
    {
        this.errorTracking = "reason-not-applicable";
        return this;       
    }

    errorForForecastDate(): this
    {
        this.errorTracking = "forecast-date";
        return this;       
    }

    errorForActualDate(): this
    {
        this.errorTracking = "actual-date";
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

    clickContinue() : this {
        cy.getByTestId("continue").click();
        return this;
    }
}

const riskAppraisalMeetingEditPage = new RiskAppraisalMeetingEditPage();
export default riskAppraisalMeetingEditPage;

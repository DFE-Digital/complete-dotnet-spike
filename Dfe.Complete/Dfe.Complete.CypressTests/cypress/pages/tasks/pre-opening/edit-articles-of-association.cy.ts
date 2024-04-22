class ArticlesOfAssociationEditPage {
    private errorTracking = "";

    titleIs(title: string): this {
        cy.getByTestId("title").should("contains.text", title)
        return this;
    }

    schoolNameIs(school: string) {
        cy.getByTestId("school-name").should("contains.text", school);
        return this;
    }


    private setDate(key: string, day: string, month: string, year: string) {
        cy.get('#' + `${key}-day`).typeFast(day);
        cy.get('#' + `${key}-month`).typeFast(month);
        cy.get('#' + `${key}-year`).typeFast(year);
    }

    checkSubmittedArticlesMatch(): this {
        cy.getById("checked-submitted-articles-match").check()
        return this
    }

    checkChairHaveSubmittedConfirmation(): this {
        cy.getById("chair-have-submitted-confirmation").check()
        return this
    }

    checkArrangementsMatchGovernancePlans(): this {
        cy.getById("arrangements-match-governance-plans").check()
        return this
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

    withSharepointLink(value: string): this {
        cy.getByTestId("sharepoint-link").typeFast(value)
        return this;
    }

    withSharepointLinkExceedingMaxLength(): this {
        cy.getByTestId("sharepoint-link").clear().invoke("val", `https://${"a".repeat(501)}`);
        return this;
    }

    errorForComments(): this {
        this.errorTracking = "comments-on-decision";
        return this;
    }

    errorForSharepointLink(): this {
        this.errorTracking = "sharepoint-link";
        return this;
    }

    errorForForecastDate(): this {
        this.errorTracking = "forecast-date";
        return this;
    }

    errorForActualDate(): this {
        this.errorTracking = "actual-date";
        return this;
    }

    showsError(error: string) {
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

    clickContinue(): this {
        cy.getByTestId("continue").click();
        return this;
    }
}

const articlesOfAssociationEditPage = new ArticlesOfAssociationEditPage();
export default articlesOfAssociationEditPage;

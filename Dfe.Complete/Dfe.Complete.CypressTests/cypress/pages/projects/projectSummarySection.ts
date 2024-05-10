export class ProjectSummarySection {
    public hasUrn(value: string): this {
        cy.contains("span", `URN ${value}`);

        return this;
    }

    public hasTransferBadge(): this {
        cy.contains("strong", "Transfer");

        return this;
    }

    public hasConversionBadge(): this {
        cy.contains("strong", "Conversion");

        return this;
    }

    public hasSchoolName(value: string): this {
        cy.contains("h1", value);

        return this;
    }

    public hasTransferDate(value: string) {
        cy.contains("dt", "Transfer date")
            .then(el => {
                cy.wrap(el).siblings().contains("dd", value);
            });

        return this;
    }

    public hasConversionDate(value: string) {
        cy.contains("dt", "Conversion date")
            .then(el => {
                cy.wrap(el).siblings().contains("dd", value);
            });

        return this;
    }
}

const projectSummarySection = new ProjectSummarySection();

export default projectSummarySection;
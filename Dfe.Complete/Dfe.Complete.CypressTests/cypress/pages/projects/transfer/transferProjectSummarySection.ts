export class TransferProjectSummarySection {
    public hasAcademyUrn(value: string): this {
        cy.contains("span", `Academy URN ${value}`);

        return this;
    }

    public hasTransferBadge(): this {
        cy.contains("strong", "Transfer");

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
}

const transferProjectSummarySection = new TransferProjectSummarySection();

export default transferProjectSummarySection;
export class ProjectRiskSummaryComponent {
    public hasProjectRiskRating(values: string[]): this {
        cy.assertChildList(`project-risk-rating`, values);

        return this;
    }

    public hasProjectRiskSummary(value: string): this {
        cy.getByTestId("project-risk-summary").should("contain.text", value);

        return this;
    }

    public hasProjectRiskDate(value: string): this {
        cy.getByTestId("project-risk-date").should("contain.text", value);

        return this;
    }
}

const projectRiskSummaryComponent = new ProjectRiskSummaryComponent();

export default projectRiskSummaryComponent;
export class ProjectRow {
    constructor(private element: Element) {}

    public hasProjectId(value: string): this {
        this.containsText("project-id", value);

        return this;
    }

    public hasProjectTitle(value: string): this {
        this.containsText("project-title", value);

        return this;
    }

    public hasTrustName(value: string): this {
        this.containsText("trust-name", value);

        return this;
    }

    public hasRegionName(value: string): this {
        this.containsText("region-name", value);

        return this;
    }

    public hasLocalAuthority(value: string): this {
        this.containsText("local-authority", value);

        return this;
    }

    public hasRealisticOpeningdate(value: string): this {
        this.containsText("provisional-opening-date", value);

        return this;
    }

    public hasStatus(value: string): this {
        this.containsText("status", value);

        return this;
    }

    public view(): this {
        cy.wrap(this.element).within(() => {
            cy.getByTestId("action").click();
        });

        return this;
    }

    private containsText(id: string, value: string) {
        cy.wrap(this.element).within(() => {
            cy.getByTestId(id).should("contain.text", value);
        });
    }
}

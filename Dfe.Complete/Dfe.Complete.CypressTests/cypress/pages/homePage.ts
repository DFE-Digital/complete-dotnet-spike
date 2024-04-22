class HomePage {

    public createNewProjects(): this {
        cy.contains("Create new projects").click();
        //   cy.login({role: ProjectRecordCreator})
        return this;
    }

    public createProject(): this {
        cy.getByTestId("create-project-button").click();

        return this;
    }

    public deleteProject(): this {
        cy.getByTestId("delete-project-button").click();

        return this;
    }

    public openFilter(): this {
        cy.getByTestId("filter-button").click();

        return this;
    }

    public withProjectFilter(project: string): this {
        cy.getByTestId("search-by-project").typeFast(project);

        return this;
    }

    public hasProjectFilter(project: string): this {
        cy.getByTestId("search-by-project")
            .should("have.value", project);

        return this;
    }

    public withRegionFilter(region: string): this {
        cy.getByTestId(`${region}-option`).check();

        return this;
    }

    public hasRegionFilter(region: string): this {
        cy.getByTestId(`${region}-option`).should("be.checked");

        return this;
    }

    public withLocalAuthorityFilter(localAuthority: string): this {
        cy.getByTestId(`${localAuthority}-option`).check();

        return this;
    }

    public hasLocalAuthorityFilter(localAuthority: string): this {
        cy.getByTestId(`${localAuthority}-option`).should("be.checked");

        return this;
    }

    public applyFilters(): this {
        cy.getByTestId("apply-filters").click();

        return this;
    }

    public clearFilters(): this {
        cy.getByTestId("clear-filters").click();

        return this;
    }

    public downloadProjectDataExport() {
        cy.getByTestId("download-data-export").click();
    }
}

const homePage = new HomePage();

export default homePage;

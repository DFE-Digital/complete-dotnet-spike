import dashboardApi from "cypress/api/dashboardApi";
import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import { Logger } from "cypress/common/logger";
import homePage from "cypress/pages/homePage";
import paginationComponent from "cypress/pages/paginationComponent";
import projectTable from "cypress/pages/projectTable";
import path from "path";

describe("Testing the home page", () => {
    beforeEach(() => {
        cy.login();
        cy.visit("/");
    });

    describe("Filtering by project", () => {
        let firstProject: ProjectDetailsRequest;
        let secondProject: ProjectDetailsRequest;
        let projectTitlePrefix: string;

        beforeEach(() => {
            firstProject = RequestBuilder.createProjectDetails();
            secondProject = RequestBuilder.createProjectDetails();
            projectTitlePrefix = firstProject.schoolName.substring(0, 10);

            firstProject.schoolName = `${projectTitlePrefix} school`;
            secondProject.schoolName = `${projectTitlePrefix} academy`;

            projectApi.post({
                projects: [firstProject, secondProject],
            });
        });

        it("Should be able to filter projects by project ID", () => {
            homePage.openFilter().withProjectFilter(projectTitlePrefix).applyFilters();

            projectTable
                .getRowByProjectId(firstProject.projectId)
                .then((row) => {
                    row.hasProjectId(firstProject.projectId);
                    row.hasProjectTitle(firstProject.schoolName);
                    row.hasStatus("Not started");
                });

            projectTable
                .getRowByProjectId(secondProject.projectId)
                .then((row) => {
                    row.hasProjectId(secondProject.projectId);
                    row.hasProjectTitle(secondProject.schoolName);
                    row.hasStatus("Not started");
                });

            // Filter is displayed and has the searched value
            // clear proves its visible, as the visibility checks don't work
            homePage
                .hasProjectFilter(projectTitlePrefix)
                .clearFilters();
        });
    });

    describe("Filtering by region", () => {
        let firstProject: ProjectDetailsRequest;

        beforeEach(() => {
            firstProject = RequestBuilder.createProjectDetails();
            firstProject.region = `North West`;

            projectApi.post({
                projects: [firstProject],
            });
        });

        it("Should be able to filter projects by region", () => {
            homePage.openFilter().withRegionFilter("North West").applyFilters();

            projectTable.allRowsHaveRegion("North West");

            // Filter is displayed and has the searched value
            // clear proves its visible, as the visibility checks don't work
            homePage
                .hasRegionFilter("North West")
                .clearFilters();
        });
    });

    describe("Filtering by region and Local authority", () => {
        let firstProject: ProjectDetailsRequest;

        beforeEach(() => {
            firstProject = RequestBuilder.createProjectDetails();
            firstProject.region = `East of England`;
            firstProject.localAuthority = "Bedford";

            const secondProject = RequestBuilder.createProjectDetails();
            firstProject.region = "East of England";

            projectApi.post({
                projects: [firstProject, secondProject],
            });
        });

        it("Should be able to filter projects by local authority", () => {
            homePage
                .openFilter()
                .withRegionFilter("East of England")
                .withLocalAuthorityFilter("Bedford")
                .applyFilters();

            projectTable.allRowsHaveLocalAuthority("Bedford");

            // Filter is displayed and has the searched value
            // clear proves its visible, as the visibility checks don't work
            homePage
                .hasRegionFilter("East of England")
                .hasLocalAuthorityFilter("Bedford")
                .clearFilters();
        });
    });

    describe("Pagination on the dashboard with filters for project", () => {
        const paginationPrefix = "Pagination";
        const region = "South East";

        beforeEach(() => {
            dashboardApi
                .get({ project: paginationPrefix, regions: [region] })
                .then((response) => {
                    const currentNumberOfProjects = response.paging.recordCount;
                    const projectsToCreate = 41 - currentNumberOfProjects;

                    const projects: Array<ProjectDetailsRequest> = [];

                    for (let idx = 0; idx < projectsToCreate; idx++) {
                        const project = RequestBuilder.createProjectDetails();
                        project.schoolName = `${project.schoolName.substring(
                            0,
                            15,
                        )} ${paginationPrefix}`;
                        project.region = region;
                        projects.push(project);
                    }

                    projectApi.post({
                        projects: projects,
                    });

                    cy.reload();
                });
        });

        it("Should paginate the projects based on my filter criteria", () => {
            homePage
                .openFilter()
                .withProjectFilter(paginationPrefix)
                .withRegionFilter(region)
                .applyFilters();

            let pageOneProjects: Array<string> = [];
            let pageTwoProjects: Array<string> = [];

            projectTable
                .getProjectIds()
                .then((projectIds: Array<string>) => {
                    pageOneProjects = projectIds;

                    Logger.log("Ensure we have 20 projects on page one");
                    expect(pageOneProjects.length).to.eq(20);

                    paginationComponent.isCurrentPage("1");

                    Logger.log(
                        "Moving to the second page using the direct link",
                    );
                    paginationComponent.goToPage("2");
                    return projectTable.getProjectIds();
                })
                .then((projectIds: Array<string>) => {
                    pageTwoProjects = projectIds;

                    Logger.log("Ensure we have 20 projects on page 2");
                    expect(pageTwoProjects.length).to.equal(20);

                    Logger.log(
                        "Ensure that the projects on page one and two are different",
                    );
                    hasNoSimilarElements(pageOneProjects, pageTwoProjects);

                    paginationComponent.isCurrentPage("2");

                    Logger.log("Move to the previous page, which is page 1");
                    paginationComponent.previous();
                    return projectTable.getProjectIds();
                })
                .then((projectIds: Array<string>) => {
                    Logger.log(
                        "On moving to page one, we should get the exact same projects",
                    );
                    expect(projectIds).to.deep.equal(pageOneProjects);

                    Logger.log("Move to the next page, which is page 2");
                    paginationComponent.next();
                    return projectTable.getProjectIds();
                })
                .then((projectIds: Array<string>) => {
                    Logger.log(
                        "On moving to page two, we should get the exact same cases",
                    );
                    expect(projectIds).to.deep.equal(pageTwoProjects);

                    Logger.log("Move to the third page");

                    paginationComponent.next();

                    return projectTable.getProjectIds();
                })
                .then((projectIds: Array<string>) => {
                    Logger.log("Should get 1 case on page 3");
                    expect(projectIds.length).to.equal(1);

                    paginationComponent.isCurrentPage("3");
                });
        });
    });

    describe("Checking the project data export", () => {
        it("Should be able to download a file of the project data export", () => {
            homePage.downloadProjectDataExport();

            const now = new Date().toISOString().split('T')[0];
            const fileName = `${now}-mfsp-all-projects-export.xlsx`;

            const downloadsFolder = Cypress.config('downloadsFolder')
            const downloadedFilename = path.join(downloadsFolder, fileName)

            cy.readFile(downloadedFilename, 'binary')
                .should(buffer => expect(buffer.length).to.be.gt(100));
        });
    });

    function hasNoSimilarElements(first: Array<string>, second: Array<string>) {
        const firstSet = new Set(first);

        const match = second.some((e) => firstSet.has(e));

        expect(match).to.be.false;
    }
});

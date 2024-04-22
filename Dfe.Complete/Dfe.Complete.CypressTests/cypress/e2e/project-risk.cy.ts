import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import { Logger } from "cypress/common/logger";
import editProjectRiskPage from "cypress/pages/risk/editProjectRiskPage";
import projectOverviewPage from "cypress/pages/projectOverviewPage";
import projectRiskSummaryPage from "cypress/pages/risk/projectRiskSummaryPage";
import validationComponent from "cypress/pages/validationComponent";
import projectRiskHistoryTable from "cypress/pages/risk/projectRiskHistoryTable";
import { toDisplayDate } from "cypress/support/formatDate";

describe("Testing that we can add a project risk", () => {
    let project: ProjectDetailsRequest;
    let now: Date;

    beforeEach(() => {
        cy.login();

        now = new Date();

        project = RequestBuilder.createProjectDetails();

        projectApi
            .post({
                projects: [project],
            })
            .then(() => {
                cy.visit(`/projects/${project.projectId}/overview`);
            });
    });

    describe("Adding a project risk", () => {
        it("Should be able to add project risk", () => {

            projectOverviewPage
                .hasProjectRiskDate("Empty")
                .hasProjectRiskRating(["Empty"])
                .hasProjectRiskSummary("Empty");

            Logger.log("Changing project risk")
            projectOverviewPage.changeProjectRisk();

            Logger.log("When there is no project risk, it should display empty for all fields");
            projectRiskSummaryPage
                .hasTitle("Current risk ratings")
                .hasSchoolName(project.schoolName)
                .hasOverallRiskRating(["Empty"])
                .hasNoOverallRiskSummary()
                .hasGovernanceAndSuitabilityRiskRating(["Empty"])
                .hasGovernanceAndSuitabilityRiskSummary("Empty")
                .hasEducationRiskRating(["Empty"])
                .hasEducationRiskSummary("Empty")
                .hasFinanceRiskRating(["Empty"])
                .hasFinanceRiskSummary("Empty")
                .hasRiskAppraisalFormSharePointLink("Empty");

            Logger.log("Add risk entry");
            projectRiskSummaryPage.addRiskEntry();

            Logger.log("Validate Governance and suitability");
            projectRiskSummaryPage.changeGovernanceAndSuitabilityRisk();

            editProjectRiskPage
                .withGovernanceAndSuitabilityRiskSummaryExceeding()
                .continue();

            validationComponent
                .hasValidationError("The summary must be 1000 characters or less");

            cy.executeAccessibilityTests();

            Logger.log("Enter a valid governance and suitability risk");
            editProjectRiskPage
                .hasSchoolName(project.schoolName)
                .withGovernanceAndSuitabilityRiskRating("AmberGreen")
                .withGovernanceAndSuitabilityRiskSummary("This is my governance and suitability risk summary")
                .continue();

            Logger.log("Validate education");
            projectRiskSummaryPage.changeEducationRisk()

            editProjectRiskPage
                .withEducationSummaryExceeding()
                .continue();

            validationComponent
                .hasValidationError("The summary must be 1000 characters or less");

            cy.executeAccessibilityTests();

            Logger.log("Enter a valid education risk");
            editProjectRiskPage
                .hasSchoolName(project.schoolName)
                .withEducationRiskRating("Red")
                .withEducationSummary("This is my education risk summary")
                .continue();

            Logger.log("Validate finance");
            projectRiskSummaryPage.changeFinanceRisk();

            editProjectRiskPage
                .withFinanceSummaryExceeding()
                .continue();

            validationComponent
                .hasValidationError("The summary must be 1000 characters or less");

            cy.executeAccessibilityTests();

            Logger.log("Enter a valid finance risk");
            editProjectRiskPage
                .hasSchoolName(project.schoolName)
                .withFinanceRiskRating("AmberRed")
                .withFinanceSummary("This is my finance risk summary")
                .continue();

            Logger.log("Validate RAF sharepoint link");
            projectRiskSummaryPage.changeRiskAppraisalFormSharePointLink();

            editProjectRiskPage
                .withRiskAppraisalFormSharePointLink("aaaa")
                .continue();

            validationComponent.hasValidationError("The SharePoint link must be a valid url");

            editProjectRiskPage
                .withRiskAppraisalFormSharePointLinkExceeding()
                .continue();

            validationComponent.hasValidationError("The SharePoint link must be 500 characters or less");

            cy.executeAccessibilityTests();

            Logger.log("Enter a valid risk appraisal form sharepoint link");
            editProjectRiskPage
                .hasSchoolName(project.schoolName)
                .withRiskAppraisalFormSharePointLink("http://www.google.co.uk")
                .continue();

            Logger.log("Validate overall risk");
            projectRiskSummaryPage.changeOverallRisk();

            editProjectRiskPage
                .withOverallRiskSummaryExceeding()
                .continue();

            validationComponent
                .hasValidationError("The summary must be 1000 characters or less");

            cy.executeAccessibilityTests();

            Logger.log("Enter a valid overall risk");
            editProjectRiskPage
                .hasSchoolName(project.schoolName)
                .withOverallRiskRating("Green")
                .withOverallRiskSummary("This is my overall risk summary")
                .continue();

            projectRiskSummaryPage
                .hasOverallRiskRating(["Green"])
                .hasOverallRiskSummary("This is my overall risk summary")
                .hasGovernanceAndSuitabilityRiskRating(["Amber", "Green"])
                .hasGovernanceAndSuitabilityRiskSummary("This is my governance and suitability risk summary")
                .hasEducationRiskRating(["Red"])
                .hasEducationRiskSummary("This is my education risk summary")
                .hasFinanceRiskRating(["Amber", "Red"])
                .hasFinanceRiskSummary("This is my finance risk summary")
                .hasRiskAppraisalFormSharePointLink("http://www.google.co.uk");

            cy.executeAccessibilityTests();

            Logger.log("Cannot create a project risk without confirming");
            projectRiskSummaryPage.createRiskEntry();

            validationComponent.hasValidationError("Confirm that you have reviewed the ratings and summaries")

            Logger.log("Create the project risk");
            projectRiskSummaryPage
                .markRiskAsReviewed()
                .createRiskEntry()
                .goToRiskSummary();

            projectRiskSummaryPage
                .hasTitle(`${toDisplayDate(now)} - current risk ratings`)
                .hasOverallRiskRating(["Green"])
                .hasOverallRiskSummary("This is my overall risk summary")
                .hasGovernanceAndSuitabilityRiskRating(["Amber", "Green"])
                .hasGovernanceAndSuitabilityRiskSummary("This is my governance and suitability risk summary")
                .hasEducationRiskRating(["Red"])
                .hasEducationRiskSummary("This is my education risk summary")
                .hasFinanceRiskRating(["Amber", "Red"])
                .hasFinanceRiskSummary("This is my finance risk summary")
                .hasRiskAppraisalFormSharePointLink("http://www.google.co.uk");

            cy.executeAccessibilityTests();

            Logger.log("Ensure that the project risk has been updated on the overview");
            cy.visit(`/projects/${project.projectId}/overview`);

            projectOverviewPage
                .hasProjectRiskDate(toDisplayDate(now))
                .hasProjectRiskRating(["Green"])
                .hasProjectRiskSummary("This is my overall risk summary");
        });

        it("Should be able to add multiple project risks with the latest being displayed by default", () => {
            Logger.log("Changing project risk")
            projectOverviewPage.changeProjectRisk();

            Logger.log("Adding the first project risk");
            projectRiskSummaryPage.addRiskEntry();

            fillProjectRisk();
            projectRiskSummaryPage
                .markRiskAsReviewed()
                .createRiskEntry()
                .goToRiskSummary();

            Logger.log("Adding the second project risk");
            projectRiskSummaryPage.addRiskEntry();

            Logger.log("Enter a valid governance and suitability risk");
            projectRiskSummaryPage.changeGovernanceAndSuitabilityRisk();

            editProjectRiskPage
                .hasGovernanceAndSuitabilityRiskRating("AmberGreen")
                .hasGovernanceAndSuitabilityRiskSummary("This is my governance and suitability risk summary")
                .withGovernanceAndSuitabilityRiskRating("Green")
                .withGovernanceAndSuitabilityRiskSummary("This is another governance and suitability risk summary")
                .continue();

            Logger.log("Enter a valid education risk");
            projectRiskSummaryPage.changeEducationRisk();

            editProjectRiskPage
                .hasEducationRiskRating("Red")
                .hasEducationRiskSummary("This is my education risk summary")
                .withEducationRiskRating("AmberRed")
                .withEducationSummary("This is another of my education risk summary")
                .continue();

            Logger.log("Enter a valid finance risk");
            projectRiskSummaryPage.changeFinanceRisk();

            editProjectRiskPage
                .hasFinanceRiskRating("AmberRed")
                .hasFinanceRiskSummary("This is my finance risk summary")
                .withFinanceRiskRating("Red")
                .withFinanceSummary("This is another of my finance risk summary")
                .continue();

            Logger.log("Enter a valid risk appraisal form sharepoint link");
            projectRiskSummaryPage.changeRiskAppraisalFormSharePointLink();

            editProjectRiskPage
                .hasRiskAppraisalFormSharePointLink("http://www.google.co.uk")
                .withRiskAppraisalFormSharePointLink("http://www.yahoo.com")
                .continue();

            Logger.log("Enter a valid overall risk");
            projectRiskSummaryPage.changeOverallRisk();

            editProjectRiskPage
                .hasOverallRiskRating("Green")
                .hasOverallRiskSummary("This is my overall risk summary")
                .withOverallRiskRating("AmberGreen")
                .withOverallRiskSummary("This is another of my overall risk summary")
                .continue();

            Logger.log("Check our changes have been applied to the check page");
            projectRiskSummaryPage
                .hasOverallRiskRating(["Amber", "Green"])
                .hasOverallRiskSummary("This is another of my overall risk summary")
                .hasGovernanceAndSuitabilityRiskRating(["Green"])
                .hasGovernanceAndSuitabilityRiskSummary("This is another governance and suitability risk summary")
                .hasEducationRiskRating(["Amber", "Red"])
                .hasEducationRiskSummary("This is another of my education risk summary")
                .hasFinanceRiskRating(["Red"])
                .hasFinanceRiskSummary("This is another of my finance risk summary")
                .hasRiskAppraisalFormSharePointLink("http://www.yahoo.com");

            projectRiskSummaryPage
                .markRiskAsReviewed()
                .createRiskEntry()
                .goToRiskSummary();

            projectRiskSummaryPage
                .hasOverallRiskRating(["Amber", "Green"])
                .hasOverallRiskSummary("This is another of my overall risk summary")
                .hasGovernanceAndSuitabilityRiskRating(["Green"])
                .hasGovernanceAndSuitabilityRiskSummary("This is another governance and suitability risk summary")
                .hasEducationRiskRating(["Amber", "Red"])
                .hasEducationRiskSummary("This is another of my education risk summary")
                .hasFinanceRiskRating(["Red"])
                .hasFinanceRiskSummary("This is another of my finance risk summary")
                .hasRiskAppraisalFormSharePointLink("http://www.yahoo.com");

            Logger.log("Should show the history of the project risk")
            projectRiskHistoryTable
                .getRowByIndex(1)
                .then((firstRow) => {
                    firstRow
                        .hasDate(toDisplayDate(now))
                        .hasRiskRating(["Amber", "Green"])
                        .hasNoViewLink();

                    return projectRiskHistoryTable.getRowByIndex(2)
                })
                .then((secondRow) => {
                    secondRow
                        .hasDate(toDisplayDate(now))
                        .hasRiskRating(["Green"]);

                    Logger.log("Select the second history entry")
                    secondRow
                        .view();

                    Logger.log("Should the information for the previous risk")
                    projectRiskSummaryPage
                        .hasTitle(`${toDisplayDate(now)} - past risk ratings`)
                        .hasOverallRiskRating(["Green"])
                        .hasOverallRiskSummary("This is my overall risk summary")
                        .hasGovernanceAndSuitabilityRiskRating(["Amber", "Green"])
                        .hasGovernanceAndSuitabilityRiskSummary("This is my governance and suitability risk summary")
                        .hasEducationRiskRating(["Red"])
                        .hasEducationRiskSummary("This is my education risk summary")
                        .hasFinanceRiskRating(["Amber", "Red"])
                        .hasFinanceRiskSummary("This is my finance risk summary")
                        .hasRiskAppraisalFormSharePointLink("http://www.google.co.uk")
                        .cannotAddRiskEntry();

                    Logger.log("Checking the change links are updated");
                    return projectRiskHistoryTable.getRowByIndex(2);
                })
                .then((secondRow) => {
                    secondRow.hasNoViewLink();

                    return projectRiskHistoryTable.getRowByIndex(1);
                })
                .then(firstRow => {
                    firstRow.view();

                    projectRiskSummaryPage
                        .hasOverallRiskRating(["Amber", "Green"])
                        .hasOverallRiskSummary("This is another of my overall risk summary")


                    Logger.log("Ensure that the latest project risk has been updated on the overview");
                    cy.visit(`/projects/${project.projectId}/overview`);

                    projectOverviewPage
                        .hasProjectRiskDate(toDisplayDate(now))
                        .hasProjectRiskRating(["Amber", "Green"])
                        .hasProjectRiskSummary("This is another of my overall risk summary");
                });
        });

        it("Should be able to add a project risk with the minimum values set", () => {
            Logger.log("Changing project risk")
            projectOverviewPage.changeProjectRisk();

            Logger.log("Add risk entry");
            projectRiskSummaryPage.addRiskEntry();

            Logger.log("Ensure that all fields are optional in the forms");
            projectRiskSummaryPage.changeGovernanceAndSuitabilityRisk();
            editProjectRiskPage.continue();
            projectRiskSummaryPage.changeEducationRisk();
            editProjectRiskPage.continue();
            projectRiskSummaryPage.changeFinanceRisk();
            editProjectRiskPage.continue();
            projectRiskSummaryPage.changeRiskAppraisalFormSharePointLink();
            editProjectRiskPage.continue();
            projectRiskSummaryPage.changeOverallRisk();
            editProjectRiskPage.continue();

            projectRiskSummaryPage
                .hasOverallRiskRating(["Empty"])
                .hasOverallRiskSummary("Empty")
                .hasGovernanceAndSuitabilityRiskRating(["Empty"])
                .hasGovernanceAndSuitabilityRiskSummary("Empty")
                .hasEducationRiskRating(["Empty"])
                .hasEducationRiskSummary("Empty")
                .hasFinanceRiskRating(["Empty"])
                .hasFinanceRiskSummary("Empty")
                .hasRiskAppraisalFormSharePointLink("Empty");

            projectRiskSummaryPage.createRiskEntry();

            validationComponent
                .hasValidationError("Enter an overall risk")
                .hasValidationError("Confirm that you have reviewed the ratings and summaries");

            Logger.log("Enter an overall risk");
            projectRiskSummaryPage.changeOverallRisk();
            editProjectRiskPage.withOverallRiskRating("Green").continue();

            projectRiskSummaryPage
                .markRiskAsReviewed()
                .createRiskEntry()
                .goToRiskSummary();

            projectRiskSummaryPage
                .hasOverallRiskRating(["Green"])
                .hasNoOverallRiskSummary()
                .hasGovernanceAndSuitabilityRiskRating(["Empty"])
                .hasGovernanceAndSuitabilityRiskSummary("Empty")
                .hasEducationRiskRating(["Empty"])
                .hasEducationRiskSummary("Empty")
                .hasFinanceRiskRating(["Empty"])
                .hasFinanceRiskSummary("Empty")
                .hasRiskAppraisalFormSharePointLink("Empty");

            projectRiskHistoryTable
                .getRowByIndex(1)
                .then((firstRow) => {
                    firstRow
                        .hasDate(toDisplayDate(now))
                        .hasRiskRating(["Green"]);
                })
        });

        it("Should add a project risk entry even if none of the data changes", () => {
            Logger.log("Changing project risk")
            projectOverviewPage.changeProjectRisk();

            Logger.log("Add risk entry");
            projectRiskSummaryPage.addRiskEntry();

            Logger.log("Enter an overall risk");
            projectRiskSummaryPage.changeOverallRisk();
            editProjectRiskPage.withOverallRiskRating("Green").continue();

            projectRiskSummaryPage
                .markRiskAsReviewed()
                .createRiskEntry()
                .goToRiskSummary();

            Logger.log("Add another risk and change nothing")
            projectRiskSummaryPage.addRiskEntry();

            projectRiskSummaryPage
                .markRiskAsReviewed()
                .createRiskEntry()
                .goToRiskSummary();

            Logger.log("Check the entry has been added");
            projectRiskSummaryPage
                .hasOverallRiskRating(["Green"]);

            projectRiskHistoryTable
                .getRowByIndex(1)
                .then((firstRow) => {
                    firstRow
                        .hasDate(toDisplayDate(now))
                        .hasRiskRating(["Green"]);

                    return projectRiskHistoryTable.getRowByIndex(2);
                }).then((secondRow) => {
                    secondRow
                        .hasDate(toDisplayDate(now))
                        .hasRiskRating(["Green"]);
                });
        });
    });
});

function fillProjectRisk(): void {
    Logger.log("Enter a valid governance and suitability risk");
    projectRiskSummaryPage.changeGovernanceAndSuitabilityRisk();

    editProjectRiskPage
        .withGovernanceAndSuitabilityRiskRating("AmberGreen")
        .withGovernanceAndSuitabilityRiskSummary("This is my governance and suitability risk summary")
        .continue();

    Logger.log("Enter a valid education risk");
    projectRiskSummaryPage.changeEducationRisk();

    editProjectRiskPage
        .withEducationRiskRating("Red")
        .withEducationSummary("This is my education risk summary")
        .continue();

    Logger.log("Enter a valid finance risk");
    projectRiskSummaryPage.changeFinanceRisk();

    editProjectRiskPage
        .withFinanceRiskRating("AmberRed")
        .withFinanceSummary("This is my finance risk summary")
        .continue();

    Logger.log("Enter a valid risk appraisal form sharepoint link");
    projectRiskSummaryPage.changeRiskAppraisalFormSharePointLink();

    editProjectRiskPage
        .withRiskAppraisalFormSharePointLink("http://www.google.co.uk")
        .continue();

    Logger.log("Enter a valid overall risk");
    projectRiskSummaryPage.changeOverallRisk();

    editProjectRiskPage
        .withOverallRiskRating("Green")
        .withOverallRiskSummary("This is my overall risk summary")
        .continue();
}

import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import { Logger } from "cypress/common/logger";
import { specialCharsTestString } from "cypress/constants/stringTestConstants";
import dataGenerator from "cypress/fixtures/dataGenerator";
import constituencyEditPage from "cypress/pages/constituencyEditPage";
import constituencySearchPage from "cypress/pages/constituencySearchPage";
import summaryPage from "cypress/pages/task-summary-base";
import taskListPage from "cypress/pages/taskListPage";

describe("Testing Constituency Task", () => {
    let project: ProjectDetailsRequest;

    beforeEach(() => {
        cy.login();

        project = RequestBuilder.createProjectDetails();

        projectApi
            .post({
                projects: [project],
            })
            .then(() => {
                cy.visit(`/projects/${project.projectId}/tasks`);
            });
    });


    it("Should successfully set Tasklist-school information", () => {

        Logger.log("Select constituency");
        taskListPage.isTaskStatusIsNotStarted("Constituency")
            .selectConstituencyFromTaskList();

        Logger.log("Confirm empty constituency");
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Constituency")
            .inOrder()
            .summaryShows("Name").IsEmpty().HasChangeLink()
            .summaryShows("MP").IsEmpty().HasNoChangeLink()
            .summaryShows("Political party").IsEmpty().HasNoChangeLink()
            .isNotMarkedAsComplete();

        cy.executeAccessibilityTests();
        Logger.log("Go back to task list");
        summaryPage.clickBack();

        Logger.log("Confirm not started and open constituency");
        taskListPage.isTaskStatusIsNotStarted("Constituency")
            .selectConstituencyFromTaskList();

        Logger.log("Check confirm puts project in In Progress");
        summaryPage.clickConfirmAndContinue();

        taskListPage.isTaskStatusInProgress("Constituency")
            .selectConstituencyFromTaskList();

        Logger.log("Check search page");

        summaryPage.clickChange();

        constituencySearchPage
            .schoolNameIs(project.schoolName)
            .titleIs("Search for a constituency")
            .searchLabelIs("Enter a name or postcode");

        cy.executeAccessibilityTests();

        Logger.log("Check back link");
        constituencySearchPage.clickBack();

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Constituency")
            .inOrder()
            .summaryShows("Name").IsEmpty().HasChangeLink()
            .summaryShows("MP").IsEmpty().HasNoChangeLink()
            .summaryShows("Political party").IsEmpty().HasNoChangeLink()
            .isNotMarkedAsComplete();

        summaryPage.clickChange();

        Logger.log("Check validation for no input");

        constituencySearchPage
            .clickContinue()
            .errorMessage("Enter a name or postcode. For example, South London or W1A 1AA")
            .errorHint("Enter a name or postcode. For example, South London or W1A 1AA");

        cy.executeAccessibilityTests();
        Logger.log("Check validation for long string (50 chars)");

        constituencySearchPage
            .enterSearch(dataGenerator.generateAlphaNumeric(51))
            .clickContinue()
            .errorMessage("The name or postcode must be 50 characters or less")
            .errorHint("The name or postcode must be 50 characters or less");

        cy.executeAccessibilityTests();
        Logger.log("Perform valid search and use None option to navigate back to search");

        constituencySearchPage
            .enterSearch(specialCharsTestString)
            .clickContinue()
            .errorMessage("Name or postcode must not include special characters other than , ( ) '")
            .errorHint("Name or postcode must not include special characters other than , ( ) '");

        Logger.log("Perform valid search and use None option to navigate back to search");


        constituencySearchPage
            .enterSearch("SW1P")
            .clickContinue()

        cy.executeAccessibilityTests();

        constituencyEditPage
            .schoolNameIs(project.schoolName)
            .titleIs("Confirm the constituency")
            .hasResult("Battersea")
            .hasResult("Cities of London and Westminster")
            .hasResult("Hammersmith")
            .hasNoneOption()
            .selectNoneOption()
            .clickContinue()

        Logger.log("Perform a search which yields no results");

        constituencySearchPage
            .enterSearch("Potato")
            .clickContinue()

        cy.executeAccessibilityTests();

        constituencyEditPage
            .schoolNameIs(project.schoolName)
            .titleIs("0 results for Potato")
            .clickSearchAgain()

        Logger.log("Perform valid search and pick option and save");

        constituencySearchPage
            .enterSearch("SW1P")
            .clickContinue()

        constituencyEditPage
            .hasResult("Battersea")
            .hasResult("Cities of London and Westminster")
            .hasResult("Hammersmith")
            .hasNoneOption()
            .selectOption("Battersea")
            .clickContinue()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Constituency")
            .inOrder()
            .summaryShows("Name").HasValue("Battersea").HasChangeLink()
            .summaryShows("MP").HasValue("Marsha De Cordova MP").HasNoChangeLink()
            .summaryShows("Political party").HasValue("Labour").HasNoChangeLink()
            .isNotMarkedAsComplete();

        Logger.log("Mark as complete");

        summaryPage
            .MarkAsComplete()
            .clickConfirmAndContinue();

        taskListPage.isTaskStatusIsCompleted("Constituency")


    });
});
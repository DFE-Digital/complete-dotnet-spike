import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import dataGenerator from "cypress/fixtures/dataGenerator";
import summaryPage from "cypress/pages/task-summary-base";
import taskListPage from "cypress/pages/taskListPage";
import articlesOfAssociationEditPage from "cypress/pages/tasks/pre-opening/edit-articles-of-association.cy";

describe("Testing articles of association Task", () => {
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
    it("Should successfully set articles of association", () => {

        cy.log("Select articles of association");
        taskListPage.isTaskStatusIsNotStarted("ArticlesOfAssociation")
            .selectArticlesOfAssociationFromTaskList();

        cy.log("Confirm empty articles of association");
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Articles of association")
            .inOrder()
            .summaryShows("Checked that the submitted articles match the model articles").IsEmpty().HasChangeLink()
            .summaryShows("Chair of trustees and senior executive lead have submitted confirmation").IsEmpty().HasChangeLink()
            .summaryShows("Governance arrangements match the details given in governance plans").IsEmpty().HasChangeLink()
            .summaryShows("Forecast date").IsEmpty().HasChangeLink()
            .summaryShows("Actual date").IsEmpty().HasChangeLink()
            .summaryShows("Comments on decision to approve (if applicable)").IsEmpty().HasChangeLink()
            .summaryShows("SharePoint link").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete();

        cy.executeAccessibilityTests();
        cy.log("Go back to task list");
        summaryPage.clickBack();

        cy.log("Confirm not started and open articles of association");
        taskListPage.isTaskStatusIsNotStarted("ArticlesOfAssociation")
            .selectArticlesOfAssociationFromTaskList();

        cy.log("Check confirm puts project in In Progress");
        summaryPage.clickConfirmAndContinue();

        taskListPage.isTaskStatusInProgress("ArticlesOfAssociation")
            .selectArticlesOfAssociationFromTaskList();

        cy.log("Check search page");

        summaryPage.clickChange();

        cy.executeAccessibilityTests();

        cy.log("All fields are optional");
        articlesOfAssociationEditPage
            .titleIs("Edit articles of association")
            .schoolNameIs(project.schoolName)
            .clickContinue()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Articles of association")
            .inOrder()
            .summaryShows("Checked that the submitted articles match the model articles").HasValue("No").HasChangeLink()
            .summaryShows("Chair of trustees and senior executive lead have submitted confirmation").HasValue("No").HasChangeLink()
            .summaryShows("Governance arrangements match the details given in governance plans").HasValue("No").HasChangeLink()
            .summaryShows("Forecast date").IsEmpty().HasChangeLink()
            .summaryShows("Actual date").IsEmpty().HasChangeLink()
            .summaryShows("Comments on decision to approve (if applicable)").IsEmpty().HasChangeLink()
            .summaryShows("SharePoint link").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete()
            .clickChange();

        cy.log("Sharepoint link validation")

        articlesOfAssociationEditPage
            .withSharepointLink(dataGenerator.generateAlphaNumeric(101))
            .clickContinue()
            .errorForSharepointLink().showsError("SharePoint link must be a valid url")
            .withSharepointLink("NotAUrl")
            .clickContinue()
            .errorForSharepointLink().showsError("SharePoint link must be a valid url")
            .withSharepointLinkExceedingMaxLength()
            .clickContinue()
            .errorForSharepointLink().showsError("SharePoint link must be 500 characters or less")
            .withSharepointLink("https://www.gov.uk/government/organisations/department-for-education")
            .clickContinue();

        summaryPage.SummaryHasValue("SharePoint link", "https://www.gov.uk/government/organisations/department-for-education")
            .clickChange();

        cy.log("Comment on decision validation")

        // *** The following lines can be uncommented to test, this takes a long time to execute and will fail in the build process ***
        // articlesOfAssociationEditPage
        //     .withComments(dataGenerator.generateAlphaNumeric(1000))
        //     .clickContinue()
        //     .errorForComments().showsError("The comments on decision to approve (if applicable) must be 999 characters or less")

        articlesOfAssociationEditPage
            .withComments("#TaTers")
            .clickContinue()
            .errorForComments().showsError("Comments on decision to approve (if applicable) must not include special characters other than , ( ) '")
            .withComments("comment that's ok")
            .clickContinue();

        summaryPage.SummaryHasValue("Comments on decision to approve (if applicable)", "comment that's ok")
            .clickChange();

        cy.log('Forecast date validation')

        articlesOfAssociationEditPage
            .withForecastDate("Z", "3", "2020")
            .clickContinue()
            .errorForForecastDate().showsError("Enter a date in the correct format")
            .withForecastDate("1", "3", "2051")
            .clickContinue()
            .errorForForecastDate().showsError("Year must be between 2000 and 2050")
            .withForecastDate("1", "3", "2050")
            .clickContinue();

        summaryPage.SummaryHasValue("Forecast date", "1 March 2050")
            .clickChange();

        cy.log('Actual date validation')

        articlesOfAssociationEditPage
            .withActualDate("Z", "3", "2020")
            .clickContinue()
            .errorForActualDate().showsError("Enter a date in the correct format")
            .withActualDate("1", "3", "2051")
            .clickContinue()
            .errorForActualDate().showsError("Year must be between 2000 and 2050")
            .withActualDate("5", "4", "2050")
            .clickContinue();

        summaryPage.SummaryHasValue("Actual date", "5 April 2050")
            .clickChange();


        cy.log('Confirm all set')

        articlesOfAssociationEditPage
            .checkArrangementsMatchGovernancePlans()
            .checkChairHaveSubmittedConfirmation()
            .checkSubmittedArticlesMatch()
            .clickContinue();

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Articles of association")
            .inOrder()
            .summaryShows("Checked that the submitted articles match the model articles").HasValue("Yes").HasChangeLink()
            .summaryShows("Chair of trustees and senior executive lead have submitted confirmation").HasValue("Yes").HasChangeLink()
            .summaryShows("Governance arrangements match the details given in governance plans").HasValue("Yes").HasChangeLink()
            .summaryShows("Forecast date").HasValue("1 March 2050").HasChangeLink()
            .summaryShows("Actual date").HasValue("5 April 2050").HasChangeLink()
            .summaryShows("Comments on decision to approve (if applicable)").HasValue("comment that's ok").HasChangeLink()
            .summaryShows("SharePoint link").HasValue("https://www.gov.uk/government/organisations/department-for-education").HasChangeLink()
            .isNotMarkedAsComplete();

        summaryPage.MarkAsComplete()
            .clickConfirmAndContinue();

        taskListPage.isTaskStatusIsCompleted("ArticlesOfAssociation");


    });

});

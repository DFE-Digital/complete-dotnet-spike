import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import dataGenerator from "cypress/fixtures/dataGenerator";
import summaryPage from "cypress/pages/task-summary-base";
import taskListPage from "cypress/pages/taskListPage";
import kickOffMeetingEditPage from "../../../pages/tasks/pre-opening/edit-kick-off-meeting.cy";

describe("Testing kick off meeting Task", () => {

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

    it("Should successfully set kick off meeting", () => {

        cy.log("Select kick off meeting");
        taskListPage.isTaskStatusIsNotStarted("KickOffMeeting")
            .selectKickOffMeetingFromTaskList();

        cy.log("Confirm empty kick off meeting");

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Kick-off meeting")
            .inOrder()
            .summaryShows("Funding arrangement details agreed between local authority and sponsor").IsEmpty().HasChangeLink()
            .summaryShows("Comments").IsEmpty().HasChangeLink()
            .summaryShows("Realistic year of opening").IsEmpty().HasChangeLink()
            .summaryShows("Provisional opening date agreed with trust").IsEmpty().HasChangeLink()
            .summaryShows("SharePoint link").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete();

        cy.executeAccessibilityTests();
        cy.log("Go back to task list");
        summaryPage.clickBack();

        cy.log("Confirm not started and open kick-off meeting");
        taskListPage.isTaskStatusIsNotStarted("KickOffMeeting")
            .selectKickOffMeetingFromTaskList();

        cy.log("Check confirm puts project in In Progress");
        summaryPage.clickConfirmAndContinue();

        taskListPage.isTaskStatusInProgress("KickOffMeeting")
            .selectKickOffMeetingFromTaskList();

        cy.log("Check search page");

        summaryPage.clickChange();

        cy.executeAccessibilityTests();

        cy.log("All fields are optional");
        kickOffMeetingEditPage
            .titleIs("Edit kick-off meeting")
            .schoolNameIs(project.schoolName)
            .clickContinue()

        cy.executeAccessibilityTests()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Kick-off meeting")
            .inOrder()
            .summaryShows("Funding arrangement details agreed between local authority and sponsor").HasValue("No").HasChangeLink()
            .summaryShows("Comments").IsEmpty().HasChangeLink()
            .summaryShows("Realistic year of opening").IsEmpty().HasChangeLink()
            .summaryShows("Provisional opening date agreed with trust").IsEmpty().HasChangeLink()
            .summaryShows("SharePoint link").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete()
            .clickChange();

        cy.log("Sharepoint link validation")

        kickOffMeetingEditPage
            .withSharepointLink(dataGenerator.generateAlphaNumeric(101))
            .clickContinue()
            .errorForSharepointLink().showsError("Sharepoint link must be a valid url")
            .withSharepointLink("NotAUrl")
            .clickContinue()
            .errorForSharepointLink().showsError("Sharepoint link must be a valid url")
            .withSharepointLinkExceedingMaxLength()
            .clickContinue()
            .errorForSharepointLink().showsError("Sharepoint link must be 500 characters or less")
            .withSharepointLink("https://www.gov.uk/government/organisations/department-for-education")
            .clickContinue();

        summaryPage.SummaryHasValue("SharePoint link", "https://www.gov.uk/government/organisations/department-for-education")
            .clickChange();

        cy.log("Comment")

        kickOffMeetingEditPage
            .withComments(dataGenerator.generateAlphaNumeric(101))
            .clickContinue()
            .errorForComments().showsError("comments must be 100 characters or less")

        kickOffMeetingEditPage
            .withComments("#TaTers")
            .clickContinue()
            .errorForComments().showsError("Comments must not include special characters other than , ( ) '")
            .withComments("comment that's ok")
            .clickContinue();

        summaryPage.SummaryHasValue("Comments", "comment that's ok")
            .clickChange();

        kickOffMeetingEditPage
            .withRealisticYearOfOpeningStartDate("1234")
            .clickContinue()
            .errorForRealisticStartDate("Start date should be in the format: 20XX")
            .withRealisticYearOfOpeningStartDate("2050")
            .withRealisticYearOfOpeningEndDate("1234")
            .clickContinue()
            .errorForRealisticStartDate("End date should be in the format: 20XX")
            .withRealisticYearOfOpeningStartDate("2049")
            .withRealisticYearOfOpeningEndDate("2050")
            .clickContinue()

        summaryPage.SummaryHasValue("Realistic year of opening", "2049/50")
            .clickChange();

        cy.log('Provisional opening date agreed with trust validation')

        kickOffMeetingEditPage
            .withProvisionalOpeningDate("Z", "3", "2020")
            .clickContinue()
            .errorForProvisionalOpeningDate().showsError("Enter a date in the correct format")
            .withProvisionalOpeningDate("1", "3", "2051")
            .clickContinue()
            .errorForProvisionalOpeningDate().showsError("Year must be between 2000 and 2050")
            .withProvisionalOpeningDate("1", "3", "2050")
            .clickContinue();

        summaryPage.SummaryHasValue("Provisional opening date agreed with trust", "1 March 2050")
            .clickChange();

        kickOffMeetingEditPage
            .withFundingArrangementsAgreed("Yes")
            .clickContinue()

        summaryPage.SummaryHasValue("Funding arrangement details agreed between local authority and sponsor", "Yes")
            .clickChange();

        cy.log('Confirm all set')

        kickOffMeetingEditPage
            .checkFundingArrangementsAgreed()
            .clickContinue()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Kick-off meeting")
            .inOrder()
            .summaryShows("Funding arrangement details agreed between local authority and sponsor").HasValue("Yes").HasChangeLink()
            .summaryShows("Comments").HasValue("comment that's ok").HasChangeLink()
            .summaryShows("Realistic year of opening").HasValue("2049/50").HasChangeLink()
            .summaryShows("Provisional opening date agreed with trust").HasValue("1 March 2050").HasChangeLink()
            .summaryShows("SharePoint link").HasValue("https://www.gov.uk/government/organisations/department-for-education").HasChangeLink()
            .isNotMarkedAsComplete()
            .MarkAsComplete()
            .clickConfirmAndContinue();

        taskListPage.isTaskStatusIsCompleted("KickOffMeeting");
    })
})

import { ProjectBuilder } from "cypress/api/projectBuilder";
import transferProjectApi from "cypress/api/transferProjectApi";
import { Logger } from "cypress/common/logger";
import projectSummarySection from "cypress/pages/projects/projectSummarySection";
import summaryPage from "cypress/pages/projects/summaryPage";
import editTransferProject from "cypress/pages/projects/transfer/editTransferProjectPage";
import { SummaryPageSection } from "cypress/pages/summaryPageSection";
import validationComponent from "cypress/pages/validationComponent";

describe("About a transfer project", () => {

    let projectId: string;

    describe("When the trust and establishment can be found", () => {

        beforeEach(() => {
            cy.login();

            transferProjectApi
                .createProject(ProjectBuilder.createTransferProjectRequest())
                .then(response => {
                    projectId = response.id;
                    cy.visit(`/transfer-projects/${projectId}/information`);
                });
        });

        it("Should be able to view and edit transfer project information", () => {
            projectSummarySection
                .hasUrn("142277")
                .hasSchoolName("Newcastle Academy");

            cy.executeAccessibilityTests();

            Logger.log("Checking the summary page sections");

            const projectDetailsSection = new SummaryPageSection("projectDetails")
            projectDetailsSection
                .inOrder()
                .titleIs("Project details")
                .summaryShows("Type").HasValue("Transfer")
                .summaryShows("Transfer date").HasValue("1 March 2026")
                .summaryShows("Local authority").HasValue("Staffordshire")
                .summaryShows("Diocese").HasValue("Not applicable")
                .summaryShows("Region").HasValue("West Midlands");

            projectDetailsSection
                .inOrder()
                .titleIs("Project details")
                .summaryShows("Type").HasValue("Transfer")
                .summaryShows("Transfer date").HasValue("1 March 2026")
                .summaryShows("Local authority").HasValue("Staffordshire")
                .summaryShows("Diocese").HasValue("Not applicable")
                .summaryShows("Region").HasValue("West Midlands");

            const reasonForTransferSection = new SummaryPageSection("reasonsFor")
            reasonForTransferSection
                .inOrder()
                .titleIs("Reasons for the transfer")
                .summaryShows("Is this transfer due to 2RI?").HasValue("Yes").HasChangeLink()
                .summaryShows("Is this transfer due to an inadequate Ofsted rating?").HasValue("Yes").HasChangeLink()
                .summaryShows("Is this transfer due to financial, safeguarding or governance issues?").HasValue("Yes").HasChangeLink();

            const advisoryBoardDetailsSection = new SummaryPageSection("advisoryBoardDetails");
            advisoryBoardDetailsSection
                .inOrder()
                .titleIs("Advisory board details")
                .summaryShows("Date of advisory board").HasValue("1 January 2022").HasChangeLink()
                .summaryShows("Conditions from advisory board").HasValue("Conditions").HasChangeLink();

            const academyDetailsSection = new SummaryPageSection("academyDetails");
            academyDetailsSection
                .inOrder()
                .titleIs("Academy details")
                .summaryShows("Name").HasValue("Newcastle Academy")
                .summaryShows("Academy URN (unique reference number)").HasValue("142277")
                .summaryShows("Type").HasValue("Academy converter")
                .summaryShows("Age range").HasValue("11 to 16")
                .summaryShows("Phase").HasValue("Secondary")
                .summaryShows("SharePoint folder").hasLink("https://educationgovuk.sharepoint.com/school").HasChangeLink();

            const incomingTrustDetailsSection = new SummaryPageSection("incomingTrustDetails");
            incomingTrustDetailsSection
                .inOrder()
                .titleIs("Incoming trust details")
                .summaryShows("Name").HasValue("WINDSOR ACADEMY TRUST")
                .summaryShows("UKPRN (UK provider reference number)").HasValue("10058502").HasChangeLink()
                .summaryShows("Group ID (identifier)").HasValue("TR02503")
                .summaryShows("Companies house number").HasValue("07523436")
                .summaryShows("Address").HasValue("Windsor Academy Trust").HasValue("Halesowen").HasValue("B63 3HY")
                .summaryShows("SharePoint folder").hasLink("https://educationgovuk.sharepoint.com/incoming").HasChangeLink();

            const outgoingTrustDetailsSection = new SummaryPageSection("outgoingTrustDetails");
            outgoingTrustDetailsSection
                .inOrder()
                .titleIs("Outgoing trust details")
                .summaryShows("Name").HasValue("UNITED ENDEAVOUR TRUST")
                .summaryShows("UKPRN (UK provider reference number)").HasValue("10061008").HasChangeLink()
                .summaryShows("Group ID (identifier)").HasValue("TR03224")
                .summaryShows("Companies house number").HasValue("09679560")
                .summaryShows("Address").HasValue("Newcastle Academy").HasValue("Ostend Place").HasValue("Newcastle Under Lyme").HasValue("ST5 2QY")
                .summaryShows("SharePoint folder").hasLink("https://educationgovuk.sharepoint.com/outgoing").HasChangeLink();

            summaryPage.clickChange();

            Logger.log("Check validation of project configuration");

            editTransferProject
                .withOutgoingTrustUkprn("")
                .withIncomingTrustUkprn("")
                .withAdvisoryBoardDate("", "", "")
                .withSchoolSharePointLink("")
                .withIncomingTrustSharePointLink("")
                .withOutgoingTrustSharePointLink("")
                .save();

            validationComponent
                .hasValidationError("Enter outgoing trust UKPRN")
                .hasValidationError("Enter incoming trust UKPRN")
                .hasValidationError("Enter a date for the advisory board, like 1 4 2023")
                .hasValidationError("Enter school SharePoint link")
                .hasValidationError("Enter outgoing trust SharePoint link")
                .hasValidationError("Enter incoming trust SharePoint link");

            cy.executeAccessibilityTests();

            editTransferProject
                .withOutgoingTrustUkprn("1")
                .withIncomingTrustUkprn("1")
                .withAdvisoryBoardDate("1", "", "")
                .withSchoolSharePointLink("my school link")
                .withIncomingTrustSharePointLink("my incoming link")
                .withOutgoingTrustSharePointLink("my outgoing link")
                .save();

            validationComponent
                .hasValidationError("The outgoing trust UKPRN must be 8 digits long and start with a 1. For example, 12345678.")
                .hasValidationError("The incoming trust UKPRN must be 8 digits long and start with a 1. For example, 12345678.")
                .hasValidationError("Enter a valid date, like 1 4 2023")
                .hasValidationError("The school SharePoint link must have the https scheme")
                .hasValidationError("The outgoing trust SharePoint link must have the https scheme")
                .hasValidationError("The incoming trust SharePoint link must have the https scheme");

            const nextYear = new Date().getFullYear() + 1;
            editTransferProject
                .withIncomingTrustSharePointLink("https://incomingtrust.com")
                .withOutgoingTrustSharePointLink("https://outgoingtrust.com")
                .withSchoolSharePointLink("https://school.com")
                .withAdvisoryBoardDate("1", "4", nextYear.toString())
                .save();

            validationComponent
                .hasValidationError("Enter school SharePoint link in the correct format. SharePoint links start with 'https://educationgovuk.sharepoint.com' or 'https://educationgovuk-my.sharepoint.com/'")
                .hasValidationError("Enter incoming trust SharePoint link in the correct format. SharePoint links start with 'https://educationgovuk.sharepoint.com' or 'https://educationgovuk-my.sharepoint.com/'")
                .hasValidationError("Enter outgoing trust SharePoint link in the correct format. SharePoint links start with 'https://educationgovuk.sharepoint.com' or 'https://educationgovuk-my.sharepoint.com/'")
                .hasValidationError("The date for the advisory board must be today or in the past");

            Logger.log("Update the project configuration");
            editTransferProject
                .withOutgoingTrustUkprn("10064307")
                .withIncomingTrustUkprn("10059329")
                .withAdvisoryBoardDate("26", "08", "2021")
                .withAdvisoryBoardConditions("The advisory board has no conditions")
                .withSchoolSharePointLink("https://educationgovuk.sharepoint.com/new-school")
                .withIncomingTrustSharePointLink("https://educationgovuk.sharepoint.com/new-incoming")
                .withOutgoingTrustSharePointLink("https://educationgovuk.sharepoint.com/new-outgoing")
                .withIsDueTo2Ir("No")
                .withIsDueToInadequateOfstedRating("No")
                .withIsDueToIssues("No")
                .save();

            Logger.log("Check the updated project configuration");

            advisoryBoardDetailsSection
                .inOrder()
                .summaryShows("Date of advisory board").HasValue("26 August 2021")
                .summaryShows("Conditions from advisory board").HasValue("The advisory board has no conditions");

            reasonForTransferSection
                .inOrder()
                .summaryShows("Is this transfer due to 2RI?").HasValue("No")
                .summaryShows("Is this transfer due to an inadequate Ofsted rating?").HasValue("No")
                .summaryShows("Is this transfer due to financial, safeguarding or governance issues?").HasValue("No");

            academyDetailsSection
                .inOrder()
                .skip(5)
                .summaryShows("SharePoint folder").hasLink("https://educationgovuk.sharepoint.com/new-school");

            incomingTrustDetailsSection
                .inOrder()
                .summaryShows("Name").HasValue("SOUTHPORT LEARNING TRUST")
                .summaryShows("UKPRN (UK provider reference number)").HasValue("10059329")
                .summaryShows("Group ID (identifier)").HasValue("TR00908")
                .summaryShows("Companies house number").HasValue("07790934")
                .summaryShows("Address").HasValue("Southport Learning Trust").HasValue("Mornington Road").HasValue("Southport").HasValue("PR9 0TT")
                .summaryShows("SharePoint folder").hasLink("https://educationgovuk.sharepoint.com/new-incoming");

            outgoingTrustDetailsSection
                .inOrder()
                .summaryShows("Name").HasValue("THE RICHMOND WEST SCHOOLS TRUST")
                .summaryShows("UKPRN (UK provider reference number)").HasValue("10064307")
                .summaryShows("Group ID (identifier)").HasValue("TR03564")
                .summaryShows("Companies house number").HasValue("10081995")
                .summaryShows("Address").HasValue("Twickenham School").HasValue("Percy Road").HasValue("Twickenham").HasValue("TW2 6JW")
                .summaryShows("SharePoint folder").hasLink("https://educationgovuk.sharepoint.com/new-outgoing").HasChangeLink();
        });
    });

    describe("When the trust and establishment information cannot be found", () => {
        beforeEach(() => {
            cy.login();

            const request = ProjectBuilder.createTransferProjectRequest();
            request.incomingTrustDetails.ukprn = "111111";
            request.outgoingTrustDetails.ukprn = "111111";
            request.urn = "1111";

            transferProjectApi
                .createProject(request)
                .then(response => {
                    projectId = response.id;
                    cy.visit(`/transfer-projects/${projectId}/information`);
                });
        });

        it("Should handle when the trust and establishment cannot be found", () => {
            projectSummarySection
                .hasUrn("1111")
                .hasSchoolName("1111");

            const projectDetailsSection = new SummaryPageSection("projectDetails")
            projectDetailsSection
                .inOrder()
                .skip(2)
                .summaryShows("Local authority").HasValue("Empty")
                .summaryShows("Diocese").HasValue("Empty");

            const academyDetailsSection = new SummaryPageSection("academyDetails");
            academyDetailsSection
                .inOrder()
                .titleIs("Academy details")
                .summaryShows("Name").HasValue("1111")
                .summaryShows("Academy URN (unique reference number)").HasValue("1111")
                .summaryShows("Type").HasValue("Empty")
                .summaryShows("Age range").HasValue("Empty")
                .summaryShows("Phase").HasValue("Empty");

            const incomingTrustDetailsSection = new SummaryPageSection("incomingTrustDetails");
            incomingTrustDetailsSection
                .inOrder()
                .summaryShows("Name").HasValue("111111")
                .summaryShows("UKPRN (UK provider reference number)").HasValue("111111")
                .summaryShows("Group ID (identifier)").HasValue("Empty")
                .summaryShows("Companies house number").HasValue("Empty")
                .summaryShows("Address").HasValue("Empty")

            const outgoingTrustDetailsSection = new SummaryPageSection("outgoingTrustDetails");
            outgoingTrustDetailsSection
                .inOrder()
                .summaryShows("Name").HasValue("111111")
                .summaryShows("UKPRN (UK provider reference number)").HasValue("111111")
                .summaryShows("Group ID (identifier)").HasValue("Empty")
                .summaryShows("Companies house number").HasValue("Empty")
                .summaryShows("Address").HasValue("Empty");
        });
    });
});
import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import { Logger } from "cypress/common/logger";
import projectOverviewPage from "cypress/pages/projectOverviewPage";
import contactsSummaryPage from "cypress/pages/contacts/contactsSummaryPage";
import dataGenerator from "cypress/fixtures/dataGenerator";
import editSchoolChairPage from "../pages/contacts/editSchoolChairPage";
import editTrustChairPage from "../pages/contacts/editTrustChairPage";

describe("Testing that we can add contacts", () => {
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

    describe("Adding Contacts", () => {
        it("Should be able to add contacts", () => {

            cy.executeAccessibilityTests();

            projectOverviewPage
                .hasSchoolChairOfGovernors("Empty")
                .hasTrustChair("Empty");
            

            Logger.log("Changing contacts")
            projectOverviewPage.changeContacts();

            cy.executeAccessibilityTests();

            Logger.log("When there are no contacts, it should display empty for all fields");
            contactsSummaryPage
                .hasTitle("Contacts")
                .hasSchoolName(project.schoolName)
                .hasTrustChairName("")
                .hasTrustChairEmail("")
                .hasSchoolChairName("")
                .hasSchoolChairEmail("");

            Logger.log("Edit School Chair");
            contactsSummaryPage.goToEditSchoolChair();

            cy.executeAccessibilityTests();

            Logger.log("Check edit school chair validation");
            editSchoolChairPage
                .hasTitle("Edit school chair of governors")
                .hasSchoolName(project.schoolName)
                .withSchoolChairName("$da")
                .clickContinue()
                .errorForSchoolChairName("School chair name must not include special characters other than , ( )")
                .withSchoolChairName("4da")
                .clickContinue()
                .errorForSchoolChairName("School chair name cannot contain numbers")
                .withSchoolChairName(dataGenerator.generateAlphaNumeric(101))
                .clickContinue()
                .errorForSchoolChairName("The school chair name must be 100 characters or less")
                .withSchoolChairEmail("da")
                .clickContinue()
                .errorForSchoolChairEmail("Enter an email address in the correct format")
                .withSchoolChairEmail(dataGenerator.generateAlphaNumeric(101))
                .clickContinue()
                .errorForSchoolChairEmail("The school chair email must be 100 characters or less")
                .withSchoolChairName("School Chair")
                .withSchoolChairEmail("school@chair.com")
                .clickContinue();
            
            cy.executeAccessibilityTests();

            Logger.log("Check user is back to contact summary page");
            contactsSummaryPage
                .hasTitle("Contacts")
                .hasSchoolName(project.schoolName)
                .hasTrustChairName("")
                .hasTrustChairEmail("")
                .hasSchoolChairName("School Chair")
                .hasSchoolChairEmail("school@chair.com");

            Logger.log("Edit trust chair");
            contactsSummaryPage.goToEditTrustChair();

            cy.executeAccessibilityTests();

            Logger.log("Check edit trust chair validation");
            editTrustChairPage
                .hasTitle("Edit trust chair")
                .hasSchoolName(project.schoolName)
                .withTrustChairName("$da")
                .clickContinue()
                .errorForTrustChairName("Trust chair name must not include special characters other than , ( )")
                .withTrustChairName("4da")
                .clickContinue()
                .errorForTrustChairName("Trust chair name cannot contain numbers")
                .withTrustChairName(dataGenerator.generateAlphaNumeric(101))
                .clickContinue()
                .errorForTrustChairName("The trust chair name must be 100 characters or less")
                .withTrustChairEmail("da")
                .clickContinue()
                .errorForTrustChairEmail("Enter an email address in the correct format")
                .withTrustChairEmail(dataGenerator.generateAlphaNumeric(101))
                .clickContinue()
                .errorForTrustChairEmail("The trust chair email must be 100 characters or less")
                .withTrustChairName("Trust Chair")
                .withTrustChairEmail("trust@chair.com")
                .clickContinue();
            
            cy.executeAccessibilityTests();

            Logger.log("Check user is back to contact summary page");
            contactsSummaryPage
                .hasTitle("Contacts")
                .hasSchoolName(project.schoolName)
                .hasTrustChairName("Trust Chair")
                .hasTrustChairEmail("trust@chair.com")
                .hasSchoolChairName("School Chair")
                .hasSchoolChairEmail("school@chair.com")
                .goToProjectsOverviewPage();
            
            cy.executeAccessibilityTests();

            Logger.log("Check user is back to projects overview page");
            projectOverviewPage
                .hasSchoolChairOfGovernors("School Chair")
                .hasTrustChair("Trust Chair");

            Logger.log("Check existing contacts can be resaved as null strings/empty on TrustChair Page");
            projectOverviewPage.changeContacts();

            cy.executeAccessibilityTests();

            contactsSummaryPage.goToEditSchoolChair();
            editSchoolChairPage
                .hasTitle("Edit school chair of governors")
                .hasSchoolName(project.schoolName)
                .withNullSchoolChairName()
                .withNullSchoolChairEmail()
                .clickContinue();
            
            cy.executeAccessibilityTests();
            
            contactsSummaryPage
                .hasTitle("Contacts")
                .hasSchoolName(project.schoolName)
                .hasTrustChairName("Trust Chair")
                .hasTrustChairEmail("trust@chair.com")
                .hasSchoolChairName("")
                .hasSchoolChairEmail("");
            
            contactsSummaryPage.goToEditTrustChair();

            cy.executeAccessibilityTests();

            editTrustChairPage
                .hasTitle("Edit trust chair")
                .hasSchoolName(project.schoolName)
                .withNullTrustChairName()
                .withNullTrustChairEmail()
                .clickContinue();
            
            cy.executeAccessibilityTests();
            
            contactsSummaryPage
                .hasTitle("Contacts")
                .hasSchoolName(project.schoolName)
                .hasTrustChairName("")
                .hasTrustChairEmail("")
                .hasSchoolChairName("")
                .hasSchoolChairEmail("");


        })
    })

})
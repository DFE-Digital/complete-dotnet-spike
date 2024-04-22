import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import summaryPage from "cypress/pages/task-summary-base";
import taskListPage from "cypress/pages/taskListPage";
import modelFundingAgreementEditPage from "../../../pages/tasks/pre-opening/edit-model-funding-agreement.cy";

describe("Testing Model funding agreement Task", () => {

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

    it("Should successfully set model funding agreement task", () => {

        cy.log("Select model funding agreement");
        taskListPage.isTaskStatusIsNotStarted("ModelFundingAgreement")
            .selectModelFundingAgreementFromTaskList();

        cy.log("Confirm empty model funding agreement");

        cy.log("Confirm empty model funding agreement");
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Model funding agreement")
            .inOrder()
            .summaryShows("Tailored a model funding agreement (FA)").IsEmpty().HasChangeLink()
            .summaryShows("Shared FA with trust").IsEmpty().HasChangeLink()
            .summaryShows("Trust agrees with model FA").IsEmpty().HasChangeLink()
            .summaryShows("Comments").IsEmpty().HasChangeLink()
            .summaryShows("Drafted FA health check").IsEmpty().HasChangeLink()
            .summaryShows("Saved FA documents in Workplaces folder").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete();


        cy.executeAccessibilityTests();
        cy.log("Go back to task list");
        summaryPage.clickBack();

        cy.log("Confirm not started and open model funding agreement");
        taskListPage.isTaskStatusIsNotStarted("ModelFundingAgreement")
            .selectModelFundingAgreementFromTaskList();

        cy.log("Check confirm puts project in In Progress");
        summaryPage.clickConfirmAndContinue();

        taskListPage.isTaskStatusInProgress("ModelFundingAgreement")
            .selectModelFundingAgreementFromTaskList();

        cy.log("Check search page");

        summaryPage.clickChange();

        cy.executeAccessibilityTests({ "aria-allowed-attr": { enabled: false } });
        
        cy.log("Date Agreed Validation")

        modelFundingAgreementEditPage
            .checkAgreesWithModelFa()
            .withAgreedDate("2","ds","2050")
            .clickContinue()
            .errorForAgreedDate().showsError("Enter a date in the correct format")
            .withAgreedDate("2","2","2090")
            .clickContinue()
            .errorForAgreedDate().showsError("Year must be between 2000 and 2050")
            .withAgreedDate("2","2","1999")
            .clickContinue()
            .errorForAgreedDate().showsError("Year must be between 2000 and 2050")

        cy.log("Date Agreed Validation")


        modelFundingAgreementEditPage
            .withComments("££hello")
            .clickContinue()
            .errorForComments().showsError("Comments must not include special characters other than , ( ) '")

        cy.log("Fill in valid model funding arrangement")

        modelFundingAgreementEditPage
            .checkAgreesWithModelFa()
            .withAgreedDate("2","2","2050")
            .withComments("comments are valid")
            .checkTailoredAModelFundingAgreement()
            .checkSharedFAWithTrust()
            .checkDraftedFAHealthcheck()
            .checkSavedFADocumentsInWorkplacesFolder()
            .clickContinue()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Model funding agreement")
            .inOrder()
            .summaryShows("Tailored a model funding agreement (FA)").HasValue("Yes").HasChangeLink()
            .summaryShows("Shared FA with trust").HasValue("Yes").HasChangeLink()
            .summaryShows("Trust agrees with model FA").HasValue("Yes").HasChangeLink()
            .summaryShows("Date Agreed").HasValue("2 February 2050").HasChangeLink()
            .summaryShows("Comments").HasValue("comments are valid").HasChangeLink()
            .summaryShows("Drafted FA health check").HasValue("Yes").HasChangeLink()
            .summaryShows("Saved FA documents in Workplaces folder").HasValue("Yes").HasChangeLink()

        cy.log("Unselect select date agreed")
       
        summaryPage.clickChange();
        modelFundingAgreementEditPage
            .uncheckAgreesWithModelFa()
            .uncheckTailoredAModelFundingAgreement()
            .uncheckSharedFAWithTrust()
            .uncheckSavedFADocumentsInWorkplacesFolder()
            .uncheckDraftedFAHealthcheck()
            .clickContinue()
            

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Model funding agreement")
            .inOrder()
            .summaryShows("Tailored a model funding agreement (FA)").HasValue("No").HasChangeLink()
            .summaryShows("Shared FA with trust").HasValue("No").HasChangeLink()
            .summaryShows("Trust agrees with model FA").HasValue("No").HasChangeLink()
            .summaryDoesNotShow("Date Agreed")
            .summaryShows("Comments").HasValue("comments are valid").HasChangeLink()
            .summaryShows("Drafted FA health check").HasValue("No").HasChangeLink()
            .summaryShows("Saved FA documents in Workplaces folder").HasValue("No").HasChangeLink()
            .isNotMarkedAsComplete()
            .MarkAsComplete()
            .clickConfirmAndContinue()

        taskListPage
            .selectModelFundingAgreementFromTaskList()
        
        summaryPage.isMarkedAsComplete()
    })
    
    
    
})
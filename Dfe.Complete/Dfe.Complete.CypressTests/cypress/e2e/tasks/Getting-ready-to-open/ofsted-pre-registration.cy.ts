import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import { Logger } from "cypress/common/logger";
import summaryPage from "cypress/pages/task-summary-base";
import taskListPage from "cypress/pages/taskListPage";
import impactAssessmentEditPage from "../../../pages/tasks/Getting-ready-to-open/edit-impact-assessment-cy";
import beforeInspectionEditPage from "../../../pages/tasks/Getting-ready-to-open/edit-ofsted-before-inspection-cy";
import afterInspectionEditPage from "../../../pages/tasks/Getting-ready-to-open/edit-ofsted-after-inspection-cy";

describe("Testing the ofsted pre registration", () => {
   
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

    it("Should be able to set impact assessment", () => {
        Logger.log("Select ofsted pre registration");
        taskListPage.isTaskStatusIsNotStarted("OfstedInspection")
            .selectOfstedPreregistrationFromTaskList();
        
        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Ofsted pre-registration")
            .inOrder()
            .summaryShows("Provided the trust with details about the process").IsEmpty().HasChangeLink()
            .summaryShows("Decided on the inspection block").IsEmpty().HasChangeLink()
            .summaryShows("Confirmed contact details for Ofsted and the trust to liaise with each other").IsEmpty().HasChangeLink()
            .summaryShows("Added the block and contact details to openers spreadsheet").IsEmpty().HasChangeLink()
            .summaryShows("Shared the outcome with the trust").IsEmpty().HasChangeLink()
            .summaryShows("Any actions to meet conditions have been taken - if applicable").IsEmpty().HasChangeLink()
            .summaryShows("Requested that the school is changed to 'proposed to open' on GIAS").IsEmpty().HasChangeLink()
            .summaryShows("Saved inspection documents and G6 agreement in Workplaces folder").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete();
        
        Logger.log("before the inspection can save null values");

        summaryPage.clickChangeById("beforepagelink-changelink")

        beforeInspectionEditPage
            .clickContinue()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Ofsted pre-registration")
            .inOrder()
            .summaryShows("Provided the trust with details about the process").IsEmpty().HasChangeLink()
            .summaryShows("Decided on the inspection block").IsEmpty().HasChangeLink()
            .summaryShows("Confirmed contact details for Ofsted and the trust to liaise with each other").IsEmpty().HasChangeLink()
            .summaryShows("Added the block and contact details to openers spreadsheet").IsEmpty().HasChangeLink()
            .summaryShows("Shared the outcome with the trust").IsEmpty().HasChangeLink()
            .summaryShows("Any actions to meet conditions have been taken - if applicable").IsEmpty().HasChangeLink()
            .summaryShows("Requested that the school is changed to 'proposed to open' on GIAS").IsEmpty().HasChangeLink()
            .summaryShows("Saved inspection documents and G6 agreement in Workplaces folder").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete()


        Logger.log("before the inspection can save null values");

        summaryPage.clickChangeById("afterpagelink-changelink")

        afterInspectionEditPage
            .clickContinue()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Ofsted pre-registration")
            .inOrder()
            .summaryShows("Provided the trust with details about the process").IsEmpty().HasChangeLink()
            .summaryShows("Decided on the inspection block").IsEmpty().HasChangeLink()
            .summaryShows("Confirmed contact details for Ofsted and the trust to liaise with each other").IsEmpty().HasChangeLink()
            .summaryShows("Added the block and contact details to openers spreadsheet").IsEmpty().HasChangeLink()
            .summaryShows("Shared the outcome with the trust").IsEmpty().HasChangeLink()
            .summaryShows("Any actions to meet conditions have been taken - if applicable").IsEmpty().HasChangeLink()
            .summaryShows("Requested that the school is changed to 'proposed to open' on GIAS").IsEmpty().HasChangeLink()
            .summaryShows("Saved inspection documents and G6 agreement in Workplaces folder").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete()

        Logger.log("before the inspection can be edited");

        summaryPage.clickChangeById("beforepagelink-changelink")
        
        beforeInspectionEditPage
            .checkProcessDetailsProvided()
            .checkBlockAndContentDetailsToOpenersSpreadsheet()
            .checkOfstedAndTrustLiaisonDetailsConfirmed()
            .checkInspectionBlockDecided()
            .clickContinue()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Ofsted pre-registration")
            .inOrder()
            .summaryShows("Provided the trust with details about the process").HasValue("Yes").HasChangeLink()
            .summaryShows("Decided on the inspection block").HasValue("Yes").HasChangeLink()
            .summaryShows("Confirmed contact details for Ofsted and the trust to liaise with each other").HasValue("Yes").HasChangeLink()
            .summaryShows("Added the block and contact details to openers spreadsheet").HasValue("Yes").HasChangeLink()
            .summaryShows("Shared the outcome with the trust").IsEmpty().HasChangeLink()
            .summaryShows("Any actions to meet conditions have been taken - if applicable").IsEmpty().HasChangeLink()
            .summaryShows("Requested that the school is changed to 'proposed to open' on GIAS").IsEmpty().HasChangeLink()
            .summaryShows("Saved inspection documents and G6 agreement in Workplaces folder").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete()

        Logger.log("after the inspection can be edited");

        summaryPage.clickChangeById("afterpagelink-changelink")
        
        afterInspectionEditPage
            .checkSharedOutcomeWithTrust()
            .checkProposedToOpenOnGias()
            .checkInspectionConditionsMet()
            .checkSavedToWorkplaces()
            .clickContinue()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Ofsted pre-registration")
            .inOrder()
            .summaryShows("Provided the trust with details about the process").HasValue("Yes").HasChangeLink()
            .summaryShows("Decided on the inspection block").HasValue("Yes").HasChangeLink()
            .summaryShows("Confirmed contact details for Ofsted and the trust to liaise with each other").HasValue("Yes").HasChangeLink()
            .summaryShows("Added the block and contact details to openers spreadsheet").HasValue("Yes").HasChangeLink()
            .summaryShows("Shared the outcome with the trust").HasValue("Yes").HasChangeLink()
            .summaryShows("Any actions to meet conditions have been taken - if applicable").HasValue("Yes").HasChangeLink()
            .summaryShows("Requested that the school is changed to 'proposed to open' on GIAS").HasValue("Yes").HasChangeLink()
            .summaryShows("Saved inspection documents and G6 agreement in Workplaces folder").HasValue("Yes").HasChangeLink()
            .isNotMarkedAsComplete()
            .clickConfirmAndContinue()

        taskListPage.isTaskStatusInProgress("OfstedInspection");
        
        Logger.log("uncheck all fields");

        taskListPage
            .selectOfstedPreregistrationFromTaskList();

        summaryPage
            .clickChangeById("beforepagelink-changelink")

        beforeInspectionEditPage
            .uncheckProcessDetailsProvided()
            .uncheckBlockAndContentDetailsToOpenersSpreadsheet()
            .uncheckOfstedAndTrustLiaisonDetailsConfirmed()
            .uncheckInspectionBlockDecided()
            .clickContinue()

        summaryPage.clickChangeById("afterpagelink-changelink")

        afterInspectionEditPage
            .uncheckSharedOutcomeWithTrust()
            .uncheckProposedToOpenOnGias()
            .uncheckInspectionConditionsMet()
            .uncheckSavedToWorkplaces()
            .clickContinue()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Ofsted pre-registration")
            .inOrder()
            .summaryShows("Provided the trust with details about the process").IsEmpty().HasChangeLink()
            .summaryShows("Decided on the inspection block").IsEmpty().HasChangeLink()
            .summaryShows("Confirmed contact details for Ofsted and the trust to liaise with each other").IsEmpty().HasChangeLink()
            .summaryShows("Added the block and contact details to openers spreadsheet").IsEmpty().HasChangeLink()
            .summaryShows("Shared the outcome with the trust").IsEmpty().HasChangeLink()
            .summaryShows("Any actions to meet conditions have been taken - if applicable").IsEmpty().HasChangeLink()
            .summaryShows("Requested that the school is changed to 'proposed to open' on GIAS").IsEmpty().HasChangeLink()
            .summaryShows("Saved inspection documents and G6 agreement in Workplaces folder").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete()
            .MarkAsComplete()
            .clickConfirmAndContinue()

        taskListPage.isTaskStatusIsCompleted("OfstedInspection");
        
        
    });
})
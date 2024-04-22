import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import { Logger } from "cypress/common/logger";
import summaryPage from "cypress/pages/task-summary-base";
import taskListPage from "cypress/pages/taskListPage";
import applicationsEvidenceEditPage from "../../../pages/tasks/Getting-ready-to-open/edit-applications-evidence-cy";
import schoolDetailsPage from "../../../pages/schoolDetailsPage";

describe("Testing the applications evidence task", () => {

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

    it("Should be able to applications evidence", () => {
        Logger.log("Select applications evidence");
        taskListPage.isTaskStatusIsNotStarted("ApplicationsEvidence")
            .selectApplicationsEvidenceFromTaskList();

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Applications evidence")
            .inOrder()
            .summaryShows("Confirmed that the trust has provided minimum viable pupil numbers").IsEmpty().HasChangeLink()
            .summaryShows("Comments").IsEmpty().HasChangeLink()
            .summaryShows("Saved the pupil place build-up form in Workplaces folder").IsEmpty().HasChangeLink()
            .summaryShows("Saved the underwriting agreement from the local authority in Workplaces folder (if applicable)").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete();

        Logger.log("Go back to task list");
        summaryPage.clickBack();

        taskListPage.selectApplicationsEvidenceFromTaskList();
        summaryPage.clickChange();

        Logger.log("Applications evidence can save null values");

        applicationsEvidenceEditPage
            .clickContinue()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Applications evidence")
            .inOrder()
            .summaryShows("Confirmed that the trust has provided minimum viable pupil numbers").IsEmpty().HasChangeLink()
            .summaryShows("Comments").IsEmpty().HasChangeLink()
            .summaryShows("Saved the pupil place build-up form in Workplaces folder").IsEmpty().HasChangeLink()
            .summaryShows("Saved the underwriting agreement from the local authority in Workplaces folder (if applicable)").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete()
            .clickChange();

        cy.executeAccessibilityTests();

        Logger.log("Applications evidence can be edited");



        applicationsEvidenceEditPage
            .withComments("!")
            .clickContinue()
            .errorForComments().showsError("Comments must not include special characters other than , ( ) '")
            .withComments("Valid text")
            .checkConfirmedPupilNumbers()
            .checkBuildUpFormSavedToWorkplaces()
            .checkUnderWritingAgreementSavedToWorkplaces()
            .clickContinue()


        Logger.log("Should update the task status");

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Applications evidence")
            .inOrder()
            .summaryShows("Confirmed that the trust has provided minimum viable pupil numbers").HasValue("Yes").HasChangeLink()
            .summaryShows("Comments").HasValue("Valid text").HasChangeLink()
            .summaryShows("Saved the pupil place build-up form in Workplaces folder").HasValue("Yes").HasChangeLink()
            .summaryShows("Saved the underwriting agreement from the local authority in Workplaces folder (if applicable)").HasValue("Yes").HasChangeLink()
            .isNotMarkedAsComplete()
            .clickConfirmAndContinue()

        taskListPage.isTaskStatusInProgress("ApplicationsEvidence");

        taskListPage.selectApplicationsEvidenceFromTaskList();
        summaryPage.clickChange();

        Logger.log("Should be able to clear all values");

        applicationsEvidenceEditPage
            .uncheckConfirmedPupilNumbers()
            .clearComments()
            .uncheckBuildUpFormSavedToWorkplaces()
            .uncheckUnderWritingAgreementSavedToWorkplaces()
            .clickContinue()

        summaryPage
            .schoolNameIs(project.schoolName)
            .titleIs("Applications evidence")
            .inOrder()
            .summaryShows("Confirmed that the trust has provided minimum viable pupil numbers").IsEmpty().HasChangeLink()
            .summaryShows("Comments").IsEmpty().HasChangeLink()
            .summaryShows("Saved the pupil place build-up form in Workplaces folder").IsEmpty().HasChangeLink()
            .summaryShows("Saved the underwriting agreement from the local authority in Workplaces folder (if applicable)").IsEmpty().HasChangeLink()
            .isNotMarkedAsComplete()
            .MarkAsComplete()
            .clickConfirmAndContinue()

        Logger.log("Should not be able to see task if school type special");

        taskListPage.isTaskStatusIsCompleted("ApplicationsEvidence")
            .selectSchoolFromTaskList()

        summaryPage.clickChange()

        schoolDetailsPage
            .withSchoolName("Test School")
            .withSchoolType("Special")
            .withSchoolPhase("Secondary")
            .withAgeRange("11", "16")
            .withFormsOfEntry("3")
            .withGender("Mixed")
            .withNursery("Yes")
            .withSixthForm("No")
            .withFaithStatus("Designation")
            .withFaithType("Jewish")
            .clickContinue();

        summaryPage.clickConfirmAndContinue()

        Logger.log("Should not be able to see applications evidence task if school type is not special")
        taskListPage.assertApplicationsEvidenceIsNotVisibleTaskList();
    });
});
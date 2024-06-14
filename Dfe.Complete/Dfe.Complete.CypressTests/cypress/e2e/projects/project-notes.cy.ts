import { ProjectBuilder } from "cypress/api/projectBuilder";
import transferProjectApi from "cypress/api/transferProjectApi";
import { Logger } from "cypress/common/logger";
import projectNotesPage from "cypress/pages/projects/projectNotesPage";
import { toDisplayDate } from "cypress/support/formatDate";

describe("Project notes", () => {

    let projectId;
    let today;

    beforeEach(() => {
        cy.login();

        today = new Date();

        transferProjectApi
            .createProject(ProjectBuilder.createTransferProjectRequest())
            .then(response => {
                projectId = response.id;
                cy.visit(`/projects/${projectId}/notes`);
            });
    });

    it("Should be able to add and edit project notes", () => {
        Logger.log("By default there are no notes for a project");
        projectNotesPage.hasNoProjectNotes();

        Logger.log("Add a project note");
        projectNotesPage
            .addProjectNote()
            .withNoteText("This is a note for the project")
            .save();

        Logger.log("Verify the note is added");
        projectNotesPage
            .getNoteAtIndex(1)
            .then(note => {
                note
                    .hasDate(toDisplayDate(today))
                    .hasOwner("Mike Stock")
                    .hasNoteText("This is a note for the project")
                    .edit()
            });

        Logger.log("Edit the note");
        projectNotesPage
            .withNoteText("This is an edited note")
            .save();

        projectNotesPage
            .getNoteAtIndex(1)
            .then(note => {
                note
                    .hasDate(toDisplayDate(today))
                    .hasOwner("Mike Stock")
                    .hasNoteText("This is an edited note")
            });

        Logger.log("Add another note");
        projectNotesPage
            .addProjectNote()
            .withNoteText("This is my second project note")
            .save();

        Logger.log("Verify both notes are displayed");
        projectNotesPage
            .getNoteAtIndex(1)
            .then(note => {
                note
                    .hasDate(toDisplayDate(today))
                    .hasOwner("Mike Stock")
                    .hasNoteText("This is my second project note")
            });

        projectNotesPage
            .getNoteAtIndex(2)
            .then(note => {
                note
                    .hasNoteText("This is an edited note");
            });
    });
});

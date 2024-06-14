class ProjectNotesPage {
    public hasNoProjectNotes() {
        cy.contains("There are not any notes for this project yet.");
    }

    public addProjectNote(): this {
        cy.contains("a", "Add note").click();

        return this;
    }

    public withNoteText(noteText: string): this {
        cy.get("textarea").clear().type(noteText);

        return this;
    }

    public save(): this {
        cy.contains("button", "Save").click();

        return this;
    }

    public getNoteAtIndex(index: number): Cypress.Chainable<NoteEntry> {
        return cy.containsById("note-entry")
            .eq(index - 1)
            .then($note => {
                return new NoteEntry($note);
            });
    }

    public hasOwner(owner: string) {
        cy.contains("Owner").next().should("have.text", owner);
    }
}

class NoteEntry {

    constructor(private element: JQuery<HTMLElement>) {

    }

    public hasDate(date: string): this {
        cy.wrap(this.element).within(() => {
            cy.contains(date);
        });

        return this;
    }

    public hasOwner(owner: string): this {

        cy.wrap(this.element).within(() => {
            cy.contains(owner);
        });

        return this;
    }

    public hasNoteText(noteText: string): this {
        cy.wrap(this.element).within(() => {
            cy.contains(noteText);
        });

        return this;
    }

    public edit(): this {
        cy.wrap(this.element).within(() => {
            cy.contains("Edit").click();
        });

        return this;
    }
}

const projectNotesPage = new ProjectNotesPage();

export default projectNotesPage;
import summaryPage from "./projects/summaryPage";

// Used if there are multiple summarys on a page that have the same title
// This class is used to target a specific summary so that we do not select the wrong elements
// Since all commands run in a within, we need to make sure that any sync operations are treated async
// We do this by using cy.wrap(null) to force cypress to schedule the command in order rather than them running immediately
export class SummaryPageSection {

    private readonly sectionId: string;

    constructor(sectionId: string) {
        this.sectionId = sectionId;
    }

    public inOrder(): this {
        cy.wrap(null).then(() => {
            summaryPage.inOrder();
        });

        return this;
    }

    public HasChangeLink(): this {
        summaryPage.HasChangeLink();

        return this;
    }

    public skip(amount: number): this {
        cy.wrap(null).then(() => {
            summaryPage.skip(amount);
        });

        return this;
    }

    public titleIs(title: string): this {
        summaryPage.titleIs(title);

        return this;
    }

    public summaryShows(key: string): this {
        cy.getById(this.sectionId).within(() => {
            summaryPage.summaryShows(key);
        })

        return this;
    }

    public HasValue(value: string): this {
        cy.getById(this.sectionId).within(() => {
            summaryPage.HasValue(value);
        })

        return this;
    }

    public hasLink(value: string): this {
        cy.getById(this.sectionId).within(() => {
            summaryPage.hasLink(value);
        })

        return this;
    }
}
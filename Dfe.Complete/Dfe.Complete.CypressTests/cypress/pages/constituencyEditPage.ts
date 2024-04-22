class ConstituencyEditPage {

    titleIs(title: string): this {
        cy.getByTestId("title").should("contains.text", title)
        return this;
    }

    schoolNameIs(school: string) {
        cy.getByTestId("school-name").should("contains.text", school);
        return this;
    }

    hasResult(result: string): this {
        cy.contains(result);
        return this;
    }

    hasNoneOption() : this {
        cy.contains("None of the above - I want to search again");
        return this;
    } 
    
    selectNoneOption() : this {
        cy.contains("None of the above - I want to search again")
            .invoke('attr', 'for')
            .then((id) => {
            cy.get('#' + id).click();
        });
        return this;
    }

    selectOption(option: string) : this {
        cy.contains(option)
            .invoke('attr', 'for')
            .then((id) => {
            cy.get('#' + id).click();
        });
        return this;
    }

    clickContinue() : this {
        cy.getByTestId("continue").click();
        return this;
    }

    clickSearchAgain() : this {
        cy.getByTestId("search-again").click();
        return this;
    }
}

const constituencyEditPage = new ConstituencyEditPage();
export default constituencyEditPage;

class DateComponent {
    public setDate(key: string, day: string, month: string, year: string) {
        cy.get('#' + `${key}-day`).typeFast(day);
        cy.get('#' + `${key}-month`).typeFast(month);
        cy.get('#' + `${key}-year`).typeFast(year);
    }

    public checkDate(key: string, day: string, month: string, year: string) {
        cy.get('#' + `${key}-day`).should("have.value", day);
        cy.get('#' + `${key}-month`).should("have.value", month);
        cy.get('#' + `${key}-year`).should("have.value", year);
    }
}

const dateComponent = new DateComponent();
export default dateComponent;

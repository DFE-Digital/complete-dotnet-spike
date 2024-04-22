import { ProjectRiskHistoryRow } from "./projectRiskHistoryRow";

class ProjectRiskHistoryTable {
    public getRowByIndex(index: number): Cypress.Chainable<ProjectRiskHistoryRow> {
        return cy.getByTestId(`risk-history-row-${index}`)
            .then((el) => {
                return new ProjectRiskHistoryRow(el);
            })
    }
}

const projectRiskHistoryTable = new ProjectRiskHistoryTable();

export default projectRiskHistoryTable;
import { EnvApi } from "cypress/constants/cypressConstants";
import { ApiBase } from "./apiBase";
import { CreateTransferProjectRequest, CreateTransferProjectResponse } from "./apiDomain";

class TransferProjectApi extends ApiBase {
    public createProject(request: CreateTransferProjectRequest): Cypress.Chainable<CreateTransferProjectResponse> {
        return cy.request<CreateTransferProjectResponse>({
            method: 'POST',
            url: Cypress.env(EnvApi) + "/api/v1/transfer-projects/",
            headers: this.getHeaders(),
            body: request
        })
            .then(response => {
                return response.body;
            });
    }
}

const transferProjectApi = new TransferProjectApi();

export default transferProjectApi;

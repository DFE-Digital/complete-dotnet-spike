import { EnvApi } from "cypress/constants/cypressConstants";
import { ApiBase } from "./apiBase";
import { CreateConversionProjectRequest, CreateConversionProjectResponse } from "./apiDomain";

class ConversionProjectApi extends ApiBase {
    public createProject(request: CreateConversionProjectRequest): Cypress.Chainable<CreateConversionProjectResponse> {
        return cy.request<CreateConversionProjectResponse>({
            method: 'POST',
            url: Cypress.env(EnvApi) + "/api/v1/conversion-projects/",
            headers: this.getHeaders(),
            body: request
        })
            .then(response => {
                return response.body;
            });
    }
}

const conversionProjectApi = new ConversionProjectApi();

export default conversionProjectApi;

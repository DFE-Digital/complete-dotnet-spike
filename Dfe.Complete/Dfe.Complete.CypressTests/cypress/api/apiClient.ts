import { EnvApi, EnvApiKey } from "cypress/constants/cypressConstants";

export class ApiClient {
    public post<TRequest extends object, TResponse extends object>(
        endpoint: string,
        request: TRequest,
    ): Cypress.Chainable<TResponse> {
        return cy
            .request<TResponse>({
                method: "POST",
                url: Cypress.env(EnvApi) + endpoint,
                headers: this.getHeaders(),
                body: request,
            })
            .then((response) => {
                return response.body;
            });
    }

    public get<TResponse extends object>(
        endpoint: string,
    ): Cypress.Chainable<TResponse> {
        return cy
            .request<TResponse>({
                method: "GET",
                url: Cypress.env(EnvApi) + endpoint,
                headers: this.getHeaders(),
            })
            .then((response) => {
                return response.body;
            });
    }

    protected getHeaders(): object {
        const result = {
            "Content-type": "application/json",
            ApiKey: Cypress.env(EnvApiKey)
        };
        return result;
    }
}

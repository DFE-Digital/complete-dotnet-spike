import { EnvApiKey, EnvUsername } from "cypress/constants/cypressConstants";

export class ApiBase {
    protected getHeaders(): object {
        const result = {
            ApiKey: Cypress.env(EnvApiKey),
            "Content-type": "application/json",
            "x-user-context-name": Cypress.env(EnvUsername)
        };
        return result;
    }
}
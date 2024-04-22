import { ApiClient } from "./apiClient";
import { CreateProjectRiskRequest, ResponseWrapper } from "./domain";

class ProjectRiskApi {
    public constructor(private apiClient: ApiClient) { }

    public post(
        projectId: string,
        request: CreateProjectRiskRequest,
    ): Cypress.Chainable {
        return this.apiClient
            .post<CreateProjectRiskRequest, ResponseWrapper<never>>(
                `/api/v1/client/projects/${projectId}/risk`,
                request,
            )
            .then((response) => {
                return response.data;
            });
    }
}

const projectRiskApi = new ProjectRiskApi(new ApiClient());

export default projectRiskApi;
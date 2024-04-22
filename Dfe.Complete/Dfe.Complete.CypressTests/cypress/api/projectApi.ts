import { ApiClient } from "./apiClient";
import {
    CreateProjectRequest,
    CreateProjectResponse,
    ResponseWrapper,
} from "./domain";

class ProjectApi {
    public constructor(private apiClient: ApiClient) {}

    public post(
        request: CreateProjectRequest,
    ): Cypress.Chainable<CreateProjectResponse> {
        return this.apiClient
            .post<CreateProjectRequest, ResponseWrapper<CreateProjectResponse>>(
                "/api/v1/client/projects/create",
                request,
            )
            .then((response) => {
                return response.data;
            });
    }
}

const projectApi = new ProjectApi(new ApiClient());

export default projectApi;

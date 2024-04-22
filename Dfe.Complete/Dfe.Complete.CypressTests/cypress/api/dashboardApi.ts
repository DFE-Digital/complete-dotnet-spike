import { ApiClient } from "./apiClient";
import {
    GetDashboardParameters,
    GetDashboardResponse,
    ResponseWrapper,
} from "./domain";

class DashboardApi {
    public constructor(private apiClient: ApiClient) {}

    public get(
        getDashboardParameters: GetDashboardParameters,
    ): Cypress.Chainable<ResponseWrapper<GetDashboardResponse>> {
        return this.apiClient
            .get<ResponseWrapper<GetDashboardResponse>>(
                `/api/v1/client/dashboard?project=${
                    getDashboardParameters.project
                }&regions=${getDashboardParameters.regions.join()}`,
            )
            .then((response) => {
                return response;
            });
    }
}

const dashboardApi = new DashboardApi(new ApiClient());

export default dashboardApi;

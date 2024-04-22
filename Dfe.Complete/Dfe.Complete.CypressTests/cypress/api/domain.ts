export type ResponseWrapper<T> = {
    data: T;
    paging: PagingResponse;
};

export type PagingResponse = {
    recordCount: number;
};

export type BulkProjectTable<TRow> = {
    headers: Array<string>;
    rows: Array<TRow>;
};

export type BulkProjectRow = {
    projectId?: string;
    projectTitle?: string;
    trustName?: string;
    region?: string;
    localAuthority?: string;
    realisticOpeningDate?: string;
    status?: string;
};

export type CreateProjectRequest = {
    projects: Array<ProjectDetailsRequest>;
};

export type ProjectDetailsRequest = {
    projectId: string;
    schoolName: string;
    applicationNumber: string;
    applicationWave: string;
    region?: string;
    localAuthority?: string;
    createdBy: string;
    TRN: string;
};

export type CreateProjectResponse = {
    projects: Array<ProjectDetailsResponse>;
};

export type ProjectDetailsResponse = {
    projectId: string;
};

export type GetDashboardParameters = {
    project: string;
    regions: Array<string>;
};

export type GetDashboardResponse = {
    projectTitle: string;
};

export type CreateProjectRiskRequest = {
    governanceAndSuitability?: ProjectRiskEntryRequest;
    education?: ProjectRiskEntryRequest;
    finance?: ProjectRiskEntryRequest;
    overall?: ProjectRiskEntryRequest;
    riskAppraisalFormSharepointLink?: string;
}

export type ProjectRiskEntryRequest = {
    riskRating?: number;
    summary?: string;
}


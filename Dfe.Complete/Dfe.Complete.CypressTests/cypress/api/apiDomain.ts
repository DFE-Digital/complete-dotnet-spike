export type CreateTransferProjectRequest = {
    urn: string;
    date: string;
    isDateProvisional: boolean;
    schoolSharePointLink: string;
    region: Region;
    isDueTo2RI: boolean;
    isDueToOfstedRating: boolean;
    isDueToIssues: boolean;
    advisoryBoardDetails: AdvisoryBoardDetails;
    incomingTrustDetails: CreateTrustDetails;
    outgoingTrustDetails: CreateTrustDetails;
};

export type CreateTrustDetails = {
    ukprn: string;
    sharepointLink: string;
};

export type AdvisoryBoardDetails = {
    date: string;
    conditions: string;
};

export type CreateTransferProjectResponse =
    {
        id: string;
    };

export type CreateConversionProjectRequest = {
    urn: string;
    date: string;
    isDateProvisional: boolean;
    schoolSharePointLink: string;
    region: Region;
    isDueTo2RI: boolean;
    hasAcademyOrderBeenIssued: boolean;
    advisoryBoardDetails: AdvisoryBoardDetails;
    incomingTrustDetails: CreateTrustDetails;
};

export type CreateConversionProjectResponse =
    {
        id: string;
    };

export enum Region {
    London = 1,
    SouthEast = 2,
    YorkshireAndTheHumber = 3,
    NorthWest = 4,
    EastOfEngland = 5,
    WestMidlands = 6,
    NorthEast = 7,
    SouthWest = 8,
    EastMidlands = 9
}
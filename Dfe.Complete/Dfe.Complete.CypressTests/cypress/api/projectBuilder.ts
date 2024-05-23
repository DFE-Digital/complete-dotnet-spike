import { CreateConversionProjectRequest, CreateTransferProjectRequest, Region } from "./apiDomain";

export class ProjectBuilder {
    public static createTransferProjectRequest(): CreateTransferProjectRequest {
        const result: CreateTransferProjectRequest = {
            urn: "142277",
            region: Region.WestMidlands,
            schoolSharePointLink: "https://educationgovuk.sharepoint.com/school",
            advisoryBoardDetails: {
                date: "2022-01-01",
                conditions: "Conditions"
            },
            date: "2026-03-01",
            isDateProvisional: true,
            isDueTo2RI: true,
            isDueToIssues: true,
            isDueToOfstedRating: true,
            incomingTrustDetails: {
                sharepointLink: "https://educationgovuk.sharepoint.com/incoming",
                ukprn: "10058502"
            },
            outgoingTrustDetails: {
                sharepointLink: "https://educationgovuk.sharepoint.com/outgoing",
                ukprn: "10061008"
            },
        };

        return result;
    }

    public static createConversionProjectRequest(): CreateConversionProjectRequest {
        const result: CreateConversionProjectRequest = {
            urn: "142277",
            region: Region.WestMidlands,
            schoolSharePointLink: "https://educationgovuk.sharepoint.com/school",
            advisoryBoardDetails: { // Replace '=' with ':'
                date: "2022-01-01",
                conditions: "Conditions"
            },
            date: "2026-03-01",
            isDateProvisional: true,
            isDueTo2RI: true,
            hasAcademyOrderBeenIssued: true,
            incomingTrustDetails: {
                sharepointLink: "https://educationgovuk.sharepoint.com/incoming",
                ukprn: "10058502"
            }
        };

        return result;
    }
}
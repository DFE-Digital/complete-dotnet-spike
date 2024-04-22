import { BulkProjectTable, BulkProjectRow } from "cypress/api/domain";
import bulkCreateProjectPage from "cypress/pages/bulkCreateProjectPage";
import { v4 } from "uuid";
import { stringify } from "csv-stringify/sync";

// Problem with importing the xlsx with the latest cypress
// if you want typings, just remove /xlsx, you will have to add it back in to work with cypress
// This is a webpack 5 issue, but the library itself is incompatible
// Tried to override the webpack config in cypress, but didn't have much luck
import { utils, write } from "xlsx/xlsx";

describe("Creating a bulk project", () => {
    beforeEach(() => {
        cy.login();
        cy.visit("/project/create/bulk");
    });

    it("Should validate an uploaded CSV file", () => {
        const completeRow: BulkProjectRow = {
            projectId: v4(),
            projectTitle: v4(),
            trustName: v4(),
            region: v4(),
            localAuthority: v4(),
            realisticOpeningDate: v4(),
            status: v4(),
        };

        const emptyRow: BulkProjectRow = {
            projectId: v4(),
        };

        const csv = createCsv([completeRow, emptyRow]);

        bulkCreateProjectPage.upload(csv, "file.csv").continue();
    });

    it("Should validate an uploaded Excel file", () => {
        const completeRow: BulkProjectRow = {
            projectId: v4(),
            projectTitle: v4(),
            trustName: v4(),
            region: v4(),
            localAuthority: v4(),
            realisticOpeningDate: v4(),
            status: v4(),
        };

        const emptyRow: BulkProjectRow = {
            projectId: v4(),
        };

        const buffer = createExcel([completeRow, emptyRow]);

        bulkCreateProjectPage.upload(buffer, "file.xlsx").continue();
    });

    function createTable(rows: Array<BulkProjectRow>) {
        const result: BulkProjectTable<BulkProjectRow> = {
            headers: [
                "projectTitle",
                "projectId",
                "trustName",
                "region",
                "localAuthority",
                "realisticOpeningDate",
                "status",
            ],
            rows: rows,
        };

        return result;
    }

    function createCsv(rows: Array<BulkProjectRow>): Buffer {
        const table = createTable(rows);

        const result = stringify(table.rows, {
            columns: table.headers,
            header: true,
        });

        return Buffer.from(result);
    }

    function createExcel(rows: Array<BulkProjectRow>): Buffer {
        const table = createTable(rows);

        const worksheet = utils.json_to_sheet(table.rows, {
            header: table.headers,
        });

        const workbook = utils.book_new();
        utils.book_append_sheet(workbook, worksheet);

        const buffer = write(workbook, {
            type: "buffer",
            bookType: "xlsx",
            compression: true,
        });

        return buffer;
    }
});

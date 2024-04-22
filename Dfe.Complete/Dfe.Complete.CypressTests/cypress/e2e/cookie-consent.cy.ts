describe("Testing cookie preferences", () => {
    beforeEach(() => {
        cy.login();
        cy.visit("/");
    });

    it.skip("Should have analytics cookies if accepted", () => {
        cy
        .getCookie("_ga").should("not.exist")
        .getCookie(".ManageFreeSchoolProjects.Consent").should("not.exist")
        .getByTestId("cookie-banner-accept").click()
        .getCookie("_ga").should("exist")
        .getCookie(".ManageFreeSchoolProjects.Consent").should("exist")
    });

    it.skip("Should remove analytics cookies if rejected", () => {
        cy.getCookie("_ga").should("not.exist")
        .getCookie(".ManageFreeSchoolProjects.Consent").should("not.exist")
        .getByTestId("cookie-banner-reject").click()
        .getCookie("_ga").should("not.exist")
        .getCookie(".ManageFreeSchoolProjects.Consent").should("exist");
    });

    it("Should remove analytics cookies if rejected if domain is different", () => {
        cy.getCookie("_ga").should("not.exist")
        .setCookie("_ga", "test", { domain: ".education.gov.uk" })
        .getCookie("_ga").should("exist")
        .getCookie(".ManageFreeSchoolProjects.Consent").should("not.exist")
        .wait(2000)
        .getByTestId("cookie-banner-reject").click()
        .wait(2000)
        .getCookie("_ga").should("not.exist")
        .getCookie(".ManageFreeSchoolProjects.Consent").should("exist");
    });
});
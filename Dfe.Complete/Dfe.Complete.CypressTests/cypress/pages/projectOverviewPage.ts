class ProjectOverviewPage {

    public selectTaskListTab(): this {
        cy.contains("Task list").click()

        return this;
    }

    public hasProjectTitleHeader(value: string): this {
        cy.getByTestId("project-title-header").should("contain.text", value);

        return this;
    }

    public hasCurrentFreeSchoolName(value: string): this {
        cy.getByTestId(`free-school-name`).should(`contain.text`, value);

        return this;
    }

    public hasProjectStatus(value: string): this {
        cy.getByTestId(`project-status`).should(`contain.text`, value);

        return this;
    }

    public hasApplicationNumber(value: string): this {
        cy.getByTestId(`application-number`).should(`contain.text`, value);

        return this;
    }

    public hasProjectId(value: string): this {
        cy.getByTestId(`project-id`).should(`contain.text`, value);

        return this;
    }

    public hasUrn(value: string): this {
        cy.getByTestId(`urn`).should(`contain.text`, value);

        return this;
    }

    public hasApplicationWave(value: string): this {
        cy.getByTestId(`application-wave`).should(`contain.text`, value);

        return this;
    }

    public hasRealisticYearOfOpening(value: string): this {
        cy.getByTestId(`realistic-year-of-opening`).should(
            `contain.text`,
            value,
        );

        return this;
    }

    public hasDateOfEntryIntoPreopening(value: string): this {
        cy.getByTestId(`date-of-entry-into-preopening`).should(
            `contain.text`,
            value,
        );

        return this;
    }

    public hasProvisionalOpeningDateAgreedWithTrust(value: string): this {
        cy.getByTestId(`provisional-opening-date-agreed-with-trust`).should(
            `contain.text`,
            value,
        );

        return this;
    }

    public hasActualOpeningDate(value: string): this {
        cy.getByTestId(`actual-opening-date`).should(`contain.text`, value);

        return this;
    }

    public hasLocalAuthority(value: string): this {
        cy.getByTestId(`local-authority`).should(`contain.text`, value);

        return this;
    }

    public hasRegion(value: string): this {
        cy.getByTestId(`region`).should(`contain.text`, value);

        return this;
    }

    public hasConstituency(value: string): this {
        cy.getByTestId(`constituency`).should(`contain.text`, value);

        return this;
    }

    public hasConstituencyMp(value: string): this {
        cy.getByTestId(`constituency-mp`).should(`contain.text`, value);

        return this;
    }

    public hasNumberOfFormsOfEntry(value: string): this {
        cy.getByTestId(`number-of-forms-of-entry`).should(
            `contain.text`,
            value,
        );

        return this;
    }

    public hasSchoolType(value: string): this {
        cy.getByTestId(`school-type`).should(`contain.text`, value);

        return this;
    }

    public hasSchoolPhase(value: string): this {
        cy.getByTestId(`school-phase`).should(`contain.text`, value);

        return this;
    }

    public hasAgeRange(value: string): this {
        cy.getByTestId(`age-range`).should(`contain.text`, value);

        return this;
    }

    public hasGender(value: string): this {
        cy.getByTestId(`gender`).should(`contain.text`, value);

        return this;
    }

    public hasNursery(value: string): this {
        cy.getByTestId(`nursery`).should(`contain.text`, value);

        return this;
    }

    public hasSixthForm(value: string): this {
        cy.getByTestId(`sixth-form`).should(`contain.text`, value);

        return this;
    }

    public hasIndependentConverter(value: string): this {
        cy.getByTestId(`independent-converter`).should(`contain.text`, value);

        return this;
    }

    public hasSpecialistResourceProvision(value: string): this {
        cy.getByTestId(`specalist-resource-provision`).should(
            `contain.text`,
            value,
        );

        return this;
    }

    public hasFaithStatus(value: string): this {
        cy.getByTestId(`faith-status`).should(`contain.text`, value);

        return this;
    }

    public hasFaithType(value: string): this {
        cy.getByTestId(`faith-type`).should(`contain.text`, value);

        return this;
    }

    public hasTrustId(value: string): this {
        cy.getByTestId(`trust-id`).should(`contain.text`, value);

        return this;
    }

    public hasTrustName(value: string): this {
        cy.getByTestId(`trust-name`).should(`contain.text`, value);

        return this;
    }

    public hasTrustType(value: string): this {
        cy.getByTestId(`trust-type`).should(`contain.text`, value);

        return this;
    }

    public changeProjectRisk(): this {
        cy.getByTestId("change-project-risk").click();

        return this;
    }

    public changeContacts(): this {
        cy.getByTestId("change-contacts").click();

        return this;
    }

    public hasProjectRiskRating(values: string[]): this {
        this.checkRagRating(`project-risk-rating`, values);

        return this;
    }

    public hasProjectRiskSummary(value: string): this {
        cy.getByTestId("project-risk-summary").should("contain.text", value);

        return this;
    }

    public hasProjectRiskDate(value: string): this {
        cy.getByTestId("project-risk-date").should("contain.text", value);

        return this;
    }

    public hasSchoolChairOfGovernors(value: string): this {
        cy.getByTestId("school-chair-of-governors").should("contain.text", value);

        return this;
    }

    public hasTrustChair(value: string): this {
        cy.getByTestId("trust-chair").should("contain.text", value);

        return this;
    }

    public hasTemporarySiteAddress(line1: string, line2: string, city: string): this {

        cy.hasAddress("temporary-site-address", line1, line2, city);

        return this;
    }

    public hasTemporarySitePostcode(postcode: string): this {
        cy.getByTestId("temporary-site-postcode").should("contain.text", postcode);

        return this;
    }

    public hasPermanentSiteAddress(line1: string, line2: string, city): this {
        cy.hasAddress("permanent-site-address", line1, line2, city);

        return this;
    }

    public hasPermanentSitePostcode(postcode: string): this {
        cy.getByTestId("permanent-site-postcode").should("contain.text", postcode);

        return this;
    }

    public changeSiteInformation(): this {
        cy.getByTestId("change-site-information").click();

        return this;

    }

    private checkRagRating(selector: string, values: string[]): void {
        cy.assertChildList(selector, values);
    }
}

const projectOverviewPage = new ProjectOverviewPage();

export default projectOverviewPage;

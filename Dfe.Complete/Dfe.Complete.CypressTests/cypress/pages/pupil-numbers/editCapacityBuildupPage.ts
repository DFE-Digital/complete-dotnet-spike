class EditCapacityBuildupPage {

    public hasSchoolName(schoolName: string): this {
        cy.getByTestId("school-name").should("contain.text", schoolName);

        return this;
    }

    public withNursery(
        currentCapacity: string,
        firstYear: string,
        secondYear: string,
        thirdYear: string,
        fourthYear: string,
        fifthYear: string,
        sixthYear: string,
        seventhYear: string): this {

        this.withRow("nursery", currentCapacity, firstYear, secondYear, thirdYear, fourthYear, fifthYear, sixthYear, seventhYear);

        return this;
    }

    public withReception(
        currentCapacity: string,
        firstYear: string,
        secondYear: string,
        thirdYear: string,
        fourthYear: string,
        fifthYear: string,
        sixthYear: string,
        seventhYear: string): this {

        this.withRowSetDirectly("reception", currentCapacity, firstYear, secondYear, thirdYear, fourthYear, fifthYear, sixthYear, seventhYear);

        return this;
    }

    public withYear1(
        currentCapacity: string,
        firstYear: string,
        secondYear: string,
        thirdYear: string,
        fourthYear: string,
        fifthYear: string,
        sixthYear: string,
        seventhYear: string): this {

        this.withRowSetDirectly("year1", currentCapacity, firstYear, secondYear, thirdYear, fourthYear, fifthYear, sixthYear, seventhYear);

        return this;
    }

    public withYear2(
        currentCapacity: string,
        firstYear: string,
        secondYear: string,
        thirdYear: string,
        fourthYear: string,
        fifthYear: string,
        sixthYear: string,
        seventhYear: string): this {

        this.withRowSetDirectly("year2", currentCapacity, firstYear, secondYear, thirdYear, fourthYear, fifthYear, sixthYear, seventhYear);

        return this;
    }

    public withYear3(
        currentCapacity: string,
        firstYear: string,
        secondYear: string,
        thirdYear: string,
        fourthYear: string,
        fifthYear: string,
        sixthYear: string,
        seventhYear: string): this {

        this.withRowSetDirectly("year3", currentCapacity, firstYear, secondYear, thirdYear, fourthYear, fifthYear, sixthYear, seventhYear);

        return this;
    }

    public withYear4(
        currentCapacity: string,
        firstYear: string,
        secondYear: string,
        thirdYear: string,
        fourthYear: string,
        fifthYear: string,
        sixthYear: string,
        seventhYear: string): this {

        this.withRowSetDirectly("year4", currentCapacity, firstYear, secondYear, thirdYear, fourthYear, fifthYear, sixthYear, seventhYear);

        return this;
    }

    public withYear5(
        currentCapacity: string,
        firstYear: string,
        secondYear: string,
        thirdYear: string,
        fourthYear: string,
        fifthYear: string,
        sixthYear: string,
        seventhYear: string): this {

        this.withRowSetDirectly("year5", currentCapacity, firstYear, secondYear, thirdYear, fourthYear, fifthYear, sixthYear, seventhYear);

        return this;
    }

    public withYear6(
        currentCapacity: string,
        firstYear: string,
        secondYear: string,
        thirdYear: string,
        fourthYear: string,
        fifthYear: string,
        sixthYear: string,
        seventhYear: string): this {

        this.withRowSetDirectly("year6", currentCapacity, firstYear, secondYear, thirdYear, fourthYear, fifthYear, sixthYear, seventhYear);

        return this;
    }

    public withYear7(
        currentCapacity: string,
        firstYear: string,
        secondYear: string,
        thirdYear: string,
        fourthYear: string,
        fifthYear: string,
        sixthYear: string,
        seventhYear: string): this {

        this.withRowSetDirectly("year7", currentCapacity, firstYear, secondYear, thirdYear, fourthYear, fifthYear, sixthYear, seventhYear);

        return this;
    }

    public withYear8(
        currentCapacity: string,
        firstYear: string,
        secondYear: string,
        thirdYear: string,
        fourthYear: string,
        fifthYear: string,
        sixthYear: string,
        seventhYear: string): this {

        this.withRowSetDirectly("year8", currentCapacity, firstYear, secondYear, thirdYear, fourthYear, fifthYear, sixthYear, seventhYear);

        return this;
    }

    public withYear9(
        currentCapacity: string,
        firstYear: string,
        secondYear: string,
        thirdYear: string,
        fourthYear: string,
        fifthYear: string,
        sixthYear: string,
        seventhYear: string): this {

        this.withRowSetDirectly("year9", currentCapacity, firstYear, secondYear, thirdYear, fourthYear, fifthYear, sixthYear, seventhYear);

        return this;
    }

    public withYear10(
        currentCapacity: string,
        firstYear: string,
        secondYear: string,
        thirdYear: string,
        fourthYear: string,
        fifthYear: string,
        sixthYear: string,
        seventhYear: string): this {

        this.withRowSetDirectly("year10", currentCapacity, firstYear, secondYear, thirdYear, fourthYear, fifthYear, sixthYear, seventhYear);

        return this;
    }

    public withYear11(
        currentCapacity: string,
        firstYear: string,
        secondYear: string,
        thirdYear: string,
        fourthYear: string,
        fifthYear: string,
        sixthYear: string,
        seventhYear: string): this {

        this.withRowSetDirectly("year11", currentCapacity, firstYear, secondYear, thirdYear, fourthYear, fifthYear, sixthYear, seventhYear);

        return this;
    }

    public withYear12(
        currentCapacity: string,
        firstYear: string,
        secondYear: string,
        thirdYear: string,
        fourthYear: string,
        fifthYear: string,
        sixthYear: string,
        seventhYear: string): this {

        this.withRow("year12", currentCapacity, firstYear, secondYear, thirdYear, fourthYear, fifthYear, sixthYear, seventhYear);

        return this;
    }

    public withYear13(
        currentCapacity: string,
        firstYear: string,
        secondYear: string,
        thirdYear: string,
        fourthYear: string,
        fifthYear: string,
        sixthYear: string,
        seventhYear: string): this {

        this.withRowSetDirectly("year13", currentCapacity, firstYear, secondYear, thirdYear, fourthYear, fifthYear, sixthYear, seventhYear);

        return this;
    }

    public withYear14(
        currentCapacity: string,
        firstYear: string,
        secondYear: string,
        thirdYear: string,
        fourthYear: string,
        fifthYear: string,
        sixthYear: string,
        seventhYear: string): this {

        this.withRowSetDirectly("year14", currentCapacity, firstYear, secondYear, thirdYear, fourthYear, fifthYear, sixthYear, seventhYear);

        return this;
    }

    private withRow(
        idPrefix: string,
        currentCapacity: string,
        firstYear: string,
        secondYear: string,
        thirdYear: string,
        fourthYear: string,
        fifthYear: string,
        sixthYear: string,
        seventhYear: string): this {

        cy.getByTestId(`${idPrefix}-current-capacity-field`).clear().type(currentCapacity);
        cy.getByTestId(`${idPrefix}-first-year-field`).clear().type(firstYear);
        cy.getByTestId(`${idPrefix}-second-year-field`).clear().type(secondYear);
        cy.getByTestId(`${idPrefix}-third-year-field`).clear().type(thirdYear);
        cy.getByTestId(`${idPrefix}-fourth-year-field`).clear().type(fourthYear);
        cy.getByTestId(`${idPrefix}-fifth-year-field`).clear().type(fifthYear);
        cy.getByTestId(`${idPrefix}-sixth-year-field`).clear().type(sixthYear);
        cy.getByTestId(`${idPrefix}-seventh-year-field`).clear().type(seventhYear);

        return this;
    }

    /**
     * Setting 130 fields is too slow, so we need to use invoke() instead of type() for the majority
     * This will make the test far more managable, only one of them will be set with type() to ensure it works
     * Have to make sure the tests are fast as well as accurate
     */
    private withRowSetDirectly(
        idPrefix: string,
        currentCapacity: string,
        firstYear: string,
        secondYear: string,
        thirdYear: string,
        fourthYear: string,
        fifthYear: string,
        sixthYear: string,
        seventhYear: string): this {

        cy.getByTestId(`${idPrefix}-current-capacity-field`).invoke('val', currentCapacity);
        cy.getByTestId(`${idPrefix}-first-year-field`).invoke('val', firstYear);
        cy.getByTestId(`${idPrefix}-second-year-field`).invoke('val', secondYear);
        cy.getByTestId(`${idPrefix}-third-year-field`).invoke('val', thirdYear);
        cy.getByTestId(`${idPrefix}-fourth-year-field`).invoke('val', fourthYear);
        cy.getByTestId(`${idPrefix}-fifth-year-field`).invoke('val', fifthYear);
        cy.getByTestId(`${idPrefix}-sixth-year-field`).invoke('val', sixthYear);
        cy.getByTestId(`${idPrefix}-seventh-year-field`).invoke('val', seventhYear);

        return this;
    }

    public saveAndContinue(): this {

        cy.getByTestId("save-and-continue").click();

        return this;
    }
}

const editCapacityBuildupPage = new EditCapacityBuildupPage();

export default editCapacityBuildupPage;
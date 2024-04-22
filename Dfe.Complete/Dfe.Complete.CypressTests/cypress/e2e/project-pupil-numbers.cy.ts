import { ProjectDetailsRequest } from "cypress/api/domain";
import projectApi from "cypress/api/projectApi";
import { RequestBuilder } from "cypress/api/requestBuilder";
import { Logger } from "cypress/common/logger";
import editCapacityWhenFullPage from "cypress/pages/pupil-numbers/editCapacityWhenFullPage";
import editPost16PublishedAdmissionNumberPage from "cypress/pages/pupil-numbers/editPost16PublishedAdmissionNumberPage";
import editCapacityBuildupPage from "cypress/pages/pupil-numbers/editCapacityBuildupPage";
import editPre16PublishedAdmissionNumberPage from "cypress/pages/pupil-numbers/editPre16PublishedAdmissionNumberPage";
import editRecruitmentAndViabilityPage from "cypress/pages/pupil-numbers/editRecruitmentAndViabilityPage";
import pupilNumbersSummaryComponent from "cypress/pages/pupil-numbers/pupilNumbersSummaryComponent";
import viewCapacityWhenFullPage from "cypress/pages/pupil-numbers/viewCapacityWhenFullPage";
import viewPost16PublishedAdmissionNumberPage from "cypress/pages/pupil-numbers/viewPost16PublishedAdmissionNumberPage";
import viewPre16CapacityBuildupPage from "cypress/pages/pupil-numbers/viewCapacityBuildupPage";
import viewPre16PublishedAdmissionNumber from "cypress/pages/pupil-numbers/viewPre16PublishedAdmissionNumberPage";
import viewPupilNumbersPage from "cypress/pages/pupil-numbers/viewPupilNumbersPage";
import viewRecruitmentAndViabilityPage from "cypress/pages/pupil-numbers/viewRecruitmentAndViabilityPage";
import validationComponent from "cypress/pages/validationComponent";

describe("Testing the setting of pupil numbers", () => {
    let project: ProjectDetailsRequest;
    const numberOutsideRangeValidationMessage = "{0} must be between 0 and 9999";
    const isNumberValidationMessage = "{0} must be a number, like 30";

    beforeEach(() => {
        cy.login();

        project = RequestBuilder.createProjectDetails();

        projectApi
            .post({
                projects: [project],
            })
            .then(() => {
                cy.visit(`/projects/${project.projectId}/overview`);
            });
    });

    it("Should be able to edit capacity when full", () => {
        pupilNumbersSummaryComponent.viewDetails();

        viewPupilNumbersPage
            .hasSchoolName(project.schoolName)
            .hasNoSaveBanner();

        Logger.log("Check all values are 0 initially");
        viewCapacityWhenFullPage
            .hasNursery("0")
            .hasReceptionToYear6("0")
            .hasYear7ToYear11("0")
            .hasYear12ToYear14("0")
            .hasSpecialEducationalNeeds("0")
            .hasAlternativeProvision("0")
            .hasTotal("0");

        cy.executeAccessibilityTests();

        Logger.log("Validate fields");
        viewPupilNumbersPage.editCapacity();

        editCapacityWhenFullPage
            .hasSchoolName(project.schoolName)
            .withNurseryCapacity("asd")
            .saveAndContinue();

        validationComponent
            .hasValidationError(isNumberValidationMessage.replace("{0}", "Nursery"));

        editCapacityWhenFullPage
            .withNurseryCapacity("10000")
            .saveAndContinue();

        validationComponent
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", "Nursery"));

        editCapacityWhenFullPage
            .withNurseryCapacity("-1")
            .withReceptionToYear6Capacity("-1")
            .withYear7ToYear11Capacity("-1")
            .withYear12ToYear14Capacity("-1")
            .withSpecialEducationalNeedsCapacity("-1")
            .withAlternativeProvisionCapacity("-1")
            .saveAndContinue();

        validationComponent
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", "Nursery"))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", "Reception to year 6"))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", "Year 7 to year 11"))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", "Year 12 to year 14"))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", "Special educational needs"))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", "Alternative provision"));

        cy.executeAccessibilityTests();

        Logger.log("Set valid values");
        editCapacityWhenFullPage
            .hasSchoolName(project.schoolName)
            .withNurseryCapacity("10")
            .withReceptionToYear6Capacity("20")
            .withYear7ToYear11Capacity("30")
            .withYear12ToYear14Capacity("40")
            .withSpecialEducationalNeedsCapacity("50")
            .withAlternativeProvisionCapacity("60")
            .saveAndContinue();

        viewPupilNumbersPage.hasSaveBanner();

        viewCapacityWhenFullPage
            .hasNursery("10")
            .hasReceptionToYear6("20")
            .hasYear7ToYear11("30")
            .hasYear12ToYear14("40")
            .hasSpecialEducationalNeeds("50")
            .hasAlternativeProvision("60")
            .hasTotal("210");
    });

    it("Should be able to edit the pre-16 published admission numbers", () => {
        pupilNumbersSummaryComponent.viewDetails();

        Logger.log("Check all values are 0 initially");
        viewPre16PublishedAdmissionNumber
            .hasReception("0")
            .hasYear7("0")
            .hasYear10("0")
            .hasOtherPre16("0")
            .hasTotal("0");

        viewPupilNumbersPage.editPre16PublishedAdmissionNumber();

        Logger.log("Validate fields");
        editPre16PublishedAdmissionNumberPage
            .withReception("asd")
            .saveAndContinue();

        validationComponent
            .hasValidationError(isNumberValidationMessage.replace("{0}", "Reception"));

        editPre16PublishedAdmissionNumberPage
            .withReception("-1")
            .withYear7("-1")
            .withYear10("-1")
            .withOtherPre16("-1")
            .saveAndContinue();

        validationComponent
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", "Reception"))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", "Year 7"))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", "Year 10"))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", "Other pre-16"))

        cy.executeAccessibilityTests();

        Logger.log("Set valid values");
        editPre16PublishedAdmissionNumberPage
            .withReception("11")
            .withYear7("22")
            .withYear10("33")
            .withOtherPre16("44")
            .saveAndContinue();

        viewPupilNumbersPage.hasSaveBanner();

        viewPre16PublishedAdmissionNumber
            .hasReception("11")
            .hasYear7("22")
            .hasYear10("33")
            .hasOtherPre16("44")
            .hasTotal("110");
    });

    it("Should be able to edit the post-16 published admission numbers", () => {
        pupilNumbersSummaryComponent.viewDetails();

        Logger.log("Check all values are 0 initially");
        viewPost16PublishedAdmissionNumberPage
            .hasYear12("0")
            .hasOtherPost16("0")
            .hasTotal("0");

        viewPupilNumbersPage.editPost16PublishedAdmissionNumber();

        Logger.log("Validate fields");
        editPost16PublishedAdmissionNumberPage
            .withYear12("asd")
            .saveAndContinue();

        validationComponent
            .hasValidationError(isNumberValidationMessage.replace("{0}", "Year 12"));

        editPost16PublishedAdmissionNumberPage
            .withYear12("-1")
            .withOtherPost16("-1")
            .saveAndContinue();

        validationComponent
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", "Year 12"))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", "Other post-16"));

        cy.executeAccessibilityTests();

        Logger.log("Set valid values");
        editPost16PublishedAdmissionNumberPage
            .withYear12("12")
            .withOtherPost16("23")
            .saveAndContinue();

        viewPupilNumbersPage.hasSaveBanner();

        viewPost16PublishedAdmissionNumberPage
            .hasYear12("12")
            .hasOtherPost16("23")
            .hasTotal("35");
    });

    it("Should be able to edit recruitment and viability", () => {
        pupilNumbersSummaryComponent.viewDetails();

        Logger.log("Check all values are 0 initially");
        viewRecruitmentAndViabilityPage
            .hasReceptionToYear6("0", "0", "0.00%", "0.00%")
            .hasYear7ToYear11("0", "0", "0.00%", "0.00%")
            .hasYear12ToYear14("0", "0", "0.00%", "0.00%")
            .hasTotal("0", "0");

        Logger.log("Validate fields");
        viewPupilNumbersPage.editRecruitmentAndViability();

        editRecruitmentAndViabilityPage
            .withReceptionToYear6("asd", "asd")
            .saveAndContinue();

        validationComponent
            .hasValidationError(isNumberValidationMessage.replace("{0}", "Reception to year 6 minimum viable number"))
            .hasValidationError(isNumberValidationMessage.replace("{0}", "Reception to year 6 applications received"));

        editRecruitmentAndViabilityPage
            .withReceptionToYear6("-1", "-1")
            .withYear7ToYear11("-1", "-1")
            .withYear12ToYear14("-1", "-1")
            .saveAndContinue();

        validationComponent
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", "Reception to year 6 minimum viable number"))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", "Reception to year 6 applications received"))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", "Year 7 to year 11 minimum viable number"))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", "Year 7 to year 11 applications received"))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", "Year 12 to year 14 minimum viable number"))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", "Year 12 to year 14 applications received"));

        cy.executeAccessibilityTests();

        Logger.log("Set valid values");
        editRecruitmentAndViabilityPage
            .withReceptionToYear6("10", "20")
            .withYear7ToYear11("62", "17")
            .withYear12ToYear14("96", "11")
            .saveAndContinue();

        viewRecruitmentAndViabilityPage
            .hasReceptionToYear6("10", "20", "200.00%", "0.00%")
            .hasYear7ToYear11("62", "17", "27.42%", "0.00%")
            .hasYear12ToYear14("96", "11", "11.46%", "0.00%")
            .hasTotal("168", "48");

        Logger.log("Add PAN values to check percentages are calculated correctly");
        viewPupilNumbersPage.editPre16PublishedAdmissionNumber();

        editPre16PublishedAdmissionNumberPage
            .withReception("60")
            .withYear7("20")
            .withYear10("30")
            .withOtherPre16("40")
            .saveAndContinue();

        viewPupilNumbersPage.editPost16PublishedAdmissionNumber();

        editPost16PublishedAdmissionNumberPage
            .withYear12("12")
            .withOtherPost16("23")
            .saveAndContinue();

        viewPupilNumbersPage.hasSaveBanner();

        viewRecruitmentAndViabilityPage
            .hasReceptionToYear6("10", "20", "200.00%", "33.33%")
            .hasYear7ToYear11("62", "17", "27.42%", "18.89%")
            .hasYear12ToYear14("96", "11", "11.46%", "31.43%")
            .hasTotal("168", "48");
    });

    it("Should be able to edit pre-16 capacity buildup", () => {
        pupilNumbersSummaryComponent.viewDetails();

        viewPre16CapacityBuildupPage
            .hasNursery("0", "0", "0", "0", "0", "0", "0", "0")
            .hasReception("0", "0", "0", "0", "0", "0", "0", "0")
            .hasYear1("0", "0", "0", "0", "0", "0", "0", "0")
            .hasYear2("0", "0", "0", "0", "0", "0", "0", "0")
            .hasYear3("0", "0", "0", "0", "0", "0", "0", "0")
            .hasYear4("0", "0", "0", "0", "0", "0", "0", "0")
            .hasYear5("0", "0", "0", "0", "0", "0", "0", "0")
            .hasYear6("0", "0", "0", "0", "0", "0", "0", "0")
            .hasYear7("0", "0", "0", "0", "0", "0", "0", "0")
            .hasYear8("0", "0", "0", "0", "0", "0", "0", "0")
            .hasYear9("0", "0", "0", "0", "0", "0", "0", "0")
            .hasYear10("0", "0", "0", "0", "0", "0", "0", "0")
            .hasYear11("0", "0", "0", "0", "0", "0", "0", "0")
            .hasPre16Total("0", "0", "0", "0", "0", "0", "0", "0");

        viewPupilNumbersPage
            .editPre16CapacityBuildup();

        Logger.log("Configuring nursery");

        editCapacityBuildupPage
            .hasSchoolName(project.schoolName)
            .withNursery("-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1")
            .saveAndContinue();

        validateCapacityBuildupRow("Nursery");

        cy.executeAccessibilityTests();

        editCapacityBuildupPage
            .hasSchoolName(project.schoolName)
            .withNursery("1", "2", "3", "4", "5", "6", "7", "8");

        Logger.log("Configuring reception");

        editCapacityBuildupPage
            .withReception("-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1")
            .saveAndContinue();

        validateCapacityBuildupRow("Reception");

        editCapacityBuildupPage
            .withReception("9", "10", "11", "12", "13", "14", "15", "16");

        Logger.log("Configuring year 1");

        editCapacityBuildupPage
            .withYear1("-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1")
            .saveAndContinue();

        validateCapacityBuildupRow("Year 1");

        editCapacityBuildupPage
            .withYear1("17", "18", "19", "20", "21", "22", "23", "24");

        Logger.log("Configuring year 2");

        editCapacityBuildupPage
            .withYear2("-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1")
            .saveAndContinue();

        validateCapacityBuildupRow("Year 2");

        editCapacityBuildupPage
            .withYear2("25", "26", "27", "28", "29", "30", "31", "32");

        Logger.log("Configuring year 3");

        editCapacityBuildupPage
            .withYear3("-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1")
            .saveAndContinue();

        validateCapacityBuildupRow("Year 3");

        editCapacityBuildupPage
            .withYear3("33", "34", "35", "36", "37", "38", "39", "40");

        Logger.log("Configuring year 4");

        editCapacityBuildupPage
            .withYear4("-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1")
            .saveAndContinue();

        validateCapacityBuildupRow("Year 4");

        editCapacityBuildupPage
            .withYear4("41", "42", "43", "44", "45", "46", "47", "48");

        Logger.log("Configuring year 5");

        editCapacityBuildupPage
            .withYear5("-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1")
            .saveAndContinue();

        validateCapacityBuildupRow("Year 5");

        editCapacityBuildupPage
            .withYear5("49", "50", "51", "52", "53", "54", "55", "56");

        Logger.log("Configuring year 6");

        editCapacityBuildupPage
            .withYear6("-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1")
            .saveAndContinue();

        validateCapacityBuildupRow("Year 6");

        editCapacityBuildupPage
            .withYear6("57", "58", "59", "60", "61", "62", "63", "64");

        Logger.log("Configuring year 7");

        editCapacityBuildupPage
            .withYear7("-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1")
            .saveAndContinue();

        validateCapacityBuildupRow("Year 7");

        editCapacityBuildupPage
            .withYear7("65", "66", "67", "68", "69", "70", "71", "72");

        Logger.log("Configuring year 8");

        editCapacityBuildupPage
            .withYear8("-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1")
            .saveAndContinue();

        validateCapacityBuildupRow("Year 8");

        editCapacityBuildupPage
            .withYear8("73", "74", "75", "76", "77", "78", "79", "80");

        Logger.log("Configuring year 9");

        editCapacityBuildupPage
            .withYear9("-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1")
            .saveAndContinue();

        validateCapacityBuildupRow("Year 9");

        editCapacityBuildupPage
            .withYear9("81", "82", "83", "84", "85", "86", "87", "88");

        Logger.log("Configuring year 10");

        editCapacityBuildupPage
            .withYear10("-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1")
            .saveAndContinue();

        validateCapacityBuildupRow("Year 10");

        editCapacityBuildupPage
            .withYear10("89", "90", "91", "92", "93", "94", "95", "96");

        Logger.log("Configuring year 11");

        editCapacityBuildupPage
            .withYear11("-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1")
            .saveAndContinue();

        validateCapacityBuildupRow("Year 11");

        editCapacityBuildupPage
            .withYear11("97", "98", "99", "100", "101", "102", "103", "104");

        Logger.log("Check the values have been set correctly");
        editCapacityBuildupPage.saveAndContinue();

        viewPupilNumbersPage.hasSaveBanner();

        viewPre16CapacityBuildupPage
            .hasNursery("1", "2", "3", "4", "5", "6", "7", "8")
            .hasReception("9", "10", "11", "12", "13", "14", "15", "16")
            .hasYear1("17", "18", "19", "20", "21", "22", "23", "24")
            .hasYear2("25", "26", "27", "28", "29", "30", "31", "32")
            .hasYear3("33", "34", "35", "36", "37", "38", "39", "40")
            .hasYear4("41", "42", "43", "44", "45", "46", "47", "48")
            .hasYear5("49", "50", "51", "52", "53", "54", "55", "56")
            .hasYear6("57", "58", "59", "60", "61", "62", "63", "64")
            .hasYear7("65", "66", "67", "68", "69", "70", "71", "72")
            .hasYear8("73", "74", "75", "76", "77", "78", "79", "80")
            .hasYear9("81", "82", "83", "84", "85", "86", "87", "88")
            .hasYear10("89", "90", "91", "92", "93", "94", "95", "96")
            .hasYear11("97", "98", "99", "100", "101", "102", "103", "104")
            .hasPre16Total("637", "650", "663", "676", "689", "702", "715", "728");
    });

    it("Should be able to edit post-16 capacity buildup", () => {
        pupilNumbersSummaryComponent.viewDetails();

        viewPre16CapacityBuildupPage
            .hasYear12("0", "0", "0", "0", "0", "0", "0", "0")
            .hasYear13("0", "0", "0", "0", "0", "0", "0", "0")
            .hasYear14("0", "0", "0", "0", "0", "0", "0", "0")
            .hasPost16Total("0", "0", "0", "0", "0", "0", "0", "0");

        viewPupilNumbersPage
            .editPost16CapacityBuildup();

        Logger.log("Configuring year 12");

        editCapacityBuildupPage
            .hasSchoolName(project.schoolName)
            .withYear12("-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1")
            .saveAndContinue();

        validateCapacityBuildupRow("Year 12");

        cy.executeAccessibilityTests();

        editCapacityBuildupPage
            .hasSchoolName(project.schoolName)
            .withYear12("2", "3", "4", "5", "6", "7", "8", "9");

        Logger.log("Configuring year 13");

        editCapacityBuildupPage
            .withYear13("-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1")
            .saveAndContinue();

        validateCapacityBuildupRow("Year 13");

        editCapacityBuildupPage
            .withYear13("10", "11", "12", "13", "14", "15", "16", "17");

        Logger.log("Configuring year 14");

        editCapacityBuildupPage
            .withYear14("-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1")
            .saveAndContinue();

        validateCapacityBuildupRow("Year 14");

        editCapacityBuildupPage
            .withYear14("18", "19", "20", "21", "22", "23", "24", "25");

        Logger.log("Check the values have been set correctly");
        editCapacityBuildupPage.saveAndContinue();

        viewPupilNumbersPage.hasSaveBanner();

        viewPre16CapacityBuildupPage
            .hasYear12("2", "3", "4", "5", "6", "7", "8", "9")
            .hasYear13("10", "11", "12", "13", "14", "15", "16", "17")
            .hasYear14("18", "19", "20", "21", "22", "23", "24", "25")
            .hasPost16Total("30", "33", "36", "39", "42", "45", "48", "51");
    });

    it("Should update the pupil numbers summary component", () => {
        pupilNumbersSummaryComponent
            .hasCapacity("0")
            .hasPre16PublishedAdmissionNumber("0")
            .hasPost16PublishedAdmissionNumber("0")
            .hasMinimumViableNumber("0")
            .hasApplicationsReceived("0");

        pupilNumbersSummaryComponent.viewDetails();

        Logger.log("configuration capacity");
        viewPupilNumbersPage.editCapacity();
        editCapacityWhenFullPage
            .withNurseryCapacity("10")
            .withReceptionToYear6Capacity("20")
            .withYear7ToYear11Capacity("30")
            .withYear12ToYear14Capacity("40")
            .withSpecialEducationalNeedsCapacity("50")
            .withAlternativeProvisionCapacity("60")
            .saveAndContinue();

        Logger.log("Configuring pre-16 published admission numbers");
        viewPupilNumbersPage.editPre16PublishedAdmissionNumber();
        editPre16PublishedAdmissionNumberPage
            .withReception("11")
            .withYear7("22")
            .withYear10("33")
            .withOtherPre16("44")
            .saveAndContinue();

        Logger.log("Configuring post-16 published admission numbers");
        viewPupilNumbersPage.editPost16PublishedAdmissionNumber();
        editPost16PublishedAdmissionNumberPage
            .withYear12("12")
            .withOtherPost16("23")
            .saveAndContinue();

        Logger.log("Configuring recruitment and viability");
        viewPupilNumbersPage.editRecruitmentAndViability();
        editRecruitmentAndViabilityPage
            .withReceptionToYear6("10", "20")
            .withYear7ToYear11("62", "17")
            .withYear12ToYear14("96", "11")
            .saveAndContinue();

        viewPupilNumbersPage.backToProjectOverview();

        pupilNumbersSummaryComponent
            .hasCapacity("210")
            .hasPre16PublishedAdmissionNumber("110")
            .hasPost16PublishedAdmissionNumber("35")
            .hasMinimumViableNumber("168")
            .hasApplicationsReceived("48");
    });

    function validateCapacityBuildupRow(schoolYear: string) {
        validationComponent
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", `${schoolYear} current capacity`))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", `${schoolYear} first year`))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", `${schoolYear} second year`))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", `${schoolYear} third year`))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", `${schoolYear} fourth year`))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", `${schoolYear} fifth year`))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", `${schoolYear} sixth year`))
            .hasValidationError(numberOutsideRangeValidationMessage.replace("{0}", `${schoolYear} seventh year`));
    }
});
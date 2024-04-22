using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.Po> Po { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Po : IAuditable
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string PupilNumbersAndCapacityAdmissionsBody { get; set; }

        public string PupilNumbersAndCapacityYrY6Capacity { get; set; }

        public string PupilNumbersAndCapacityY7Y11Capacity { get; set; }

        public string PupilNumbersAndCapacityYrY11Pre16Capacity { get; set; }

        public string PupilNumbersAndCapacityY12Y14Post16Capacity { get; set; }

        public string PupilNumbersAndCapacityTotalOfCapacityTotals { get; set; }

        public bool? PupilNumbersAndCapacityManualOverwrite { get; set; }

        public string PupilNumbersAndCapacitySpecialistResourceProvisionSpecial { get; set; }

        public string PupilNumbersAndCapacitySpecialistResourceProvisionAp { get; set; }

        public string PupilNumbersAndCapacityNurseryUnder5s { get; set; }

        public string PupilNumbersAndCapacityYrPan { get; set; }

        public string PupilNumbersAndCapacityY7Pan { get; set; }

        public string PupilNumbersAndCapacityY10Pan { get; set; }

        public string PupilNumbersAndCapacityYOtherPanPre16 { get; set; }

        public string PupilNumbersAndCapacityTotalPanPre16 { get; set; }

        public string PupilNumbersAndCapacityY12Pan { get; set; }

        public string PupilNumbersAndCapacityYOtherPanPost16 { get; set; }

        public string PupilNumbersAndCapacityTotalPanPost16 { get; set; }

        public string PupilNumbersAndCapacityMinimumFirstYearRecruitmentForViabilityYrY6 { get; set; }

        public string PupilNumbersAndCapacityNoApplicationsReceivedYrY6 { get; set; }

        public string PupilNumbersAndCapacityReceivedApplicationsVsPanYrY6 { get; set; }

        public string PupilNumbersAndCapacityReceivedApplicationsVsViabilityYrY6 { get; set; }

        public string PupilNumbersAndCapacityNoApplicationsAcceptedYrY6 { get; set; }

        public string PupilNumbersAndCapacityAcceptedApplicationsVsPanYrY6 { get; set; }

        public string PupilNumbersAndCapacityAcceptedApplicationsVsViabilityYrY6 { get; set; }

        public string PupilNumbersAndCapacityMinimumFirstYearRecruitmentForViabilityY7Y11 { get; set; }

        public string PupilNumbersAndCapacityNoApplicationsReceivedY7Y11 { get; set; }

        public string PupilNumbersAndCapacityReceivedApplicationsVsPanY7Y11 { get; set; }

        public string PupilNumbersAndCapacityReceivedApplicationsVsViabilityY7Y11 { get; set; }

        public string PupilNumbersAndCapacityNoApplicationsAcceptedY7Y11 { get; set; }

        public string PupilNumbersAndCapacityAcceptedApplicationsVsPanY7Y11 { get; set; }

        public string PupilNumbersAndCapacityAcceptedApplicationsVsViabilityY7Y11 { get; set; }

        public string PupilNumbersAndCapacityMinimumFirstYearRecruitmentForViabilityY12Y14 { get; set; }

        public string PupilNumbersAndCapacityNoApplicationsReceivedY12Y14 { get; set; }

        public string PupilNumbersAndCapacityReceivedApplicationsVsViabilityY12Y14 { get; set; }

        public string PupilNumbersAndCapacityReceivedApplicationsVsPanY12Y14 { get; set; }

        public string PupilNumbersAndCapacityNoApplicationsAcceptedY12Y14 { get; set; }

        public string PupilNumbersAndCapacityAcceptedApplicationsVsPanY12Y14 { get; set; }

        public string PupilNumbersAndCapacityAcceptedApplicationsVsViabilityY12Y14 { get; set; }

        public string PupilNumbersAndCapacityMinimumFirstYearRecruitmentForViabilityTotal { get; set; }

        public string PupilNumbersAndCapacityNoApplicationsReceivedTotal { get; set; }

        public string PupilNumbersAndCapacityNoApplicationsAcceptedTotal { get; set; }

        public string PupilNumbersAndCapacityAcademicYearFirstYear { get; set; }

        public string PupilNumbersAndCapacityAcademicYearSecondYear { get; set; }

        public string PupilNumbersAndCapacityAcademicYearThirdYear { get; set; }

        public string PupilNumbersAndCapacityAcademicYearFourthYear { get; set; }

        public string PupilNumbersAndCapacityAcademicYearFifthYear { get; set; }

        public string PupilNumbersAndCapacityAcademicYearSixthYear { get; set; }

        public string PupilNumbersAndCapacityAcademicYearSeventhYear { get; set; }

        public string PupilNumbersAndCapacityCellA1NurseryCurrentPupilNumbersIfAlreadyOpen { get; set; }

        public string PupilNumbersAndCapacityCellB1NurseryFirstYear { get; set; }

        public string PupilNumbersAndCapacityCellC1NurserySecondYear { get; set; }

        public string PupilNumbersAndCapacityCellD1NurseryThirdYear { get; set; }

        public string PupilNumbersAndCapacityCellE1NurseryFourthYear { get; set; }

        public string PupilNumbersAndCapacityCellF1NurseryFifthYear { get; set; }

        public string PupilNumbersAndCapacityCellG1NurserySixthYear { get; set; }

        public string PupilNumbersAndCapacityCellH1NurserySeventhYear { get; set; }

        public string PupilNumbersAndCapacityCellA2ReceptionCurrentPupilNumbersIfAlreadyOpen { get; set; }

        public string PupilNumbersAndCapacityCellB2ReceptionFirstYear { get; set; }

        public string PupilNumbersAndCapacityCellC2ReceptionSecondYear { get; set; }

        public string PupilNumbersAndCapacityCellD2ReceptionThirdYear { get; set; }

        public string PupilNumbersAndCapacityCellE2ReceptionFourthYear { get; set; }

        public string PupilNumbersAndCapacityCellF2ReceptionFifthYear { get; set; }

        public string PupilNumbersAndCapacityCellG2ReceptionSixthYear { get; set; }

        public string PupilNumbersAndCapacityCellH2ReceptionSeventhYear { get; set; }

        public string PupilNumbersAndCapacityCellA3Year1CurrentPupilNumbersIfAlreadyOpen { get; set; }

        public string PupilNumbersAndCapacityCellB3Year1FirstYear { get; set; }

        public string PupilNumbersAndCapacityCellC3Year1SecondYear { get; set; }

        public string PupilNumbersAndCapacityCellD3Year1ThirdYear { get; set; }

        public string PupilNumbersAndCapacityCellE3Year1FourthYear { get; set; }

        public string PupilNumbersAndCapacityCellF3Year1FifthYear { get; set; }

        public string PupilNumbersAndCapacityCellG3Year1SixthYear { get; set; }

        public string PupilNumbersAndCapacityCellH3Year1SeventhYear { get; set; }

        public string PupilNumbersAndCapacityCellA4Year2CurrentPupilNumbersIfAlreadyOpen { get; set; }

        public string PupilNumbersAndCapacityCellB4Year2FirstYear { get; set; }

        public string PupilNumbersAndCapacityCellC4Year2SecondYear { get; set; }

        public string PupilNumbersAndCapacityCellD4Year2ThirdYear { get; set; }

        public string PupilNumbersAndCapacityCellE4Year2FourthYear { get; set; }

        public string PupilNumbersAndCapacityCellF4Year2FifthYear { get; set; }

        public string PupilNumbersAndCapacityCellG4Year2SixthYear { get; set; }

        public string PupilNumbersAndCapacityCellH4Year2SeventhYear { get; set; }

        public string PupilNumbersAndCapacityCellA5Year3CurrentPupilNumbersIfAlreadyOpen { get; set; }

        public string PupilNumbersAndCapacityCellB5Year3FirstYear { get; set; }

        public string PupilNumbersAndCapacityCellC5Year3SecondYear { get; set; }

        public string PupilNumbersAndCapacityCellD5Year3ThirdYear { get; set; }

        public string PupilNumbersAndCapacityCellE5Year3FourthYear { get; set; }

        public string PupilNumbersAndCapacityCellF5Year3FifthYear { get; set; }

        public string PupilNumbersAndCapacityCellG5Year3SixthYear { get; set; }

        public string PupilNumbersAndCapacityCellH5Year3SeventhYear { get; set; }

        public string PupilNumbersAndCapacityCellA6Year4CurrentPupilNumbersIfAlreadyOpen { get; set; }

        public string PupilNumbersAndCapacityCellB6Year4FirstYear { get; set; }

        public string PupilNumbersAndCapacityCellC6Year4SecondYear { get; set; }

        public string PupilNumbersAndCapacityCellD6Year4ThirdYear { get; set; }

        public string PupilNumbersAndCapacityCellE6Year4FourthYear { get; set; }

        public string PupilNumbersAndCapacityCellF6Year4FifthYear { get; set; }

        public string PupilNumbersAndCapacityCellG6Year4SixthYear { get; set; }

        public string PupilNumbersAndCapacityCellH6Year4SeventhYear { get; set; }

        public string PupilNumbersAndCapacityCellA7Year5CurrentPupilNumbersIfAlreadyOpen { get; set; }

        public string PupilNumbersAndCapacityCellB7Year5FirstYear { get; set; }

        public string PupilNumbersAndCapacityCellC7Year5SecondYear { get; set; }

        public string PupilNumbersAndCapacityCellD7Year5ThirdYear { get; set; }

        public string PupilNumbersAndCapacityCellE7Year5FourthYear { get; set; }

        public string PupilNumbersAndCapacityCellF7Year5FifthYear { get; set; }

        public string PupilNumbersAndCapacityCellG7Year5SixthYear { get; set; }

        public string PupilNumbersAndCapacityCellH7Year5SeventhYear { get; set; }

        public string PupilNumbersAndCapacityCellA8Year6CurrentPupilNumbersIfAlreadyOpen { get; set; }

        public string PupilNumbersAndCapacityCellB8Year6FirstYear { get; set; }

        public string PupilNumbersAndCapacityCellC8Year6SecondYear { get; set; }

        public string PupilNumbersAndCapacityCellD8Year6ThirdYear { get; set; }

        public string PupilNumbersAndCapacityCellE8Year6FourthYear { get; set; }

        public string PupilNumbersAndCapacityCellF8Year6FifthYear { get; set; }

        public string PupilNumbersAndCapacityCellG8Year6SixthYear { get; set; }

        public string PupilNumbersAndCapacityCellH8Year6SeventhYear { get; set; }

        public string PupilNumbersAndCapacityCellA9Year7CurrentPupilNumbersIfAlreadyOpen { get; set; }

        public string PupilNumbersAndCapacityCellB9Year7FirstYear { get; set; }

        public string PupilNumbersAndCapacityCellC9Year7SecondYear { get; set; }

        public string PupilNumbersAndCapacityCellD9Year7ThirdYear { get; set; }

        public string PupilNumbersAndCapacityCellE9Year7FourthYear { get; set; }

        public string PupilNumbersAndCapacityCellF9Year7FifthYear { get; set; }

        public string PupilNumbersAndCapacityCellG9Year7SixthYear { get; set; }

        public string PupilNumbersAndCapacityCellH9Year7SeventhYear { get; set; }

        public string PupilNumbersAndCapacityCellA10Year8CurrentPupilNumbersIfAlreadyOpen { get; set; }

        public string PupilNumbersAndCapacityCellB10Year8FirstYear { get; set; }

        public string PupilNumbersAndCapacityCellC10Year8SecondYear { get; set; }

        public string PupilNumbersAndCapacityCellD10Year8ThirdYear { get; set; }

        public string PupilNumbersAndCapacityCellE10Year8FourthYear { get; set; }

        public string PupilNumbersAndCapacityCellF10Year8FifthYear { get; set; }

        public string PupilNumbersAndCapacityCellG10Year8SixthYear { get; set; }

        public string PupilNumbersAndCapacityCellH10Year8SeventhYear { get; set; }

        public string PupilNumbersAndCapacityCellA11Year9CurrentPupilNumbersIfAlreadyOpen { get; set; }

        public string PupilNumbersAndCapacityCellB11Year9FirstYear { get; set; }

        public string PupilNumbersAndCapacityCellC11Year9SecondYear { get; set; }

        public string PupilNumbersAndCapacityCellD11Year9ThirdYear { get; set; }

        public string PupilNumbersAndCapacityCellE11Year9FourthYear { get; set; }

        public string PupilNumbersAndCapacityCellF11Year9FifthYear { get; set; }

        public string PupilNumbersAndCapacityCellG11Year9SixthYear { get; set; }

        public string PupilNumbersAndCapacityCellH11Year9SeventhYear { get; set; }

        public string PupilNumbersAndCapacityCellA12Year10CurrentPupilNumbersIfAlreadyOpen { get; set; }

        public string PupilNumbersAndCapacityCellB12Year10FirstYear { get; set; }

        public string PupilNumbersAndCapacityCellC12Year10SecondYear { get; set; }

        public string PupilNumbersAndCapacityCellD12Year10ThirdYear { get; set; }

        public string PupilNumbersAndCapacityCellE12Year10FourthYear { get; set; }

        public string PupilNumbersAndCapacityCellF12Year10FifthYear { get; set; }

        public string PupilNumbersAndCapacityCellG12Year10SixthYear { get; set; }

        public string PupilNumbersAndCapacityCellH12Year10SeventhYear { get; set; }

        public string PupilNumbersAndCapacityCellA13Year11CurrentPupilNumbersIfAlreadyOpen { get; set; }

        public string PupilNumbersAndCapacityCellB13Year11FirstYear { get; set; }

        public string PupilNumbersAndCapacityCellC13Year11SecondYear { get; set; }

        public string PupilNumbersAndCapacityCellD13Year11ThirdYear { get; set; }

        public string PupilNumbersAndCapacityCellE13Year11FourthYear { get; set; }

        public string PupilNumbersAndCapacityCellF13Year11FifthYear { get; set; }

        public string PupilNumbersAndCapacityCellG13Year11SixthYear { get; set; }

        public string PupilNumbersAndCapacityCellH13Year11SeventhYear { get; set; }

        public string PupilNumbersAndCapacityTotalPre16A { get; set; }

        public string PupilNumbersAndCapacityTotalPre16B { get; set; }

        public string PupilNumbersAndCapacityTotalPre16C { get; set; }

        public string PupilNumbersAndCapacityTotalPre16D { get; set; }

        public string PupilNumbersAndCapacityTotalPre16E { get; set; }

        public string PupilNumbersAndCapacityTotalPre16F { get; set; }

        public string PupilNumbersAndCapacityTotalPre16G { get; set; }

        public string PupilNumbersAndCapacityTotalPre16H { get; set; }

        public string PupilNumbersAndCapacityCellA14Year12CurrentPupilNumbersIfAlreadyOpen { get; set; }

        public string PupilNumbersAndCapacityCellB14Year12FirstYear { get; set; }

        public string PupilNumbersAndCapacityCellC14Year12SecondYear { get; set; }

        public string PupilNumbersAndCapacityCellD14Year12ThirdYear { get; set; }

        public string PupilNumbersAndCapacityCellE14Year12FourthYear { get; set; }

        public string PupilNumbersAndCapacityCellF14Year12FifthYear { get; set; }

        public string PupilNumbersAndCapacityCellG14Year12SixthYear { get; set; }

        public string PupilNumbersAndCapacityCellH14Year12SeventhYear { get; set; }

        public string PupilNumbersAndCapacityCellA15Year13CurrentPupilNumbersIfAlreadyOpen { get; set; }

        public string PupilNumbersAndCapacityCellB15Year13FirstYear { get; set; }

        public string PupilNumbersAndCapacityCellC15Year13SecondYear { get; set; }

        public string PupilNumbersAndCapacityCellD15Year13ThirdYear { get; set; }

        public string PupilNumbersAndCapacityCellE15Year13FourthYear { get; set; }

        public string PupilNumbersAndCapacityCellF15Year13FifthYear { get; set; }

        public string PupilNumbersAndCapacityCellG15Year13SixthYear { get; set; }

        public string PupilNumbersAndCapacityCellH15Year13SeventhYear { get; set; }

        public string PupilNumbersAndCapacityCellA16Year14CurrentPupilNumbersIfAlreadyOpen { get; set; }

        public string PupilNumbersAndCapacityCellB16Year14FirstYear { get; set; }

        public string PupilNumbersAndCapacityCellC16Year14SecondYear { get; set; }

        public string PupilNumbersAndCapacityCellD16Year14ThirdYear { get; set; }

        public string PupilNumbersAndCapacityCellE16Year14FourthYear { get; set; }

        public string PupilNumbersAndCapacityCellF16Year14FifthYear { get; set; }

        public string PupilNumbersAndCapacityCellG16Year14SixthYear { get; set; }

        public string PupilNumbersAndCapacityCellH16Year14SeventhYear { get; set; }

        public string PupilNumbersAndCapacityTotalPost16A { get; set; }

        public string PupilNumbersAndCapacityTotalPost16B { get; set; }

        public string PupilNumbersAndCapacityTotalPost16C { get; set; }

        public string PupilNumbersAndCapacityTotalPost16D { get; set; }

        public string PupilNumbersAndCapacityTotalPost16E { get; set; }

        public string PupilNumbersAndCapacityTotalPost16F { get; set; }

        public string PupilNumbersAndCapacityTotalPost16G { get; set; }

        public string PupilNumbersAndCapacityTotalPost16H { get; set; }

        public string PupilNumbersAndCapacityCellTotalATotalCurrentPupilNumbersIfAlreadyOpen { get; set; }

        public string PupilNumbersAndCapacityCellTotalBTotalFirstYear { get; set; }

        public string PupilNumbersAndCapacityCellTotalCTotalSecondYear { get; set; }

        public string PupilNumbersAndCapacityCellTotalDTotalThirdYear { get; set; }

        public string PupilNumbersAndCapacityCellTotalETotalFourthYear { get; set; }

        public string PupilNumbersAndCapacityCellTotalFTotalFifthYear { get; set; }

        public string PupilNumbersAndCapacityCellTotalGTotalSixthYear { get; set; }

        public string PupilNumbersAndCapacityCellTotalHTotalSeventhYear { get; set; }

        public string FinancialPlanningOptInToRpa { get; set; }

        public DateTime? FinancialPlanningStartDateOfRpa { get; set; }

        public string FinancialPlanningTypeOfRpaCover { get; set; }

        public string ProjectDevelopmentGrantFundingInitialGrantAllocation { get; set; }

        public string ProjectDevelopmentGrantFundingRevisedGrantAllocation { get; set; }

        public bool? ProjectDevelopmentGrantFundingManuallyOverwrite { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateNextFinancialStatementBudgetProfileIsDueBack { get; set; }

        public string ProjectDevelopmentGrantFundingTotalPaymentsMade { get; set; }

        public bool? ProjectDevelopmentGrantFundingPo01ManuallyOverwrite { get; set; }

        public string ProjectDevelopmentGrantFundingPaymentAmountWrittenOff { get; set; }

        public string ProjectDevelopmentGrantFundingPaymentsStopped { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDatePaymentsStopped { get; set; }

        public string ProjectDevelopmentGrantFundingStoppedPaymentsAuthorisedBy { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf1stPaymentDue { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf1stPaymentDue { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf2ndPaymentDue { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf2ndPaymentDue { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf3rdPaymentDue { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf3rdPaymentDue { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf4thPaymentDue { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf4thPaymentDue { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf5thPaymentDue { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf5thPaymentDue { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf6thPaymentDue { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf6thPaymentDue { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf7thPaymentDue { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf7thPaymentDue { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf8thPaymentDue { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf8thPaymentDue { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf9thPaymentDue { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf9thPaymentDue { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf10thPaymentDue { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf10thPaymentDue { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf11thPaymentDue { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf11thPaymentDue { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf12thPaymentDue { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf12thPaymentDue { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf1stActualPayment { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf1stPayment { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf2ndActualPayment { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf2ndPayment { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf3rdActualPayment { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf3rdPayment { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf4thActualPayment { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf4thPayment { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf5thActualPayment { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf5thPayment { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf6thActualPayment { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf6thPayment { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf7thActualPayment { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf7thPayment { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf8thActualPayment { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf8thPayment { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf9thActualPayment { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf9thPayment { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf10thActualPayment { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf10thPayment { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf11thActualPayment { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf11thPayment { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf12thActualPayment { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf12thPayment { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf1stRefund { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf1stRefund { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf2ndRefund { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf2ndRefund { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf3rdRefund { get; set; }

        public string ProjectDevelopmentGrantFundingAmountOf3rdRefund { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingPdgGrantLetterDate { get; set; }

        public string ProjectDevelopmentGrantFundingPdgGrantLetterLink { get; set; }

        public DateTime? ProjectDevelopmentGrantFunding1stPdgGrantVariationDate { get; set; }

        public string ProjectDevelopmentGrantFunding1stPdgGrantVariationLink { get; set; }

        public DateTime? ProjectDevelopmentGrantFunding2ndPdgGrantVariationDate { get; set; }

        public string ProjectDevelopmentGrantFunding2ndPdgGrantVariationLink { get; set; }

        public DateTime? ProjectDevelopmentGrantFunding3rdPdgGrantVariationDate { get; set; }

        public string ProjectDevelopmentGrantFunding3rdPdgGrantVariationLink { get; set; }

        public DateTime? ProjectDevelopmentGrantFunding4thPdgGrantVariationDate { get; set; }

        public string ProjectDevelopmentGrantFunding4thPdgGrantVariationLink { get; set; }

        public string ProjectDevelopmentGrantFundingSopSupplierNumber { get; set; }

        public string ProjectDevelopmentGrantFundingSop7ActionTaken { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateSop7ActionTaken { get; set; }

        public string ProjectDevelopmentGrantFundingReasonFor1stWriteOff { get; set; }

        public string ProjectDevelopmentGrantFundingAmountApprovedFor1stWriteOff { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf1stWriteOff { get; set; }

        public string ProjectDevelopmentGrantFunding1stWriteOffApprovedInFsgBy { get; set; }

        public string ProjectDevelopmentGrantFundingFinanceBusinessPartnerApprovalReceivedFrom { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateWriteOffApprovedByFinanceBusinessPartners { get; set; }

        public string ProjectDevelopmentGrantFundingLinkWriteOffPaperworkRepository { get; set; }

        public string ProjectDevelopmentGrantFundingReasonFor2ndWriteOff { get; set; }

        public string ProjectDevelopmentGrantFundingAmountApprovedFor2ndWriteOff { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf2ndWriteOff { get; set; }

        public string ProjectDevelopmentGrantFunding2ndWriteOffApprovedInFsgBy { get; set; }

        public string ProjectDevelopmentGrantFunding2ndFinanceBusinessPartnerApprovalReceivedFrom { get; set; }

        public DateTime? ProjectDevelopmentGrantFunding2ndDateWriteOffApprovedByFinanceBusinessPartners { get; set; }

        public string ProjectDevelopmentGrantFunding2ndLinkWriteOffPaperworkRepository { get; set; }

        public string ProjectDevelopmentGrantFundingReasonFor3rdWriteOff { get; set; }

        public string ProjectDevelopmentGrantFundingAmountApprovedFor3rdWriteOff { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateOf3rdWriteOff { get; set; }

        public string ProjectDevelopmentGrantFunding3rdWriteOffApprovedInFsgBy { get; set; }

        public string ProjectDevelopmentGrantFunding3rdFinanceBusinessPartnerApprovalReceivedFrom { get; set; }

        public DateTime? ProjectDevelopmentGrantFunding3rdDateWriteOffApprovedByFinanceBusinessPartners { get; set; }

        public string ProjectDevelopmentGrantFunding3rdLinkWriteOffPaperworkRepository { get; set; }

        public string ProjectDevelopmentGrantFundingReasonForLiability { get; set; }

        public string ProjectDevelopmentGrantFundingPeriodOfUnderwrite { get; set; }

        public string ProjectDevelopmentGrantFundingAmountToBeUnderwritten { get; set; }

        public string ProjectDevelopmentGrantFundingUnderwriteApprovedBy { get; set; }

        public DateTime? ProjectDevelopmentGrantFundingDateUnderwriteApproved { get; set; }

        public string ProjectDevelopmentGrantFundingContingencyClearedRealised { get; set; }

        public string ProjectDevelopmentGrantFundingAmountRealised { get; set; }

        public string ProjectDevelopmentGrantFundingAmountCleared { get; set; }
    }
}
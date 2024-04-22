using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using System;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.UseCases.Project.Tasks.PDG
{

    public class PDGDashboardBuilderTests
    {

        [Fact]
        public void WhenNoPaymentExistReturnNull()
        {
            var po = new Po()
            {
            };

            var result = PDGDashboardBuilder.Build(po);

            result.PaymentScheduleDate.Should().BeNull();
            result.PaymentActualDate.Should().BeNull();
            result.PaymentScheduleAmount.Should().BeNull();
            result.PaymentActualAmount.Should().BeNull();

        }

        [Fact]
        public void When1stPaymentisEnteredUseFirstPayment()
        {
            var po = new Po()
            {
                ProjectDevelopmentGrantFundingAmountOf1stPayment = "100",
                ProjectDevelopmentGrantFundingAmountOf1stPaymentDue = "1",
                ProjectDevelopmentGrantFundingDateOf1stPaymentDue = new DateTime(2020, 1, 1),
                ProjectDevelopmentGrantFundingDateOf1stActualPayment = new DateTime(2020, 2, 1),
            };

            var result = PDGDashboardBuilder.Build(po);

            result.PaymentScheduleDate.Should().Be(new DateTime(2020, 1, 1));
            result.PaymentActualDate.Should().Be(new DateTime(2020, 2, 1));
            result.PaymentActualAmount.Should().Be(100);
            result.PaymentScheduleAmount.Should().Be(1);

        }

        [Fact]
        public void When2ndPaymentisEnteredUse2ndPayment()
        {
            var po = new Po()
            {
                ProjectDevelopmentGrantFundingAmountOf1stPayment = "100",
                ProjectDevelopmentGrantFundingAmountOf1stPaymentDue = "1",
                ProjectDevelopmentGrantFundingDateOf1stPaymentDue = new DateTime(2020, 1, 1),
                ProjectDevelopmentGrantFundingDateOf1stActualPayment = new DateTime(2020, 2, 1),
                ProjectDevelopmentGrantFundingAmountOf2ndPayment = "200",
                ProjectDevelopmentGrantFundingAmountOf2ndPaymentDue = "2",
                ProjectDevelopmentGrantFundingDateOf2ndPaymentDue = new DateTime(2020, 1, 2),
                ProjectDevelopmentGrantFundingDateOf2ndActualPayment = new DateTime(2020, 2, 2),
            };

            var result = PDGDashboardBuilder.Build(po);

            result.PaymentScheduleDate.Should().Be(new DateTime(2020, 1, 2));
            result.PaymentActualDate.Should().Be(new DateTime(2020, 2, 2));
            result.PaymentActualAmount.Should().Be(300);
            result.PaymentScheduleAmount.Should().Be(3);
        }


        [Fact]
        public void When3rdPaymentisEnteredUse3rdPayment()
        {
            var po = new Po()
            {
                ProjectDevelopmentGrantFundingAmountOf1stPayment = "100",
                ProjectDevelopmentGrantFundingAmountOf1stPaymentDue = "1",
                ProjectDevelopmentGrantFundingDateOf1stPaymentDue = new DateTime(2020, 1, 1),
                ProjectDevelopmentGrantFundingDateOf1stActualPayment = new DateTime(2020, 2, 1),
                ProjectDevelopmentGrantFundingAmountOf2ndPayment = "200",
                ProjectDevelopmentGrantFundingAmountOf2ndPaymentDue = "2",
                ProjectDevelopmentGrantFundingDateOf2ndPaymentDue = new DateTime(2020, 1, 2),
                ProjectDevelopmentGrantFundingDateOf2ndActualPayment = new DateTime(2020, 2, 2),
                ProjectDevelopmentGrantFundingAmountOf3rdPayment = "300",
                ProjectDevelopmentGrantFundingAmountOf3rdPaymentDue = "3",
                ProjectDevelopmentGrantFundingDateOf3rdPaymentDue = new DateTime(2020, 1, 3),
                ProjectDevelopmentGrantFundingDateOf3rdActualPayment = new DateTime(2020, 2, 3),
            };

            var result = PDGDashboardBuilder.Build(po);

            result.PaymentScheduleDate.Should().Be(new DateTime(2020, 1, 3));
            result.PaymentActualDate.Should().Be(new DateTime(2020, 2, 3));
            result.PaymentActualAmount.Should().Be(600);
            result.PaymentScheduleAmount.Should().Be(6);
        }


        [Fact]
        public void When4thPaymentisEnteredUse4thPayment()
        {
            var po = new Po()
            {
                ProjectDevelopmentGrantFundingAmountOf1stPayment = "100",
                ProjectDevelopmentGrantFundingAmountOf1stPaymentDue = "1",
                ProjectDevelopmentGrantFundingDateOf1stPaymentDue = new DateTime(2020, 1, 1),
                ProjectDevelopmentGrantFundingDateOf1stActualPayment = new DateTime(2020, 2, 1),
                ProjectDevelopmentGrantFundingAmountOf2ndPayment = "200",
                ProjectDevelopmentGrantFundingAmountOf2ndPaymentDue = "2",
                ProjectDevelopmentGrantFundingDateOf2ndPaymentDue = new DateTime(2020, 1, 2),
                ProjectDevelopmentGrantFundingDateOf2ndActualPayment = new DateTime(2020, 2, 2),
                ProjectDevelopmentGrantFundingAmountOf3rdPayment = "300",
                ProjectDevelopmentGrantFundingAmountOf3rdPaymentDue = "3",
                ProjectDevelopmentGrantFundingDateOf3rdPaymentDue = new DateTime(2020, 1, 3),
                ProjectDevelopmentGrantFundingDateOf3rdActualPayment = new DateTime(2020, 2, 3),
                ProjectDevelopmentGrantFundingAmountOf4thPayment = "400",
                ProjectDevelopmentGrantFundingAmountOf4thPaymentDue = "4",
                ProjectDevelopmentGrantFundingDateOf4thPaymentDue = new DateTime(2020, 1, 4),
                ProjectDevelopmentGrantFundingDateOf4thActualPayment = new DateTime(2020, 2, 4),
            };

            var result = PDGDashboardBuilder.Build(po);

            result.PaymentScheduleDate.Should().Be(new DateTime(2020, 1, 4));
            result.PaymentActualDate.Should().Be(new DateTime(2020, 2, 4));
            result.PaymentActualAmount.Should().Be(1000);
            result.PaymentScheduleAmount.Should().Be(10);
        }
        [Fact]
        public void When5thPaymentisEnteredUse5thPayment()
        {
            var po = new Po()
            {
                ProjectDevelopmentGrantFundingAmountOf1stPayment = "100",
                ProjectDevelopmentGrantFundingAmountOf1stPaymentDue = "1",
                ProjectDevelopmentGrantFundingDateOf1stPaymentDue = new DateTime(2020, 1, 1),
                ProjectDevelopmentGrantFundingDateOf1stActualPayment = new DateTime(2020, 2, 1),
                ProjectDevelopmentGrantFundingAmountOf2ndPayment = "200",
                ProjectDevelopmentGrantFundingAmountOf2ndPaymentDue = "2",
                ProjectDevelopmentGrantFundingDateOf2ndPaymentDue = new DateTime(2020, 1, 2),
                ProjectDevelopmentGrantFundingDateOf2ndActualPayment = new DateTime(2020, 2, 2),
                ProjectDevelopmentGrantFundingAmountOf3rdPayment = "300",
                ProjectDevelopmentGrantFundingAmountOf3rdPaymentDue = "3",
                ProjectDevelopmentGrantFundingDateOf3rdPaymentDue = new DateTime(2020, 1, 3),
                ProjectDevelopmentGrantFundingDateOf3rdActualPayment = new DateTime(2020, 2, 3),
                ProjectDevelopmentGrantFundingAmountOf4thPayment = "400",
                ProjectDevelopmentGrantFundingAmountOf4thPaymentDue = "4",
                ProjectDevelopmentGrantFundingDateOf4thPaymentDue = new DateTime(2020, 1, 4),
                ProjectDevelopmentGrantFundingDateOf4thActualPayment = new DateTime(2020, 2, 4),
                ProjectDevelopmentGrantFundingAmountOf5thPayment = "500",
                ProjectDevelopmentGrantFundingAmountOf5thPaymentDue = "5",
                ProjectDevelopmentGrantFundingDateOf5thPaymentDue = new DateTime(2020, 1, 5),
                ProjectDevelopmentGrantFundingDateOf5thActualPayment = new DateTime(2020, 2, 5),
            };

            var result = PDGDashboardBuilder.Build(po);

            result.PaymentScheduleDate.Should().Be(new DateTime(2020, 1, 5));
            result.PaymentActualDate.Should().Be(new DateTime(2020, 2, 5));
            result.PaymentActualAmount.Should().Be(1500);
            result.PaymentScheduleAmount.Should().Be(15);
        }

        [Fact]
        public void When6thPaymentisEnteredUse6thPayment()
        {
            var po = new Po()
            {
                ProjectDevelopmentGrantFundingAmountOf1stPayment = "100",
                ProjectDevelopmentGrantFundingAmountOf1stPaymentDue = "1",
                ProjectDevelopmentGrantFundingDateOf1stPaymentDue = new DateTime(2020, 1, 1),
                ProjectDevelopmentGrantFundingDateOf1stActualPayment = new DateTime(2020, 2, 1),
                ProjectDevelopmentGrantFundingAmountOf2ndPayment = "200",
                ProjectDevelopmentGrantFundingAmountOf2ndPaymentDue = "2",
                ProjectDevelopmentGrantFundingDateOf2ndPaymentDue = new DateTime(2020, 1, 2),
                ProjectDevelopmentGrantFundingDateOf2ndActualPayment = new DateTime(2020, 2, 2),
                ProjectDevelopmentGrantFundingAmountOf3rdPayment = "300",
                ProjectDevelopmentGrantFundingAmountOf3rdPaymentDue = "3",
                ProjectDevelopmentGrantFundingDateOf3rdPaymentDue = new DateTime(2020, 1, 3),
                ProjectDevelopmentGrantFundingDateOf3rdActualPayment = new DateTime(2020, 2, 3),
                ProjectDevelopmentGrantFundingAmountOf4thPayment = "400",
                ProjectDevelopmentGrantFundingAmountOf4thPaymentDue = "4",
                ProjectDevelopmentGrantFundingDateOf4thPaymentDue = new DateTime(2020, 1, 4),
                ProjectDevelopmentGrantFundingDateOf4thActualPayment = new DateTime(2020, 2, 4),
                ProjectDevelopmentGrantFundingAmountOf5thPayment = "500",
                ProjectDevelopmentGrantFundingAmountOf5thPaymentDue = "5",
                ProjectDevelopmentGrantFundingDateOf5thPaymentDue = new DateTime(2020, 1, 5),
                ProjectDevelopmentGrantFundingDateOf5thActualPayment = new DateTime(2020, 2, 5),
                ProjectDevelopmentGrantFundingAmountOf6thPayment = "600",
                ProjectDevelopmentGrantFundingAmountOf6thPaymentDue = "6",
                ProjectDevelopmentGrantFundingDateOf6thPaymentDue = new DateTime(2020, 1, 6),
                ProjectDevelopmentGrantFundingDateOf6thActualPayment = new DateTime(2020, 2, 6),
            };

            var result = PDGDashboardBuilder.Build(po);

            result.PaymentScheduleDate.Should().Be(new DateTime(2020, 1, 6));
            result.PaymentActualDate.Should().Be(new DateTime(2020, 2, 6));
            result.PaymentActualAmount.Should().Be(2100);
            result.PaymentScheduleAmount.Should().Be(21);
        }

        [Fact]
        public void When7thPaymentisEnteredUse7thPayment()
        {
            var po = new Po()
            {
                ProjectDevelopmentGrantFundingAmountOf1stPayment = "100",
                ProjectDevelopmentGrantFundingAmountOf1stPaymentDue = "1",
                ProjectDevelopmentGrantFundingDateOf1stPaymentDue = new DateTime(2020, 1, 1),
                ProjectDevelopmentGrantFundingDateOf1stActualPayment = new DateTime(2020, 2, 1),
                ProjectDevelopmentGrantFundingAmountOf2ndPayment = "200",
                ProjectDevelopmentGrantFundingAmountOf2ndPaymentDue = "2",
                ProjectDevelopmentGrantFundingDateOf2ndPaymentDue = new DateTime(2020, 1, 2),
                ProjectDevelopmentGrantFundingDateOf2ndActualPayment = new DateTime(2020, 2, 2),
                ProjectDevelopmentGrantFundingAmountOf3rdPayment = "300",
                ProjectDevelopmentGrantFundingAmountOf3rdPaymentDue = "3",
                ProjectDevelopmentGrantFundingDateOf3rdPaymentDue = new DateTime(2020, 1, 3),
                ProjectDevelopmentGrantFundingDateOf3rdActualPayment = new DateTime(2020, 2, 3),
                ProjectDevelopmentGrantFundingAmountOf4thPayment = "400",
                ProjectDevelopmentGrantFundingAmountOf4thPaymentDue = "4",
                ProjectDevelopmentGrantFundingDateOf4thPaymentDue = new DateTime(2020, 1, 4),
                ProjectDevelopmentGrantFundingDateOf4thActualPayment = new DateTime(2020, 2, 4),
                ProjectDevelopmentGrantFundingAmountOf5thPayment = "500",
                ProjectDevelopmentGrantFundingAmountOf5thPaymentDue = "5",
                ProjectDevelopmentGrantFundingDateOf5thPaymentDue = new DateTime(2020, 1, 5),
                ProjectDevelopmentGrantFundingDateOf5thActualPayment = new DateTime(2020, 2, 5),
                ProjectDevelopmentGrantFundingAmountOf6thPayment = "600",
                ProjectDevelopmentGrantFundingAmountOf6thPaymentDue = "6",
                ProjectDevelopmentGrantFundingDateOf6thPaymentDue = new DateTime(2020, 1, 6),
                ProjectDevelopmentGrantFundingDateOf6thActualPayment = new DateTime(2020, 2, 6),
                ProjectDevelopmentGrantFundingAmountOf7thPayment = "700",
                ProjectDevelopmentGrantFundingAmountOf7thPaymentDue = "7",
                ProjectDevelopmentGrantFundingDateOf7thPaymentDue = new DateTime(2020, 1, 7),
                ProjectDevelopmentGrantFundingDateOf7thActualPayment = new DateTime(2020, 2, 7),
            };

            var result = PDGDashboardBuilder.Build(po);

            result.PaymentScheduleDate.Should().Be(new DateTime(2020, 1, 7));
            result.PaymentActualDate.Should().Be(new DateTime(2020, 2, 7));
            result.PaymentActualAmount.Should().Be(2800);
            result.PaymentScheduleAmount.Should().Be(28);
        }

        [Fact]
        public void When8thPaymentisEnteredUse8thPayment()
        {
            var po = new Po()
            {
                ProjectDevelopmentGrantFundingAmountOf1stPayment = "100",
                ProjectDevelopmentGrantFundingAmountOf1stPaymentDue = "1",
                ProjectDevelopmentGrantFundingDateOf1stPaymentDue = new DateTime(2020, 1, 1),
                ProjectDevelopmentGrantFundingDateOf1stActualPayment = new DateTime(2020, 2, 1),
                ProjectDevelopmentGrantFundingAmountOf2ndPayment = "200",
                ProjectDevelopmentGrantFundingAmountOf2ndPaymentDue = "2",
                ProjectDevelopmentGrantFundingDateOf2ndPaymentDue = new DateTime(2020, 1, 2),
                ProjectDevelopmentGrantFundingDateOf2ndActualPayment = new DateTime(2020, 2, 2),
                ProjectDevelopmentGrantFundingAmountOf3rdPayment = "300",
                ProjectDevelopmentGrantFundingAmountOf3rdPaymentDue = "3",
                ProjectDevelopmentGrantFundingDateOf3rdPaymentDue = new DateTime(2020, 1, 3),
                ProjectDevelopmentGrantFundingDateOf3rdActualPayment = new DateTime(2020, 2, 3),
                ProjectDevelopmentGrantFundingAmountOf4thPayment = "400",
                ProjectDevelopmentGrantFundingAmountOf4thPaymentDue = "4",
                ProjectDevelopmentGrantFundingDateOf4thPaymentDue = new DateTime(2020, 1, 4),
                ProjectDevelopmentGrantFundingDateOf4thActualPayment = new DateTime(2020, 2, 4),
                ProjectDevelopmentGrantFundingAmountOf5thPayment = "500",
                ProjectDevelopmentGrantFundingAmountOf5thPaymentDue = "5",
                ProjectDevelopmentGrantFundingDateOf5thPaymentDue = new DateTime(2020, 1, 5),
                ProjectDevelopmentGrantFundingDateOf5thActualPayment = new DateTime(2020, 2, 5),
                ProjectDevelopmentGrantFundingAmountOf6thPayment = "600",
                ProjectDevelopmentGrantFundingAmountOf6thPaymentDue = "6",
                ProjectDevelopmentGrantFundingDateOf6thPaymentDue = new DateTime(2020, 1, 6),
                ProjectDevelopmentGrantFundingDateOf6thActualPayment = new DateTime(2020, 2, 6),
                ProjectDevelopmentGrantFundingAmountOf7thPayment = "700",
                ProjectDevelopmentGrantFundingAmountOf7thPaymentDue = "7",
                ProjectDevelopmentGrantFundingDateOf7thPaymentDue = new DateTime(2020, 1, 7),
                ProjectDevelopmentGrantFundingDateOf7thActualPayment = new DateTime(2020, 2, 7),
                ProjectDevelopmentGrantFundingAmountOf8thPayment = "800",
                ProjectDevelopmentGrantFundingAmountOf8thPaymentDue = "8",
                ProjectDevelopmentGrantFundingDateOf8thPaymentDue = new DateTime(2020, 1, 8),
                ProjectDevelopmentGrantFundingDateOf8thActualPayment = new DateTime(2020, 2, 8),
            };

            var result = PDGDashboardBuilder.Build(po);

            result.PaymentScheduleDate.Should().Be(new DateTime(2020, 1, 8));
            result.PaymentActualDate.Should().Be(new DateTime(2020, 2, 8));
            result.PaymentActualAmount.Should().Be(3600);
            result.PaymentScheduleAmount.Should().Be(36);
        }

        [Fact]
        public void When9thPaymentisEnteredUse9thPayment()
        {
            var po = new Po()
            {
                ProjectDevelopmentGrantFundingAmountOf1stPayment = "100",
                ProjectDevelopmentGrantFundingAmountOf1stPaymentDue = "1",
                ProjectDevelopmentGrantFundingDateOf1stPaymentDue = new DateTime(2020, 1, 1),
                ProjectDevelopmentGrantFundingDateOf1stActualPayment = new DateTime(2020, 2, 1),
                ProjectDevelopmentGrantFundingAmountOf2ndPayment = "200",
                ProjectDevelopmentGrantFundingAmountOf2ndPaymentDue = "2",
                ProjectDevelopmentGrantFundingDateOf2ndPaymentDue = new DateTime(2020, 1, 2),
                ProjectDevelopmentGrantFundingDateOf2ndActualPayment = new DateTime(2020, 2, 2),
                ProjectDevelopmentGrantFundingAmountOf3rdPayment = "300",
                ProjectDevelopmentGrantFundingAmountOf3rdPaymentDue = "3",
                ProjectDevelopmentGrantFundingDateOf3rdPaymentDue = new DateTime(2020, 1, 3),
                ProjectDevelopmentGrantFundingDateOf3rdActualPayment = new DateTime(2020, 2, 3),
                ProjectDevelopmentGrantFundingAmountOf4thPayment = "400",
                ProjectDevelopmentGrantFundingAmountOf4thPaymentDue = "4",
                ProjectDevelopmentGrantFundingDateOf4thPaymentDue = new DateTime(2020, 1, 4),
                ProjectDevelopmentGrantFundingDateOf4thActualPayment = new DateTime(2020, 2, 4),
                ProjectDevelopmentGrantFundingAmountOf5thPayment = "500",
                ProjectDevelopmentGrantFundingAmountOf5thPaymentDue = "5",
                ProjectDevelopmentGrantFundingDateOf5thPaymentDue = new DateTime(2020, 1, 5),
                ProjectDevelopmentGrantFundingDateOf5thActualPayment = new DateTime(2020, 2, 5),
                ProjectDevelopmentGrantFundingAmountOf6thPayment = "600",
                ProjectDevelopmentGrantFundingAmountOf6thPaymentDue = "6",
                ProjectDevelopmentGrantFundingDateOf6thPaymentDue = new DateTime(2020, 1, 6),
                ProjectDevelopmentGrantFundingDateOf6thActualPayment = new DateTime(2020, 2, 6),
                ProjectDevelopmentGrantFundingAmountOf7thPayment = "700",
                ProjectDevelopmentGrantFundingAmountOf7thPaymentDue = "7",
                ProjectDevelopmentGrantFundingDateOf7thPaymentDue = new DateTime(2020, 1, 7),
                ProjectDevelopmentGrantFundingDateOf7thActualPayment = new DateTime(2020, 2, 7),
                ProjectDevelopmentGrantFundingAmountOf8thPayment = "800",
                ProjectDevelopmentGrantFundingAmountOf8thPaymentDue = "8",
                ProjectDevelopmentGrantFundingDateOf8thPaymentDue = new DateTime(2020, 1, 8),
                ProjectDevelopmentGrantFundingDateOf8thActualPayment = new DateTime(2020, 2, 8),
                ProjectDevelopmentGrantFundingAmountOf9thPayment = "900",
                ProjectDevelopmentGrantFundingAmountOf9thPaymentDue = "9",
                ProjectDevelopmentGrantFundingDateOf9thPaymentDue = new DateTime(2020, 1, 9),
                ProjectDevelopmentGrantFundingDateOf9thActualPayment = new DateTime(2020, 2, 9),
            };

            var result = PDGDashboardBuilder.Build(po);

            result.PaymentScheduleDate.Should().Be(new DateTime(2020, 1, 9));
            result.PaymentActualDate.Should().Be(new DateTime(2020, 2, 9));
            result.PaymentActualAmount.Should().Be(4500);
            result.PaymentScheduleAmount.Should().Be(45);

        }

        [Fact]
        public void When10thPaymentisEnteredUse10thPayment()
        {
            var po = new Po()
            {
                ProjectDevelopmentGrantFundingAmountOf1stPayment = "100",
                ProjectDevelopmentGrantFundingAmountOf1stPaymentDue = "1",
                ProjectDevelopmentGrantFundingDateOf1stPaymentDue = new DateTime(2020, 1, 1),
                ProjectDevelopmentGrantFundingDateOf1stActualPayment = new DateTime(2020, 2, 1),
                ProjectDevelopmentGrantFundingAmountOf2ndPayment = "200",
                ProjectDevelopmentGrantFundingAmountOf2ndPaymentDue = "2",
                ProjectDevelopmentGrantFundingDateOf2ndPaymentDue = new DateTime(2020, 1, 2),
                ProjectDevelopmentGrantFundingDateOf2ndActualPayment = new DateTime(2020, 2, 2),
                ProjectDevelopmentGrantFundingAmountOf3rdPayment = "300",
                ProjectDevelopmentGrantFundingAmountOf3rdPaymentDue = "3",
                ProjectDevelopmentGrantFundingDateOf3rdPaymentDue = new DateTime(2020, 1, 3),
                ProjectDevelopmentGrantFundingDateOf3rdActualPayment = new DateTime(2020, 2, 3),
                ProjectDevelopmentGrantFundingAmountOf4thPayment = "400",
                ProjectDevelopmentGrantFundingAmountOf4thPaymentDue = "4",
                ProjectDevelopmentGrantFundingDateOf4thPaymentDue = new DateTime(2020, 1, 4),
                ProjectDevelopmentGrantFundingDateOf4thActualPayment = new DateTime(2020, 2, 4),
                ProjectDevelopmentGrantFundingAmountOf5thPayment = "500",
                ProjectDevelopmentGrantFundingAmountOf5thPaymentDue = "5",
                ProjectDevelopmentGrantFundingDateOf5thPaymentDue = new DateTime(2020, 1, 5),
                ProjectDevelopmentGrantFundingDateOf5thActualPayment = new DateTime(2020, 2, 5),
                ProjectDevelopmentGrantFundingAmountOf6thPayment = "600",
                ProjectDevelopmentGrantFundingAmountOf6thPaymentDue = "6",
                ProjectDevelopmentGrantFundingDateOf6thPaymentDue = new DateTime(2020, 1, 6),
                ProjectDevelopmentGrantFundingDateOf6thActualPayment = new DateTime(2020, 2, 6),
                ProjectDevelopmentGrantFundingAmountOf7thPayment = "700",
                ProjectDevelopmentGrantFundingAmountOf7thPaymentDue = "7",
                ProjectDevelopmentGrantFundingDateOf7thPaymentDue = new DateTime(2020, 1, 7),
                ProjectDevelopmentGrantFundingDateOf7thActualPayment = new DateTime(2020, 2, 7),
                ProjectDevelopmentGrantFundingAmountOf8thPayment = "800",
                ProjectDevelopmentGrantFundingAmountOf8thPaymentDue = "8",
                ProjectDevelopmentGrantFundingDateOf8thPaymentDue = new DateTime(2020, 1, 8),
                ProjectDevelopmentGrantFundingDateOf8thActualPayment = new DateTime(2020, 2, 8),
                ProjectDevelopmentGrantFundingAmountOf9thPayment = "900",
                ProjectDevelopmentGrantFundingAmountOf9thPaymentDue = "9",
                ProjectDevelopmentGrantFundingDateOf9thPaymentDue = new DateTime(2020, 1, 9),
                ProjectDevelopmentGrantFundingDateOf9thActualPayment = new DateTime(2020, 2, 9),
                ProjectDevelopmentGrantFundingAmountOf10thPayment = "1000",
                ProjectDevelopmentGrantFundingAmountOf10thPaymentDue = "10",
                ProjectDevelopmentGrantFundingDateOf10thPaymentDue = new DateTime(2020, 1, 10),
                ProjectDevelopmentGrantFundingDateOf10thActualPayment = new DateTime(2020, 2, 10)
            };

            var result = PDGDashboardBuilder.Build(po);

            result.PaymentScheduleDate.Should().Be(new DateTime(2020, 1, 10));
            result.PaymentActualDate.Should().Be(new DateTime(2020, 2, 10));
            result.PaymentActualAmount.Should().Be(5500);
            result.PaymentScheduleAmount.Should().Be(55);

        }

        [Fact]
        public void When11thPaymentisEnteredUse11thPayment()
        {
            var po = new Po()
            {
                ProjectDevelopmentGrantFundingAmountOf1stPayment = "100",
                ProjectDevelopmentGrantFundingAmountOf1stPaymentDue = "1",
                ProjectDevelopmentGrantFundingDateOf1stPaymentDue = new DateTime(2020, 1, 1),
                ProjectDevelopmentGrantFundingDateOf1stActualPayment = new DateTime(2020, 2, 1),
                ProjectDevelopmentGrantFundingAmountOf2ndPayment = "200",
                ProjectDevelopmentGrantFundingAmountOf2ndPaymentDue = "2",
                ProjectDevelopmentGrantFundingDateOf2ndPaymentDue = new DateTime(2020, 1, 2),
                ProjectDevelopmentGrantFundingDateOf2ndActualPayment = new DateTime(2020, 2, 2),
                ProjectDevelopmentGrantFundingAmountOf3rdPayment = "300",
                ProjectDevelopmentGrantFundingAmountOf3rdPaymentDue = "3",
                ProjectDevelopmentGrantFundingDateOf3rdPaymentDue = new DateTime(2020, 1, 3),
                ProjectDevelopmentGrantFundingDateOf3rdActualPayment = new DateTime(2020, 2, 3),
                ProjectDevelopmentGrantFundingAmountOf4thPayment = "400",
                ProjectDevelopmentGrantFundingAmountOf4thPaymentDue = "4",
                ProjectDevelopmentGrantFundingDateOf4thPaymentDue = new DateTime(2020, 1, 4),
                ProjectDevelopmentGrantFundingDateOf4thActualPayment = new DateTime(2020, 2, 4),
                ProjectDevelopmentGrantFundingAmountOf5thPayment = "500",
                ProjectDevelopmentGrantFundingAmountOf5thPaymentDue = "5",
                ProjectDevelopmentGrantFundingDateOf5thPaymentDue = new DateTime(2020, 1, 5),
                ProjectDevelopmentGrantFundingDateOf5thActualPayment = new DateTime(2020, 2, 5),
                ProjectDevelopmentGrantFundingAmountOf6thPayment = "600",
                ProjectDevelopmentGrantFundingAmountOf6thPaymentDue = "6",
                ProjectDevelopmentGrantFundingDateOf6thPaymentDue = new DateTime(2020, 1, 6),
                ProjectDevelopmentGrantFundingDateOf6thActualPayment = new DateTime(2020, 2, 6),
                ProjectDevelopmentGrantFundingAmountOf7thPayment = "700",
                ProjectDevelopmentGrantFundingAmountOf7thPaymentDue = "7",
                ProjectDevelopmentGrantFundingDateOf7thPaymentDue = new DateTime(2020, 1, 7),
                ProjectDevelopmentGrantFundingDateOf7thActualPayment = new DateTime(2020, 2, 7),
                ProjectDevelopmentGrantFundingAmountOf8thPayment = "800",
                ProjectDevelopmentGrantFundingAmountOf8thPaymentDue = "8",
                ProjectDevelopmentGrantFundingDateOf8thPaymentDue = new DateTime(2020, 1, 8),
                ProjectDevelopmentGrantFundingDateOf8thActualPayment = new DateTime(2020, 2, 8),
                ProjectDevelopmentGrantFundingAmountOf9thPayment = "900",
                ProjectDevelopmentGrantFundingAmountOf9thPaymentDue = "9",
                ProjectDevelopmentGrantFundingDateOf9thPaymentDue = new DateTime(2020, 1, 9),
                ProjectDevelopmentGrantFundingDateOf9thActualPayment = new DateTime(2020, 2, 9),
                ProjectDevelopmentGrantFundingAmountOf10thPayment = "1000",
                ProjectDevelopmentGrantFundingAmountOf10thPaymentDue = "10",
                ProjectDevelopmentGrantFundingDateOf10thPaymentDue = new DateTime(2020, 1, 10),
                ProjectDevelopmentGrantFundingDateOf10thActualPayment = new DateTime(2020, 2, 10),
                ProjectDevelopmentGrantFundingAmountOf11thPayment = "1100",
                ProjectDevelopmentGrantFundingAmountOf11thPaymentDue = "11",
                ProjectDevelopmentGrantFundingDateOf11thPaymentDue = new DateTime(2020, 1, 11),
                ProjectDevelopmentGrantFundingDateOf11thActualPayment = new DateTime(2020, 2, 11),
            };

            var result = PDGDashboardBuilder.Build(po);

            result.PaymentScheduleDate.Should().Be(new DateTime(2020, 1, 11));
            result.PaymentActualDate.Should().Be(new DateTime(2020, 2, 11));
            result.PaymentActualAmount.Should().Be(6600);
            result.PaymentScheduleAmount.Should().Be(66);

        }


        [Fact]
        public void When12thPaymentisEnteredUse12thPayment()
        {
            var po = new Po()
            {
                ProjectDevelopmentGrantFundingAmountOf1stPayment = "100",
                ProjectDevelopmentGrantFundingAmountOf1stPaymentDue = "1",
                ProjectDevelopmentGrantFundingDateOf1stPaymentDue = new DateTime(2020, 1, 1),
                ProjectDevelopmentGrantFundingDateOf1stActualPayment = new DateTime(2020, 2, 1),
                ProjectDevelopmentGrantFundingAmountOf2ndPayment = "200",
                ProjectDevelopmentGrantFundingAmountOf2ndPaymentDue = "2",
                ProjectDevelopmentGrantFundingDateOf2ndPaymentDue = new DateTime(2020, 1, 2),
                ProjectDevelopmentGrantFundingDateOf2ndActualPayment = new DateTime(2020, 2, 2),
                ProjectDevelopmentGrantFundingAmountOf3rdPayment = "300",
                ProjectDevelopmentGrantFundingAmountOf3rdPaymentDue = "3",
                ProjectDevelopmentGrantFundingDateOf3rdPaymentDue = new DateTime(2020, 1, 3),
                ProjectDevelopmentGrantFundingDateOf3rdActualPayment = new DateTime(2020, 2, 3),
                ProjectDevelopmentGrantFundingAmountOf4thPayment = "400",
                ProjectDevelopmentGrantFundingAmountOf4thPaymentDue = "4",
                ProjectDevelopmentGrantFundingDateOf4thPaymentDue = new DateTime(2020, 1, 4),
                ProjectDevelopmentGrantFundingDateOf4thActualPayment = new DateTime(2020, 2, 4),
                ProjectDevelopmentGrantFundingAmountOf5thPayment = "500",
                ProjectDevelopmentGrantFundingAmountOf5thPaymentDue = "5",
                ProjectDevelopmentGrantFundingDateOf5thPaymentDue = new DateTime(2020, 1, 5),
                ProjectDevelopmentGrantFundingDateOf5thActualPayment = new DateTime(2020, 2, 5),
                ProjectDevelopmentGrantFundingAmountOf6thPayment = "600",
                ProjectDevelopmentGrantFundingAmountOf6thPaymentDue = "6",
                ProjectDevelopmentGrantFundingDateOf6thPaymentDue = new DateTime(2020, 1, 6),
                ProjectDevelopmentGrantFundingDateOf6thActualPayment = new DateTime(2020, 2, 6),
                ProjectDevelopmentGrantFundingAmountOf7thPayment = "700",
                ProjectDevelopmentGrantFundingAmountOf7thPaymentDue = "7",
                ProjectDevelopmentGrantFundingDateOf7thPaymentDue = new DateTime(2020, 1, 7),
                ProjectDevelopmentGrantFundingDateOf7thActualPayment = new DateTime(2020, 2, 7),
                ProjectDevelopmentGrantFundingAmountOf8thPayment = "800",
                ProjectDevelopmentGrantFundingAmountOf8thPaymentDue = "8",
                ProjectDevelopmentGrantFundingDateOf8thPaymentDue = new DateTime(2020, 1, 8),
                ProjectDevelopmentGrantFundingDateOf8thActualPayment = new DateTime(2020, 2, 8),
                ProjectDevelopmentGrantFundingAmountOf9thPayment = "900",
                ProjectDevelopmentGrantFundingAmountOf9thPaymentDue = "9",
                ProjectDevelopmentGrantFundingDateOf9thPaymentDue = new DateTime(2020, 1, 9),
                ProjectDevelopmentGrantFundingDateOf9thActualPayment = new DateTime(2020, 2, 9),
                ProjectDevelopmentGrantFundingAmountOf10thPayment = "1000",
                ProjectDevelopmentGrantFundingAmountOf10thPaymentDue = "10",
                ProjectDevelopmentGrantFundingDateOf10thPaymentDue = new DateTime(2020, 1, 10),
                ProjectDevelopmentGrantFundingDateOf10thActualPayment = new DateTime(2020, 2, 10),
                ProjectDevelopmentGrantFundingAmountOf11thPayment = "1100",
                ProjectDevelopmentGrantFundingAmountOf11thPaymentDue = "11",
                ProjectDevelopmentGrantFundingDateOf11thPaymentDue = new DateTime(2020, 1, 11),
                ProjectDevelopmentGrantFundingDateOf11thActualPayment = new DateTime(2020, 2, 11),
                ProjectDevelopmentGrantFundingAmountOf12thPayment = "1200",
                ProjectDevelopmentGrantFundingAmountOf12thPaymentDue = "12",
                ProjectDevelopmentGrantFundingDateOf12thPaymentDue = new DateTime(2020, 1, 12),
                ProjectDevelopmentGrantFundingDateOf12thActualPayment = new DateTime(2020, 2, 12)
            };

            var result = PDGDashboardBuilder.Build(po);

            result.PaymentScheduleDate.Should().Be(new DateTime(2020, 1, 12));
            result.PaymentActualDate.Should().Be(new DateTime(2020, 2, 12));
            result.PaymentActualAmount.Should().Be(7800);
            result.PaymentScheduleAmount.Should().Be(78);

        }
    }
}

using Dfe.Complete.Constants;
using Dfe.Complete.TagHelpers;
using FluentAssertions;

namespace Dfe.Complete.Tests.Components
{
    public class SummaryItemValueBuilderTests
    {
        [Fact]
        public void When_Null()
        {
            var result = SummaryItemValueBuilder.Execute(null, null);

            result.Should().Be(HtmlTagConstants.Empty);
        }

        [Theory]
        [InlineData("Value", "Value")]
        [InlineData("", HtmlTagConstants.Empty)]
        public void When_String(string value, string expected)
        {
            var result = SummaryItemValueBuilder.Execute(value, typeof(string));

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(true, "Yes")]
        [InlineData(false, "No")]
        public void When_Boolean(bool value, string expected)
        {
            var result = SummaryItemValueBuilder.Execute(value, typeof(bool));

            result.Should().Be(expected);
        }

        [Fact]
        public void When_OptionalBoolean()
        {
            var result = SummaryItemValueBuilder.Execute(true, typeof(bool?));

            result.Should().Be("Yes");
        }

        [Fact]
        public void When_Date()
        {
            var date = new DateTime(2023, 1, 1);

            var result = SummaryItemValueBuilder.Execute(date, typeof(DateTime));

            result.Should().Be("1 January 2023");
        }

        [Fact]
        public void When_OptionalDate()
        {
            var date = new DateTime(2023, 1, 1);

            var result = SummaryItemValueBuilder.Execute(date, typeof(DateTime?));

            result.Should().Be("1 January 2023");
        }

        [Fact]
        public void When_Decimal()
        {
            var value = 123.45m;

            var result = SummaryItemValueBuilder.Execute(value, typeof(decimal));

            result.Should().Be("£123.45");
        }

        [Fact]
        public void When_OptionalDecimal()
        {
            var value = 123.45m;

            var result = SummaryItemValueBuilder.Execute(value, typeof(decimal?));

            result.Should().Be("£123.45");
        }

        //[Fact]
        //public void When_Enum()
        //{
        //    var value = ProjectState.Active;

        //    var result = SummaryItemValueBuilder.Execute(value, typeof(ProjectState));

        //    result.Should().Be("Active");
        //}

        //[Fact]
        //public void When_OptionalEnum()
        //{
        //    var value = ProjectState.Completed;

        //    var result = SummaryItemValueBuilder.Execute(value, typeof(ProjectState?));

        //    result.Should().Be("Completed");
        //}

        [Fact]
        public void when_EnumNotSet()
        {
            var value = TestEnum.NotSet;

            var result = SummaryItemValueBuilder.Execute(value, typeof(TestEnum));

            result.Should().Be(HtmlTagConstants.Empty);
        }

        //[Fact]
        //public void When_Address()
        //{
        //    var address = new Address() { Street = "Street", Locality = "Locality", Additional = "Additional", Town = "Town", County = "County", Postcode = "Postcode"  };

        //    var result = SummaryItemValueBuilder.Execute(address, typeof(Address));

        //    result.Should().Be("Street<br />Locality<br />Additional<br />Town<br />County<br />Postcode");
        //}

        //[Fact]
        //public void When_Address_Empty()
        //{
        //    var address = new Address();

        //    var result = SummaryItemValueBuilder.Execute(address, typeof(Address));

        //    result.Should().Be(HtmlTagConstants.Empty);
        //}

        [Fact]
        public void Build_ReturnsFormattedLink_ForLinkSummaryItem()
        {
            var linkSummaryItem = new LinkSummaryItem
            {
                Label = "Label",
                Link = "http://example.com",
                LinkText = "Example"
            };

            var result = SummaryItemValueBuilder.Execute(linkSummaryItem, typeof(LinkSummaryItem));

            result.Should().Be(@"Label<br /><a target=""_blank"" class=""govuk-link"" href=""http://example.com"">Example (opens in a new tab)</a>");
        }
    }

    internal enum TestEnum
    {
        NotSet = 1
    }
}

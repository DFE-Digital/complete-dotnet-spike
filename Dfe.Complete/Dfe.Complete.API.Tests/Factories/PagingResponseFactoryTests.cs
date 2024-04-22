using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using System.Collections.Generic;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Factories
{
    public class PagingResponseFactoryTests
    {
        [Fact]
        public void CreatingPagingResponse_WithRecordCountLessThanCount_Should_ReturnPagingResponseWithNullNextPageUrl()
        {
            const int recordCount = 2;
            const int recordsPerPage = 50;
            const int page = 1;

            var expectedPagingResponse = new PagingResponse
            {
                Page = page,
                RecordCount = recordCount,
                TotalPages = 1,
                NextPageUrl = null
            };

            var httpRequest = Substitute.For<HttpRequest>();

            var result = PagingResponseFactory.Create(page, recordsPerPage, recordCount, httpRequest);

            result.Should().BeEquivalentTo(expectedPagingResponse);
        }

        [Theory]
        [InlineData(1, 50)]
        [InlineData(10, 5)]
        [InlineData(3, 17)]
        [InlineData(6, 9)]
        public void CreatePagingResponse_WithTotalPageCount_Should_ReturnCorrectResult(int recordsPerPage, int expectedTotalPages)
        {
            var recordCount = 50;
            HttpRequest mockHttpRequest = CreateHttpRequest();

            var result = PagingResponseFactory.Create(1, recordsPerPage, recordCount, mockHttpRequest);

            result.TotalPages.Should().Be(expectedTotalPages);
        }

        [Theory]
        [InlineData(1, 50, false, false)]
        [InlineData(1, 10, true, false)]
        [InlineData(3, 10, true, true)]
        [InlineData(5, 10, false, true)]
        public void CreatePagingResponse_WithNextAndPrevious_Should_ReturnCorrectResult(int page, int recordsPerPage, bool hasNext, bool hasPrevious)
        {
            var recordCount = 50;

            HttpRequest mockHttpRequest = CreateHttpRequest();

            var result = PagingResponseFactory.Create(page, recordsPerPage, recordCount, mockHttpRequest);

            result.HasNext.Should().Be(hasNext);
            result.HasPrevious.Should().Be(hasPrevious);
        }

        [Fact]
        public void CreatingPagingResponse_WithRecordGreaterThanViewedRecords_Should_ReturnPagingResponseWithNextPageUrlPointingToNextPage()
        {
            const int recordCount = 2;
            const int count = 1;
            const int page = 1;
            var expectedNextPageUrl = $@"/controller-name/?page={page + 1}&count={count}";

            var expectedPagingResponse = new PagingResponse
            {
                Page = page,
                RecordCount = recordCount,
                NextPageUrl = expectedNextPageUrl,
                HasNext = true,
                HasPrevious = false,
                TotalPages = 2
            };

            var mockHttpRequest = CreateHttpRequest();

            var result = PagingResponseFactory.Create(page, count, recordCount, mockHttpRequest);

            result.Should().BeEquivalentTo(expectedPagingResponse);
        }

        [Fact]
        public void CreatingPagingResponse_WithRecordCountEqualToCountAndQueryParameters_Should_ReturnPagingResponseWithNextPageUrlPointingToNextPageIncludingQueryParameters()
        {
            const int recordCount = 2;
            const int count = 1;
            const int page = 1;

            var query = new Dictionary<string, StringValues>
            {
                {"queryParameter", "queryValue"}
            };

            var queryCollection = new QueryCollection(query);

            var expectedNextPageUrl = $@"/controller-name/?queryParameter=queryValue&page={page + 1}&count={count}";

            var expectedPagingResponse = new PagingResponse
            {
                Page = page,
                RecordCount = recordCount,
                NextPageUrl = expectedNextPageUrl,
                HasNext = true,
                HasPrevious = false,
                TotalPages = 2
            };

            var mockHttpRequest = CreateHttpRequest();
            mockHttpRequest.Query = queryCollection;

            var result = PagingResponseFactory.Create(page, count, recordCount, mockHttpRequest);

            result.Should().BeEquivalentTo(expectedPagingResponse);
        }

        private static HttpRequest CreateHttpRequest()
        {
            var mockHttpRequest = Substitute.For<HttpRequest>();
            mockHttpRequest.Scheme = "https";
            mockHttpRequest.Path = "/controller-name/";
            mockHttpRequest.Query = new QueryCollection();
            return mockHttpRequest;
        }
    }
}
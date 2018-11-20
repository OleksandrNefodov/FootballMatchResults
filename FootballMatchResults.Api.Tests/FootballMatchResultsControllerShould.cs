using System;
using FootballMatchResults.Api.Controllers;
using FootballMatchResults.API.Tests;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using FootballMatchResults.Api.Models;
using System.Collections.Generic;

namespace FootballMatchResults.Api.Tests
{
    public class FootballMatchResultsControllerShould : IClassFixture<TestFixture>
    {
        private readonly FootballMatchResultsController _controller;
        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { new FilterRequest{EndDate = DateTime.UtcNow, StartDate = new DateTime(2014, 4, 1)} }
        };

        private static readonly FilterRequest request = new FilterRequest
        {
            EndDate = DateTime.UtcNow,
            StartDate = DateTime.UtcNow            
        };
    

        public FootballMatchResultsControllerShould(TestFixture fixture)
        {
            _controller = fixture.MessageController;
        }

        [Fact]
        public void ReturnAllResultsJson()
        {
             IActionResult result = _controller.Get();
             var okResult = result as OkObjectResult;

             var results = Assert.IsType<string>(okResult.Value);
             Assert.True(!string.IsNullOrEmpty(results));
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void ReturnFilteredResults(FilterRequest request)
        {
            IActionResult result = _controller.Post(request);
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            var results = Assert.IsType<List<MatchResult>>(okResult.Value);
            List<MatchResult> realResults = okResult.Value as List<MatchResult>;
            Assert.True(realResults.Count > 0);
        }
    }
}

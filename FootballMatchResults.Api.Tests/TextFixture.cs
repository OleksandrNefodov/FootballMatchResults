using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using FootballMatchResults.Api.Controllers;
using FootballMatchResults.Api.Helpers;
using FootballMatchResults.Api.Models;
using FootballMatchResults.Api.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace FootballMatchResults.API.Tests
{
    public class TestFixture
    {
        public TestFixture()
        {
            var services = new ServiceCollection().AddLogging();
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://functionapp2018071101324.blob.core.windows.net/")
            };

            httpClient.DefaultRequestHeaders.Clear();  
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            services.AddSingleton<HttpClient>(httpClient);
            services.AddSingleton<JsonHelper, JsonHelper>();

            services.AddTransient<IResultMatchRepository, ResultMatchRepository>((ctx) =>
            {
                var client = ctx.GetService<HttpClient>();
                var helper = ctx.GetService<JsonHelper>();
                var factory = ctx.GetService<ILoggerFactory>();
                
                var logger = factory.CreateLogger<ResultMatchRepository>();

                return new ResultMatchRepository(client, logger, helper);
            });

            services.AddSingleton<FootballMatchResultsController, FootballMatchResultsController>();

            ServiceProvider = services.BuildServiceProvider();
        }

        private IServiceProvider ServiceProvider { get; set; }

        public IResultMatchRepository DataRepository => ServiceProvider.GetService<IResultMatchRepository>();

        public FootballMatchResultsController MessageController => ServiceProvider.GetService<FootballMatchResultsController>();
        
    }
}
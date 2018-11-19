using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FootballMatchResults.Api.Configuration;
using FootballMatchResults.Api.Helpers;
using FootballMatchResults.Dashboard.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FootballMatchResults.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ApplicationConfiguration configuration = Configuration.GetSection("ApplicationConfiguration")
                .Get<ApplicationConfiguration>();

            services            
            .AddSingleton<IResultMatchRepository, ResultMatchRepository>()
            .AddCors(o => o.AddPolicy("MyPolicy", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();

                }))
            .AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var apiEndPoint = new Uri(configuration.AdafyTestDataUrl);

            var httpClient = new HttpClient
            {
                BaseAddress = apiEndPoint,
            };

            httpClient.DefaultRequestHeaders.Clear();  
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            services.AddSingleton<HttpClient>(httpClient);

            services.AddSingleton<JsonHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }            

            app.UseCors("MyPolicy");
            app.UseStatusCodePages();
            app.UseMvc();
        }
    }
}

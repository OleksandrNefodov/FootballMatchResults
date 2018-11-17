using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FootballMatchResults.Dashboard.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FootballMatchResults.Dashboard
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors();

            ApplicationConfiguration configuration = Configuration.GetSection("ApplicationConfiguration")
                .Get<ApplicationConfiguration>();

            services.AddSingleton<IApplicationConfiguration, ApplicationConfiguration>(
                e => configuration);

        
            var apiEndPoint = new Uri(configuration.FootballMatchResultsApiUrl);
            var httpClient = new HttpClient
            {
                BaseAddress = apiEndPoint,
            };

            httpClient.DefaultRequestHeaders.Clear();  
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            services.AddSingleton<HttpClient>(httpClient);
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
            
            app.UseStaticFiles();

            ApplicationConfiguration configuration = Configuration.GetSection("ApplicationConfiguration")
                .Get<ApplicationConfiguration>();

            app.UseCors(builder =>
            builder
            .WithOrigins(configuration.FootballMatchResultsApiUrl)
            .AllowAnyHeader()
            );


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

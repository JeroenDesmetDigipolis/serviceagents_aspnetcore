﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Digipolis.ServiceAgents;
using System.IO;

namespace SampleApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), false, true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.

            //To add a single serviceAgent just use the AddSingleServiceAgent<T> extension
            //services.AddSingleServiceAgent<DemoAgent>(settings =>
            //{
            //    settings.Scheme = HttpSchema.Http;
            //    settings.Host = "localhost";
            //    settings.Port = "50267";
            //    //settings.Path = "api/";
            //    settings.AuthScheme = AuthScheme.ApiKey;
            //    settings.ApiKey = "myapikey";
            //});


            //services.AddSingleServiceAgent<OAuthDemoAgent>(settings =>
            //{
            //    settings.Scheme = HttpSchema.Https;
            //    settings.Host = "mycompany.com";
            //    settings.Port = "443";
            //    settings.Path = "testoauthtoolbox/v2";
            //    settings.AuthScheme = AuthScheme.OAuthClientCredentials;
            //    settings.OAuthClientId = "f44d3641-8249-440d-a6e5-61b7b4893184";
            //    settings.OAuthClientSecret = "2659485f-f0be-4526-bb7a-0541365351f5";
            //    settings.OAuthScope = "testoauthDigipolis.v2.all";
            //    settings.OAuthPathAddition = "oauth2/token";
            //    settings.ApiKey = "";


            //});

            //services.AddServiceAgents(settings =>
            //{
            //    settings.FileName = "_config/serviceagents.json";
            //});

            //To use a json configuration file use the AddServiceAgents extension
            services.AddServiceAgents(settings =>
            {
                settings.FileName = Path.Combine(Directory.GetCurrentDirectory(), "_config/serviceagents.json");
            });

            //services.AddServiceAgents(json =>
            //{
            //    json.FileName = Path.Combine(Directory.GetCurrentDirectory(), "_config/serviceagents.json");
            //}, serviceAgentSettings =>
            //{
            //    serviceAgentSettings.Services.Single(s => s.Key == nameof(DemoAgent)).Value.BasicAuthPassword = "userNamefromcode";
            //    serviceAgentSettings.Services.Single(s => s.Key == nameof(DemoAgent)).Value.BasicAuthUserName = "passwordfromcode";
            //}, null);

            //When combined with CorrelationId use an overload to add client behaviour (Dependency on Digipolis.WebApi required)
            //services.AddServiceAgents(settings =>
            //{
            //    settings.FileName = "_config/serviceagents.json";
            //}, (serviceProvider, client) => client.SetCorrelationValues(serviceProvider));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            app.UseMvc();
        }
    }
}

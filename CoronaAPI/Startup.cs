using System;
using System.IO;
using System.Reflection;
using CoronaAPI.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using CoronaAPI.Service.Interfaces;
using CoronaAPI.Service;
using CoronaAPI.Repository.Interfaces;
using CoronaAPI.Repository;
using Newtonsoft.Json.Converters;

namespace CoronaAPI
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

            // Controllers
            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));
            
            // DI 
            services.AddTransient<ICoronaDataHandler, CoronaDataHandler>();
            services.AddTransient<IHttpCoronaDataFetcher, HttpCoronaDataFetcher>();

            services.AddHttpClient<IHttpCoronaDataFetcher, HttpCoronaDataFetcher>(client =>
            {
                client.BaseAddress = new Uri(Constants.OpenDataECDCUrl);
            });
            
            // Automapper
            services.ConfigureAutomapper();
            
            // Json Serializer

            // Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "CoronaAPI", Version = "v1" });
                
                // Include XML comments in swagger UI;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            }).AddSwaggerGenNewtonsoftSupport();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoronaAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

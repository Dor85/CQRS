using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Project.Api.Services;
using Company.Project.Application;
using Company.Project.Application.Common.Interfaces;
using Company.Project.Insfrastructure;
using Company.Project.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Company.Project.Api.Middleware;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Company.Project.Api
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
            services.AddInfrastructure(Configuration);
            services.AddPersistence(Configuration);
            services.AddApplication();

            //TODO: to use this, need to create an IHealthCheck implementation on my project.
            //services.AddHealthChecks()
            //    .AddCheck<TaskDbContext>("MySql",
            //        failureStatus: HealthStatus.Unhealthy,
            //        tags: new[] { "Db", "MySQL" });


            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddHttpContextAccessor();

            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IDbContext>());

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddOpenApiDocument(configure =>
            {
                configure.Title = "Task API";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseCustomExceptionHandler();
            app.UseStaticFiles();

            //app.UseHealthChecks("/health");

            app.UseOpenApi();
            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/api";
            });

            app.UseMvc();
        }
    }
}

using Company.Project.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.Persistence
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddEntityFrameworkMySql();
            //services.AddDbContextPool<TaskDbContext>((serviceProvider, optionsBuilder) =>
            //{
            //    optionsBuilder.UseMySql(configuration.GetConnectionString("TaskManagerDatabase"));
            //    optionsBuilder.UseInternalServiceProvider(serviceProvider);
            //});

            services.AddDbContext<TaskDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("TaskManagerDatabase")));

            services.AddScoped<IDbContext>(provider => provider.GetService<TaskDbContext>());

            return services;
        }
    }
}

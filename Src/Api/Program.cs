using System;
using System.Threading;
using System.Threading.Tasks;
using Company.Project.Application.Data.SeedData;
using Company.Project.Persistence;
using MediatR;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Company.Project.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            await CreateAndSeedDataBase(host);

            host.Run();
        }

        private static async Task CreateAndSeedDataBase(IWebHost host)
        {
            int retries = 1;
            bool shouldExit = false;
            using (var scope = host.Services.CreateScope())
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                while (retries < 10 && !shouldExit)
                {
                    try
                    {
                        var services = scope.ServiceProvider;

                        var taskDbContext = services.GetRequiredService<TaskDbContext>();
                        logger.LogInformation($"Trying to connect to: {taskDbContext.Database.GetDbConnection().ConnectionString} ");
                        taskDbContext.Database.Migrate();

                        var mediator = services.GetRequiredService<IMediator>();
                        await mediator.Send(new SeedDataCommand(), CancellationToken.None);
                        shouldExit = true;
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("An error occurred initializing the database", ex);
                        var sleep = (int)Math.Pow(2, retries) * 1000;
                        logger.LogInformation($"Thread going to sleep for: {sleep} milliseconds");
                        Thread.Sleep(sleep);
                        retries++;
                        logger.LogInformation($"Starting Attempt {retries}.");
                    }
                }
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;
                config
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true);

                if (env.IsDevelopment())
                {

                }
                config.AddEnvironmentVariables();

                if (args != null)
                {
                    config.AddCommandLine(args);
                }

            })
            .UseStartup<Startup>();
    }
}

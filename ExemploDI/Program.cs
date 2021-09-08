using System;
using ExemploDI.Services;
using ExemploDI.Stores;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ExemploDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = ConfigureServices();

            var _logger = provider.GetRequiredService<ILogger<Program>>();

            _logger.LogInformation("Hello World!\n");

            var carService = provider.GetRequiredService<CarServices>();

            carService.List();

            carService.Get(8);

            _logger.LogInformation("Good Bye!\n");
        }

        static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(LoadConfiguration());

            services.AddLogging(loggerBuilder =>
            {
                loggerBuilder.ClearProviders();
                loggerBuilder.AddConsole();
                loggerBuilder.SetMinimumLevel(LogLevel.Trace);
            });

            services.AddScoped<CarServices>();

            services.AddSingleton<ICarStore, CarStore>();

            return services.BuildServiceProvider();
        }

        static IConfiguration LoadConfiguration()
        {
            return new ConfigurationBuilder()
              .AddJsonFile($"appsettings.json", true, true)
              .AddEnvironmentVariables()
              .Build();
        }
    }
}

using HealthCheckService.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HealthCheckService.Infrastructure;

public class HostBuilder
{
    public static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            services.AddScoped<IImplementation, Implementation>();
            services.AddScoped<IHealthChecker, HealthChecker>();
        });
}

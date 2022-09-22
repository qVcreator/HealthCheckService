using HealthCheckService.Infrastructure;
using HealthCheckService.Interfaces;
using Microsoft.Extensions.DependencyInjection;



var host = HostBuilder.CreateHostBuilder().Build();

host.Services.CreateScope();

await host.Services.GetService<IImplementation>()!.Run();

while (true)
{
    Thread.Sleep(10000);
}
using HealthCheckService.Interfaces;
using Microsoft.Extensions.Logging;
using System.Timers;

namespace HealthCheckService.Infrastructure;

public class HealthChecker : IHealthChecker
{
    private readonly List<string> _servicesToCheck;
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;

    public HealthChecker(ILogger<HealthChecker> logger)
    {
        _servicesToCheck = new List<string>()
        {
            "https://piter-education.ru:6010/health"
        };
        _httpClient = new HttpClient();
        _logger = logger;
    }

    public async Task Check(object? sender, ElapsedEventArgs e)
    {
        foreach(var service in _servicesToCheck)
        {
            await _httpClient.GetStringAsync(service);
        }
    }
}

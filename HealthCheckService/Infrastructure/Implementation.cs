using HealthCheckService.Interfaces;
using Microsoft.Extensions.Logging;
using System.Timers;
using Timer = System.Timers.Timer;

namespace HealthCheckService.Infrastructure;

public class Implementation : IImplementation
{
    private readonly IHealthChecker _currencyHandle;
    private readonly ILogger _logger;

    public Implementation(IHealthChecker currencyHandle, ILogger<Implementation> logger)
    {
        _currencyHandle = currencyHandle;
        _logger = logger;
    }

    public async Task Run()
    {
        var period = 1080000;

        var timer = new Timer(period);

        await _currencyHandle.Check(this, EventArgs.Empty as ElapsedEventArgs);

        timer.Elapsed += async (s, e) => await _currencyHandle.Check(s, e);
        timer.AutoReset = true;
        timer.Start();

    }
}

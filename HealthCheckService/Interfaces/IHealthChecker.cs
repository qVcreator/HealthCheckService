using System.Timers;

namespace HealthCheckService.Interfaces;

public interface IHealthChecker
{
    Task Check(object? sender, ElapsedEventArgs e);
}

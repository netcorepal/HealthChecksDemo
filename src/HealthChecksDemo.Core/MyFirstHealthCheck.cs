using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
namespace HealthChecksDemo
{
    class MyFirstHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var result = new HealthCheckResult(HealthStatus.Degraded);
            return Task.FromResult(result);
        }
    }
}

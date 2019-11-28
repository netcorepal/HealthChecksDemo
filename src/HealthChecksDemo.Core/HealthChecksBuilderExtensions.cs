using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Diagnostics.HealthChecks;
namespace HealthChecksDemo
{
    public static class HealthChecksBuilderExtensions
    {
        public static IHealthChecksBuilder AddMyFirstHealthCheck(this IHealthChecksBuilder builder, string name, HealthStatus? failureStatus = null, IEnumerable<string> tags = null)
        {
            builder.AddCheck<MyFirstHealthCheck>(name, failureStatus, tags);
            return builder;
        }
    }
}

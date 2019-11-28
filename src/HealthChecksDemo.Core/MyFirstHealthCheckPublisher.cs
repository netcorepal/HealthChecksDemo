using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
namespace HealthChecksDemo
{
    public class MyFirstHealthCheckPublisher : IHealthCheckPublisher
    {
        HttpClient httpClient;
        MyFirstHealthCheckPublisherOptions options;
        public MyFirstHealthCheckPublisher(HttpClient httpClient, IOptions<MyFirstHealthCheckPublisherOptions> options)
        {
            this.httpClient = httpClient;
            this.options = options?.Value;
        }

        public async Task PublishAsync(HealthReport report, CancellationToken cancellationToken)
        {
            var content = new StringBuilder("健康检查：");
            content.AppendLine(Environment.MachineName);
            content.AppendLine($"总耗时{report.TotalDuration.TotalMilliseconds}");
            foreach (var item in report.Entries)
            {
                content.AppendLine($"{item.Key}:{item.Value.Status.ToString()},耗时{item.Value.Duration.TotalMilliseconds},{item.Value.Description}");
            }
            var json = JsonConvert.SerializeObject(new
            {
                msgtype = "text",
                text = new
                {
                    content = content.ToString()
                }
            });
            var stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var r = await httpClient.PostAsync(options.DingTalkUrl, stringContent, cancellationToken);
            var str = await r.Content.ReadAsStringAsync();
        }
    }


    public class MyFirstHealthCheckPublisherOptions
    {
        public string DingTalkUrl { get; set; }
    }
}

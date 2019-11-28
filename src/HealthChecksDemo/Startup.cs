using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

namespace HealthChecksDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        internal static bool Ready = true;
        internal static bool Live = true;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.Configure<MyFirstHealthCheckPublisherOptions>(Configuration.GetSection("MyFirstHealthCheckPublisherOptions"));
            services.AddHttpClient<IHealthCheckPublisher, MyFirstHealthCheckPublisher>();
            services.Configure<HealthCheckPublisherOptions>(option =>
            {
                option.Period = TimeSpan.FromSeconds(10);
            });
            services.AddHealthChecks()           
                .AddMyFirstHealthCheck("myfirstchecker", tags: new string[] { "live" })
                //.AddSqlServer(connectionString: "localhost", name: "sql")
                .AddCheck("live", () =>
                {
                    return Live ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy();
                }, new string[] { "live", "all" })
                .AddCheck("ready", () =>
                {
                    return Ready ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy();
                }, new string[] { "ready", "all" });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapHealthChecks("/healthcheck").RequireHost("www.abc.com");
                //endpoints.MapHealthChecks("/healthcheck2").RequireHost("localhost");
                //endpoints.MapHealthChecks("/healthcheck3");
                endpoints.MapHealthChecks("/live", new HealthCheckOptions { Predicate = checker => checker.Tags.Contains("live") });
                endpoints.MapHealthChecks("/ready", new HealthCheckOptions { Predicate = checker => checker.Tags.Contains("ready") });
                endpoints.MapHealthChecks("/checkall");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

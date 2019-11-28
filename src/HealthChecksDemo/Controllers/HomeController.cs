using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace HealthChecksDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SetReady([FromQuery]bool ready)
        {
            Startup.Ready = ready;
            if (!ready)
            {
                Task.Run(async () =>
                {
                    await Task.Delay(60000);
                    Startup.Ready = true;
                });
            }
            return Content($"{Environment.MachineName} : Ready={Startup.Ready}");
        }

        public IActionResult SetLive([FromQuery]bool live)
        {
            Startup.Live = live;
            return Content($"{Environment.MachineName} : Live={Startup.Live}");
        }

        public IActionResult Exit([FromServices]IHostApplicationLifetime application)
        {
            Task.Run(async () =>
            {
                await Task.Delay(3000);
                application.StopApplication();
            });
            return Content($"{Environment.MachineName} : Stopping");
        }
    }
}
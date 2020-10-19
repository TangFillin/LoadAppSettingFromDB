using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoadAppSettingFromDB.Models;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using LoadAppSettingFromDB.ConfigurationSet;

namespace LoadAppSettingFromDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration Configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            var config = JsonSerializer.Deserialize<SystemConfig>(Configuration["system.name"]);

            //var sysName = Configuration["system.name"].ToString();
            return View("Index", config);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

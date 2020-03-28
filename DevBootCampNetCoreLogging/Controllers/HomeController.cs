using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevBootCampNetCoreLogging.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace DevBootCampNetCoreLogging.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration _configuration;

        //get an ILogger via dependency injection

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;

            _configuration = configuration;
        }
        public IActionResult Index()
        {

            _logger.LogInformation("Entered Index method at: " + System.DateTime.UtcNow.ToString());

            string fakeAppSetting = _configuration["FakeAppSetting"];

            _logger.LogInformation("FakeAppSettingValue: " + fakeAppSetting);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

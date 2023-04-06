using appsettingsJson_AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Options;

namespace appsettingsJson_AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        MailInfo _mailInfo;
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(IOptions<MailInfo> mailInfo, ILogger<HomeController> logger, IConfiguration configuration)
        {
            _mailInfo = mailInfo.Value;
            //_configuration = configuration;
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            //MailInfo mailInfo = _configuration.GetSection("MailInfo").Get<MailInfo>();

            var a = _mailInfo.EmailInfo;

            return View();
        }

        public IActionResult Privacy()
        {
            var value1 = _configuration["OrnekMetin"];
            var value2 = _configuration["Person"];
            var value3 = _configuration["Person:Name"];
            var value4 = _configuration["Person:Surname"];
            var v5 = _configuration["Logging:LogLevel:Microsoft.AspNetCore"];
            var v6 = _configuration.GetSection("Peron");


            var v7 = _configuration.GetSection("Person").Get(typeof(Person));

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
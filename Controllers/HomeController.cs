using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealtimeGraphWithHostedService.Models;
using RealtimeGraphWithHostedService.Services;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RealtimeGraphWithHostedService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStockData stockData;

        public HomeController(ILogger<HomeController> logger, IStockData stockData)
        {
            _logger = logger;
            this.stockData = stockData;
        }

        public async Task<IActionResult> Index()
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

using Microsoft.AspNetCore.Mvc;
using sportLeague.Models;
using System.Diagnostics;
using sportLeague.Models;


namespace sportLeague.Controllers
{
    public class HomeController : Controller
    {
        //private SportsContext context {  get; set; }

        //public HomeController(SportsContext ctx) => context = ctx;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            //var leagues = context.Leagues.OrderBy(m=>m.Name).ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
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

using libreriaClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace libreriaClient.Controllers
{
    public class HomeController : Controller
    {
        HomeModel message = new HomeModel();

        public IActionResult Index(IFormCollection formCollection)
        {
            string buscar = formCollection["buscar"];
            return View(buscar);
        }
        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        } */
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TP1.Models;
using TP1.Views;

namespace TP1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Resultados(int cuadrado, float dividendo, float divisor)
        {
            ViewBag.div = dividendo / divisor;
            ViewBag.cuadrado = cuadrado * cuadrado;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ListProv()
        {
            ListProvViewModel model = new ListProvViewModel();
            model.data = CJson.GetProvincias();
            return View(model.data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

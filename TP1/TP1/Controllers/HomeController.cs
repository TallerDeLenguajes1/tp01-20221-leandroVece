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
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Resultados(string cuadrado, string dividendo, string divisor)
        {
            try
            {
                ViewBag.div = Convert.ToDouble(dividendo) / Convert.ToDouble(divisor);
            }
            catch (Exception ex)
            {
                ViewBag.cuadrado = "no";
                Logger.Error("Error" + ex.Message);
            }
            try
            {
                ViewBag.cuadrado = Convert.ToDouble(cuadrado) * Convert.ToDouble(cuadrado);
            }
            catch (Exception ex)
            {
                ViewBag.div = "no";
                Logger.Error("Error" + ex.Message);
            }

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

        public IActionResult CalcularLitro(string kilometros)
        {
            try
            {
                ViewBag.litros = Convert.ToDouble(kilometros) / 4;
            }
            catch (Exception ex)
            {
                ViewBag.cuadrado = "no";
                Logger.Error("Error" + ex.Message);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}

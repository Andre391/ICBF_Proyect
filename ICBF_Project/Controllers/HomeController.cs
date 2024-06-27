using ICBF_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Client;

namespace ICBF_Project.Controllers
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

        [Authorize(Roles = "Administrador")]
        public IActionResult Usuarios()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Niños()
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Acudiente")]
        public IActionResult AvanceAcademico()
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Madre Comunitaria")]
        public IActionResult Asistencia()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Jardines()
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
        }
    }
}

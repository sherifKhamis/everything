using Fahrgemeinschaftsplattform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fahrgemeinschaftsplattform.Controllers
{
    // HomeController dient als Standard-Controller der Anwendung für grundlegende Seiten wie Startseite und Datenschutz
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // Logger für Protokollierung von Informationen und Fehlern

        // Konstruktor zur Injektion des Loggers
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET-Methode für die Startseite
        public IActionResult Index()
        {
            return View(); // Gibt die Standard-View für die Startseite zurück
        }

        // GET-Methode für die Datenschutzseite
        public IActionResult Privacy()
        {
            return View(); // Gibt die View für die Datenschutzrichtlinien zurück
        }

        // Methode für die Fehlerseite
        // Verwendet ResponseCache, um sicherzustellen, dass keine Cache-Speicherung für die Fehlerseite erfolgt
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Erstellt eine neue Instanz von ErrorViewModel und übergibt die RequestId, falls vorhanden, für die Fehlerdiagnose
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

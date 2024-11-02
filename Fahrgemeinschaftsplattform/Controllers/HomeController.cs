using Fahrgemeinschaftsplattform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fahrgemeinschaftsplattform.Controllers
{
    // HomeController dient als Standard-Controller der Anwendung f�r grundlegende Seiten wie Startseite und Datenschutz
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // Logger f�r Protokollierung von Informationen und Fehlern

        // Konstruktor zur Injektion des Loggers
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET-Methode f�r die Startseite
        public IActionResult Index()
        {
            return View(); // Gibt die Standard-View f�r die Startseite zur�ck
        }

        // GET-Methode f�r die Datenschutzseite
        public IActionResult Privacy()
        {
            return View(); // Gibt die View f�r die Datenschutzrichtlinien zur�ck
        }

        // Methode f�r die Fehlerseite
        // Verwendet ResponseCache, um sicherzustellen, dass keine Cache-Speicherung f�r die Fehlerseite erfolgt
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Erstellt eine neue Instanz von ErrorViewModel und �bergibt die RequestId, falls vorhanden, f�r die Fehlerdiagnose
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

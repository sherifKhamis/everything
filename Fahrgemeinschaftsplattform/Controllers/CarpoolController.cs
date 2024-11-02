using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Fahrgemeinschaftsplattform.Services;

namespace Fahrgemeinschaftsplattform.Controllers
{
    // Controller für Carpool-Funktionen, hauptsächlich zur Anzeige der Ergebnisse in einer View
    public class CarpoolController : Controller
    {
        private readonly CarpoolService _carpoolService; // Instanz des CarpoolService zur Verarbeitung von Logik für Fahrten

        // Konstruktor zur Injektion des CarpoolService
        public CarpoolController(CarpoolService carpoolService)
        {
            _carpoolService = carpoolService;
        }

        // GET-Methode zum Suchen einer passenden Fahrt
        [HttpGet]
        public async Task<IActionResult> FindRide(double startLat, double startLon, double endLat, double endLon, DateTime requestedDeparture)
        {
            // Aufrufen des CarpoolService, um passende Fahrten zu finden
            var matches = await _carpoolService.FindMatchingRides(startLat, startLon, endLat, endLon, requestedDeparture, 100, 60);

            // Rückgabe der gefundenen Ergebnisse an eine View zur Anzeige
            return View(matches);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Fahrgemeinschaftsplattform.Data;
using Fahrgemeinschaftsplattform.Models;
using Fahrgemeinschaftsplattform.Services;
using Microsoft.EntityFrameworkCore;
using Route = Fahrgemeinschaftsplattform.Models.Route;
using Microsoft.AspNetCore.Authorization;

namespace Fahrgemeinschaftsplattform.Controllers
{
    // Controller zum Verwalten von Routen, die für Benutzer zugänglich sind, die angemeldet sind
    [Authorize] // Nur autorisierte Benutzer haben Zugriff auf diesen Controller
    public class RoutesController : Controller
    {
        private readonly ApplicationDbContext _context; // Datenbankkontext für den Zugriff auf Routen

        // Konstruktor zur Injektion des Datenbankkontexts
        public RoutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET-Methode zum Anzeigen aller Fahrten
        public async Task<IActionResult> Index()
        {
            // Abrufen aller Routen aus der Datenbank
            var routes = await _context.Routen.ToListAsync();
            return View(routes); // Rückgabe der Routen zur Anzeige in der View
        }

        // GET-Methode zum Anzeigen des Formulars zum Erstellen einer neuen Fahrt
        public IActionResult Create()
        {
            return View(); // Zeigt ein Formular zur Erstellung einer neuen Route an
        }

        // POST-Methode zum Speichern einer neuen Fahrt
        [HttpPost]
        [ValidateAntiForgeryToken] // Schutz vor CSRF-Angriffen
        public async Task<IActionResult> Create(Route route)
        {
            // Überprüfung, ob das Model gültig ist
            if (ModelState.IsValid)
            {
                _context.Routen.Add(route); // Hinzufügen der neuen Route zur Datenbank
                await _context.SaveChangesAsync(); // Speichern der Änderungen
                return RedirectToAction(nameof(Index)); // Weiterleitung zur Übersicht aller Routen nach erfolgreichem Erstellen
            }

            return View(route); // Falls das Model ungültig ist, Rückgabe der View mit den fehlerhaften Daten
        }

        // GET-Methode für das Formular zum Finden passender Fahrten
        public IActionResult FindRides()
        {
            return View(); // Zeigt eine View an, um Eingabedaten für die Suche nach Fahrten einzugeben
        }

        // POST-Methode zum Anzeigen der Ergebnisse passender Fahrten
        [HttpPost]
        public async Task<IActionResult> FindRides(double startLat, double startLon, double endLat, double endLon, DateTime requestedDeparture)
        {
            // Erstellen einer Instanz des CarpoolService zur Suche passender Fahrten
            var carpoolService = new CarpoolService(_context);
            var matchingRides = await carpoolService.FindMatchingRides(startLat, startLon, endLat, endLon, requestedDeparture, 100, 60);

            // Rückgabe der gefundenen Fahrten an die "MatchingResults" View zur Anzeige der Ergebnisse
            return View("MatchingResults", matchingRides);
        }
    }
}

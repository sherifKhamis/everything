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
    [Authorize]
    public class RoutesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Alle Fahrten anzeigen
        public async Task<IActionResult> Index()
        {
            var routes = await _context.Routen.ToListAsync();
            return View(routes);
        }

        // Formular zum Erstellen einer neuen Fahrt anzeigen
        public IActionResult Create()
        {
            return View();
        }

        // Neue Fahrt speichern
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Route route)
        {

            if (ModelState.IsValid)
            {
                _context.Routen.Add(route);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(route);
        }


        // View zum Finden passender Fahrten
        public IActionResult FindRides()
        {
            return View();
        }

        // Ergebnisse der passenden Fahrten anzeigen
        [HttpPost]
        public async Task<IActionResult> FindRides(double startLat, double startLon, double endLat, double endLon, DateTime requestedDeparture)
        {
            // Hier wird der CarpoolService genutzt, um passende Fahrten zu finden
            var carpoolService = new CarpoolService(_context);
            var matchingRides = await carpoolService.FindMatchingRides(startLat, startLon, endLat, endLon, requestedDeparture, 100, 60);

            return View("MatchingResults", matchingRides);
        }
    }
}

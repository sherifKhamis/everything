using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fahrgemeinschaftsplattform.Data;
using Fahrgemeinschaftsplattform.Models;
using Fahrgemeinschaftsplattform.Services;
using Route = Fahrgemeinschaftsplattform.Models.Route;

namespace Fahrgemeinschaftsplattform.Controllers
{
    // API-Controller für die Verwaltung von Fahrten und Anfragen in der Fahrgemeinschaftsplattform
    [Route("api/[controller]")]
    [ApiController]
    public class CarpoolApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context; // Datenbankkontext für den Zugriff auf die Datenbank
        private readonly CarpoolService _carpoolService; // Service zur Verarbeitung und Suche passender Fahrten

        // Konstruktor für Dependency Injection von ApplicationDbContext und CarpoolService
        public CarpoolApiController(ApplicationDbContext context, CarpoolService carpoolService)
        {
            _context = context;
            _carpoolService = carpoolService;
        }

        // 1. Endpunkt zum Erstellen einer neuen Fahrt
        [HttpPost("create-route")]
        public async Task<IActionResult> CreateRoute([FromBody] Route route)
        {
            // Überprüfung, ob die Model-Daten gültig sind
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Fehlerhafte Anfrage zurückgeben, wenn Model ungültig ist

            _context.Routen.Add(route); // Neue Route zur Datenbank hinzufügen
            await _context.SaveChangesAsync(); // Änderungen speichern

            return Ok(route); // Erfolgreiche Antwort mit der neu erstellten Route zurückgeben
        }

        // 2. Endpunkt zum Abrufen aller verfügbaren Fahrten
        [HttpGet("all-routes")]
        public async Task<IActionResult> GetAllRoutes()
        {
            // Abrufen aller Routen, einschließlich der Fahrerinformation, aus der Datenbank
            var routes = await _context.Routen.Include(r => r.FahrerName).ToListAsync();
            return Ok(routes); // Erfolgreiche Antwort mit der Liste aller Routen zurückgeben
        }

        // 3. Endpunkt für die Anfragenerstellung
        [HttpPost("create-request")]
        public async Task<IActionResult> CreateRequest([FromBody] Anfrage request)
        {
            // Überprüfung, ob die Model-Daten gültig sind
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Fehlerhafte Anfrage zurückgeben, wenn Model ungültig ist

            _context.Anfragen.Add(request); // Neue Anfrage zur Datenbank hinzufügen
            await _context.SaveChangesAsync(); // Änderungen speichern

            return Ok(request); // Erfolgreiche Antwort mit der neu erstellten Anfrage zurückgeben
        }

        // 4. Endpunkt zum Finden passender Fahrten basierend auf Standort und Abfahrtszeit
        [HttpGet("find-matching-rides")]
        public async Task<IActionResult> FindMatchingRides(double startLat, double startLon, double endLat, double endLon, DateTime requestedDeparture)
        {
            // Verwenden des CarpoolService, um passende Fahrten auf Basis der Standort- und Zeitangaben zu finden
            var matches = await _carpoolService.FindMatchingRides(startLat, startLon, endLat, endLon, requestedDeparture, 100, 60);
            return Ok(matches); // Erfolgreiche Antwort mit den gefundenen, passenden Fahrten zurückgeben
        }
    }
}

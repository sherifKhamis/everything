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
    [Route("api/[controller]")]
    [ApiController]
    public class CarpoolApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly CarpoolService _carpoolService;

        public CarpoolApiController(ApplicationDbContext context, CarpoolService carpoolService)
        {
            _context = context;
            _carpoolService = carpoolService;
        }

        // 1. Endpunkt zum Erstellen einer neuen Fahrt
        [HttpPost("create-route")]
        public async Task<IActionResult> CreateRoute([FromBody] Route route)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Routen.Add(route);
            await _context.SaveChangesAsync();

            return Ok(route);
        }

        // 2. Endpunkt zum Abrufen aller verfügbaren Fahrten
        [HttpGet("all-routes")]
        public async Task<IActionResult> GetAllRoutes()
        {
            var routes = await _context.Routen.Include(r => r.FahrerName).ToListAsync();
            return Ok(routes);
        }

        // 3. Endpunkt für die Anfragenerstellung
        [HttpPost("create-request")]
        public async Task<IActionResult> CreateRequest([FromBody] Anfrage request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Anfragen.Add(request);
            await _context.SaveChangesAsync();

            return Ok(request);
        }

        // 4. Endpunkt zum Finden passender Fahrten basierend auf Standort und Abfahrtszeit
        [HttpGet("find-matching-rides")]
        public async Task<IActionResult> FindMatchingRides(double startLat, double startLon, double endLat, double endLon, DateTime requestedDeparture)
        {
            var matches = await _carpoolService.FindMatchingRides(startLat, startLon, endLat, endLon, requestedDeparture, 100, 60);
            return Ok(matches);
        }
    }
}

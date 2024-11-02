using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Fahrgemeinschaftsplattform.Services;

namespace Fahrgemeinschaftsplattform.Controllers
{
    public class CarpoolController : Controller
    {
        private readonly CarpoolService _carpoolService;

        public CarpoolController(CarpoolService carpoolService)
        {
            _carpoolService = carpoolService;
        }

        [HttpGet]
        public async Task<IActionResult> FindRide(double startLat, double startLon, double endLat, double endLon, DateTime requestedDeparture)
        {
            var matches = await _carpoolService.FindMatchingRides(startLat, startLon, endLat, endLon, requestedDeparture, 100, 60);
            return View(matches); // Anzeige der Ergebnisse in einer View
        }
    }
}


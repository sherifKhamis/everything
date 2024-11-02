using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fahrgemeinschaftsplattform.Data; // Namespace deines DbContext
using Fahrgemeinschaftsplattform.Models;
using Route = Fahrgemeinschaftsplattform.Models.Route;

namespace Fahrgemeinschaftsplattform.Services
{
    public class CarpoolService
    {
        private readonly ApplicationDbContext _context;

        public CarpoolService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Route>> FindMatchingRides(double startLat, double startLon, double endLat, double endLon, DateTime requestedDeparture, double maxDistanceKm, int maxTimeDifferenceMinutes)
        {
            // Zeitbereich für die Abfahrtszeit berechnen
            var minDepartureTime = requestedDeparture.AddMinutes(-maxTimeDifferenceMinutes);
            var maxDepartureTime = requestedDeparture.AddMinutes(maxTimeDifferenceMinutes);

            // Abfrage mit Zeitbereich durchführen
            var query = _context.Routen
                .AsNoTracking()
                .Where(r => r.Abfahrtszeit >= minDepartureTime && r.Abfahrtszeit <= maxDepartureTime);

            // Führe die Abfrage aus und lade die Daten in den Speicher
            var routes = await query.ToListAsync();

            // Führe die Entfernungskriterien im Speicher durch
            var matchingRides = routes
                .Where(r =>
                    GetDistance(r.StartLatitude, r.StartLongitude, startLat, startLon) <= maxDistanceKm &&
                    GetDistance(r.EndLatitude, r.EndLongitude, endLat, endLon) <= maxDistanceKm)
                .ToList();

            return matchingRides;
        }

        // Berechnet die Distanz zwischen zwei Punkten in Kilometern (Haversine-Formel)
        private double GetDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371; // Radius der Erde in Kilometern
            var lat = (lat2 - lat1) * Math.PI / 180.0;
            var lon = (lon2 - lon1) * Math.PI / 180.0;

            var a = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
                    Math.Cos(lat1 * Math.PI / 180.0) * Math.Cos(lat2 * Math.PI / 180.0) *
                    Math.Sin(lon / 2) * Math.Sin(lon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }
    }
}

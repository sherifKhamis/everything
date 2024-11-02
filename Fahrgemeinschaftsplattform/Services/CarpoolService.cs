using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fahrgemeinschaftsplattform.Data; // Namespace des DbContext
using Fahrgemeinschaftsplattform.Models;
using Route = Fahrgemeinschaftsplattform.Models.Route;

namespace Fahrgemeinschaftsplattform.Services
{
    // Service-Klasse zur Verwaltung von Fahrgemeinschaften und zur Suche nach passenden Fahrten
    public class CarpoolService
    {
        private readonly ApplicationDbContext _context; // Datenbankkontext für den Zugriff auf Routen

        // Konstruktor zur Injektion des ApplicationDbContext
        public CarpoolService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Methode zur Suche nach passenden Fahrten basierend auf Standort und Abfahrtszeit
        public async Task<List<Route>> FindMatchingRides(double startLat, double startLon, double endLat, double endLon, DateTime requestedDeparture, double maxDistanceKm, int maxTimeDifferenceMinutes)
        {
            // Berechnet den Zeitbereich für die Abfahrtszeit basierend auf maxTimeDifferenceMinutes
            var minDepartureTime = requestedDeparture.AddMinutes(-maxTimeDifferenceMinutes);
            var maxDepartureTime = requestedDeparture.AddMinutes(maxTimeDifferenceMinutes);

            // Abfrage aller Routen, deren Abfahrtszeit innerhalb des berechneten Zeitbereichs liegt
            var query = _context.Routen
                .AsNoTracking() // Kein Tracking, da die Daten nicht geändert werden
                .Where(r => r.Abfahrtszeit >= minDepartureTime && r.Abfahrtszeit <= maxDepartureTime);

            // Führt die Abfrage aus und lädt die Ergebnisse in den Speicher
            var routes = await query.ToListAsync();

            // Filtert die Routen im Speicher basierend auf der Entfernung zwischen Start- und Zielpunkten
            var matchingRides = routes
                .Where(r =>
                    GetDistance(r.StartLatitude, r.StartLongitude, startLat, startLon) <= maxDistanceKm &&
                    GetDistance(r.EndLatitude, r.EndLongitude, endLat, endLon) <= maxDistanceKm)
                .ToList();

            return matchingRides; // Gibt die gefilterte Liste der passenden Fahrten zurück
        }

        // Hilfsmethode zur Berechnung der Entfernung zwischen zwei geografischen Punkten in Kilometern (Haversine-Formel)
        private double GetDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371; // Radius der Erde in Kilometern
            var lat = (lat2 - lat1) * Math.PI / 180.0; // Berechnet die Breitenänderung in Radianten
            var lon = (lon2 - lon1) * Math.PI / 180.0; // Berechnet die Längenänderung in Radianten

            // Anwendung der Haversine-Formel zur Berechnung der Entfernung
            var a = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
                    Math.Cos(lat1 * Math.PI / 180.0) * Math.Cos(lat2 * Math.PI / 180.0) *
                    Math.Sin(lon / 2) * Math.Sin(lon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c; // Rückgabe der berechneten Entfernung
        }
    }
}

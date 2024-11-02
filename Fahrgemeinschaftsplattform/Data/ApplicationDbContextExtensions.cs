using Fahrgemeinschaftsplattform.Data;
using Fahrgemeinschaftsplattform.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Route = Fahrgemeinschaftsplattform.Models.Route;

public static class ApplicationDbContextExtensions
{
    public static void Seed(this ApplicationDbContext context)
    {
        // Überprüfen, ob die Datenbank bereits gefüllt ist
        if (!context.Routen.Any())
        {
            // Beispiel für das Hinzufügen von Dummy-Routen
            context.Routen.AddRange(
                new Route
                {
                    FahrerName = "Max Mustermann",
                    StartLatitude = 50.1109,
                    StartLongitude = 8.6821,
                    EndLatitude = 48.1351,
                    EndLongitude = 11.5820,
                    Abfahrtszeit = DateTime.Now.AddHours(2),
                    VerfuegbareSitze = 3
                },
                new Route
                {
                    FahrerName = "Erika Musterfrau",
                    StartLatitude = 52.5200,
                    StartLongitude = 13.4050,
                    EndLatitude = 53.5511,
                    EndLongitude = 9.9937,
                    Abfahrtszeit = DateTime.Now.AddHours(5),
                    VerfuegbareSitze = 4
                }
            );

            // Änderungen in der Datenbank speichern
            context.SaveChanges();
        }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fahrgemeinschaftsplattform.Models
{
    // Benutzerklasse, die von IdentityUser erbt und zusätzliche Eigenschaften für die Fahrgemeinschaftsplattform enthält
    public class User : IdentityUser
    {
        public string Name { get; set; } // Name des Benutzers
    }

    // Modell für Fahrer, die Routen anbieten
    public class Fahrer
    {
        public int Id { get; set; } // Eindeutige ID des Fahrers
        public string Name { get; set; } // Name des Fahrers
        public string Kontakt { get; set; } // Kontaktinformationen des Fahrers
        public ICollection<Route> Routen { get; set; } // Ein Fahrer kann mehrere Routen anbieten
    }

    // Modell für Mitfahrer, die Anfragen für Fahrten stellen
    public class Mitfahrer
    {
        public int Id { get; set; } // Eindeutige ID des Mitfahrers
        public string Name { get; set; } // Name des Mitfahrers
        public string Kontakt { get; set; } // Kontaktinformationen des Mitfahrers
        public ICollection<Anfrage> Anfragen { get; set; } // Ein Mitfahrer kann mehrere Anfragen stellen
    }

    // Modell für eine Route (Fahrt), die ein Fahrer anbietet
    public class Route
    {
        public int Id { get; set; } // Eindeutige ID der Route
        public double StartLatitude { get; set; } // Breitengrad des Startpunkts
        public double StartLongitude { get; set; } // Längengrad des Startpunkts
        public double EndLatitude { get; set; } // Breitengrad des Endpunkts
        public double EndLongitude { get; set; } // Längengrad des Endpunkts
        public DateTime Abfahrtszeit { get; set; } // Zeitpunkt der Abfahrt
        public int VerfuegbareSitze { get; set; } // Anzahl der verfügbaren Sitzplätze

        public string FahrerName { get; set; } // Name des Fahrers für diese Route
    }

    // Modell für eine Anfrage, die ein Mitfahrer stellt, um eine Fahrt zu finden
    public class Anfrage
    {
        public int Id { get; set; } // Eindeutige ID der Anfrage
        public double StartLatitude { get; set; } // Breitengrad des Startpunkts
        public double StartLongitude { get; set; } // Längengrad des Startpunkts
        public double EndLatitude { get; set; } // Breitengrad des Endpunkts
        public double EndLongitude { get; set; } // Längengrad des Endpunkts
        public DateTime GewuenschteAbfahrtszeit { get; set; } // Gewünschter Zeitpunkt der Abfahrt

        public string MitfahrerName { get; set; } // Name des Mitfahrers für diese Anfrage
    }
}

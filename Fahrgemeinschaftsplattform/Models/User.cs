using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fahrgemeinschaftsplattform.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }

    public class Fahrer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kontakt { get; set; }
        public ICollection<Route> Routen { get; set; } // Ein Fahrer kann mehrere Routen anbieten
    }

    public class Mitfahrer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kontakt { get; set; }
        public ICollection<Anfrage> Anfragen { get; set; } // Ein Mitfahrer kann mehrere Anfragen stellen
    }

    public class Route
    {
        public int Id { get; set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double EndLatitude { get; set; }
        public double EndLongitude { get; set; }
        public DateTime Abfahrtszeit { get; set; }
        public int VerfuegbareSitze { get; set; }

        public string FahrerName { get; set; }
    }

    public class Anfrage
    {
        public int Id { get; set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double EndLatitude { get; set; }
        public double EndLongitude { get; set; }
        public DateTime GewuenschteAbfahrtszeit { get; set; }

        public string MitfahrerName { get; set; }
    }
}

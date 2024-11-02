using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Fahrgemeinschaftsplattform.Models;
using Route = Fahrgemeinschaftsplattform.Models.Route;

namespace Fahrgemeinschaftsplattform.Data
{
    // ApplicationDbContext erbt von IdentityDbContext<User> und bietet daher Identitätsverwaltung (Benutzer-Authentifizierung und -Autorisierung)
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        // Konstruktor, der die DbContextOptions an die Basisklasse weitergibt
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet für die Fahrer-Tabelle
        public DbSet<Fahrer> Fahrer { get; set; }

        // DbSet für die Mitfahrer-Tabelle
        public DbSet<Mitfahrer> Mitfahrer { get; set; }

        // DbSet für die Routen-Tabelle
        public DbSet<Route> Routen { get; set; }

        // DbSet für die Anfragen-Tabelle
        public DbSet<Anfrage> Anfragen { get; set; }

        // Methode zur weiteren Konfiguration des Modells
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Aufruf der Basismethode, um die Identitätskonfigurationen zu übernehmen
        }
    }
}

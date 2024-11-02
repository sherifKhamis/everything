using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Fahrgemeinschaftsplattform.Models;
using Route = Fahrgemeinschaftsplattform.Models.Route;

namespace Fahrgemeinschaftsplattform.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Fahrer> Fahrer { get; set; }
        public DbSet<Mitfahrer> Mitfahrer { get; set; }
        public DbSet<Route> Routen { get; set; }
        public DbSet<Anfrage> Anfragen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Fahrgemeinschaftsplattform.Models;
using System.Collections.Generic;

namespace Fahrgemeinschaftsplattform.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Carpool> Carpools { get; set; }
    }
}

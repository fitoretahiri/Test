using Food_delivery_app_LabCouse1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Food_delivery_app_LabCouse1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Restaurant> Restaurant { get; set; }

        public DbSet<Qyteti> Qyteti { get; set; }

        public DbSet<Menu> Menu { get; set; }

        public DbSet<Roli> Roli { get; set; }

        public DbSet<Perdoruesi> Perdoruesi { get; set; }

        public DbSet<Klienti> Klienti { get; set; }

        public DbSet<Restaurant_Qyteti> restaurant_Qyteti { get; set; }

        public DbSet<Transportuesi> Transportuesi { get; set; }
    }
}

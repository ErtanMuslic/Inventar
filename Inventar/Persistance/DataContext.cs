using System.Security.Cryptography.X509Certificates;
using Inventar.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventar.Persistance
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected DataContext()
        {
            //Salje Modele
           
        }

        public DbSet<Inventari> inventars { get; set; }

        public DbSet<Radnici> radnicis { get; set; }

        public DbSet<Prostorija> prostorijas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
}

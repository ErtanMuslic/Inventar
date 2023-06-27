using System.Security.Cryptography.X509Certificates;
using Inventar.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventar.Persistance
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected DataContext()
        {
           
        }

        public DbSet<Inventari> Inventars { get; set; }

        public DbSet<Radnici> Radnicis { get; set; }

        public DbSet<Prostorija> Prostorijas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
}

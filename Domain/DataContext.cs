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

        public DbSet<Inventory> Inventory { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<Room> Rooms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

          
    }
}
}

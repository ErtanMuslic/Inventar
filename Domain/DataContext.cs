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
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Worker)
                .WithOne()
                .HasForeignKey<Room>(r => r.workerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Room)
                .WithMany(r => r.Inventory)
                .HasForeignKey(i => i.RoomId)
                .IsRequired(false);

            //modelBuilder.Entity<Room>()
            //    .HasOne(r => r.Inventory)
            //    .WithOne(r => r.Room)
            //    .HasForeignKey<Inventory>(i => i.RoomId)
            //    .IsRequired(false);

            //modelBuilder.Entity<Room>()
            //    .HasOne(r => r.Inventory)
            //    .WithOne(i => i.Room)
            //    .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);

          
    }
}
}

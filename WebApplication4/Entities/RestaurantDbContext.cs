using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Entities
{
    public class RestaurantDbContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=RestaurantDb; Trusted_Connection=True;";
        public DbSet<Restaurant> Restaurants { get; set; }
        public  DbSet<Address> Address { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .HasMaxLength(50);

            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .HasMaxLength(50);
            modelBuilder.Entity<Employee>(eb =>
            {
                eb.Property(e => e.FirstName).HasColumnName("First Name");
                eb.Property(e => e.LastName).HasColumnName("Last Name");
                eb.Property(e => e.BirthDate).HasColumnType("date");
            });
            
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}

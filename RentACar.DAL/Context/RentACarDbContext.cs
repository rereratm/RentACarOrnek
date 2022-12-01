using Microsoft.EntityFrameworkCore;
using RentACar.DAL.Entities;
using System.Reflection;

namespace RentACar.DAL.Context
{
    public class RentACarDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=RentACarDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarCustomer> CarCustomers { get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Owner> Owners{ get; set; }
    }
}

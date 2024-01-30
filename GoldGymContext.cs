using GoldGymAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldGymAPI
{
    public class GoldGymContext : DbContext
    {
        public GoldGymContext(DbContextOptions<GoldGymContext> options)
            : base(options)
        {
        }

        // Define DbSets for your tables
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Service> Services { get; set; }

    }
}
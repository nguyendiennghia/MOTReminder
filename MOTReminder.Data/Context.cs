using Microsoft.EntityFrameworkCore;
using MOTReminder.Data.Model;

namespace MOTReminder.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var customerBuilder = modelBuilder.Entity<Customer>();
            customerBuilder.ToTable("Customer").HasKey(c => c.ID);
            customerBuilder.Property(c => c.ID).ValueGeneratedOnAdd();
            customerBuilder.HasIndex(c => c.Email).IsUnique();
            customerBuilder.HasMany(c => c.Vehicles).WithOne(c => c.Customer);

            var vehicleBuilder = modelBuilder.Entity<Vehicle>();
            vehicleBuilder.ToTable("Vehicle").HasKey(v => v.ID);
            vehicleBuilder.Property(v => v.ID).ValueGeneratedOnAdd();
            vehicleBuilder.HasIndex(v => v.RegNo).IsUnique();
            vehicleBuilder.HasOne(v => v.Customer).WithMany(v => v.Vehicles);
            vehicleBuilder.Property(v => v.MOTExpiry).HasColumnName("UniversalMOTExpiry");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}

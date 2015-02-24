namespace CarRental.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CarRentalDb : DbContext
    {
        public CarRentalDb()
            : base("name=MySchedulerConnectionString")
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(e => e.Price)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Car)
                .HasForeignKey(e => e.car_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarType>()
                .HasMany(e => e.Cars)
                .WithRequired(e => e.CarType)
                .WillCascadeOnDelete(false);
        }
    }
}

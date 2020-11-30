using Microsoft.EntityFrameworkCore;
using ToutBox.Challange.Core.DeliveryPrice;

namespace ToutBox.Challenge.Data
{
    public class ToutboxContext : DbContext
    {
        DbSet<DeliveryServicePriceTime> DeliveryServicePriceTimes { get; set; }
        DbSet<ServicePriceTime> ServicePriceTimes { get; set; }

        public ToutboxContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=toutbox;User Id=SA;Password=Pass@word;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DeliveryServicePriceTimeMappingConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

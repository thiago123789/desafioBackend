using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToutBox.Challange.Core.DeliveryPrice;

namespace ToutBox.Challenge.Data
{
    public class DeliveryServicePriceTimeMappingConfiguration : IEntityTypeConfiguration<DeliveryServicePriceTime>
    {
        public void Configure(EntityTypeBuilder<DeliveryServicePriceTime> builder)
        {
            builder.ToTable("DeliveryCalcEvent");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.RequestDateTime).IsRequired();

            builder.OwnsOne(e => e.SourceZipCode)
                   .Property(e => e.Value).HasField("_value")
                   .UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction)
                   .IsRequired();

            builder.OwnsOne(e => e.DestinationZipCode)
                   .Property(e => e.Value)
                   .UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction)
                   .IsRequired();

            builder.OwnsMany(e => e.ServicesPriceTimes, ac =>
            {
                ac.OwnsOne(m => m.DeliveryService, pc =>
                {
                    pc.Property(p => p.ServiceCode).IsRequired();
                    pc.Property(p => p.ServiceName).IsRequired();
                }).UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);
                ac.Property(m => m.Price).HasPrecision(16, 2).IsRequired();
                ac.Property(m => m.Time).IsRequired();
            }).UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);                
        }
    }
}

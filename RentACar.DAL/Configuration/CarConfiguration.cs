using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.DAL.Entities;

namespace RentACar.DAL.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.OwnerId).IsRequired();
            builder.Property(p => p.Brand).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Model).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Year).IsRequired();
            builder.Property(p => p.GasDieselElectric).HasMaxLength(8).IsRequired();

            builder.HasOne(p => p.OwnerFK).WithMany(p => p.Cars).HasForeignKey(p => p.OwnerId);
        }
    }
}

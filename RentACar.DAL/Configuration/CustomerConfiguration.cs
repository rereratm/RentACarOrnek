using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.DAL.Entities;

namespace RentACar.DAL.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.TcNo).HasMaxLength(11).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Surname).HasMaxLength(20).IsRequired();
        }
    }
}

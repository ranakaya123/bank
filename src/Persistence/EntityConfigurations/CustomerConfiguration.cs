using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.UseTptMappingStrategy();
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CustomerNumber)
               .HasMaxLength(32)
               .IsRequired();

        builder.Property(x => x.Name)
               .HasMaxLength(150)
               .IsRequired();

        builder.Property(x => x.Email)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(x => x.Phone)
               .HasMaxLength(32);

        builder.Property(x => x.Address)
               .HasMaxLength(500);

        builder.Property(x => x.IsActive)
               .HasDefaultValue(true);

        builder.Property(x => x.RegistrationDate)
               .IsRequired();

        // Indexes
        builder.HasIndex(x => x.CustomerNumber).IsUnique();
        builder.HasIndex(x => x.Email).IsUnique();
    }
}

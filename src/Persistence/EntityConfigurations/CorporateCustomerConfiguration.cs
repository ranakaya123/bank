using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Persistence.EntityConfigurations;

public class CorporateCustomerConfiguration : IEntityTypeConfiguration<CorporateCustomer>
{
    public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
    {
        builder.ToTable("CorporateCustomers");
        builder.UseTptMappingStrategy();

        builder.Property(x => x.CompanyName).HasMaxLength(200).IsRequired();
        builder.Property(x => x.TaxNumber).HasMaxLength(32);
        builder.Property(x => x.TradeRegistryNumber).HasMaxLength(64);
        builder.Property(x => x.ContactPerson).HasMaxLength(150);
        builder.Property(x => x.ContactPersonPhone).HasMaxLength(32);
        builder.Property(x => x.ContactPersonEmail).HasMaxLength(200);
        builder.Property(x => x.Sector).HasMaxLength(100);
        builder.Property(x => x.EstablishmentDate);

        // Indexes
        builder.HasIndex(x => x.TaxNumber).IsUnique();
        builder.HasIndex(x => x.TradeRegistryNumber).IsUnique();
    }
}

using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Persistence.EntityConfigurations;

public class IndividualCustomerConfiguration : IEntityTypeConfiguration<IndividualCustomer>
{
    public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
    {
        builder.ToTable("IndividualCustomers");
        builder.UseTptMappingStrategy();

        builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
        builder.Property(x => x.NationalId).HasMaxLength(20);
        builder.Property(x => x.Gender).HasMaxLength(20);
        builder.Property(x => x.DateOfBirth);

        // Indexes
        builder.HasIndex(x => x.NationalId).IsUnique();
    }
}

using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Persistence.EntityConfigurations;

public class CorporateCreditTypeConfiguration : IEntityTypeConfiguration<CorporateCreditType>
{
    public void Configure(EntityTypeBuilder<CorporateCreditType> builder)
    {
        builder.ToTable("CorporateCreditTypes");
        
        builder.Property(x => x.BusinessRequirements)
            .HasMaxLength(1000);
            
        builder.Property(x => x.MinCompanyAge)
            .IsRequired();
            
        builder.Property(x => x.MinAnnualRevenue)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
            
        builder.Property(x => x.RequiredLicenses)
            .HasMaxLength(500);
            
        // Indexes
        builder.HasIndex(x => x.MinCompanyAge);
        builder.HasIndex(x => x.MinAnnualRevenue);
    }
}

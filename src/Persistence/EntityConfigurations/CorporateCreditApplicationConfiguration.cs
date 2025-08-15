using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Persistence.EntityConfigurations;

public class CorporateCreditApplicationConfiguration : IEntityTypeConfiguration<CorporateCreditApplication>
{
    public void Configure(EntityTypeBuilder<CorporateCreditApplication> builder)
    {
        builder.ToTable("CorporateCreditApplications");
        
        builder.Property(x => x.CompanyName)
            .HasMaxLength(200)
            .IsRequired();
            
        builder.Property(x => x.BusinessType)
            .HasMaxLength(100)
            .IsRequired();
            
        builder.Property(x => x.CompanyAge)
            .IsRequired();
            
        builder.Property(x => x.AnnualRevenue)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
            
        builder.Property(x => x.EmployeeCount)
            .IsRequired();
            
        builder.Property(x => x.TaxNumber)
            .HasMaxLength(50)
            .IsRequired();
            
        builder.Property(x => x.TradeRegistryNumber)
            .HasMaxLength(50)
            .IsRequired();
            
        // Indexes
        builder.HasIndex(x => x.CompanyName);
        builder.HasIndex(x => x.BusinessType);
        builder.HasIndex(x => x.TaxNumber).IsUnique();
        builder.HasIndex(x => x.TradeRegistryNumber).IsUnique();
    }
}

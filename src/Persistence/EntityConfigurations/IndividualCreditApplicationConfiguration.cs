using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Persistence.EntityConfigurations;

public class IndividualCreditApplicationConfiguration : IEntityTypeConfiguration<IndividualCreditApplication>
{
    public void Configure(EntityTypeBuilder<IndividualCreditApplication> builder)
    {
        builder.ToTable("IndividualCreditApplications");
        
        builder.Property(x => x.EmploymentType)
            .HasMaxLength(50)
            .IsRequired();
            
        builder.Property(x => x.EmployerName)
            .HasMaxLength(200);
            
        builder.Property(x => x.EmploymentDuration)
            .IsRequired();
            
        builder.Property(x => x.CollateralType)
            .HasMaxLength(100);
            
        builder.Property(x => x.CollateralValue)
            .HasColumnType("decimal(18,2)");
            
        // Indexes
        builder.HasIndex(x => x.EmploymentType);
        builder.HasIndex(x => x.EmploymentDuration);
    }
}

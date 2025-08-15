using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Persistence.EntityConfigurations;

public class IndividualCreditTypeConfiguration : IEntityTypeConfiguration<IndividualCreditType>
{
    public void Configure(EntityTypeBuilder<IndividualCreditType> builder)
    {
        builder.ToTable("IndividualCreditTypes");
        
        builder.Property(x => x.RequiredDocuments)
            .HasMaxLength(1000);
            
        builder.Property(x => x.MaxMonthlyIncome)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
            
        builder.Property(x => x.MinAge)
            .IsRequired();
            
        builder.Property(x => x.MaxAge)
            .IsRequired();
            
        // Indexes
        builder.HasIndex(x => x.MinAge);
        builder.HasIndex(x => x.MaxAge);
    }
}

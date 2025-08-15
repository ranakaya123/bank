using Bank.Domain.Entities;
using Bank.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Persistence.EntityConfigurations;

public class CreditCalculationRuleConfiguration : IEntityTypeConfiguration<CreditCalculationRule>
{
    public void Configure(EntityTypeBuilder<CreditCalculationRule> builder)
    {
        builder.ToTable("CreditCalculationRules");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.RuleName)
            .IsRequired()
            .HasMaxLength(100);
            
        builder.Property(x => x.RuleDescription)
            .HasMaxLength(500);
            
        builder.Property(x => x.Type)
            .IsRequired();
            
        builder.Property(x => x.Formula)
            .IsRequired()
            .HasMaxLength(2000);
            
        builder.Property(x => x.MinValue)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
            
        builder.Property(x => x.MaxValue)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
            
        builder.Property(x => x.Priority)
            .IsRequired();
            
        builder.Property(x => x.IsActive)
            .IsRequired();
            
        // Relationships
        builder.HasOne(x => x.CreditType)
            .WithMany(x => x.CreditCalculationRules)
            .HasForeignKey(x => x.CreditTypeId)
            .OnDelete(DeleteBehavior.Restrict);
            
        // Indexes
        builder.HasIndex(x => x.CreditTypeId);
        builder.HasIndex(x => x.Type);
        builder.HasIndex(x => x.Priority);
        builder.HasIndex(x => x.IsActive);
    }
}

using Bank.Domain.Entities;
using Bank.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Persistence.EntityConfigurations;

public class CreditApprovalHistoryConfiguration : IEntityTypeConfiguration<CreditApprovalHistory>
{
    public void Configure(EntityTypeBuilder<CreditApprovalHistory> builder)
    {
        builder.ToTable("CreditApprovalHistories");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Status)
            .IsRequired();
            
        builder.Property(x => x.Notes)
            .HasMaxLength(1000);
            
        builder.Property(x => x.ProcessDate)
            .IsRequired();
            
        // Relationships
        builder.HasOne(x => x.CreditApplication)
            .WithMany(x => x.CreditApprovalHistories)
            .HasForeignKey(x => x.CreditApplicationId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasOne(x => x.CreditApprovalStep)
            .WithMany(x => x.CreditApprovalHistories)
            .HasForeignKey(x => x.CreditApprovalStepId)
            .OnDelete(DeleteBehavior.Restrict);
            
        // Indexes
        builder.HasIndex(x => x.CreditApplicationId);
        builder.HasIndex(x => x.CreditApprovalStepId);
        builder.HasIndex(x => x.Status);
        builder.HasIndex(x => x.ProcessDate);
    }
}

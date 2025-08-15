using Bank.Domain.Entities;
using Bank.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Persistence.EntityConfigurations;

public class CreditApprovalStepConfiguration : IEntityTypeConfiguration<CreditApprovalStep>
{
    public void Configure(EntityTypeBuilder<CreditApprovalStep> builder)
    {
        builder.ToTable("CreditApprovalSteps");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.StepName)
            .IsRequired()
            .HasMaxLength(100);
            
        builder.Property(x => x.StepDescription)
            .HasMaxLength(500);
            
        builder.Property(x => x.Type)
            .IsRequired();
            
        builder.Property(x => x.Order)
            .IsRequired();
            
        builder.Property(x => x.IsRequired)
            .IsRequired();
            
        builder.Property(x => x.IsActive)
            .IsRequired();
            
        // Relationships
        builder.HasOne(x => x.CreditType)
            .WithMany(x => x.CreditApprovalSteps)
            .HasForeignKey(x => x.CreditTypeId)
            .OnDelete(DeleteBehavior.Restrict);
            
        // Indexes
        builder.HasIndex(x => x.CreditTypeId);
        builder.HasIndex(x => x.Type);
        builder.HasIndex(x => x.Order);
        builder.HasIndex(x => x.IsActive);
    }
}

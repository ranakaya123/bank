using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Persistence.EntityConfigurations;

public class CreditApplicationConfiguration : IEntityTypeConfiguration<CreditApplication>
{
    public void Configure(EntityTypeBuilder<CreditApplication> builder)
    {
        builder.ToTable("CreditApplications");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.RequestedAmount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
            
        builder.Property(x => x.RequestedTerm)
            .IsRequired();
            
        builder.Property(x => x.MonthlyIncome)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
            
        builder.Property(x => x.Purpose)
            .HasMaxLength(500)
            .IsRequired();
            
        builder.Property(x => x.Status)
            .IsRequired();
            
        builder.Property(x => x.ApplicationDate)
            .IsRequired();
            
        builder.Property(x => x.RejectionReason)
            .HasMaxLength(1000);
            
        // Kredi hesaplama sonuçları
        builder.Property(x => x.ApprovedAmount)
            .HasColumnType("decimal(18,2)");
            
        builder.Property(x => x.MonthlyPayment)
            .HasColumnType("decimal(18,2)");
            
        builder.Property(x => x.TotalPayment)
            .HasColumnType("decimal(18,2)");
            
        builder.Property(x => x.InterestAmount)
            .HasColumnType("decimal(18,2)");
            
        // Relationships
        builder.HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasOne(x => x.CreditType)
            .WithMany(x => x.CreditApplications)
            .HasForeignKey(x => x.CreditTypeId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasOne(x => x.SubCreditType)
            .WithMany(x => x.CreditApplications)
            .HasForeignKey(x => x.SubCreditTypeId)
            .OnDelete(DeleteBehavior.Restrict);
            
        // TPT Inheritance Strategy
        builder.UseTptMappingStrategy();
        
        // Indexes
        builder.HasIndex(x => x.CustomerId);
        builder.HasIndex(x => x.CreditTypeId);
        builder.HasIndex(x => x.Status);
        builder.HasIndex(x => x.ApplicationDate);
    }
}

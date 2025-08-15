using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Persistence.EntityConfigurations;

public class SubCreditTypeConfiguration : IEntityTypeConfiguration<SubCreditType>
{
    public void Configure(EntityTypeBuilder<SubCreditType> builder)
    {
        builder.ToTable("SubCreditTypes");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
            
        builder.Property(x => x.Description)
            .HasMaxLength(500);
            
        builder.Property(x => x.SpecificInterestRate)
            .HasColumnType("decimal(5,2)")
            .IsRequired();
            
        builder.Property(x => x.SpecialConditions)
            .HasMaxLength(1000);
            
        builder.Property(x => x.IsActive)
            .IsRequired();
            
        // Relationships
        builder.HasOne(x => x.CreditType)
            .WithMany(x => x.SubCreditTypes)
            .HasForeignKey(x => x.CreditTypeId)
            .OnDelete(DeleteBehavior.Restrict);
            
        // Indexes
        builder.HasIndex(x => x.CreditTypeId);
        builder.HasIndex(x => x.IsActive);
        builder.HasIndex(x => x.Name);
    }
}

using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Persistence.EntityConfigurations;

public class CreditTypeConfiguration : IEntityTypeConfiguration<CreditType>
{
    public void Configure(EntityTypeBuilder<CreditType> builder)
    {
        builder.ToTable("CreditTypes");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
            
        builder.Property(x => x.Description)
            .HasMaxLength(500);
            
        builder.Property(x => x.MinAmount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
            
        builder.Property(x => x.MaxAmount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
            
        builder.Property(x => x.MinTerm)
            .IsRequired();
            
        builder.Property(x => x.MaxTerm)
            .IsRequired();
            
        builder.Property(x => x.InterestRate)
            .HasColumnType("decimal(5,2)")
            .IsRequired();
            
        builder.Property(x => x.Category)
            .IsRequired();
            
        builder.Property(x => x.IsActive)
            .IsRequired();
            
        // TPT Inheritance Strategy
        builder.UseTptMappingStrategy();
        
        // Indexes
        builder.HasIndex(x => x.Category);
        builder.HasIndex(x => x.IsActive);
        builder.HasIndex(x => x.Name).IsUnique();
    }
}

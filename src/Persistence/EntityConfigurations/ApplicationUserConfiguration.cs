using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Persistence.EntityConfigurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("ApplicationUsers");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserId)
               .IsRequired();

        builder.Property(x => x.CustomerId)
               .IsRequired();

        builder.Property(x => x.CustomerType)
               .HasMaxLength(20)
               .IsRequired();

        // Indexes
        builder.HasIndex(x => x.UserId).IsUnique();
        builder.HasIndex(x => x.CustomerId).IsUnique();

        // Relationships - Use NO ACTION to prevent cascade issues
        builder.HasOne(x => x.User)
               .WithOne()
               .HasForeignKey<ApplicationUser>(x => x.UserId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Customer)
               .WithOne()
               .HasForeignKey<ApplicationUser>(x => x.CustomerId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}

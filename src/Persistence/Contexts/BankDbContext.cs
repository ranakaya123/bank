using Bank.Domain.Entities;
using Bank.Core.Security.Entity;
using Microsoft.EntityFrameworkCore;

namespace Bank.Persistence.Contexts;

public class BankDbContext : DbContext
{
    public BankDbContext(DbContextOptions<BankDbContext> options) : base(options)
    {
    }

    // Security Entities
    public DbSet<User> Users => Set<User>();
    public DbSet<Operation> Operations => Set<Operation>();
    public DbSet<UserOperationClaim> UserOperationClaims => Set<UserOperationClaim>();

    // Application Users
    public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<IndividualCustomer> IndividualCustomers => Set<IndividualCustomer>();
    public DbSet<CorporateCustomer> CorporateCustomers => Set<CorporateCustomer>();
    
    // Credit System
    public DbSet<CreditType> CreditTypes => Set<CreditType>();
    public DbSet<IndividualCreditType> IndividualCreditTypes => Set<IndividualCreditType>();
    public DbSet<CorporateCreditType> CorporateCreditTypes => Set<CorporateCreditType>();
    public DbSet<SubCreditType> SubCreditTypes => Set<SubCreditType>();
    public DbSet<CreditApplication> CreditApplications => Set<CreditApplication>();
    public DbSet<IndividualCreditApplication> IndividualCreditApplications => Set<IndividualCreditApplication>();
    public DbSet<CorporateCreditApplication> CorporateCreditApplications => Set<CorporateCreditApplication>();
    public DbSet<CreditCalculationRule> CreditCalculationRules => Set<CreditCalculationRule>();
    public DbSet<CreditApprovalStep> CreditApprovalSteps => Set<CreditApprovalStep>();
    public DbSet<CreditApprovalHistory> CreditApprovalHistories => Set<CreditApprovalHistory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}

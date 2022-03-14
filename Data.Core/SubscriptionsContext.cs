using Domain.Developers.Entities;
using Domain.Payments.Entities;
using Domain.Subscriptions.Entities;
using Domain.Subscriptions.Entities.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Core;

public class SubscriptionsContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public DbSet<CompanySubscription> CompanySubscriptions { get; set; }
    public DbSet<ProjectSubscription> ProjectSubscriptions { get; set; }
    public DbSet<UserSubscription> UserSubscriptions { get; set; }
    public DbSet<SubscriptionLevel> SubscriptionLevels { get; set; }
    public DbSet<Tariff> Tariffs { get; set; }

    public SubscriptionsContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration["devpoint_core_db"]);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompanySubscription>()
            .HasOne(companySubscription => (Company) companySubscription.Company);
        modelBuilder.Entity<CompanySubscription>()
            .HasOne(companySubscription => (User) companySubscription.Subscriber);
        
        modelBuilder.Entity<ProjectSubscription>()
            .HasOne(projectSubscription => (Project) projectSubscription.Project);
        modelBuilder.Entity<ProjectSubscription>()
            .HasOne(projectSubscription => (User) projectSubscription.Subscriber);
        
        modelBuilder.Entity<UserSubscription>()
            .HasOne(userSubscription => (User) userSubscription.User);
        modelBuilder.Entity<UserSubscription>()
            .HasOne(userSubscription => (User) userSubscription.Subscriber);
        
        
    }
}
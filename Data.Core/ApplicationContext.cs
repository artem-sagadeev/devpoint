using Domain.Content.Entities;
using Domain.Developers.Entities;
using Domain.Payments.Entities;
using Domain.Subscriptions.Entities;
using Domain.Subscriptions.Entities.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Core;

public class ApplicationContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public DbSet<CompanySubscription> CompanySubscriptions { get; set; }
    public DbSet<ProjectSubscription> ProjectSubscriptions { get; set; }
    public DbSet<UserSubscription> UserSubscriptions { get; set; }
    public DbSet<SubscriptionLevel> SubscriptionLevels { get; set; }
    public DbSet<Tariff> Tariffs { get; set; }
    
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
    public DbSet<Bill> Bills { get; set; }
    public DbSet<Replenishment> Replenishments { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Withdrawal> Withdrawals { get; set; }

    public ApplicationContext(DbContextOptions options, IConfiguration configuration) : base(options)
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
        
        modelBuilder.Entity<Comment>()
            .HasOne(comment => (User) comment.User);
        
        modelBuilder.Entity<Post>()
            .HasOne(post => (Project) post.Project);
        modelBuilder.Entity<Post>()
            .HasOne(post => (SubscriptionLevel) post.RequiredSubscriptionLevel);
        modelBuilder.Entity<Post>()
            .HasOne(post => (User) post.User);
        
        modelBuilder.Entity<Bill>()
            .HasOne(comment => (Subscription) comment.Subscription);
        
        modelBuilder.Entity<Wallet>()
            .HasOne(wallet => (User) wallet.User);
        
        modelBuilder.Entity<Subscription>()
            .HasOne(subscription => (User) subscription.Subscriber);
    }
}
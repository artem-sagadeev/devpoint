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
    
    public DbSet<Developer> Developers { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public DbSet<CompanySubscription> CompanySubscriptions { get; set; }
    public DbSet<ProjectSubscription> ProjectSubscriptions { get; set; }
    public DbSet<DeveloperSubscription> DeveloperSubscriptions { get; set; }
    public DbSet<SubscriptionLevel> SubscriptionLevels { get; set; }
    public DbSet<Tariff> Tariffs { get; set; }
    
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
    public DbSet<Bill> Bills { get; set; }
    public DbSet<Replenishment> Replenishments { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Withdrawal> Withdrawals { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration["devpoint_core_db"]);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>()
            .HasOne(company => company.Owner)
            .WithMany(owner => owner.OwnedCompanies);
        modelBuilder.Entity<Company>()
            .HasMany(company => company.Developers)
            .WithMany(developer => developer.Companies);
        
        modelBuilder.Entity<Project>()
            .HasOne(project => project.Owner)
            .WithMany(owner => owner.OwnedProjects);
        modelBuilder.Entity<Project>()
            .HasMany(project => project.Developers)
            .WithMany(developer => developer.Projects);
    }
}
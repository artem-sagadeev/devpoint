using Domain.Content.Entities;
using Domain.Developers.Entities;
using Domain.Payments.Entities;
using Domain.Subscriptions.Entities.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Core;

public class PaymentsContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public DbSet<Bill> Bills { get; set; }
    public DbSet<Replenishment> Replenishments { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Withdrawal> Withdrawals { get; set; }

    public PaymentsContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration["devpoint_core_db"]);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>()
            .HasOne(comment => (Subscription) comment.Subscription);
        
        modelBuilder.Entity<Wallet>()
            .HasOne(wallet => (User) wallet.User);
        
        modelBuilder.Entity<Subscription>()
            .HasOne(subscription => (User) subscription.Subscriber);
    }
}
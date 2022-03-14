using Domain.Content.Entities;
using Domain.Developers.Entities;
using Domain.Subscriptions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Core;

public class ContentContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public ContentContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration["devpoint_core_db"]);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>()
            .HasOne(comment => (User) comment.User);
        
        modelBuilder.Entity<Post>()
            .HasOne(post => (Project) post.Project);
        modelBuilder.Entity<Post>()
            .HasOne(post => (SubscriptionLevel) post.RequiredSubscriptionLevel);
        modelBuilder.Entity<Post>()
            .HasOne(post => (User) post.User);
    }
}
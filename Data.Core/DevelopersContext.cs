using Domain.Developers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Core;

public class DevelopersContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public DevelopersContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration["devpoint_core_db"]);
    }
}
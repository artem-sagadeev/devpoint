using Domain.Subscriptions.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Core;

public static class Seed
{
    private static readonly List<SubscriptionLevel> SubscriptionLevels = new()
    {
        new SubscriptionLevel(1, "Free"),
        new SubscriptionLevel(2, "Basic"),
        new SubscriptionLevel(3, "Improved"),
        new SubscriptionLevel(4, "Pro"),
    };
    
    private static readonly List<Tariff> Tariffs = new()
    {
        new Tariff(1, 100, SubscriptionType.Project, SubscriptionLevels[0].Id),
        new Tariff(2, 100, SubscriptionType.Project, SubscriptionLevels[1].Id),
        new Tariff(3, 100, SubscriptionType.Project, SubscriptionLevels[2].Id),
        new Tariff(4, 100, SubscriptionType.Project, SubscriptionLevels[3].Id),
        
        new Tariff(5, 100, SubscriptionType.User, SubscriptionLevels[0].Id),
        new Tariff(6, 100, SubscriptionType.User, SubscriptionLevels[1].Id),
        new Tariff(7, 100, SubscriptionType.User, SubscriptionLevels[2].Id),
        new Tariff(8, 100, SubscriptionType.User, SubscriptionLevels[3].Id),
        
        new Tariff(9, 100, SubscriptionType.Company, SubscriptionLevels[0].Id),
        new Tariff(10, 100, SubscriptionType.Company, SubscriptionLevels[1].Id),
        new Tariff(11, 100, SubscriptionType.Company, SubscriptionLevels[2].Id),
        new Tariff(12, 100, SubscriptionType.Company, SubscriptionLevels[3].Id),
    };

    public static void AddSubscriptionLevels(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SubscriptionLevel>().HasData(SubscriptionLevels);
    }
    
    public static void AddTariffs(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tariff>().HasData(Tariffs);
    }
}
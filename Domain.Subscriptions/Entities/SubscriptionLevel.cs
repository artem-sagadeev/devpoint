using Domain.Subscriptions.Interfaces;

namespace Domain.Subscriptions.Entities;

public class SubscriptionLevel : ISubscriptionLevel
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public SubscriptionLevel(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
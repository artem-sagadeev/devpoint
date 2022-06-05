namespace Domain.Subscriptions.Entities;

public class SubscriptionLevel
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public SubscriptionLevel(string name)
    {
        Name = name;
    }
}
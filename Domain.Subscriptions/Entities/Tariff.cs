namespace Domain.Subscriptions.Entities;

public enum SubscriptionType
{
    User,
    Project, 
    Company
}

public class Tariff
{
    public int Id { get; set; }
    public int PricePerMonth { get; set; }
    public SubscriptionType SubscriptionType { get; set; }
    public int SubscriptionLevelId { get; set; }
    public SubscriptionLevel SubscriptionLevel { get; set; }

    public Tariff(int id, int pricePerMonth, SubscriptionType subscriptionType, int subscriptionLevelId)
    {
        Id = id;
        PricePerMonth = pricePerMonth;
        SubscriptionType = subscriptionType;
        SubscriptionLevelId = subscriptionLevelId;
    }
    
    public Tariff(int pricePerMonth, SubscriptionType subscriptionType, SubscriptionLevel subscriptionLevel)
    {
        PricePerMonth = pricePerMonth;
        SubscriptionType = subscriptionType;
        SubscriptionLevel = subscriptionLevel;
    }
    
    private Tariff() {}
}
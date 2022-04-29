using Domain.Developers.Entities;

namespace Domain.Subscriptions.Entities.Subscriptions;

public class DeveloperSubscription : Subscription
{
    public Developer Developer { get; set; }

    public DeveloperSubscription(DateTime endTime, bool isAutoRenewal, Tariff tariff, Developer subscriber, Developer developer)
        : base(endTime, isAutoRenewal, tariff, subscriber)
    {
        Developer = developer;
    }
    
    private DeveloperSubscription() {}
}
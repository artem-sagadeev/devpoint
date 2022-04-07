using Domain.Developers.Entities;
using Domain.Developers.Interfaces;
using Domain.Subscriptions.Interfaces;

namespace Domain.Subscriptions.Entities.Subscriptions;

public class DeveloperSubscription : Subscription
{
    public IDeveloper Developer { get; set; }

    public DeveloperSubscription(DateTime endTime, bool isAutoRenewal, Tariff tariff, IDeveloper subscriber, IDeveloper developer)
        : base(endTime, isAutoRenewal, tariff, subscriber)
    {
        Developer = developer;
    }
    
    private DeveloperSubscription() {}
}
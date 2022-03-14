using Domain.Developers.Entities;
using Domain.Developers.Interfaces;
using Domain.Subscriptions.Interfaces;

namespace Domain.Subscriptions.Entities.Subscriptions;

public class UserSubscription : Subscription
{
    public IUser User { get; set; }

    public UserSubscription(DateTime endTime, bool isAutoRenewal, Tariff tariff, IUser subscriber, IUser user)
        : base(endTime, isAutoRenewal, tariff, subscriber)
    {
        User = user;
    }
    
    private UserSubscription() {}
}
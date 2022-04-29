using Domain.Subscriptions.Entities;

namespace Services.Subscriptions.SubscriptionLevels;

public interface ISubscriptionLevelService
{
    public Task<SubscriptionLevel> GetSubscriptionLevel(int subscriptionLevelId);
}
using Domain.Subscriptions.Entities.Subscriptions;

namespace Web.API.Controllers.Subscriptions.DTOs;

public class SubscriptionDto
{
    public int Id { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsAutoRenewal { get; set; }

    public SubscriptionDto(Subscription subscription)
    {
        Id = subscription.Id;
        EndTime = subscription.EndTime;
        IsAutoRenewal = subscription.IsAutoRenewal;
    }
}
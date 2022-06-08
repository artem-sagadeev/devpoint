using Domain.Developers.Entities;

namespace Domain.Subscriptions.Entities.Subscriptions;

public class Subscription
{
    public int Id { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsAutoRenewal { get; set; }
    public Tariff Tariff { get; set; }
    public Developer Subscriber { get; set; }
    public Guid SubscriberId { get; set; }

    protected Subscription(DateTime endTime, bool isAutoRenewal, Tariff tariff, Developer subscriber)
    {
        EndTime = endTime;
        IsAutoRenewal = isAutoRenewal;
        Tariff = tariff;
        Subscriber = subscriber;
    }
    
    protected Subscription() {}
}
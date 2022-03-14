using Domain.Developers.Interfaces;
using Domain.Subscriptions.Interfaces;

namespace Domain.Subscriptions.Entities.Subscriptions;

public class Subscription : ISubscription
{
    public int Id { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsAutoRenewal { get; set; }
    public Tariff Tariff { get; set; }
    public IUser Subscriber { get; set; }

    protected Subscription(DateTime endTime, bool isAutoRenewal, Tariff tariff, IUser subscriber)
    {
        EndTime = endTime;
        IsAutoRenewal = isAutoRenewal;
        Tariff = tariff;
        Subscriber = subscriber;
    }
    
    protected Subscription() {}
}
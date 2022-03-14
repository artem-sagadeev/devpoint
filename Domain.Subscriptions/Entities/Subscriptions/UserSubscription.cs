using Domain.Developers.Entities;
using Domain.Developers.Interfaces;
using Domain.Subscriptions.Interfaces;

namespace Domain.Subscriptions.Entities.Subscriptions;

public class UserSubscription : ISubscription
{
    public int Id { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsAutoRenewal { get; set; }
    public Tariff Tariff { get; set; }
    public IUser Subscriber { get; set; }
    public IUser User { get; set; }

    public UserSubscription(DateTime endTime, bool isAutoRenewal, Tariff tariff, IUser subscriber, IUser user)
    {
        EndTime = endTime;
        IsAutoRenewal = isAutoRenewal;
        Tariff = tariff;
        Subscriber = subscriber;
        User = user;
    }
}
using Domain.Developers.Entities;
using Domain.Developers.Interfaces;
using Domain.Subscriptions.Entities;

namespace Domain.Subscriptions.Interfaces;

public interface ISubscription
{
    public int Id { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsAutoRenewal { get; set; }
    public Tariff Tariff { get; set; }
    public IUser Subscriber { get; set; }
}
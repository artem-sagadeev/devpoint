using Domain.Developers.Entities;
using Domain.Developers.Interfaces;
using Domain.Subscriptions.Interfaces;

namespace Domain.Subscriptions.Entities.Subscriptions;

public class CompanySubscription : ISubscription
{
    public int Id { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsAutoRenewal { get; set; }
    public Tariff Tariff { get; set; }
    public IUser Subscriber { get; set; }
    public ICompany Company { get; set; }

    public CompanySubscription(DateTime endTime, bool isAutoRenewal, Tariff tariff, IUser subscriber, ICompany company)
    {
        EndTime = endTime;
        IsAutoRenewal = isAutoRenewal;
        Tariff = tariff;
        Subscriber = subscriber;
        Company = company;
    }
}
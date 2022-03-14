using Domain.Developers.Entities;
using Domain.Developers.Interfaces;
using Domain.Subscriptions.Interfaces;

namespace Domain.Subscriptions.Entities.Subscriptions;

public class CompanySubscription : Subscription
{
    public ICompany Company { get; set; }

    public CompanySubscription(DateTime endTime, bool isAutoRenewal, Tariff tariff, IUser subscriber, ICompany company)
        : base(endTime, isAutoRenewal, tariff, subscriber)
    {
        Company = company;
    }
    
    private CompanySubscription() {}
}
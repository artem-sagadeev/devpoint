using Domain.Developers.Entities;

namespace Domain.Subscriptions.Entities.Subscriptions;

public class CompanySubscription : Subscription
{
    public Company Company { get; set; }

    public CompanySubscription(DateTime endTime, bool isAutoRenewal, Tariff tariff, Developer subscriber, Company company)
        : base(endTime, isAutoRenewal, tariff, subscriber)
    {
        Company = company;
    }
    
    private CompanySubscription() {}
}
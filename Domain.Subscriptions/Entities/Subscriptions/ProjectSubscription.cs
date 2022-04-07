using Domain.Developers.Entities;
using Domain.Developers.Interfaces;
using Domain.Subscriptions.Interfaces;

namespace Domain.Subscriptions.Entities.Subscriptions;

public class ProjectSubscription : Subscription
{
    public IProject Project { get; set; }

    public ProjectSubscription(DateTime endTime, bool isAutoRenewal, Tariff tariff, IDeveloper subscriber, IProject project)
        : base(endTime, isAutoRenewal, tariff, subscriber)
    {
        Project = project;
    }
    
    private ProjectSubscription() {}
}
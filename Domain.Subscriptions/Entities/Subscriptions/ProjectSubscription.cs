using Domain.Developers.Entities;

namespace Domain.Subscriptions.Entities.Subscriptions;

public class ProjectSubscription : Subscription
{
    public Project Project { get; set; }

    public ProjectSubscription(DateTime endTime, bool isAutoRenewal, Tariff tariff, Developer subscriber, Project project)
        : base(endTime, isAutoRenewal, tariff, subscriber)
    {
        Project = project;
    }
    
    private ProjectSubscription() {}
}
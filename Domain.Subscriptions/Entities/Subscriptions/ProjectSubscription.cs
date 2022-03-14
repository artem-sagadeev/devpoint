using Domain.Developers.Entities;
using Domain.Developers.Interfaces;
using Domain.Subscriptions.Interfaces;

namespace Domain.Subscriptions.Entities.Subscriptions;

public class ProjectSubscription : ISubscription
{
    public int Id { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsAutoRenewal { get; set; }
    public Tariff Tariff { get; set; }
    public IUser Subscriber { get; set; }
    public IProject Project { get; set; }

    public ProjectSubscription(DateTime endTime, bool isAutoRenewal, Tariff tariff, IUser subscriber, IProject project)
    {
        EndTime = endTime;
        IsAutoRenewal = isAutoRenewal;
        Tariff = tariff;
        Subscriber = subscriber;
        Project = project;
    }
}
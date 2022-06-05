using Domain.Developers.Entities;
using Domain.Subscriptions.Entities;
using Domain.Subscriptions.Entities.Subscriptions;

namespace Services.Subscriptions.Subscriptions;

public interface ISubscriptionService
{
    public Task<List<Subscription>> GetAllSubscriptions();

    public Task<List<Subscription>> GetSubscriptions(List<int> subscriptionIds);

    public Task<Subscription> GetSubscription(int subscriptionId);

    public Task<ProjectSubscription> GetProjectSubscription(int projectSubscriptionId);

    public Task<DeveloperSubscription> GetDeveloperSubscription(int developerSubscriptionId);

    public Task<CompanySubscription> GetCompanySubscription(int companySubscriptionId);

    public Task<Tariff> GetSubscriptionTariff(int subscriptionId);

    public Task<Developer> GetSubscriptionSubscriber(int subscriptionId);

    public Task<int> CreateProjectSubscription(DateTime endTime, bool isAutoRenewal, int tariffId, Guid subscriberId,
        Guid projectId);

    public Task<int> CreateDeveloperSubscription(DateTime endTime, bool isAutoRenewal, int tariffId, Guid subscriberId,
        Guid developerId);
    
    public Task<int> CreateCompanySubscription(DateTime endTime, bool isAutoRenewal, int tariffId, Guid subscriberId,
        Guid companyId); 
}
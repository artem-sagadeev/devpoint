using Domain.Content.Entities;
using Domain.Developers.Entities;
using Domain.Subscriptions.Entities;
using Domain.Subscriptions.Entities.Subscriptions;

namespace Services.Subscriptions.Subscriptions;

public interface ISubscriptionService
{
    public Task<List<Subscription>> GetAllSubscriptions();

    public Task<List<Subscription>> GetSubscriptions(List<int> subscriptionIds);

    public Task<Subscription> GetSubscription(int subscriptionId);

    public IQueryable<ProjectSubscription> GetProjectSubscriptions(Guid projectId);

    public IQueryable<DeveloperSubscription> GetDeveloperSubscriptions(Guid developerId);

    public IQueryable<CompanySubscription> GetCompanySubscriptions(Guid companyId);

    public Task<Tariff> GetSubscriptionTariff(int subscriptionId);

    public Task<Developer> GetSubscriptionSubscriber(int subscriptionId);

    public Task<int> UserCompanySubscriptionLevel(Guid? userDevId, Guid companyId);
    public Task<int> UserDeveloperSubscriptionLevel(Guid? userDevId, Guid developerId);
    public Task<int> UserProjectSubscriptionLevel(Guid? userDevId, Guid projectId);
    public bool HasSufficientSubscriptionLevel(Post post, Guid? userDevId, int userSubLevel);
    
    public Task<int> UserSubscriptionLevel(Guid userId, Guid entityId, EntityType type);

    public Task<int> CreateProjectSubscription(DateTime endTime, bool isAutoRenewal, int tariffId, Guid subscriberId,
        Guid projectId);

    public Task<int> CreateDeveloperSubscription(DateTime endTime, bool isAutoRenewal, int tariffId, Guid subscriberId,
        Guid developerId);
    
    public Task<int> CreateCompanySubscription(DateTime endTime, bool isAutoRenewal, int tariffId, Guid subscriberId,
        Guid companyId); 
}
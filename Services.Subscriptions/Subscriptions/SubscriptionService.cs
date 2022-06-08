using Data.Core;
using Domain.Content.Entities;
using Domain.Developers.Entities;
using Domain.Subscriptions.Entities;
using Domain.Subscriptions.Entities.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Services.Developers.Companies;
using Services.Developers.Developers;
using Services.Developers.Projects;
using Services.Subscriptions.Tariffs;

namespace Services.Subscriptions.Subscriptions;

public class SubscriptionService : ISubscriptionService
{
    private readonly ApplicationContext _context;
    private readonly ITariffService _tariffService;
    private readonly IDeveloperService _developerService;
    private readonly IProjectService _projectService;
    private readonly ICompanyService _companyService;

    public SubscriptionService(ApplicationContext context, ITariffService tariffService, IDeveloperService developerService, IProjectService projectService, ICompanyService companyService)
    {
        _context = context;
        _tariffService = tariffService;
        _developerService = developerService;
        _projectService = projectService;
        _companyService = companyService;
    }

    public async Task<List<Subscription>> GetAllSubscriptions()
    {
        var companySubscriptions = await _context.CompanySubscriptions.ToListAsync();
        var projectSubscriptions = await _context.ProjectSubscriptions.ToListAsync();
        var developerSubscriptions = await _context.DeveloperSubscriptions.ToListAsync();

        var allSubscriptions = new List<Subscription>();
        allSubscriptions.AddRange(companySubscriptions);
        allSubscriptions.AddRange(projectSubscriptions);
        allSubscriptions.AddRange(developerSubscriptions);

        return allSubscriptions;
    }

    public async Task<List<Subscription>> GetSubscriptions(List<int> subscriptionIds)
    {
        var companySubscriptions = await _context
            .CompanySubscriptions
            .Where(s => subscriptionIds.Contains(s.Id))
            .ToListAsync();
        var projectSubscriptions = await _context
            .ProjectSubscriptions
            .Where(s => subscriptionIds.Contains(s.Id))
            .ToListAsync();
        var developerSubscriptions = await _context
            .DeveloperSubscriptions
            .Where(s => subscriptionIds.Contains(s.Id))
            .ToListAsync();
        
        var allSubscriptions = new List<Subscription>();
        allSubscriptions.AddRange(companySubscriptions);
        allSubscriptions.AddRange(projectSubscriptions);
        allSubscriptions.AddRange(developerSubscriptions);
        
        return allSubscriptions;
    }

    public async Task<Subscription> GetSubscription(int subscriptionId)
    {
        var companySubscription = (Subscription) await _context.CompanySubscriptions.FindAsync(subscriptionId);
        var projectSubscription = (Subscription) await _context.ProjectSubscriptions.FindAsync(subscriptionId);
        var developerSubscription = (Subscription) await _context.DeveloperSubscriptions.FindAsync(subscriptionId);
        var subscription = companySubscription ?? projectSubscription ?? developerSubscription;
        
        return subscription;
    }

    public IQueryable<ProjectSubscription> GetProjectSubscriptions(Guid id)
    {
        var subscription = _context.ProjectSubscriptions
            .Where(sub => sub.Project.Id == id);

        return subscription;
    }

    public IQueryable<DeveloperSubscription> GetDeveloperSubscriptions(Guid id)
    {
        var subscription = _context.DeveloperSubscriptions
            .Where(sub => sub.Developer.Id == id);

        return subscription;
    }

    public IQueryable<CompanySubscription> GetCompanySubscriptions(Guid id)
    {
        var subscription = _context.CompanySubscriptions
            .Where(sub => sub.Company.Id == id);

        return subscription;
    }

    public async Task<Tariff> GetSubscriptionTariff(int subscriptionId)
    {
        var subscription = await GetSubscription(subscriptionId);
        _context.Entry(subscription).Reference(s => s.Tariff);

        return subscription.Tariff;
    }

    public async Task<Developer> GetSubscriptionSubscriber(int subscriptionId)
    {
        var subscription = await GetSubscription(subscriptionId);
        _context.Entry(subscription).Reference(s => s.Subscriber);

        return subscription.Subscriber;
    }

    public async Task<int> UserCompanySubscriptionLevel(Guid? userDevId, Guid companyId)
    {
        if (!userDevId.HasValue)
            return 0;
        
        var subLevel = 0;

        var sub = await GetCompanySubscriptions(companyId)
            .FirstOrDefaultAsync(sub => sub.Subscriber.Id == userDevId);
        
        if (sub is not null)
            subLevel = sub.Id;

        return subLevel;
    }
    
    public async Task<int> UserDeveloperSubscriptionLevel(Guid? userDevId, Guid developerId)
    {
        if (!userDevId.HasValue)
            return 0;
        
        var subLevel = 0;

        var sub = await GetDeveloperSubscriptions(developerId)
            .FirstOrDefaultAsync(sub => sub.Subscriber.Id == userDevId);
        
        if (sub is not null)
            subLevel = sub.Id;

        return subLevel;
    }
    
    public async Task<int> UserProjectSubscriptionLevel(Guid? userDevId, Guid projectId)
    {
        if (!userDevId.HasValue)
            return 0;
        
        var subLevel = 0;

        var sub = await GetProjectSubscriptions(projectId)
            .FirstOrDefaultAsync(sub => sub.Subscriber.Id == userDevId);
        
        if (sub is not null)
            subLevel = sub.Id;

        return subLevel;
    }

    public bool HasSufficientSubscriptionLevel(Post post, Guid? userDevId, int userSubLevel)
    {
        if (!userDevId.HasValue)
            return false;
        
        return userDevId == post.DeveloperId || userSubLevel >= post.RequiredSubscriptionLevelId;
    }

    public async Task<int> CreateProjectSubscription(DateTime endTime, bool isAutoRenewal, int tariffId, 
        Guid subscriberId, Guid projectId)
    {
        var tariff = await _tariffService.GetTariff(tariffId);
        var subscriber = await _developerService.GetDeveloper(subscriberId);
        var project = await _projectService.GetProject(projectId);
        var subscription = new ProjectSubscription(endTime, isAutoRenewal, tariff, subscriber, project);
        _context.ProjectSubscriptions.Add(subscription);
        await _context.SaveChangesAsync();

        return subscription.Id;
    }

    public async Task<int> CreateDeveloperSubscription(DateTime endTime, bool isAutoRenewal, int tariffId, 
        Guid subscriberId, Guid developerId)
    {
        var tariff = await _tariffService.GetTariff(tariffId);
        var subscriber = await _developerService.GetDeveloper(subscriberId);
        var developer = await _developerService.GetDeveloper(developerId);
        var subscription = new DeveloperSubscription(endTime, isAutoRenewal, tariff, subscriber, developer);
        _context.DeveloperSubscriptions.Add(subscription);
        await _context.SaveChangesAsync();

        return subscription.Id;
    }

    public async Task<int> CreateCompanySubscription(DateTime endTime, bool isAutoRenewal, int tariffId, Guid subscriberId, Guid companyId)
    {
        var tariff = await _tariffService.GetTariff(tariffId);
        var subscriber = await _developerService.GetDeveloper(subscriberId);
        var company = await _companyService.GetCompany(companyId);
        var subscription = new CompanySubscription(endTime, isAutoRenewal, tariff, subscriber, company);
        _context.CompanySubscriptions.Add(subscription);
        await _context.SaveChangesAsync();

        return subscription.Id;
    }
    
    public async Task<int> UserSubscriptionLevel(Guid userId, Guid entityId, EntityType type)
    {
        Subscription sub;
        switch (type)
        {
            case EntityType.Developer:
                sub = await _context.DeveloperSubscriptions
                    .Include(s => s.Tariff)
                    .FirstOrDefaultAsync(s => 
                    s.Subscriber.Id == userId &&
                    s.Developer.Id == entityId);
                break;
            case EntityType.Project:
                sub = await _context.ProjectSubscriptions
                    .Include(s => s.Tariff)
                    .FirstOrDefaultAsync(s => 
                    s.Subscriber.Id == userId &&
                    s.Project.Id == entityId);
                break;
            case EntityType.Company:
                sub = await _context.CompanySubscriptions
                    .Include(s => s.Tariff)
                    .FirstOrDefaultAsync(s => 
                    s.Subscriber.Id == userId &&
                    s.Company.Id == entityId);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        return sub?.Tariff?.SubscriptionLevelId ?? 0;
    }
}
using Data.Core;
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

    public async Task<ProjectSubscription> GetProjectSubscription(int projectSubscriptionId)
    {
        var subscription = await _context.ProjectSubscriptions.FindAsync(projectSubscriptionId);

        return subscription;
    }

    public async Task<DeveloperSubscription> GetDeveloperSubscription(int developerSubscriptionId)
    {
        var subscription = await _context.DeveloperSubscriptions.FindAsync(developerSubscriptionId);

        return subscription;
    }

    public async Task<CompanySubscription> GetCompanySubscription(int companySubscriptionId)
    {
        var subscription = await _context.CompanySubscriptions.FindAsync(companySubscriptionId);

        return subscription;
    }

    public async Task<Tariff> GetSubscriptionTariff(int subscriptionId)
    {
        var subscription = await GetSubscription(subscriptionId);
        _context.Entry(subscription).Reference(s => s.Tariff);

        return subscription.Tariff;
    }

    public async Task<Developer> GetSubscriber(int subscriptionId)
    {
        var subscription = await GetSubscription(subscriptionId);
        _context.Entry(subscription).Reference(s => s.Subscriber);

        return subscription.Subscriber;
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
}
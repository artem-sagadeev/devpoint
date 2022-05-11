using Microsoft.AspNetCore.Mvc;
using Services.Subscriptions.Subscriptions;
using Web.API.Controllers.Developers.DTOs;
using Web.API.Controllers.Subscriptions.DTOs;

namespace Web.API.Controllers.Subscriptions;

[ApiController]
[Route("subscriptions")]
public class SubscriptionController : Controller
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionController(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllSubscriptions()
    {
        var subscriptions = await _subscriptionService.GetAllSubscriptions();
        var result = subscriptions.Select(subscription => new SubscriptionDto(subscription));

        return Ok(result);
    }

    [HttpGet]
    [Route("{subscriptionIds}")]
    public async Task<IActionResult> GetSubscriptions(List<int> subscriptionIds)
    {
        var subscriptions = await _subscriptionService.GetSubscriptions(subscriptionIds);
        var result = subscriptions.Select(subscription => new SubscriptionDto(subscription));

        return Ok(result);
    }

    [HttpGet]
    [Route("{subscriptionId:int}")]
    public async Task<IActionResult> GetSubscription(int subscriptionId)
    {
        var subscription = await _subscriptionService.GetSubscription(subscriptionId);
        var result = new SubscriptionDto(subscription);

        return Ok(result);
    }
    
    [HttpGet]
    [Route("{projectSubscriptionId:int}")]
    public async Task<IActionResult> GetProjectSubscription(int projectSubscriptionId)
    {
        var subscription = await _subscriptionService.GetProjectSubscription(projectSubscriptionId);
        var result = new SubscriptionDto(subscription);

        return Ok(result);
    }
    
    [HttpGet]
    [Route("{developerSubscriptionId:int}")]
    public async Task<IActionResult> GetDeveloperSubscription(int developerSubscriptionId)
    {
        var subscription = await _subscriptionService.GetDeveloperSubscription(developerSubscriptionId);
        var result = new SubscriptionDto(subscription);

        return Ok(result);
    }
    
    [HttpGet]
    [Route("{companySubscriptionId:int}")]
    public async Task<IActionResult> GetCompanySubscription(int companySubscriptionId)
    {
        var subscription = await _subscriptionService.GetCompanySubscription(companySubscriptionId);
        var result = new SubscriptionDto(subscription);

        return Ok(result);
    }

    [HttpGet]
    [Route("{subscriptionId:int}/tariff")]
    public async Task<IActionResult> GetSubscriptionTariff(int subscriptionId)
    {
        var tariff = await _subscriptionService.GetSubscriptionTariff(subscriptionId);
        var result = new TariffDto(tariff);

        return Ok(result);
    }

    [HttpGet]
    [Route("{subscriptionId:int}/subscriber")]
    public async Task<IActionResult> GetSubscriptionSubscriber(int subscriptionId)
    {
        var subscriber = await _subscriptionService.GetSubscriptionSubscriber(subscriptionId);
        var result = new DeveloperDto(subscriber);

        return Ok(result);
    }

    [HttpPost]
    [Route("create/project-subscription")]
    public async Task<IActionResult> CreateProjectSubscription(DateTime endTime, bool isAutoRenewal, int tariffId,
        Guid subscriberId, Guid projectId)
    {
        var subscriptionId = await _subscriptionService
            .CreateProjectSubscription(endTime, isAutoRenewal, tariffId, subscriberId, projectId);

        return Ok(subscriptionId);
    }
    
    [HttpPost]
    [Route("create/developer-subscription")]
    public async Task<IActionResult> CreateDeveloperSubscription(DateTime endTime, bool isAutoRenewal, int tariffId,
        Guid subscriberId, Guid projectId)
    {
        var subscriptionId = await _subscriptionService
            .CreateDeveloperSubscription(endTime, isAutoRenewal, tariffId, subscriberId, projectId);

        return Ok(subscriptionId);
    }
    
    [HttpPost]
    [Route("create/company-subscription")]
    public async Task<IActionResult> CreateCompanySubscription(DateTime endTime, bool isAutoRenewal, int tariffId,
        Guid subscriberId, Guid projectId)
    {
        var subscriptionId = await _subscriptionService
            .CreateCompanySubscription(endTime, isAutoRenewal, tariffId, subscriberId, projectId);

        return Ok(subscriptionId);
    }
}
using Microsoft.AspNetCore.Mvc;
using Services.Developers.Developers;

namespace Web.API.Controllers;

[ApiController]
[Route("developers")]
public class DeveloperController : Controller
{
    private readonly IDeveloperService _developerService;

    public DeveloperController(IDeveloperService developerService)
    {
        _developerService = developerService;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllDevelopers()
    {
        var developers = await _developerService.GetAllDevelopers();
        
        return Ok(developers);
    }

    [HttpGet]
    [Route("{developerIds}")]
    public async Task<IActionResult> GetDevelopers(List<Guid> developerIds)
    {
        var developers = await _developerService.GetDevelopers(developerIds);

        return Ok(developers);
    }

    [HttpGet]
    [Route("{developerId:guid}")]
    public async Task<IActionResult> GetDeveloper(Guid developerId)
    {
        var developer = await _developerService.GetDeveloper(developerId);

        return Ok(developer);
    }

    [HttpGet]
    [Route("{developerId:guid}/owned-projects")]
    public async Task<IActionResult> GetOwnedProjects(Guid developerId)
    {
        var projects = await _developerService.GetOwnedProjects(developerId);

        return Ok(projects);
    }
    
    [HttpGet]
    [Route("{developerId:guid}/projects")]
    public async Task<IActionResult> GetDeveloperProjects(Guid developerId)
    {
        var projects = await _developerService.GetDeveloperProjects(developerId);

        return Ok(projects);
    }
    
    [HttpGet]
    [Route("{developerId:guid}/owned-companies")]
    public async Task<IActionResult> GetOwnedCompanies(Guid developerId)
    {
        var companies = await _developerService.GetOwnedCompanies(developerId);

        return Ok(companies);
    }
    
    [HttpGet]
    [Route("{developerId:guid}/companies")]
    public async Task<IActionResult> GetDeveloperCompanies(Guid developerId)
    {
        var companies = await _developerService.GetDeveloperCompanies(developerId);

        return Ok(companies);
    }
    
    [HttpGet]
    [Route("{developerId:guid}/tags")]
    public async Task<IActionResult> GetDeveloperTags(Guid developerId)
    {
        var tags = await _developerService.GetDeveloperTags(developerId);

        return Ok(tags);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateDeveloper(string name)
    {
        var developerId = await _developerService.CreateDeveloper(name);

        return Ok(developerId);
    }
    
    [HttpPut]
    [Route("{developerId:guid}/update/name")]
    public async Task<IActionResult> UpdateDeveloper(Guid developerId, string name)
    {
        await _developerService.UpdateName(developerId, name);

        return Ok();
    }
    
    [HttpPut]
    [Route("{developerId:guid}/update/projects")]
    public async Task<IActionResult> UpdateProjects(Guid developerId, List<Guid> projectIds)
    {
        await _developerService.UpdateProjects(developerId, projectIds);

        return Ok();
    }
    
    [HttpPut]
    [Route("{developerId:guid}/update/companies")]
    public async Task<IActionResult> UpdateCompanies(Guid developerId, List<Guid> companyIds)
    {
        await _developerService.UpdateCompanies(developerId, companyIds);

        return Ok();
    }
    
    [HttpPut]
    [Route("{developerId:guid}/update/tags")]
    public async Task<IActionResult> UpdateTags(Guid developerId, List<int> tagIds)
    {
        await _developerService.UpdateTags(developerId, tagIds);

        return Ok();
    }
}
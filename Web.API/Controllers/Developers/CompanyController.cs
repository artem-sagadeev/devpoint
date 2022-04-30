using Microsoft.AspNetCore.Mvc;
using Services.Developers.Companies;
using Web.API.Controllers.Developers.DTOs;

namespace Web.API.Controllers.Developers;

[ApiController]
[Route("companies")]
public class CompanyController : Controller
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllCompanies()
    {
        var companies = await _companyService.GetAllCompanies();
        var result = companies.Select(c => new CompanyDto(c));
        
        return Ok(result);
    }

    [HttpGet]
    [Route("{companyIds}")]
    public async Task<IActionResult> GetCompanies(List<Guid> companyIds)
    {
        var companies = await _companyService.GetCompanies(companyIds);
        var result = companies.Select(c => new CompanyDto(c));
        
        return Ok(result);
    }

    [HttpGet]
    [Route("{companyId:guid}")]
    public async Task<IActionResult> GetCompany(Guid companyId)
    {
        var company = await _companyService.GetCompany(companyId);
        var result = new CompanyDto(company);
        
        return Ok(result);
    }

    [HttpGet]
    [Route("{companyId:guid}/owner")]
    public async Task<IActionResult> GetOwner(Guid companyId)
    {
        var owner = await _companyService.GetOwner(companyId);
        var result = new DeveloperDto(owner);
        
        return Ok(result);
    }
    
    [HttpGet]
    [Route("{companyId:guid}/developers")]
    public async Task<IActionResult> GetCompanyDevelopers(Guid companyId)
    {
        var developers = await _companyService.GetCompanyDevelopers(companyId);
        var result = developers.Select(d => new DeveloperDto(d));

        return Ok(result);
    }
    
    [HttpGet]
    [Route("{companyId:guid}/projects")]
    public async Task<IActionResult> GetCompanyProjects(Guid companyId)
    {
        var projects = await _companyService.GetCompanyProjects(companyId);
        var result = projects.Select(p => new ProjectDto(p));
        
        return Ok(result);
    }
    
    [HttpGet]
    [Route("{companyId:guid}/tags")]
    public async Task<IActionResult> GetCompanyTags(Guid companyId)
    {
        var tags = await _companyService.GetCompanyTags(companyId);
        var result = tags.Select(t => new TagDto(t));
        
        return Ok(result);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateCompany(string name, Guid ownerId)
    {
        var companyId = await _companyService.CreateCompany(name, ownerId);

        return Ok(companyId);
    }

    [HttpPut]
    [Route("{companyId:guid}/update/name")]
    public async Task<IActionResult> UpdateName(Guid companyId, string name)
    {
        await _companyService.UpdateName(companyId, name);

        return Ok();
    }
    
    [HttpPut]
    [Route("{companyId:guid}/update/coordinates")]
    public async Task<IActionResult> UpdateCoordinates(Guid companyId, decimal latitude, decimal longitude)
    {
        await _companyService.UpdateCoordinates(companyId, latitude, longitude);

        return Ok();
    }
    
    [HttpPut]
    [Route("{companyId:guid}/update/developers")]
    public async Task<IActionResult> UpdateDevelopers(Guid companyId, List<Guid> developerIds)
    {
        await _companyService.UpdateDevelopers(companyId, developerIds);

        return Ok();
    }
    
    [HttpPut]
    [Route("{companyId:guid}/update/projects")]
    public async Task<IActionResult> UpdateProjects(Guid companyId, List<Guid> projectIds)
    {
        await _companyService.UpdateProjects(companyId, projectIds);

        return Ok();
    }
    
    [HttpPut]
    [Route("{companyId:guid}/update/tags")]
    public async Task<IActionResult> UpdateTags(Guid companyId, List<int> tagIds)
    {
        await _companyService.UpdateTags(companyId, tagIds);

        return Ok();
    }
}
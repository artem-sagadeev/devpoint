using Microsoft.AspNetCore.Mvc;
using Services.Developers.Projects;
using Web.API.Controllers.Content.DTOs;
using Web.API.Controllers.Developers.DTOs;

namespace Web.API.Controllers.Developers;

[ApiController]
[Route("projects")]
public class ProjectController : Controller
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }
    
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllProjects()
    {
        var projects = await _projectService.GetAllProjects();
        var result = projects.Select(p => new ProjectDto(p));
        
        return Ok(result);
    }

    [HttpGet]
    [Route("{projectIds}")]
    public async Task<IActionResult> GetProjects(List<Guid> projectIds)
    {
        var projects = await _projectService.GetProjects(projectIds);
        var result = projects.Select(p => new ProjectDto(p));
        
        return Ok(result);
    }

    [HttpGet]
    [Route("{projectId:guid}")]
    public async Task<IActionResult> GetProject(Guid projectId)
    {
        var project = await _projectService.GetProject(projectId);
        var result = new ProjectDto(project);
        
        return Ok(result);
    }

    [HttpGet]
    [Route("{projectId:guid}/owner")]
    public async Task<IActionResult> GetOwner(Guid projectId)
    {
        var owner = await _projectService.GetOwner(projectId);
        var result = new DeveloperDto(owner);

        return Ok(result);
    }

    [HttpGet]
    [Route("{projectId:guid}/company")]
    public async Task<IActionResult> GetProjectCompany(Guid projectId)
    {
        var company = await _projectService.GetProjectCompany(projectId);
        var result = new CompanyDto(company);
        
        return Ok(result);
    }

    [HttpGet]
    [Route("{projectId:guid}/developers")]
    public async Task<IActionResult> GetProjectDevelopers(Guid projectId)
    {
        var developers = await _projectService.GetProjectDevelopers(projectId);
        var result = developers.Select(d => new DeveloperDto(d));
        
        return Ok(result);
    }

    [HttpGet]
    [Route("{projectId:guid}/tags")]
    public async Task<IActionResult> GetProjectTags(Guid projectId)
    {
        var tags = await _projectService.GetProjectTags(projectId);
        var result = tags.Select(t => new TagDto(t));

        return Ok(result);
    }
    
    [HttpGet]
    [Route("{projectId:guid}/posts")]
    public async Task<IActionResult> GetProjectPosts(Guid projectId)
    {
        var posts = await _projectService.GetProjectPosts(projectId);
        var result = posts.Select(p => new PostDto(p));
        
        return Ok(result);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateProject(string name, Guid ownerId, Guid? companyId)
    {
        var projectId = await _projectService.CreateProject(name, ownerId, companyId);

        return Ok(projectId);
    }
    
    [HttpPut]
    [Route("{projectId:guid}/update/name")]
    public async Task<IActionResult> UpdateName(Guid projectId, string name)
    {
        await _projectService.UpdateName(projectId, name);

        return Ok();
    }

    [HttpPut]
    [Route("{projectId:guid}/update/developers")]
    public async Task<IActionResult> UpdateDevelopers(Guid projectId, List<Guid> developerIds)
    {
        await _projectService.UpdateDevelopers(projectId, developerIds);

        return Ok();
    }

    [HttpPut]
    [Route("{projectId:guid}/update/tags")]
    public async Task<IActionResult> UpdateTags(Guid projectId, List<int> tagIds)
    {
        await _projectService.UpdateTags(projectId, tagIds);

        return Ok();
    }
}
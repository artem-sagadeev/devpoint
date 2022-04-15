using Microsoft.AspNetCore.Mvc;
using Services.Developers.DTOs;
using Services.Developers.Interfaces;

namespace Web.API.Controllers;

[ApiController]
[Route("projects")]
public class ProjectsController : Controller
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetProject(Guid id)
    {
        var result = await _projectService.GetProject(id);

        return Ok(result);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateProject(ProjectDto dto)
    {
        var result = await _projectService.CreateProject(dto);

        return Ok(result);
    }
    
    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateProject(ProjectDto dto)
    {
        var result = await _projectService.UpdateProject(dto);

        return Ok(result);
    }
}